﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#pragma once
#include "pch.h"
#include <winrt/Windows.ApplicationModel.Core.h>
#include "PushNotificationUtility.h"
#include <algorithm>

inline const winrt::hstring ACTIVATED_EVENT_ARGS_KEY = L"GlobalActivatedEventArgs";
inline const winrt::hstring LRP_ACTIVATED_EVENT_ARGS_KEY = L"LRPActivatedEventArgs";

namespace PushNotificationHelpers
{
    using namespace winrt::Microsoft::Windows::PushNotifications::Helpers;
}

MIDL_INTERFACE("19858C8F-4597-401D-A9A8-CB1457198C95") INotificationDeserializer : IInspectable
{
    virtual winrt::Windows::Foundation::IInspectable Deserialize() = 0;
};

struct ChannelDetails
{
    winrt::hstring channelUri;
    winrt::hstring channelId;
    winrt::hstring appId;
    winrt::Windows::Foundation::DateTime channelExpiryTime;
};

inline std::wstring GetCurrentProcessPath()
{
    std::wstring processPath{};
    THROW_IF_FAILED(wil::GetModuleFileNameExW(GetCurrentProcess(), nullptr, processPath));
    std::transform(processPath.begin(), processPath.end(), processPath.begin(), ::towlower);
    return processPath;
};
