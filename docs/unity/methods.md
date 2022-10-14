# ADBMobile.cs methods

## Configuration methods

* **CollectLifecycleData**

  Indicates to the SDK that lifecycle data should be collected for use across all solutions in the SDK. For more information, see [Lifecycle Metrics](/docs/ios/metrics.md).

  * Here is the syntax for this method:

    ```java
    public static void CollectLifecycleData();
    ```

  * Here is the code sample for this method:

    ```java
    ADBMobile.CollectLifecycleData();
    ```

* **EnableLocalNotifications (iOS only)**

  Enable local notifications in your app.

  * Here is the syntax for this method:

    ```java
    public static void EnableLocalNotifications();
    ```

  * Here is the code sample for this method:

    ```java
    ADBMobile.EnableLocalNotifications();
    ```

* **GetDebugLogging**

  Returns the current debug logging preference. The default value is `false`.

  * Here is the syntax for this method:

    ```java
    public static bool GetDebugLogging();
    ```

  * Here is the code sample for this method:

    ```java
    var debugEnabled = ADBMobile.GetDebugLogging();
    ```

* **GetLifetimeValue**

  Returns the lifetime value of the current user.

  * Here is the syntax for this method:

    ```java
    public static double GetLifetimeValue();
    ```

  * Here is the code sample for this method:

    ```java
    var lifetimeValuea = ADBMobile.GetLifetimeValue();
    ```

* **GetPrivacyStatus**

  Returns the enum representation of the privacy status for current user.
  * `MOBILE_PRIVACY_STATUS_OPT_IN`: Hits are sent immediately.
  * `MOBILE_PRIVACY_STATUS_OPT_OUT`: Hits are discarded.
  * `MOBILE_PRIVACY_STATUS_UNKNOWN`: If offline tracking is enabled, hits are saved until the privacy status changes to opt-in (then hits are sent) or opt-out (then hits are discarded).

    If offline tracking is not enabled, hits are discarded until the privacy status changes to opt in. The default value is set in the [ADBMobileConfig.json](/docs/ios/configuration/json-config/json-config.md) file.

  * Here is the syntax for this method:

    ```java
    public static ADBPrivacyStatus GetPrivacyStatus();
    ```

  * Here is the code sample for this method:

    ```java
    var privacyStatus = ADBMobile.GetPrivacyStatus();
    ```

* **GetUserIdentifier**

  Returns the custom user identifier if a custom identifier has been set. Returns null if a custom identifier is not set. The default value is `null`.

  * Here is the syntax for this method:

    ```java
    public static string GetUserIdentifier();
    ```

  * Here is the code sample for this method:

    ```java
    var userId = ADBMobile.GetUserIdentifier();
    ```

* **GetVersion**

  Gets the library version.

  * Here is the syntax for this method:

    ```java
    public static string GetVersion();
    ```

  * Here is the code sample for this method:

    ```java
    var version = ADBMobile.GetVersion();
    ```

* **KeepLifecycleSessionAlive (iOS only)**

  Indicates to the SDK that your next resume from background should not start a new session, regardless of the value of lifecycle session timeout in your config file.

  > **Tip:** This method is intended to be used for apps that register for notifications while in the background and should only be called from your code that runs while your app is in the background.

  * Here is the syntax for this method:

    ```java
    public static void KeepLifecycleSessionAlive();
    ```

  * Here is the code sample for this method:

    ```java
    ADBMobile.KeepLifecycleSessionAlive();
    ```

* **PauseCollectingLifecycleData (Android only)**

  Indicates to the SDK that your app is paused, so that lifecycle metrics are calculated correctly. For example, on pause collects a timestamp to determine previous session length. This also sets a flag so that lifecycle correctly knows that the app did not crash. For more information, see [Lifecycle Metrics](/docs/android/metrics.md).

  * Here is the syntax for this method:

    ```java
    public static void PauseCollectingLifecycleData();
    ```

  * Here is the code sample for this method:

    ```java
    ADBMobile.PauseCollectingLifecycleData();
    ```

* **SetContext (Android only)**

  Indicates to the SDK that it should set its application context from the UnityPlayer's current activity.

  * Here is the syntax for this method:

    ```java
    public static void SetContext();
    ```

  * Here is the code sample for this method:

    ```java
    ADBMobile.SetContext();
    ```

* **SetDebugLogging**

  Sets the debug logging preference to enabled.

  * Here is the syntax for this method:

    ```java
    public static void SetDebugLogging (bool enabled);
    ```

  * Here is the code sample for this method:

    ```java
    ADBMobile.SetDebugLogging(true);
    ```

