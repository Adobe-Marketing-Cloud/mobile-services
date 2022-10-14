# Android methods

Android methods for Xamarin components for Experience Cloud solutions 4.x SDK.

## Configuration methods

* **DebugLogging**

  Returns the current debug logging preference, and the default is false.

  * Here is the syntax for this method:

    ```java
    public static Boolean DebugLogging;
    ```

  * Here is the code sample for this method:

    ```java
    getter: var debuglog = Config.DebugLogging;
    setter: Config.DebugLogging = (Java.Lang.Boolean)true;
    ```

* **LifetimeValue**

  Returns the lifetime value of the current user. 

  * Here is the syntax for this method:

    ```java
    public static BigDecimal LifetimeValue; 
    ```

  * Here is the code sample for this method:

    ```java
     var lifetimeValue = Config.LifetimeValue;
    ```

* **PrivacyStatus**

   Returns the enum representation of the privacy status for current user. 
  * `ADBMobilePrivacyStatus.OptIn` - hits are sent immediately. 
  * `ADBMobilePrivacyStatus.OptOut` - hits are discarded. 
  * `ADBMobilePrivacyStatus.Unknown` - If offline tracking is enabled, hits are saved until the privacy status changes to opt-in (then hits are sent) or opt-out (then hits are discarded). If offline tracking is not enabled, hits are discarded until the privacy status changes to opt in. 
  
   The default value is set in the [ADBMobileConfig.json](/docs/android/configuration/json-config/json-config.md) file.

  * Here is the syntax for this method:

    ```java
    public static MobilePrivacyStatus PrivacyStatus; 
    ```

  * Here is the code sample for this method:

    ```java
    getter: var privacyStatus = Config.PrivacyStatus; 
    setter: Config.PrivacyStatus = MobilePrivacyStatus.MobilePrivacyStatusUnknown;
    ```

* **UserIdentifier**

  If a custom identifier has been set, returns this identifier. If a custom identifier is not set, returns null. The default value is `null`.

  * Here is the syntax for this method:

    ```java
    public static UserIdentifier();
    ```

  * Here is the code sample for this method:

    ```java
    getter: var userId = Config.UserIdentifier;
    setter: Config.UserIdentifier = "imBatman";
    ```

* **Version**

  Gets the library version. 

  * Here is the syntax for this method:

    ```java
    public static string Version;
    ```

  * Here is the code sample for this method:

    ```java
    var version = ADBMobile.Version;
    ```

* **PauseCollectingLifecycleData**

  Indicates to the SDK that your app is paused, so that lifecycle metrics are calculated correctly. For example, on pause collects a timestamp to determine previous session length. This also sets a flag so that lifecycle correctly knows that the app did not crash. For more information, see [Lifecycle Metrics](/docs/android/metrics.md).

  * Here is the syntax for this method:

    ```java
    public static void PauseCollectingLifecycleData (); 
    ```

  * Here is the code sample for this method:

    ```java
    Config.PauseCollectingLifecycleData();
    ```

* **CollectLifecycleData (Activity activity)**

  (4.2 or later) Indicates to the SDK that lifecycle data should be collected for use across all solutions in the SDK. For more information, see [Lifecycle Metrics](/docs/android/metrics.md). 

  * Here is the syntax for this method:

    ```java
    public static void collectLifecycleData(Activity activity); 
    ```

  * Here is the code sample for this method:

    ```java
    Config.CollectLifecycleData (this);
    ```

* **CollectLifecycleData (Activity activity)**

  (4.2 or later) Indicates to the SDK that lifecycle data should be collected for use across all solutions in the SDK. For more information, see [Lifecycle Metrics](/docs/android/metrics.md).

  * Here is the syntax for this method:

    ```java
    public static void collectLifecycleData(Activity activity, IDictionary<string, Object> context));
    ```

  * Here is the code sample for this method:

    ```java
    IDictionary<string, Java.Lang.Object> context = new Dictionary<string, 
    Java.Lang.Object> ();
    context.Add ("key", "value");
    Config.CollectLifecycleData (this, context);
    ```

