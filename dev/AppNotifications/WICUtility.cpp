
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#include "pch.h"
#include <cwctype>
#include <winrt/Windows.Foundation.h>
#include <winrt/base.h>
#include <externs.h>

#include <wil/resource.h>
#include <wil/win32_helpers.h>
#include <propkey.h> // PKEY properties
#include <propsys.h> // IPropertyStore
#include <ShObjIdl_core.h>
#include <wincodec.h>
#include <Ocidl.h>
#include <wrl\module.h>
#include <windows.h>


using namespace Microsoft::WRL;

typedef enum
{
    BMPV_1,
    BMPV_5,
} BITMAP_VERSION;


HRESULT ConvertWICBitmapPixelFormat(_In_ IWICImagingFactory* pWICImagingFactory, _In_ IWICBitmapSource* pWICBitmapSource, _In_ WICPixelFormatGUID guidPixelFormatSource, _In_ WICBitmapDitherType bitmapDitherType, _COM_Outptr_ IWICBitmapSource** ppWICBitmapSource)
{
    *ppWICBitmapSource = nullptr;

    winrt::com_ptr<IWICFormatConverter> spWICFormatConverter;

    THROW_IF_FAILED(pWICImagingFactory->CreateFormatConverter(spWICFormatConverter.put()));

    THROW_IF_FAILED(spWICFormatConverter->Initialize(pWICBitmapSource, guidPixelFormatSource, bitmapDitherType, nullptr, 0.f, WICBitmapPaletteTypeCustom));

    // Store the converted bitmap as ppToRenderBitmapSource
    THROW_IF_FAILED(spWICFormatConverter->QueryInterface(IID_PPV_ARGS(ppWICBitmapSource)));

    return S_OK;
}

HRESULT AddFrameToWICBitmap(_In_ IWICImagingFactory* pWICImagingFactory, _In_ IWICBitmapEncoder* pWICBitmapEncoder, _In_ IWICBitmapSource* pWICBitmapSource, _In_ BITMAP_VERSION bmpv)
{
    ComPtr<IWICBitmapFrameEncode> spWICFrameEncoder;
    ComPtr<IPropertyBag2> spWICEncoderOptions;

    THROW_IF_FAILED(pWICBitmapEncoder->CreateNewFrame(&spWICFrameEncoder, &spWICEncoderOptions));

    GUID containerGuid;
    THROW_IF_FAILED(pWICBitmapEncoder->GetContainerFormat(&containerGuid));

    if ((containerGuid == GUID_ContainerFormatBmp) && (bmpv == BMPV_5))
    {
        // Write the encoder option to the property bag instance.
        VARIANT varValue = {};
        PROPBAG2 v5HeaderOption = {};

        // Options to enable the v5 header support for 32bppBGRA.
        varValue.vt = VT_BOOL;
        varValue.boolVal = VARIANT_TRUE;
        std::wstring str = L"EnableV5Header32bppBGRA";

        v5HeaderOption.pstrName = (LPOLESTR)str.c_str();

        THROW_IF_FAILED(spWICEncoderOptions->Write(1, &v5HeaderOption, &varValue));
    }

    THROW_IF_FAILED(spWICFrameEncoder->Initialize(spWICEncoderOptions.Get()));

    // Get/set the size of the image
    UINT uWidth, uHeight;
    THROW_IF_FAILED(pWICBitmapSource->GetSize(&uWidth, &uHeight));

    THROW_IF_FAILED(spWICFrameEncoder->SetSize(uWidth, uHeight));

    ComPtr<IWICBitmapSource> spBitmapSourceConverted;
    THROW_IF_FAILED(ConvertWICBitmapPixelFormat(pWICImagingFactory, pWICBitmapSource, GUID_WICPixelFormat32bppBGRA, WICBitmapDitherTypeNone, &spBitmapSourceConverted));

    WICRect rect = { 0, 0, static_cast<INT>(uWidth), static_cast<INT>(uHeight) };

    // Write the image data and commit
    THROW_IF_FAILED(spWICFrameEncoder->WriteSource(spBitmapSourceConverted.Get(), &rect));

    THROW_IF_FAILED(spWICFrameEncoder->Commit());

    return S_OK;
}


HRESULT GetStreamOfWICBitmapSourceWorker(_In_opt_ IWICImagingFactory* pWICImagingFactory, _In_ IWICBitmapSource* pWICBitmapSource, _In_ REFGUID guidContainerFormat, _In_ BITMAP_VERSION bmpv, _COM_Outptr_ IStream** ppStreamOut)
{
    *ppStreamOut = nullptr;

    HRESULT hr = S_OK;

    if (SUCCEEDED(hr))
    {
        ComPtr<IStream> spImageStream;
        hr = CreateStreamOnHGlobal(nullptr, true, &spImageStream);
        if (SUCCEEDED(hr))
        {
            // Create encoder and initialize it
            ComPtr<IWICBitmapEncoder> spWICEncoder;
            hr = pWICImagingFactory->CreateEncoder(guidContainerFormat, nullptr, &spWICEncoder);
            if (SUCCEEDED(hr))
            {
                hr = spWICEncoder->Initialize(spImageStream.Get(), WICBitmapEncoderCacheOption::WICBitmapEncoderNoCache);
                if (SUCCEEDED(hr))
                {
                    // Add a single frame to the encoder with the Bitmap
                    hr = AddFrameToWICBitmap(pWICImagingFactory, spWICEncoder.Get(), pWICBitmapSource, bmpv);
                    if (SUCCEEDED(hr))
                    {
                        hr = spWICEncoder->Commit();
                        if (SUCCEEDED(hr))
                        {
                            // Seek the stream to the beginning and transfer
                            static const LARGE_INTEGER lnBeginning = {};
                            hr = spImageStream->Seek(lnBeginning, STREAM_SEEK_SET, nullptr);
                            if (SUCCEEDED(hr))
                            {
                                hr = spImageStream.CopyTo(ppStreamOut);
                            }
                        }
                    }
                }
            }
        }
    }
    return hr;
}

