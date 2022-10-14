# iOS methods

iOS methods for Xamarin components for Experience Cloud solutions 4.x SDK.

## Configuration methods

* **CollectLifecycleData**

  Indicates to the SDK that lifecycle data should be collected for use across all solutions in the SDK. For more information, see [Lifecycle Metrics](/docs/ios/metrics.md). 

  * Here is the syntax for this method:

    ```objective-c
    public static void CollectLifecycleData();
    ```

  * Here is the code sample for this method:

    ```objective-c
    ADBMobile.CollectLifecycleData();
    ```

* **DebugLogging**

  Returns the current debug logging preference. The default value is `false`. 

  * Here is the syntax for this method:

    ```objective-c
    public static bool DebugLogging(); 
    ```

  * Here is the code sample for this method:

    ```objective-c
    var debugEnabled = ADBMobile.DebugLogging();
    ```

* **SetDebugLogging**

  Sets the debug logging preference to enabled.

  * Here is the syntax for this method:

    ```objective-c
    public static void SetDebugLogging(bool enabled);
    ```

  * Here is the code sample for this method:

    ```objective-c
    ADBMobile.SetDebugLogging(true);
    ```

* **LifetimeValue**

  Returns the lifetime value of the current user. 

  * Here is the syntax for this method:

    ```objective-c
    public static double LifetimeValue();
    ```

  * Here is the code sample for this method:

    ```objective-c
    var lifetimeValue = ADBMobile.LifetimeValue();
    ```

* **PrivacyStatus**

  Returns the enum representation of the privacy status for current user.
  * `ADBMobilePrivacyStatus.OptIn` - hits are sent immediately.
  * `ADBMobilePrivacyStatus.OptOut` - hits are discarded.
  * ADBMobilePrivacyStatus.Unknown  - If offline tracking is enabled, hits are saved until the privacy status changes to opt-in (then hits are sent) or opt-out (then hits are discarded). If offline tracking is disabled, hits are discarded until the privacy status changes to opt in. 
  
  The default value is set in the [ADBMobileConfig.json](/docs/ios/configuration/json-config/json-config.md).

  * Here is the syntax for this method:

    ```objective-c
    public static ADBPrivacyStatus PrivacyStatus();
    ```

  * Here is the code sample for this method:

    ```objective-c
    var privacyStatus = ADBMobile.PrivacyStatus();
    ```

* **SetPrivacyStatus**

  Sets the privacy status for the current user to status. Set to one of the following values: 
  * `ADBMobilePrivacyStatus.OptIn` - hits are sent immediately.
  * `ADBMobilePrivacyStatus.OptOut` - hits are discarded.
  * `ADBMobilePrivacyStatus.Unknown`  - If offline tracking is enabled, hits are saved until the privacy status changes to opt-in (then hits are sent) or opt-out (then hits are discarded). If offline tracking is not enabled, hits are discarded until the privacy status changes to opt in. 

  * Here is the syntax for this method:

    ```objective-c
    public static void SetPrivacyStatus(ADBPrivacyStatus status) 
    ```

  * Here is the code sample for this method:

    ```objective-c
    ADBMobile.SetPrivacyStatus(ADBMobilePrivacyStatus.OptIn); 
    ```

* **UserIdentifier**

  Returns the custom user identifier if a custom identifier has been set. Returns null if a custom identifier is not set. The default value is `null`.

  * Here is the syntax for this method:

    ```objective-c
    public static string UserIdentifier(); 
    ```

  * Here is the code sample for this method:

    ```objective-c
    var userId = ADBMobile.UserIdentifier(); 
    ```

* **SetUserIdentifier**

  Returns the custom user identifier if a custom identifier has been set. Returns null if a custom identifier is not set. The default value is `null`. 

  * Here is the syntax for this method:

    ```objective-c
    public static string UserIdentifier();
    ```

  * Here is the code sample for this method:

    ```objective-c
    ADBMobile.SetUserIdentifier ("customUserIdentifier"); 
    ```

* **GetVersion**

  Gets the library version. 

  * Here is the syntax for this method:

    ```objective-c
    public static string Version();
    ```

  * Here is the code sample for this method:

    ```objective-c
    var version = ADBMobile.Version();
    ```