* **OverrideConfigStream**

  (4.2 or later) Lets you load a different `ADBMobile JSON` config file when the application starts. The different configuration is used until the application is closed. 

  * Here is the syntax for this method:

    ```java
    public static void OverrideConfigStream (Stream stream);
    ```

  * Here is the code sample for this method:

    ```java
    Stream st1 = Assets.Open ("ADBMobileConfig-2.json"); 
    Config.OverrideConfigStream (st1); 
    ```

* **SetLargeIconResourceId(int resourceId)**

  (4.2 or later) Sets the large icon that is used for notifications created by the SDK. This icon is the primary image that is displayed when the user sees the complete notification in the notification center. 

  * Here is the syntax for this method:

    ```java
    public static void SetLargeIconResourceId( int resourceId);
    ```

  * Here is the code sample for this method:

    ```java
    Config.SetLargeIconResourceId(R.drawable.appIcon);
    ```

* **SetSmallIconResourceId(int resourceId)**

  (4.2 or later) Sets the small icon that is used for notifications created by the SDK. This icon displays in the status bar and is the secondary image shown when the user sees the complete notification in the notification center. 

  * Here is the syntax for this method:

    ```java
    public static void SetSmallIconResourceId( int resourceId); 
    ```

  * Here is the code sample for this method:

    ```java
     Config.SetSmallIconResourceId(R.drawable.appIcon);
    ```

## Analytics methods

* **TrackingIdentifier**

  Returns the automatically generated ID for Analytics. This is an app-specific unique ID that is generated on initial launch and is stored and used from that point forward. This ID is preserved between app upgrades and is removed on uninstall. 

  * Here is the syntax for this method:

    ```java
    public static string TrackingIdentifier;
    ```

  * Here is the code sample for this method:

    ```java
    Var trackingId = Analytics.TrackingIdentifier
    ```

* **TrackState**

  Tracks an app state with optional context data. `States` are the views that are available in your app, such as "title screen", "level 1", "pause", and so on. These states are similar to pages on a website, and `TrackState` calls increment page views. If state is empty, it displays as "app name app version (build)" in reports. If you see this value in reports, make sure you are setting state in each `TrackState` call. 
  
  > **Tip:** This is the only tracking call that increments page views. 

  * Here is the syntax for this method:

    ```java
    public static void TrackState (string state, IDictionary<string, Object> cdata); 
    ```

  * Here is the code sample for this method:

    ```java
    var cdata = new Dictionary<string, Java.Lang.Object>(); 
    cdata.Add ("key", (Java.Lang.Object)"value"); 
    Analytics.TrackState ("stateName", (IDictionary<string, 
    Java.Lang.Object>)cdata);
    ```

* **TrackAction**

  Tracks an action in your app. Actions are the things that happen in your app that you want to measure, such as "deaths", "level gained", "feed subscriptions", and other metrics. 
  
  > **Tip:** 
  >If you have code that might run while the app is in the background (for example, a background data retrieval), use `trackActionFromBackground` instead. 

  * Here is the syntax for this method:

    ```java
    public static void TrackAction(string action, IDictionary<string,Object> cdata); 
    ```

  * Here is the code sample for this method:

    ```java
    var cdata = new Dictionary<string, Java.Lang.Object> (); 
    cdata.Add ("key", (Java.Lang.Object)"value");
    Analytics.TrackAction ("actionName", (IDictionary<string, 
    Java.Lang.Object>)cdata);
    ``` 

* **TrackLocation**

  Sends the current latitude and longitude coordinates. Also uses points of interest defined in the `ADBMobileConfig.json` file to determine whether the location that was provided as a parameter is in any of your POIs. If the current coordinates are in a defined POI, a context data variable is populated and sent with the `TrackLocation` call. 

  * Here is the syntax for this method:

    ```java
    public static void TrackLocation(Location location, IDictionary<string, Object> cdata); 
    ```

  * Here is the code sample for this method:

    ```java
     Location loc = new Location(LocationManager.GpsProvider);;
     loc.Latitude = 111; 
     loc.Longitude = 44; 
     loc.Accuracy = 5; 
     Analytics.TrackLocation (loc, null);
    ```

