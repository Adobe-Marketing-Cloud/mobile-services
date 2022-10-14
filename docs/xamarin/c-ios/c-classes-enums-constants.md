# Classes and enums

List of classes and enumerations for use in Xamarin applications.

## Classes

### ADBVisitorID

```objective-c
public class ADBVisitorID : NSObject
{
    public override IntPtr ClassHandle {
        get;
    }
    public ADBVisitorID ();
    public virtual ADBMobileVisitorAuthenticationState AuthenticationState ();
    public virtual string Identifier ();
    public virtual string IdType ();
}
```

### ADBTargetLocationRequest

```objective-c
public class ADBTargetLocationRequest : NSObject
{ 
    public override IntPtr ClassHandle {
        get;
    }
    public virtual string DefaultContent {
        get;
        set;
    }
    public virtual string Name {
        get;
        set;
    }
    public virtual NSMutableDictionary Parameters {
        get;
        set;
    }

    public ADBTargetLocationRequest ();
}
```

### ADBMediaState

```objective-c
public class ADBMediaState : NSObject
{ 
    public virtual bool Ad {
        get;
        set;
    }
    public override IntPtr ClassHandle {
        get;
    }
    public virtual bool Clicked {
        get;
        set;
    }

    public virtual bool Complete {
        get;
        set;
    }
    public virtual bool EventFirstTime {
        get;
        set;
    }
    public virtual nuint EventType {
        get;
        set;
    }
    public virtual double Length {
        get;
        set;
    }
    public virtual string MediaEvent {
        get;
        set;
    }
    public virtual nuint Milestone {
        get;
        set;
    }
    public virtual string Name {
        get; 
        set; 
    } 
 
    public virtual double Offset { 
        get;
        set;
    }
    public virtual nuint OffsetMilestone {
        get;
        set;
    }
    public virtual NSDate OpenTime {
        get;
        set;
    }
    public virtual double Percent {
        get;
        set;
    }

    public virtual string PlayerName {
        get;
        set;
    }
    public virtual string Segment {
        get;
        set;
    }
    public virtual double SegmentLength {
        get;
        set;
    }
    public virtual nuint SegmentNum {
        get;
        set;
    }
    public virtual double TimePlayed {
        get;
        set;
    }
    public virtual double TimePlayedSinceTrack {
        get;
        set;
    }
    public virtual double Timestamp {
        get;
        set;
    }
    public ADBMediaState ();
}
```

### ADBMediaSettings

```objective-c
public class ADBMediaSettings : NSObject
{ 
    public virtual string Channel {
        get;
        set;
    }
    public override IntPtr ClassHandle {
        get;
    }
    public virtual nuint CompleteCloseOffsetThreshold {
        get;
        set;
    }
    public virtual string CPM {
        get;
        set;
    }
    public virtual bool IsMediaAd {
        get;
        set;
    }
    public virtual double Length {
        get;
        set;
    }
    public virtual string Milestones {
        get;
        set;
    }
    public virtual string Name {
        get;
        set;
    }
    public virtual string OffsetMilestones {
        get;
        set;
    }
    public virtual string ParentName {
        get;
        set;
    } 
    public virtual string ParentPod {
        get;
        set;
    }
    public virtual double ParentPodPosition {
        get;
        set;
    }
    public virtual string PlayerID {
        get;
        set;
    }
    public virtual string PlayerName {
        get;
        set;
    }
    public virtual bool SegmentByMilestones {
        get;
        set;
    }
    public virtual bool SegmentByOffsetMilestones {
        get;
        set;
    }
    public virtual nuint TrackSeconds {
        get;
        set;
    }
    public ADBMediaSettings (); 
}
```

### Constants

```objective-c
public static class Constants 
{ 
    public static NSString ADBConfigKeyCallbackDeepLink {
        get;
    }
    public static NSString ADBTargetParameterCategoryId {
        get;
    }
    public static NSString ADBTargetParameterMbox3rdPartyId {
        get;
    }
    public static NSString ADBTargetParameterMboxHost {
        get;
    }
    public static NSString ADBTargetParameterMboxPageValue {
        get;
    }
    public static NSString ADBTargetParameterMboxPc {
        get;
    }
    public static NSString ADBTargetParameterMboxSessionId {
        get;
    }
    public static NSString ADBTargetParameterOrderId {
        get;
    }
    public static NSString ADBTargetParameterOrderTotal {
        get;
    }
    public static NSString ADBTargetParameterProductPurchasedId {
        get;
    }
}
```

## Enumerations

### ADBMobileVisitorAuthenticationState

```objective-c
public enum ADBMobileVisitorAuthenticationState : ulong 
{ 
    Unknown, 
    Authenticated, 
    LoggedOut 
}
```

### ADBMobilePrivacyStatus

```objective-c
public enum ADBMobilePrivacyStatus : ulong 
{ 
    OptIn = 1uL, 
    OptOut, 
    Unknown 
}
```

### ADBMobileDataEvent

```objective-c
public enum ADBMobileDataEvent : ulong 
{ 
    Lifecycle, 
    AcquisitionInstall, 
    AcquisitionLaunch, 
    DeepLink 
}
```

### ADBMobileAppExtensionType

```objective-c
public enum ADBMobileAppExtensionType : ulong 
{ 
    Regular, 
    StandAlone 
}
```