* **KeepLifecycleSessionAlive (iOS only)**

  Indicates to the SDK that your next resume from background should not start a new session, regardless of the value of lifecycle session timeout in your config file. 
  
  > **Tip:** This method is intended to be used for apps that register for notifications while in background and should only be called from your code that runs while your app is in the background.  

  * Here is the syntax for this method:

    ```objective-c
    public static void KeepLifecycleSessionAlive();
    ```

  * Here is the code sample for this method:

    ```objective-c
    ADBMobile.KeepLifecycleSessionAlive();
    ```

## Analytics methods

* **TrackingIdentifier**

  Retrieves the analytics tracking identifier. 

  * Here is the syntax for this method:

    ```objective-c
    public static string TrackingIdentifier();
    ```

  * Here is the code sample for this method:

    ```objective-c
    var trackingId = ADBMobile.TrackingIdentifier();
    ```

* **TrackState**

  Tracks an app state with optional context data. States are the views that are available in your app, such as "title screen", "level 1", "pause", and so on. These states are similar to pages on a website, and `TrackState` calls increment page views.If state is empty, it displays as "app name app version (build)" in reports. If you see this value in reports, make sure you are setting state in each `TrackState` call. 
  
  > **Tip:** This is the only tracking call that increments page views.

  * Here is the syntax for this method:

    ```objective-c
    public static void TrackState(string state, NSDictionary cdata); 
    ```

  * Here is the code sample for this method:

    ```objective-c
    NSDictionary contextData; 
     contextData = NSDictionary.FromObjectAndKey (NSObject.FromObject("val"),NSObject.FromObject("key")); 
      ADBMobile.TrackState("title screen", contextData); 
    ```

* **TrackAction**

  Tracks an action in your app. Actions are the things that happen in your app that you want to measure, such as "deaths", "level gained", "feed subscriptions", and other metrics. 
  
  > **Tip:** If you have code that might run while the app is in the background (for example, a background data retrieval), use `trackActionFromBackground` instead.

  * Here is the syntax for this method:

    ```objective-c
    public static void TrackAction(string action, NSDictionary cdata); 
    ```

  * Here is the code sample for this method:

    ```objective-c
    ADBMobile.TrackAction("level gained", null); 
    ```

* **TrackActionFromBackground (iOS only)**

  Tracks an action that occurred in the background. This suppresses lifecycle events from firing in certain scenarios.
  
  > **Tip:**  This method should only be called in code that runs while your app is in the background. 

  * Here is the syntax for this method:

    ```objective-c
    public static void TrackActionFromBackground(string action, NSDictionary cdata); 
    ```

  * Here is the code sample for this method:

    ```objective-c
    ADBMobile.TrackActionFromBackground("majorLocationChange", null);
    ```

* **TrackLocation**

  Sends the current latitude and longitude coordinates. Also uses points of interest defined in the `ADBMobileConfig.json` file to determine if the location provided as a parameter is within any of your POI. If the current coordinates are within a defined POI, a context data variable is populated and sent with the `TrackLocation` call. 

  * Here is the syntax for this method:

    ```objective-c
    public static void TrackLocation(CLLocation location, NSDictionary cdata); 
    ```

  * Here is the code sample for this method:

    ```objective-c
    CoreLocation.CLLocation l = new CoreLocation.CLLocation  (111.111, 44.156);
    ADBMobile.TrackLocation (l, null);
    ```

* **TrackBeacon**

  Tracks when a users enters proximity of a beacon. 

  * Here is the syntax for this method:

    ```objective-c
    public static void TrackBeacon( CLBeacon beacon, NSDictionary cdata);
    ```

  * Here is the code sample for this method:

    ```objective-c
    CoreLocation.CLBeacon beacon = new CoreLocation.CLBeacon (); 
    ADBMobile.TrackBeacon (beacon, null);
    ```

* **TrackingClearCurrentBeacon**

  Clears beacons data after a user leaves the proximity of the beacon.

  * Here is the syntax for this method:

    ```objective-c
    public static void TrackingClearCurrentBeacon();
    ```

  * Here is the code sample for this method:

    ```objective-c
    ADBMobile.TrackingClearCurrentBeacon();
    ```

