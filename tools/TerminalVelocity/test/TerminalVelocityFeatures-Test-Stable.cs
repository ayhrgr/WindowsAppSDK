﻿// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

// THIS FILE IS AUTOMATICALLY GENERATED; DO NOT EDIT IT

// INPUT FILE: TerminalVelocityFeatures-Test.xml

// Feature constants
//DISABLED: WINDOWSAPPRUNTIME_FEATURE_ALWAYSDISABLED_ENABLED
//DISABLED: WINDOWSAPPRUNTIME_FEATURE_ALWAYSDISABLED_ALWAYSENABLEDCHANNELS_EXPERIMENTAL_ENABLED
//DISABLED: WINDOWSAPPRUNTIME_FEATURE_ALWAYSDISABLED_ALWAYSENABLEDCHANNELS_EXPERIMENTALPREVIEW_ENABLED
//DISABLED: WINDOWSAPPRUNTIME_FEATURE_ALWAYSDISABLED_ALWAYSENABLEDCHANNELS_EXPERIMENTALPREVIEWSTABLE_ENABLED
//DISABLED: WINDOWSAPPRUNTIME_FEATURE_ALWAYSDISABLED_ALWAYSENABLEDCHANNELS_EXPERIMENTALPREVIEWWINDOWSINBOX_ENABLED
//DISABLED: WINDOWSAPPRUNTIME_FEATURE_ALWAYSDISABLED_ALWAYSENABLEDCHANNELS_EXPERIMENTALSTABLE_ENABLED
//DISABLED: WINDOWSAPPRUNTIME_FEATURE_ALWAYSDISABLED_ALWAYSENABLEDCHANNELS_EXPERIMENTALSTABLEWINDOWSINBOX_ENABLED
//DISABLED: WINDOWSAPPRUNTIME_FEATURE_ALWAYSDISABLED_ALWAYSENABLEDCHANNELS_EXPERIMENTALWINDOWSINBOX_ENABLED
//DISABLED: WINDOWSAPPRUNTIME_FEATURE_ALWAYSDISABLED_ALWAYSENABLEDCHANNELS_PREVIEW_ENABLED
//DISABLED: WINDOWSAPPRUNTIME_FEATURE_ALWAYSDISABLED_ALWAYSENABLEDCHANNELS_PREVIEWSTABLEWINDOWSINBOX_ENABLED
//DISABLED: WINDOWSAPPRUNTIME_FEATURE_ALWAYSDISABLED_ALWAYSENABLEDCHANNELS_STABLE_ENABLED
//DISABLED: WINDOWSAPPRUNTIME_FEATURE_ALWAYSDISABLED_ALWAYSENABLEDCHANNELS_WINDOWSINBOX_ENABLED
//DISABLED: WINDOWSAPPRUNTIME_FEATURE_ALWAYSDISABLED_ID_ENABLED
#Define WINDOWSAPPRUNTIME_FEATURE_ALWAYSENABLED_ENABLED
#Define WINDOWSAPPRUNTIME_FEATURE_ALWAYSENABLED_ALWAYSDISABLEDCHANNELS_EXPERIMENTAL_ENABLED
#Define WINDOWSAPPRUNTIME_FEATURE_ALWAYSENABLED_ALWAYSDISABLEDCHANNELS_EXPERIMENTALPREVIEW_ENABLED
//DISABLED: WINDOWSAPPRUNTIME_FEATURE_ALWAYSENABLED_ALWAYSDISABLEDCHANNELS_EXPERIMENTALPREVIEWSTABLE_ENABLED
#Define WINDOWSAPPRUNTIME_FEATURE_ALWAYSENABLED_ALWAYSDISABLEDCHANNELS_EXPERIMENTALPREVIEWWINDOWSINBOX_ENABLED
//DISABLED: WINDOWSAPPRUNTIME_FEATURE_ALWAYSENABLED_ALWAYSDISABLEDCHANNELS_EXPERIMENTALSTABLE_ENABLED
//DISABLED: WINDOWSAPPRUNTIME_FEATURE_ALWAYSENABLED_ALWAYSDISABLEDCHANNELS_EXPERIMENTALSTABLEWINDOWSINBOX_ENABLED
#Define WINDOWSAPPRUNTIME_FEATURE_ALWAYSENABLED_ALWAYSDISABLEDCHANNELS_EXPERIMENTALWINDOWSINBOX_ENABLED
#Define WINDOWSAPPRUNTIME_FEATURE_ALWAYSENABLED_ALWAYSDISABLEDCHANNELS_PREVIEW_ENABLED
//DISABLED: WINDOWSAPPRUNTIME_FEATURE_ALWAYSENABLED_ALWAYSDISABLEDCHANNELS_PREVIEWSTABLEWINDOWSINBOX_ENABLED
//DISABLED: WINDOWSAPPRUNTIME_FEATURE_ALWAYSENABLED_ALWAYSDISABLEDCHANNELS_STABLE_ENABLED
#Define WINDOWSAPPRUNTIME_FEATURE_ALWAYSENABLED_ALWAYSDISABLEDCHANNELS_WINDOWSINBOX_ENABLED
#Define WINDOWSAPPRUNTIME_FEATURE_ALWAYSENABLED_ID_ENABLED