* **SetPrivacyStatus**

  Sets the privacy status for the current user to status. Set to one of the following values:

  * `MOBILE_PRIVACY_STATUS_OPT_IN`: Hits are sent immediately.
  * `MOBILE_PRIVACY_STATUS_OPT_OUT`: Hits are discarded.
  * `MOBILE_PRIVACY_STATUS_UNKNOWN`: If offline tracking is enabled, hits are saved until the privacy status changes to opt-in (then hits are sent) or opt-out (then hits are discarded). If offline tracking is not enabled, hits are discarded until the privacy status changes to opt in.

  * Here is the syntax for this method:

    ```java
    public static void SetPrivacyStatus(ADBPrivacyStatusstatus);
    ```

  * Here is the code sample for this syntax:

    ```java
    ADBMobile.SetPrivacyStatus(ADBMobile.ADBPrivacyStatus.MOBILE_PRIVACY_STATUS_OPT_IN);
    ```

* **SetUserIdentifier**

  Sets the user identifier to userId.

  * Here is the syntax for this method:

    ```java
    public static void SetUserIdentifier(string userId);
    ```

  * Here is the code sample for this method:

    ```java
    ADBMobile.SetUserIdentifier("myCustomUserId");
    ```

## Analytics methods

* **GetTrackingIdentifier**

  Retrieves the analytics tracking identifier.

  * Here is the syntax for this method:

    ```java
    public static string GetTrackingIdentifier();
    ```

  * Here is the code sample for this method:

    ```java
    var trackingId = ADBMobile.GetTrackingIdentifier();
    ```

* **TrackState**

  Tracks an app state with optional context data. States are the views that are available in your app, such as "title screen", "level 1", "pause", and so on. These states are similar to pages on a website, and `TrackState` calls increment page views.

  If state is empty, it displays as *`app name app version (build)`* in reports. If you see this value in reports, make sure you are setting state in each `TrackState` call.

  > **Tip:** This is the only tracking call that increments page views.

  * Here is the syntax for this method:

    ```java
    public static void TrackState(string state, Dictionary<string, object> cdata);
    ```

  * Here is the code sample for this method:

    ```java
    var contextData = new Dictionary<string, object>);
    contextData.Add ("user", "jim");
    ADBMobile.TrackState("title screen", contextData);
    ```

* **TrackAction**

  Tracks an action in your app. Actions are the things that happen in your app that you want to measure, such as "deaths", "level gained", "feed subscriptions", and other metrics.

  > **Tip:** If you have code that might run while the app is in the background (for example, a background data retrieval), use `trackActionFromBackground` instead.

  * Here is the syntax for this method:

    ```java
    public static void TrackAction(string action, Dictionary<string, object> cdata);
    ```

  * Here is the code sample for this method:

    ```java
    ADBMobile.TrackAction("level gained", null);
    ```

* **TrackActionFromBackground (iOS only)**

  Tracks an action that occurred in the background. This suppresses lifecycle events from firing in certain scenarios.

  > **Tip:** This method should only be called in code that runs while your app is in the background.

  * Here is the syntax for this method:

    ```java
    public static void TrackActionFromBackground(string action, Dictionary<string,object> cdata);
    ```

  * Here is the code sample for this method:

    ```java
    ADBMobile.TrackActionFromBackground("majorLocationChange", null);
    ```

* **TrackLocation**

  Sends the current latitude and longitude coordinates. Also uses points of interest defined in the `ADBMobileConfig.json` file to determine if the location provided as a parameter is within any of your POI. If the current coordinates are within a defined POI, a context data variable is populated and sent with the TrackLocation call.

  * Here is the syntax for this method:

    ```java
    public static void TrackLocation(float latValue, float lonValue, Dictionary<string, object> cdata);
    ```

  * Here is the code sample for this method:

    ```java
    ADBMobile.TrackLocation(28.418649, -81.581324, null);
    ```

* **TrackBeacon**

  Tracks when a users enters proximity of a beacon.

  * Here is the syntax for this method:

    ```java
    public static void TrackBeacon(int major, int minor, string uuid, ADBBeaconProximity proximity, Dictionary<string, object> cdata);
    ```

* **TrackingClearCurrentBeacon**

  Clears beacons data after a user leaves the proximity of the beacon.

  * Here is the syntax for this method:

    ```java
    public static void TrackingClearCurrentBeacon();
    ```

  * Here is the code sample for this method:

    ```java
    ADBMobile.TrackingClearCurrentBeacon();
    ```