* **TrackLifetimeValueIncrease**

  Adds amount to the user's lifetime value. 

  * Here is the syntax for this method:

    public nbsp;static void TrackLifetimeValueIncrease(double amount, NSDictionary cdata); 

  * Here is the code sample for this method:

    ```objective-c
    ADBMobile.TrackLifetimeValueIncrease(5, null); 
    ```

* **TrackTimedActionStart**

  Start a timed action with name action. If you call this method for an action that has already started, the previous timed action is overwritten.  
  
  > **Tip:** This call does not send a hit. 

  * Here is the syntax for this method:

    ```objective-c
    public static void TrackTimedActionStart(string action, NSDictionary cdata); 
    ```

  * Here is the code sample for this method:

    ```objective-c
    ADBMobile.TrackTimedActionStart("level2", null);
    ```

* **TrackTimedActionUpdate**

  Pass in data to update the context data associated with the given action. The data passed in is appended to the existing data for the given action, and overwrites the data if the same key is already defined for action. 
  
  > **Tip:** This call does not send a hit.

  * Here is the syntax for this method:

    ```objective-c
    public static void TrackTimedActionUpdate(string action, NSDictionary cdata); 
    ```

  * Here is the code sample for this method:

    ```objective-c
    NSDictionary updatedData = NSDictionary.FromObjectAndKey (NSObject.FromObject("val2"), NSObject.FromObject ("key2")); 
      ADBMobile.TrackTimedActionUpdate("level2", updatedData); 
    ```

* **TrackTimedActionEnd**

  End a timed action.

  * Here is the syntax for this method:

    ```objective-c
    public static void TrackTimedActionEnd(string action, Func<double, double, NSMutableDictionary, sbyte> block); 
    ```

  * Here is the code sample for this method:

    ```objective-c
    ADBMobile.TrackTimedActionEnd  ("level2", (double  arg1,  double  arg2,  NSMutableDictionary  arg3)  =>  { 
    return  Convert.ToSByte(true); 
    });
    ```

* **TrackingTimedActionExists**

  Returns whether a timed action is (or is not) in progress.

  * Here is the syntax for this method:

    ```objective-c
    public static bool TrackingTimedActionExists(string action); 
    ```

  * Here is the code sample for this method:

    ```objective-c
    ADBMobile.TrackTimedActionEnd  ("timedAction",  (double  inAppDuration, 
    double  totalDuration,  NSMutableDictionary  data)  =>  { 
                 return  true; 
    });
    ```

* **TrackingSendQueuedHits**

  Forces the library to send all hits in the offline queue no matter how many are currently queued.

  * Here is the syntax for this method:

    ```objective-c
    public static void TrackingSendQueuedHits();
    ```

  * Here is the code sample for this method:

    ```objective-c
    ADBMobile.TrackingSendQueuedHits(); 
    ```

* **TrackingClearQueue**

  Clears all hits from the offline queue. 

  * Here is the syntax for this method:

    ```objective-c
    public static void TrackingClearQueue(); 
    ```

  * Here is the code sample for this method:

    ```objective-c
     ADBMobile.TrackingClearQueue();
    ```

* **TrackingGetQueueSize**

  Retrieves the number of hits currently in the offline queue. 

  * Here is the code sample for this method:

    ```objective-c
    public static int TrackingGetQueueSize();
    ```

  * Here is the code sample for this method:

    ```objective-c
    var queueSize = ADBMobile.TrackingGetQueueSize(); 
    ```

## Experience Cloud ID methods

* **GetMarketingCloudID**

  Retrieves the Experience Cloud ID from the ID service.

  * Here is the syntax for this method:

    ```objective-c
    public static string GetMarketingCloudID(); 
    ```

  * Here is the code sample for this method:

    ```objective-c
    var mcid = ADBMobile.GetMarketingCloudID();
    ```

* **VisitorSyncIdentifiers**

  With the Experience Cloud ID, you can set additional customer IDs to associate with each visitor. The Visitor API accepts multiple Customer IDs for the same visitor, along with a customer type identifier to separate the scope of the different customer IDs. This method corresponds to setCustomerIDs in the JavaScript library. 

  * Here is the syntax for this method:

    ```objective-c
    public static void VisitorSyncIdentifiers(NSDictionary identifiers);
    ```

  * Here is the code sample for this method:

    ```objective-c
    NSDictionary  ids  =  NSDictionary.FromObjectAndKey  (NSObject.FromObject  ("value2"),  NSObject.FromObject  ("pushID")); 
    ADBMobile.VisitorSyncIdentifiers(ids); 
    ```