* **TrackBeacon**

  Tracks when a users enters proximity of a beacon.

  * Here is the syntax for this method:

    ```java
    public static void TrackBeacon (string uuid, string major, string minor,  Analytics.BEACON_PROXIMITY prox, IDictionary<string, Object> cdata); 
    ```  

  * Here is the code sample for this method:

    ```java
    Analytics.TrackBeacon ("UUID", "1", "2", 
    Analytics.BEACON_PROXIMITY.ProximityImmediate, null); 
    ```

* **ClearBeacon**

  Clears beacons data after a user leaves the proximity of the beacon. 

  * Here is the syntax for this method:

    ```java
    public static void TrackingClearCurrentBeacon();
    ```

  * Here is the code sample for this method:

    ```java
    Analytics.ClearBeacon(); 
    ```

* **TrackLifetimeValueIncrease**

  Adds an amount to the user's lifetime value.

  * Here is the syntax for this method:

    ```java
    public static void TrackLifetimeValueIncrease (double amount, IDictionary<string,Object> cdata); 
    ```

  * Here is the code sample for this method:

    ```java
    Analytics.TrackLifetimeValueIncrease(5,null);
    ```

* **TrackTimedActionStart**

  Start a timed action with name action. If you call this method for an action that has already started, the previous timed action is overwritten.
  
  > **Tip:**  This call does not send a hit. 

  * Here is the syntax for this method:

    ```java
    public static void TrackTimedActionStart(string action,IDictionary<string, Object> cdata); 
    ```

  * Here is code sample for this method:

    ```java
    Analytics.TrackTimedActionStart("level2", null);
    ```

* **TrackTimedActionUpdate**

  Pass in data to update the context data that is associated with the given action. The data passed in is appended to the existing data for the given action, and overwrites the data if the same key is already defined for action. 
  
  > **Tip:** This call does not send a hit. 

  * Here is the syntax for this method:

    ```java

    public static void TrackTimedActionUpdate(string action, IDictionary<string, Object> cdata); 
    ```

  * Here is the code sample for this method:

    ```java
    var updatedData = new Dictionary<string, Java.Lang.Object> (); 
    cdata.Add ("key", (Java.Lang.Object)"value"); 
    Analytics.TrackTimedActionUpdate("level2", updatedData); 
    ```

* **TrackTimedActionEnd**

  End a timed action. 

  * Here is the syntax for this method:

    ```java
    public static void TrackTimedActionEnd(string action,
      Analytics.ITimedActionBlock block);
    ```

  * Here is the code sample for this method:

    ```java
    Analytics.TrackTimedActionEnd ("level2", new TimedActionBlock()); 
         class TimedActionBlock: Java.Lang.Object, 
    Analytics.ITimedActionBlock{ 
         public Java.Lang.Object Call (long inAppDuration, long 
    totalDuration IDictionary<string, Java.Lang.Object> contextData){ 
         return Java.Lang.Boolean.True; 
      } 
    }
    ```

* **TrackingTimedActionExists**

  Returns whether a timed action is in progress.

  * Here is the syntax for this method:

    ```java
    public static bool TrackingTimedActionExists(string action); 
    ```

  * Here is the code sample for this method:

    ```java
    var level2InProgress = Analytics.TrackingTimedActionExists("level2"); 
    ```

* **SendQueuedHits**

  Forces the library to send all hits in the offline queue, regardless of how many hits are currently queued.

  * Here is the syntax for this method:

    ```java
    public static void SendQueuedHits();
    ```

  * Here is the code sample for this method:

    ```java
    Analytics.SendQueuedHits(); 
    ```

* **ClearQueue**

  Clears all hits from the offline queue. 

  * Here is the syntax for this method:

    ```java
    public static void ClearQueue(); 
    ```

  * Here is the code sample for this method:

    ```java
    Analytics.ClearQueue(); 
    ```

* **QueueSize**

  Retrieves the number of hits that are currently in the offline queue.

  * Here is the syntax for this method:

    ```java
    public static long QueueSize(); 
    ```

  * Here is the code sample for this method:

    ```java
    var queueSize = Analytics.QueueSize();
    ```

## Experience Cloud ID methods

* **MarketingCloudId**

  Retrieves the Experience Cloud ID from the ID service.

  * Here is the syntax for this method:

    ```java
    public static string MarketingCloudId;
    ```

  * Here is the code sample for this method:

    ```java
    var mcid = Visitor.MarketingCloudId;
    ```