* **TrackLifetimeValueIncrease**

  Adds amount to the user's lifetime value.

  * Here is the syntax for this method:

    ```java
    public static void TrackLifetimeValueIncrease(double amount, Dictionary<string, object> cdata);
    ```

  * Here is the code sample for this method:

    ```java
    ADBMobile.TrackLifetimeValueIncrease(5, null);
    ```

* **TrackTimedActionStart**

  Start a timed action with name action. If you call this method for an action that has already started, the previous timed action is overwritten.

  > **Tip:** This call does not send a hit.

  * Here is the syntax for this method:

    ```java
    public static void TrackTimedActionStart(string action, Dictionary<string,object> cdata);
    ```

  * Here is the code sample for this method:

    ```java
    ADBMobile.TrackTimedActionStart("level2", null);
    ```

* **TrackTimedActionUpdate**

  Pass in data to update the context data associated with the given action. The data passed in is appended to the existing data for the given action, and overwrites the data if the same key is already defined for action.

  > **Tip:** This call does not send a hit.

  * Here is the syntax for this method:

    ```java
    public static void TrackTimedActionUpdate(string action, Dictionary<string, object> cdata);
    ```

  * Here is the code sample for this method:

    ```java
    var contextData = new Dictionary<string, object>;
    contextData.Add("checkpoint", "1:32");
       ADBMobile.TrackTimedActionUpdate("level2", contextData);
    ```

* **TrackTimedActionEnd**

  End a timed action.

  * Here is the syntax for this method:

    ```java
    public static void TrackTimedActionEnd(string action);
    ```

  * Here is the code sample for this method:

    ```java
    ADBMobile.TrackTimedActionEnd("level2");
    ```

* **TrackingTimedActionExists**

  Returns whether or not a timed action is in progress.

  * Here is the syntax for this method:

    ```java
    public static bool TrackingTimedActionExists(string action);
    ```

  * Here is the code sample for this method:

    ```java
     var level2InProgress = ADBMobile.TrackingTimedActionExists("level2");
    ```

* **TrackingSendQueuedHits**

  Forces the library to send all hits in the offline queue no matter how many are currently queued.

  * Here is the syntax for this method:

    ```java
    public static void TrackingSendQueuedHits();
    ```

  * Here is the code sample for this method:

    ```java
    ADBMobile.TrackingSendQueuedHits();
    ```

* **TrackingClearQueue**

  Clears all hits from the offline queue.

  * Here is the syntax for this method:

    ```java
    public static void TrackingClearQueue();
    ```

  * Here is the code sample for this method:

    ```java
    ADBMobile.TrackingClearQueue();
    ```

* **TrackingGetQueueSize**

  Retrieves the number of hits currently in the offline queue.

  * Here is the syntax for this method:

    ```java
    public static int TrackingGetQueueSize();
    ```

  * Here is the code sample for this method:

    ```java
    var queueSize = ADBMobile.TrackingGetQueueSize();
    ```

## Experience Cloud ID methods

* **GetMarketingCloudID**

  Retrieves the Experience Cloud ID from the ID service.

  * Here is the syntax for this method:

    ```java
    public static string GetMarketingCloudID();
    ```

  * Here is the code sample for this method:

    ```java
    var mcid = ADBMobile.GetMarketingCloudID();
    ```

* **VisitorSyncIdentifiers**

  With the Experience Cloud ID, you can set additional customer IDs to associate with each visitor. The Visitor API accepts multiple Customer IDs for the same visitor, along with a customer type identifier to separate the scope of the different customer IDs. This method corresponds to setCustomerIDs in the JavaScript library.

  * Here is the syntax for this method:

    ```java
    public static void VisitorSyncIdentifiers(Dictionary<string, object> identifiers);
    ```

  * Here is the code sample for this method:

    ```java
    var ids = new Dictionary<string, object> ();
    ids.Add ("player1", "jimbob");
    ADBMobile.VisitorSyncIdentifiers(ids);
    ```

## Acquisition methods

* **ProcessGooglePlayInstallReferrerUrl** *(Android only)*

  Pass the referrer URL returned from a call to the Google Play Install Referrer API to this method.

  * Here is the syntax for this method:

    ```java
    public static void ProcessGooglePlayInstallReferrerUrl(string referrerUrl);
    ```

  * Here is the code sample for this method:

    ```java
    // in actual implementation, the referrer url should be retrieved
    // from the Google Play Install Referrer API.
    var myReferrer = "utm_source=unityTestSource&utm_content=unityTestContent&utm_campaign=unityTestCampaign";
    ADBMobile.ProcessGooglePlayInstallReferrerUrl(myReferrer);
    ```
