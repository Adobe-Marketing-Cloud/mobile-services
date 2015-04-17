using System;
using ObjCRuntime;

[assembly: LinkWith ("AdobeMobileLibrary.a", LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Arm64, ForceLoad = true, Frameworks = "SystemConfiguration", LinkerFlags="-lsqlite3.0")]
