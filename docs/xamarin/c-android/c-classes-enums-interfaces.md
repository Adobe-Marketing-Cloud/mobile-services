# Classes, enums, and interfaces

List of classes and enumerations for use in Xamarin applications.

## Classes

### MediaEventType

```java
public class MediaEventType : Object 
{
    public const int MediaEventTypeClick; 
    public const int MediaEventTypeTrack; 
    public const int MediaEventTypeStop; 
    public const int MediaEventTypeClose; 
    public const int MediaEventTypeComplete; 
    public const int MediaEventTypeMonitor; 
    public const int MediaEventTypePlay; 
    public MediaEventType (); 
}
```

### TargetLocationRequest

```java
public class TargetLocationRequest : Object 
{
    public const string TargetParameterCategoryId = "categoryId"; 
    public const string TargetParameterProductPurchaseId = "purchasedProductIds"; 
    public const string TargetParameterMbox3rdpartyId = "mbox3rdPartyId"; 
    public const string TargetParameterMboxHost = "mboxHost"; 
    public const string TargetParameterMboxPageValue = "mboxPageValue"; 
    public const string TargetParameterMboxPc = "mboxPC"; 
    public const string TargetParameterMboxSessionId = "mboxSession"; 
    public const string TargetParameterOrderId = "orderId"; 
    public const string TargetParameterOrderTotal = "orderTotal"; 
    public string DefaultContent { 
        get;
        set;
    }
    public string Name {
        get;
        set;
    }
    public IDictionary Parameters {
        get;
        set;
    }
}
```

### VisitorID

```java
public class VisitorID : Object {
    public VisitorID.VisitorIDAuthenticationState 
      AuthenticationState {
        get;
        set;
    }
    public string Id {
        get;
        set;
    }
    public string IdOrigin {
        get;
        set;
    }
    public string IdType {
        get;
        set;
    }
}

```

## Enumerations

### MobileDataEvent

```java
public sealed class MobileDataEvent : Enum{
    public static Config.MobileDataEvent MobileEventAcquisitionInstall {
        get;
    }
    public static Config.MobileDataEvent MobileEventAcquisitionLaunch {
        get;
    }
    public static Config.MobileDataEvent MobileEventLifecycle {
        get;
    }
    public static Config.MobileDataEvent ValueOf (string p0);
    public static Config.MobileDataEvent[] Values ();
}
```

### MobilePrivacyStatus

```java
public sealed class MobilePrivacyStatus : Enum{
    public static MobilePrivacyStatus MobilePrivacyStatusOptIn {
        get;
    }
    public static MobilePrivacyStatus MobilePrivacyStatusOptOut {
        get;
    }
    public static MobilePrivacyStatus MobilePrivacyStatusUnknown {
        get;
    }
    public static MobilePrivacyStatus ValueOf (string p0);
    public static MobilePrivacyStatus[] Values ();
}
```

### VisitorIDAuthenticationState

```java
public sealed class VisitorIDAuthenticationState : Enum { 
    public static VisitorID.VisitorIDAuthenticationState VisitorIdAuthenticationStateAuthenticated {
        get;
    }
    public static VisitorID.VisitorIDAuthenticationState VisitorIdAuthenticationStateLoggedOut {
        get;
    }
    public static VisitorID.VisitorIDAuthenticationState VisitorIdAuthenticationStateUnknown {
        get;
    }
    public static VisitorID.VisitorIDAuthenticationState ValueOf (string p0);
    public static VisitorID.VisitorIDAuthenticationState[] Values ();
}
```

## Interfaces

### IAdobeDataCallback

```
public interface IAdobeDataCallback : IJavaObject, IDisposable 
{ 
    void Call (Config.MobileDataEvent p0, IDictionary<string, Object> p1); 
}
```

### ITimedActionBlock

```
public interface ITimedActionBlock : IJavaObject, IDisposable {
    Object Call (long p0, long p1, IDictionary<string, Object> p2);
}
```

### IAudienceManagerCallback

```
public interface IAudienceManagerCallback : IJavaObject, IDisposable {
    void Call (Object p0);
}
```

### IMediaCallback

```java
public interface IMediaCallback : IJavaObject, IDisposable {
    void Call (Object p0);
}
```

### ITargetCallback

```java
public interface ITargetCallback : IJavaObject, IDisposable {
    void Call (Object p0); 
}
```