* **SyncIdentifiers**

  With the Experience Cloud ID, you can set additional customer IDs to associate with each visitor. The Visitor API accepts multiple customer IDs for the same visitor, with a customer type identifier to separate the scope of the different customer IDs. This method corresponds to `setCustomerIDs` in the JavaScript library. 

  * Here is the syntax for this method:

    ```java
    public static void SyncIdentifiers((IDictionary<string> identifiers);
    ```

  * Here is the code sample for this method:

    ```java
    IDictionary<string,string> ids = new Dictionary<string, string> ();
    ids.Add ("pushID", ;"value2");
    Visitor.SyncIdentifiers (ids);
    ```

## Target methods

* **LoadRequest**

  Sends a request to your configured Target server and returns the string value of the offer generated in a `Action<NSDictionary>` callback.

  * Here is the syntax for this method:

    ```java
    public static void LoadRequest (TargetLocationRequest request, Target.ITargetCallback callback); 
    ```

  * Here is the code sample for this method:

    ```java
    class TargetBlock: Java.Lang.Object, Target.ITargetCallback{ 
        public void Call (Java.Lang.Object content) 
       { 
        Console.WriteLine (content.ToString()); 
       } 
    } 
    var req = Target.CreateRequest ("AndroidTest", "defGal", parameters); 
         Target.LoadRequest (req, new TargetBlock()); 
    ```

* **CreateRequest**

  Convenience constructor to create an `ADBTargetLocationRequest` object with the given parameters.

  * Here is the syntax for this method:

    ```java
    public static TargetLocationRequest TargetCreateRequest(string name,string defaultContent,IDictionary<string,string> parameters); 
    ```

  * Here is the code sample for this method:

    ```java
    IDictionary<string, Java.Lang.Object> parameters = new Dictionary> string, Java.Lang.Object> (); 
        parameters.Add ("key1", "value2"); 
    var req = Target.CreateRequest ("AndroidTest", "defGal", parameters); 
    ```

* **CreateOrderConfirmRequest**

  Creates an `ADBTargetLocationRequest`.

  * Here is the syntax for this method:

    ```java
    public static TargetLocationRequest TargetCreateRequest (string name, string defaultContent, IDictionary<;string, string> parameters);
    ```

  * Here is the code sample for this method:

    ```java
    var orderConfirm = Target.CreateOrderConfirmRequest ("myOrder", "12345", "29.41", "cool stuff", null); 
    ```

* **ClearCookies**

  Clears Target cookies from your app. 

  * Here is the syntax for this method:

    ```java
    public static void ClearCookies(); 
    ```

  * Here is the code sample for this method:

    ```java
    Target.ClearCookies (); 
    ```

## Audience Manager

* **VisitorProfile**

  Returns the visitor profile that was most recently obtained. Returns nil if no signal has been submitted yet. The visitor profile is saved in `NSUserDefaults` for easy access across multiple launches of your app.

  * Here is the syntax for this method:

    ```java
    public static IDictionary<string, Object> VisitorProfile; 
    ```

  * Here is the code sample for this method:

    ```java
    NSDictionary profile = AudienceManager.VisitorProfile; 
    ```

* **Dpid**

  Returns the current `DPID`. 

  * Here is the syntax for this method:

    ```java
    public static string Dpuuid; 
    ```

  * Here is the code sample for this method:

    ```java
    string currentDpid = AudienceManager.Dpid;
    ```

* **Dpuuid**

  Returns the current `DPUUID`. 

  * Here is the syntax for this method:

    ```java
    public static string AudienceDpuuid; 
    ```

  * Here is the code sample for this method:

    ```java
    string currentDpuuid = AudienceManager.Dpuuid;
    ```

* **AudienceSetDpidAndDpuuid**

  Sets the `dpid` and `dpuuid`. If `dpid` and `dpuuid` are set, they are sent with each signal.

  * Here is the syntax for this method:

    ```java
    public static void AudienceSetDpidAndDpuuid (string Dpid, String Dpuuid);
    ```

  * Here is the code sample for this method:

    ```java
    AudienceManager.SetDpidAndDpuuid ("testDpid", "testDpuuid");
    ```