## Target methods

* **TargetLoadRequest**

  Sends request to your configured Target server and returns the string value of the offer generated in a `Action<NSDictionary>` callback.

  * Here is the syntax for this method:

    ```objective-c
    public static void TargetLoadRequest (ADBTargetLocationRequest request, Action<NSString> callback); 
    ```

  * Here is the code sample for this method:

    ```objective-c
    NSDictionary  dict  =  NSDictionary.FromObjectAndKey  (NSObject.FromObject  ("value2"),  NSObject.FromObject  ("key1")); 
    ADBTargetLocationRequest  req  =  ADBMobile.TargetCreateRequest  ("iOSTest",  "defGal",  dict); 
    ADBMobile.TargetLoadRequest(req,    (context)  =>  { 
    Console.WriteLine  (context); 
    });
    ```

* **TargetCreateRequest**

  Convenience constructor to create an `ADBTargetLocationRequest` object with the given parameters. 

  * Here is the syntax for this method:

    ```objective-c
    public static ADBTargetLocationRequest ADBTargetLocationRequest TargetCreateRequest (string name, string defaultContent, NSDictionary parameters); 
    ```

  * Here is the code sample for this method:

    ```objective-c
    NSDictionary  dict  =  NSDictionary.FromObjectAndKey  (NSObject.FromObject  ("value2"),  NSObject.FromObject  ("key1")); 
    ADBTargetLocationRequest  req  =  ADBMobile.TargetCreateRequest  ("iOSTest",  "defGal",  dict); 
    ```

* **TargetCreateOrderConfirmRequest**

  Creates an `ADBTargetLocationRequest`.

  * Here is the syntax for this method:

    ```objective-c
    public static ADBTargetLocationRequest ADBTargetLocationRequest TargetCreateRequest (string name, string defaultContent, NSDictionary parameters);
    ```

  * Here is the code sample for this method:

    ```objective-c
    ADBMobile.TargetCreateOrderConfirmRequest ("myOrder", "12345", "29.41", "cool stuff", null); 
    ```

* **TargetClearCookies**

  Clears any target cookies from your app. 

  * Here is the syntax for this method:

    ```objective-c
    public static void TargetClearCookies(); 
    ```

  * Here is the code sample for this method:

    ```objective-c 
    ADBMobile.TargetClearCookies(); 
    ```

## Audience Manager

* **AudienceVisitorProfile**

  Returns the visitor profile that was most recently obtained. Returns nil if no signal has been submitted yet. Visitor profile is saved in `NSUserDefaults` for easy access across multiple launches of your app. 

  * Here is the syntax for this method:

    ```objective-c
    public static NSDictionary AudienceVisitorProfile (); 
    ```

  * Here is the code sample for this method:

    ```objective-c
    NSDictionary profile = ADBMobile.AudienceVisitorProfile();
    ```

* **AudienceDpid**

  Returns the current DPID. 

  * Here is the syntax for this method:

    ```objective-c
    public static string AudienceDpid ();
    ```

  * Here is the code sample for this method:

    ```objective-c
    string currentDpid = ADBMobile.AudienceDpid();
    ```

* **AudienceDpuuid**

  Returns the current DPUUID.

  * Here is the syntax for this method:

    ```objective-c
    public static string AudienceDpuuid ();
    ```

  * Here is the code sample for this method:

    ```objective-c
    string currentDpuuid = ADBMobile.AudienceDpuuid(); 
    ```

* **AudienceSetDpidAndDpuuid**

  Sets the dpid and dpuuid. If dpid and dpuuid are set, they will be sent with each signal. 

  * Here is the syntax for this method:

    ```objective-c
    public static void AudienceSetDpidAndDpuuid (NSDictionary data, Action<NSDictionary> callback); 
    ```

  * Here is the code sample for this method:

    ```objective-c
    ADBMobile.AudienceSetDpidAndDpuuid ("testDppid", "testDpuuid")
    ```