HRESULT GetStreamOfWICBitmapSource(_In_opt_ IWICImagingFactory* pWICImagingFactory, _In_ IWICBitmapSource* pWICBitmapSource, _In_ REFGUID guidContainerFormat, _COM_Outptr_ IStream** ppStreamOut)
{
    return GetStreamOfWICBitmapSourceWorker(pWICImagingFactory, pWICBitmapSource, guidContainerFormat, BMPV_1, ppStreamOut);
}

inline HRESULT SaveImageWithWIC(_In_opt_ IWICImagingFactory* pWICImagingFactory, _In_ IWICBitmapSource* pWICBitmapSource, _In_ REFGUID guidContainerFormat, _In_opt_ PCWSTR pszImagePath, _In_opt_ IStream* pStream)
{
    HRESULT hr = ((nullptr != pszImagePath) || (nullptr != pStream)) ? S_OK : E_INVALIDARG;

    if (SUCCEEDED(hr))
    {
        Microsoft::WRL::ComPtr<IStream> spImageStream;
        hr = GetStreamOfWICBitmapSource(pWICImagingFactory, pWICBitmapSource, guidContainerFormat, &spImageStream);
        if (SUCCEEDED(hr))
        {
            Microsoft::WRL::ComPtr<IStream> spStream = pStream;
            if (spStream == nullptr)
            {
                hr = SHCreateStreamOnFileEx(pszImagePath, STGM_CREATE | STGM_READWRITE, FILE_ATTRIBUTE_NORMAL, TRUE, nullptr, &spStream);
            }
            if (SUCCEEDED(hr))
            {
                // Seek the stream to the beginning and transfer
                static LARGE_INTEGER const lnBeginning = { 0 };
                hr = spImageStream->Seek(lnBeginning, STREAM_SEEK_SET, nullptr);
                if (SUCCEEDED(hr))
                {
                    static ULARGE_INTEGER lnbuffer = { INT_MAX };
                    hr = spImageStream->CopyTo(spStream.Get(), lnbuffer, nullptr, nullptr);
                    if (SUCCEEDED(hr) && (nullptr == pStream)) // Don't commit streams that are provided to the function
                    {
                        hr = spStream->Commit(STGC_DEFAULT);
                    }
                }
            }
        }
    }
    return hr;
}


HRESULT WriteHIconToPngFile(_In_ HICON hIcon, _In_ PCWSTR pszFileName)
{
    winrt::com_ptr<IWICImagingFactory> spWICImagingFactory;

    THROW_IF_FAILED(CoCreateInstance(CLSID_WICImagingFactory, nullptr, CLSCTX_INPROC_SERVER, IID_PPV_ARGS(&spWICImagingFactory)));

    ComPtr<IWICBitmapSource> spWICBitmapSource;
    ComPtr<IWICBitmap> spWICBitmap;

    THROW_IF_FAILED(spWICImagingFactory->CreateBitmapFromHICON(hIcon, &spWICBitmap));

    THROW_IF_FAILED(spWICBitmap.CopyTo(IID_PPV_ARGS(&spWICBitmapSource)));

    UINT width;
    UINT height;
    THROW_IF_FAILED(spWICBitmapSource->GetSize(&width, &height));

    // Create stream to save the HICON to.
    ComPtr<IStream> spStream;
    THROW_IF_FAILED(CreateStreamOnHGlobal(nullptr, TRUE, &spStream));

    THROW_IF_FAILED(SaveImageWithWIC(spWICImagingFactory.get(), spWICBitmap.Get(), GUID_ContainerFormatPng, nullptr, spStream.Get()));

    // Write out the stream to a file.
    ComPtr<IStream> spStreamOut;
    THROW_IF_FAILED(SHCreateStreamOnFileEx(pszFileName, STGM_CREATE | STGM_WRITE | STGM_SHARE_DENY_WRITE, FILE_ATTRIBUTE_NORMAL, TRUE, nullptr, &spStreamOut));

    STATSTG statstg;
    THROW_IF_FAILED(spStream->Stat(&statstg, STATFLAG_NONAME));

    THROW_IF_FAILED(IStream_Reset(spStream.Get()));

    THROW_IF_FAILED(spStreamOut->SetSize(statstg.cbSize));

    THROW_IF_FAILED(spStream->CopyTo(spStreamOut.Get(), statstg.cbSize, nullptr, nullptr));

    THROW_IF_FAILED(spStreamOut->Commit(STGC_DANGEROUSLYCOMMITMERELYTODISKCACHE));

    return S_OK;
}