* **SignalWithData**

  Sends audience management a signal with traits and get the matching segments returned in a `Action<NSDictionary>` callback. 

  * Here is the syntax for this method:

    ```java
    public static void SignalWithData (IDictionary<string, Object> audienceData, AudienceManager.IAudienceManagerCallback callback); 
    ```

  * Here is the code sample for this method:

    ```java
    class AudienceManagerCallback: Java.Lang.Object, 
     AudienceManager.IAudienceManagerCallback{ 
       public void Call (Java.Lang.Object content) 
      {
        Console.WriteLine (content.ToString()); 
      }
    }
    IDictionary<string, Java.Lang.Object> traits = new Dictionary<string, 
    Java.Lang.Object> (); 
       traits.Add ("trait", "b");
    AudienceManager.SignalWithData (traits, new AudienceManagerCallback());
    ``` 

* **Reset**

  Resets audience manager `UUID` and purges current visitor profile. 

  * Here is the syntax for this method:

    ```java
    public static void Reset ();
    ```

  * Here is the code sample for this method:

    ```java
     AudienceManager.Reset ();
    ```

## Video

For more information about Video Analytics, see [Video Analytics](/docs/android/analytics-main/video-qs.md). 

* **MediaSettings**

  Returns an `MediaSettings` object with specified parameters.

  * Here is the syntax for this method:

    ```java
    public static MediaSettings SettingsWith (string name, double length, string playerName, string playerID);  
    ```

  * Here is the code sample for this method:

    ``` java
    MediaSettings settings = Media.SettingsWith("name1", 10, "playerName1", "playerID1");
    ```

* **AdSettingsWith**

  Returns an `MediaSettings` object for use with tracking an ad video. 

  * Here is the syntax for this method:

    ```java
    public static MediaSettings AdSettingsWith ( string name, double length, 
      string playerName, string parentName, string parentPod, 
    double parentPodPosition, string CPM); 
    ```

  * Here is the code sample for this method:

    ```java
    MediaSettings adSettings = Media.AdSettingsWith ("adName1", 2, "playerName1", "name1", "podName1", 4, "CPM1"); 
    ```

* **Open**

  Opens an `ADBMediaSettings` object for tracking.

  * Here is the syntax for this method:

    ```java
    public static void Open (MediaSettings settings, Media.IMediaCallback callback);
    ```

  * Here is the code sample for this method:

    ```java
    MediaSettings settings = Media.SettingsWith ("name1", 10, "playerName1", "playerID1"); 
       Media.Open (settings, new MediaCallback()); 
       class MediaCallback: Java.Lang.Object, Media.IMediaCallback{ 
    public void Call (Java.Lang.Object content) 
    {
    }
    }
    ```

* **Close**

  Closes the media item named name. 

  * Here is the syntax for this method:

    ```java
    public static void Close(string name);
    ```

  * Here is the code sample for this method:

    ```java
    Media.Close (settings.Name); 
    ```

* **Play**

  Plays the media item named name at the given offset (in seconds).

  * Here is the syntax for this method:

    ```java
    public static void Play ( string name, double offset); 
    ```

  * Here is the code sample for this method:

    ```java
    Media.Play (settings.Name, 0); 
    ```

* **Complete**

  Manually mark the media item as complete at the offset provided (in seconds). 

  * Here is the syntax for this method:

    ```java
    public static void Complete (string name, double offset); 
    ```

  * Here is the code sample for this method:

    ```java
    Media.Complete (settings.Name, 5); 
    ```

* **Stop**

  Notifies the media module that the video has been stopped or paused at the given offset. 

  * Here is the syntax for this method:

    ```java
    public static void Stop ( string name, double offset); 
    ```

  * Here is the code sample for this method:

    ```java
    Media.Stop (settings.Name, 3);
    ```

* **Click**

  Notifies the media module that the media item has been clicked.

  * Here is the syntax for this method:

    ```java
    public static void Click ( string name, double offset); 
    ```

  * Here is the code sample for this method:

    ```java
    Media.Click (settings.Name, 3); 
    ```

* **Track**

  Sends a track action call (no page view) for the current media state.

  * Here is the syntax for this method:

    ```java
    public static void Track ( string name, NSDictionary data); 
    ```

  * Here is the code sample for this method:

    ```java
    Media.Track (settings.Name, null); 
    ```