namespace Test.TerminalVelocity.Features
{

public static class Feature_AlwaysDisabled
{
#if WINDOWSAPPRUNTIME_FEATURE_ALWAYSDISABLED_ENABLED
    public const bool IsEnabled = true;
#else
    public const bool IsEnabled = false;
#endif
};

public static class Feature_AlwaysDisabled_AlwaysEnabledChannels_Experimental
{
#if WINDOWSAPPRUNTIME_FEATURE_ALWAYSDISABLED_ALWAYSENABLEDCHANNELS_EXPERIMENTAL_ENABLED
    public const bool IsEnabled = true;
#else
    public const bool IsEnabled = false;
#endif
};

public static class Feature_AlwaysDisabled_AlwaysEnabledChannels_ExperimentalPreview
{
#if WINDOWSAPPRUNTIME_FEATURE_ALWAYSDISABLED_ALWAYSENABLEDCHANNELS_EXPERIMENTALPREVIEW_ENABLED
    public const bool IsEnabled = true;
#else
    public const bool IsEnabled = false;
#endif
};

public static class Feature_AlwaysDisabled_AlwaysEnabledChannels_ExperimentalPreviewStable
{
#if WINDOWSAPPRUNTIME_FEATURE_ALWAYSDISABLED_ALWAYSENABLEDCHANNELS_EXPERIMENTALPREVIEWSTABLE_ENABLED
    public const bool IsEnabled = true;
#else
    public const bool IsEnabled = false;
#endif
};

public static class Feature_AlwaysDisabled_AlwaysEnabledChannels_ExperimentalPreviewWindowsInbox
{
#if WINDOWSAPPRUNTIME_FEATURE_ALWAYSDISABLED_ALWAYSENABLEDCHANNELS_EXPERIMENTALPREVIEWWINDOWSINBOX_ENABLED
    public const bool IsEnabled = true;
#else
    public const bool IsEnabled = false;
#endif
};

public static class Feature_AlwaysDisabled_AlwaysEnabledChannels_ExperimentalStable
{
#if WINDOWSAPPRUNTIME_FEATURE_ALWAYSDISABLED_ALWAYSENABLEDCHANNELS_EXPERIMENTALSTABLE_ENABLED
    public const bool IsEnabled = true;
#else
    public const bool IsEnabled = false;
#endif
};

public static class Feature_AlwaysDisabled_AlwaysEnabledChannels_ExperimentalStableWindowsInbox
{
#if WINDOWSAPPRUNTIME_FEATURE_ALWAYSDISABLED_ALWAYSENABLEDCHANNELS_EXPERIMENTALSTABLEWINDOWSINBOX_ENABLED
    public const bool IsEnabled = true;
#else
    public const bool IsEnabled = false;
#endif
};

public static class Feature_AlwaysDisabled_AlwaysEnabledChannels_ExperimentalWindowsInbox
{
#if WINDOWSAPPRUNTIME_FEATURE_ALWAYSDISABLED_ALWAYSENABLEDCHANNELS_EXPERIMENTALWINDOWSINBOX_ENABLED
    public const bool IsEnabled = true;
#else
    public const bool IsEnabled = false;
#endif
};

public static class Feature_AlwaysDisabled_AlwaysEnabledChannels_Preview
{
#if WINDOWSAPPRUNTIME_FEATURE_ALWAYSDISABLED_ALWAYSENABLEDCHANNELS_PREVIEW_ENABLED
    public const bool IsEnabled = true;
#else
    public const bool IsEnabled = false;
#endif
};

public static class Feature_AlwaysDisabled_AlwaysEnabledChannels_PreviewStableWindowsInbox
{
#if WINDOWSAPPRUNTIME_FEATURE_ALWAYSDISABLED_ALWAYSENABLEDCHANNELS_PREVIEWSTABLEWINDOWSINBOX_ENABLED
    public const bool IsEnabled = true;
#else
    public const bool IsEnabled = false;
#endif
};

public static class Feature_AlwaysDisabled_AlwaysEnabledChannels_Stable
{
#if WINDOWSAPPRUNTIME_FEATURE_ALWAYSDISABLED_ALWAYSENABLEDCHANNELS_STABLE_ENABLED
    public const bool IsEnabled = true;
#else
    public const bool IsEnabled = false;
#endif
};

public static class Feature_AlwaysDisabled_AlwaysEnabledChannels_WindowsInbox
{
#if WINDOWSAPPRUNTIME_FEATURE_ALWAYSDISABLED_ALWAYSENABLEDCHANNELS_WINDOWSINBOX_ENABLED
    public const bool IsEnabled = true;
#else
    public const bool IsEnabled = false;
#endif
};

public static class Feature_AlwaysDisabled_Id
{
#if WINDOWSAPPRUNTIME_FEATURE_ALWAYSDISABLED_ID_ENABLED
    public const bool IsEnabled = true;
#else
    public const bool IsEnabled = false;
#endif
};

public static class Feature_AlwaysEnabled
{
#if WINDOWSAPPRUNTIME_FEATURE_ALWAYSENABLED_ENABLED
    public const bool IsEnabled = true;
#else
    public const bool IsEnabled = false;
#endif
};

public static class Feature_AlwaysEnabled_AlwaysDisabledChannels_Experimental
{
#if WINDOWSAPPRUNTIME_FEATURE_ALWAYSENABLED_ALWAYSDISABLEDCHANNELS_EXPERIMENTAL_ENABLED
    public const bool IsEnabled = true;
#else
    public const bool IsEnabled = false;
#endif
};

public static class Feature_AlwaysEnabled_AlwaysDisabledChannels_ExperimentalPreview
{
#if WINDOWSAPPRUNTIME_FEATURE_ALWAYSENABLED_ALWAYSDISABLEDCHANNELS_EXPERIMENTALPREVIEW_ENABLED
    public const bool IsEnabled = true;
#else
    public const bool IsEnabled = false;
#endif
};

public static class Feature_AlwaysEnabled_AlwaysDisabledChannels_ExperimentalPreviewStable
{
#if WINDOWSAPPRUNTIME_FEATURE_ALWAYSENABLED_ALWAYSDISABLEDCHANNELS_EXPERIMENTALPREVIEWSTABLE_ENABLED
    public const bool IsEnabled = true;
#else
    public const bool IsEnabled = false;
#endif
};

public static class Feature_AlwaysEnabled_AlwaysDisabledChannels_ExperimentalPreviewWindowsInbox
{
#if WINDOWSAPPRUNTIME_FEATURE_ALWAYSENABLED_ALWAYSDISABLEDCHANNELS_EXPERIMENTALPREVIEWWINDOWSINBOX_ENABLED
    public const bool IsEnabled = true;
#else
    public const bool IsEnabled = false;
#endif
};

public static class Feature_AlwaysEnabled_AlwaysDisabledChannels_ExperimentalStable
{
#if WINDOWSAPPRUNTIME_FEATURE_ALWAYSENABLED_ALWAYSDISABLEDCHANNELS_EXPERIMENTALSTABLE_ENABLED
    public const bool IsEnabled = true;
#else
    public const bool IsEnabled = false;
#endif
};

public static class Feature_AlwaysEnabled_AlwaysDisabledChannels_ExperimentalStableWindowsInbox
{
#if WINDOWSAPPRUNTIME_FEATURE_ALWAYSENABLED_ALWAYSDISABLEDCHANNELS_EXPERIMENTALSTABLEWINDOWSINBOX_ENABLED
    public const bool IsEnabled = true;
#else
    public const bool IsEnabled = false;
#endif
};

public static class Feature_AlwaysEnabled_AlwaysDisabledChannels_ExperimentalWindowsInbox
{
#if WINDOWSAPPRUNTIME_FEATURE_ALWAYSENABLED_ALWAYSDISABLEDCHANNELS_EXPERIMENTALWINDOWSINBOX_ENABLED
    public const bool IsEnabled = true;
#else
    public const bool IsEnabled = false;
#endif
};

public static class Feature_AlwaysEnabled_AlwaysDisabledChannels_Preview
{
#if WINDOWSAPPRUNTIME_FEATURE_ALWAYSENABLED_ALWAYSDISABLEDCHANNELS_PREVIEW_ENABLED
    public const bool IsEnabled = true;
#else
    public const bool IsEnabled = false;
#endif
};

public static class Feature_AlwaysEnabled_AlwaysDisabledChannels_PreviewStableWindowsInbox
{
#if WINDOWSAPPRUNTIME_FEATURE_ALWAYSENABLED_ALWAYSDISABLEDCHANNELS_PREVIEWSTABLEWINDOWSINBOX_ENABLED
    public const bool IsEnabled = true;
#else
    public const bool IsEnabled = false;
#endif
};

public static class Feature_AlwaysEnabled_AlwaysDisabledChannels_Stable
{
#if WINDOWSAPPRUNTIME_FEATURE_ALWAYSENABLED_ALWAYSDISABLEDCHANNELS_STABLE_ENABLED
    public const bool IsEnabled = true;
#else
    public const bool IsEnabled = false;
#endif
};

public static class Feature_AlwaysEnabled_AlwaysDisabledChannels_WindowsInbox
{
#if WINDOWSAPPRUNTIME_FEATURE_ALWAYSENABLED_ALWAYSDISABLEDCHANNELS_WINDOWSINBOX_ENABLED
    public const bool IsEnabled = true;
#else
    public const bool IsEnabled = false;
#endif
};

public static class Feature_AlwaysEnabled_Id
{
#if WINDOWSAPPRUNTIME_FEATURE_ALWAYSENABLED_ID_ENABLED
    public const bool IsEnabled = true;
#else
    public const bool IsEnabled = false;
#endif
};

} // namespace Test.TerminalVelocity.Features