* **AudienceSignalWithData**

  Sends audience management a signal with traits and get the matching segments returned in a `Action<NSDictionary>`  callback. 

  * Here is the syntax for this method:

    ```objective-c
    public static void AudienceSignalWithData (NSDictionary data, Action<NSDictionary> callback); 
    ```

  * Here is the code sample for this method:

    ```objective-c
    NSDictionary  audienceData  =  NSDictionary.FromObjectAndKey  (NSObject.FromObject  ("value2"),  NSObject.FromObject  ("key1")); 
    ADBMobile.AudienceSignalWithData  (audienceData,  (context)  =>  { 
    Console.WriteLine  (context); 
    }); 
    ```

* **AudienceReset**

  Resets audience manager UUID and purges current visitor profile. 

  * Here is the syntax for this method:

    ```objective-c
    public static void AudienceReset ();
    ```

  * Here is the syntax for this method:

    ```objective-c
    ADBMobile.AudienceReset ();
    ```

## Video

For more information, see [Video Analytics](/docs/ios/getting-started/dev-qs.md). 

* **MediaCreateSettings**

  Returns an `ADBMediaSettings` object with specified parameters.

  * Here is the syntax for this method:

    ```objective-c
    public static ADBMediaSettings MediaCreateSettings ([string name, double length, string playerName, string playerID); 
    ```

  * Here is the code sample for this method:

    ```objective-c
    ADBMediaSettings settings = ADBMobile.MediaCreateSettings ("name1", 10, "playerName1", "playerID1"); 
    ```

* **MediaAdCreateSettings**

  Returns an `ADBMediaSettings` object for use with tracking an ad video.

  * Here is the syntax for this method:

    ```objective-c
    public static ADBMediaSettings MediaAdCreateSettings ( string name,  double length,  string playerName,  string parentName,  string parentPod,  double parentPodPosition,  string CPM); 
    ```

  * Here is the code sample for this method:

    ```objective-c
    ADBMediaSettings adSettings = ADBMobile.MediaAdCreateSettings("adName1", 2, "playerName1", "name1", "podName1", 4, "CPM1");
    ```

* **MediaOpenWithSettings**

  Opens an `ADBMediaSettings` object for tracking. 

  * Here is the syntax for this method:

    ```objective-c
    public static void MediaOpenWithSettings ( ADBMediaSettings settings,  Action<ADBMediaState> callback); 
    ```

  * Here is the code sample for this method:

    ```objective-c
    ADBMediaSettings settings = ADBMobile.MediaCreateSettings  ("name1",  10,  "playerName1",  "playerID1"); 
    ADBMobile.MediaOpenWithSettings  (settings,  (state)  =>  { 
    Console.WriteLine  (state.Name); 
    }); 
    ```

* **MediaClose**

  Closes the media item named name. 

  * Here is the syntax for this method:

    ```objective-c
    public static void MediaClose ( string name);
    ```

  * Here is the code sample for this method:

    ```objective-c
    ADBMobile.MediaClose  (settings.Name);
    ```

* **MediaPlay**

  Plays the media item named name at the given offset (in seconds). 

  * Here is the syntax for this method:

    ```objective-c
    public static void MediaPlay ( string name, double offset);
    ```

  * Here is the code sample for this method:

    ```objective-c
    ADBMobile.MediaPlay (settings.Name, 0); 
    ```

* **MediaComplete**

  Manually mark the media item as complete at the offset provided (in seconds). 

  * Here is the syntax for this method:

    ```objective-c
    public static void MediaComplete ( string name, double offset);
    ```

  * Here is the code sample for this method:

    ```objective-c
    ADBMobile.MediaComplete (settings.Name, 5);
    ```

* **MediaStop**

   Notifies the media module that the video has been stopped or paused at the given offset. 

  * Here is the syntax for this method:

    ```objective-c
    public static void MediaStop ( string name, double offset);
    ```

  * Here is the code sample for this method:

    ```objective-c
    ADBMobile.MediaStop (settings.Name, 3);
    ```

* **MediaClick**

  Notifies the media module that the media item has been clicked. 

  * Here is the syntax for this method:

    ```objective-c
    public static void MediaClick ( string name, double offset); 
    ```

* **MediaTrack**

  Sends a track action call (no page view) for the current media state.

  * Here is the syntax for this method:

    ```objective-c
    public static void MediaTrack ( string name, NSDictionary data); 
    ```

  * Here is the code sample for this method:

    ```objective-c
     ADBMobile.MediaTrack (settings.Name, null);
    ```
