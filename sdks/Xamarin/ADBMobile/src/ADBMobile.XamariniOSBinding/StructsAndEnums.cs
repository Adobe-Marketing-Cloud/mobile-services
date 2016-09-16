using System;
using ObjCRuntime;

namespace Com.Adobe.Mobile
{
    [Native]
    public enum ADBMobilePrivacyStatus : ulong
    {
        OptIn = 1,
        OptOut = 2,
        Unknown = 3
    }

    [Native]
    public enum ADBMobileVisitorAuthenticationState : ulong
    {
        Unknown = 0,
        Authenticated = 1,
        LoggedOut = 2
    }

    [Native]
    public enum ADBMobileDataEvent : ulong
    {
        Lifecycle,
        AcquisitionInstall,
        AcquisitionLaunch,
        DeepLink
    }
}
