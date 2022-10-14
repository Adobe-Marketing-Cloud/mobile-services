# Analytics methods

Information to help you use the Universal Windows Platform SDK with Adobe Analytics.

The SDK currently has support for multiple Adobe Experience Cloud Solutions, including Analytics, Target, and Audience Manager. Methods are prefixed according to the solution. Analytics methods are prefixed with "Analytics."

Each of these methods is used to send data into your Adobe Analytics report suite.

> **Tip:** When you consume `winmd` methods from winJS (JavaScript), all methods automatically have their first letter lowercased.

* **TrackState (winJS: trackState)**

  Tracks an app state with optional context data. States are the views that are available in your app, such as "home dashboard", "app settings", "cart", and so on. These states are similar to pages on a website, and `TrackState` calls increment page views. 
  If `state` is empty, it displays as "app name app version (build)" in reports. If you see this value in reports, make sure you are setting `state` in each `TrackState` call. 
  
  > **Tip:** This is the only tracking call that increments page views. 

  * Here is the syntax for this method:

    ```csharp
    static void TrackState(Platform::String ^state, Windows::Foundation::Collections::IMap<Platform::String^, Platform::Object> ^contextData); 
    ```

  * Here is the code sample for this method:

    ```js
    var ADB = ADBMobile
    ADB.Analytics.trackState("loginScreen", null);
    ```

* **TrackAction (winJS: trackAction)**

  Tracks an action in your app. Actions are the things that happen in your app that you want to measure, such as "logons", "banner taps", "feed subscriptions", and other metrics.

  * Here is the syntax for this method:

    ```csharp
    static void TrackAction(Platform::String ^action, Windows::Foundation::Collections::IMap<Platform::String^, Platform::Object> ^contextData); 
    ```

  * Here is the code sample for this method:

    ```js
    varADB=ADBMobile; 
    ADB.Analytics.trackAction("ButtonClick",null); 
    ```

* **GetTrackingIdentifierAsync (winJS: getTrackingIdentifierAsync)**

  Returns the automatically generated visitor ID for Analytics. This is an app-specific unique visitor ID that is generated on initial launch and then stored and used from that point forward. This ID is preserved between app upgrades, and is removed on uninstall. 

  * Here is the syntax for this method:
  
    ```csharp
    static Windows::Foundation::IAsyncOperation<Platform::String> ^GetTrackingIdentifierAsync(); 
    ```

  * Here is the code sample for this method:

    ```js
    vartrackingIdentifier; 
    ADBMobile.Analytics.getTrackingIdentifierAsync().then(function(trackingid){
    trackingIdentifier=trackingid;
    });
    ```

* **TrackLocation (winJS: trackLocation)**

  Sends the current x y coordinates. Also uses points of interest defined in the `ADBMobileConfig.json` file to determine if the location provided as a parameter is within any of your POI. If the current coordinates are within a defined POI, a context data variable is populated and sent with the `trackLocation` call.

  * Here is the syntax for this method:

    ```csharp
    static void TrackLocation(double lat, double lon, double accuracy, Windows::Foundation::Collections::IMap<Platform::String^, Platform::Object> ^contextData);
    ```

  * Here is the code sample for this method:

    ```js
    varADB=ADBMobile; 
    ADB.Analytics.trackLocation(47.60621,-122.33207,null);
    ```

* **TrackLifetime​ValueIncrease (winJS: trackLifetime​ValueIncrease)**

  Adds `amount` to the user's lifetime value.

  * Here is the syntax for this method:

    ```csharp
    static void TrackLifetimeValueIncrease(float amount, Windows::Foundation::Collections::IMap<Platform::String^, Platform::Object> ^contextData); 
    ```

  * Here is the code sample for this method:

    ```js
    varADB=ADBMobile;
    ADB.Analytics.trackLifetimeValueIncrease(10,null);
    ```

* **TrackTimed​ActionStart (winJS: trackTimed​ActionStart)**

  Start a timed action with name `action`. If you call this method for an action that has already started, the previous timed action is overwritten. 
  
  > **Tip:** This call does not send a hit.

  * Here is the syntax for this method:

    ```csharp
    static void TrackTimedActionStart(Platform::String ^action, Windows::Foundation::Collections::IMap<Platform::String^, Platform::Object^> ^contextData); 
    ```

  * Here is the code sample for this method:

    ```js
    varADB=ADBMobile;
    ADB.Analytics.trackTimedActionStart("cartToCheckout",null); 
    ```

* **TrackTimed​ActionUpdate (winJS: trackTimed​ActionUpdate)**

  Pass in `contextData` to update the context data associated with the given `action`. The `data` passed in is appended to the existing data for the given action, and overwrites the data if the same key is already defined for `action`. 
  
  > **Tip:** This call does not send a hit. 

  * Here is the syntax for this method:

    ```csharp
    static void TrackTimedActionUpdate(Platform::String ^action, Windows::Foundation::Collections::IMap<Platform::String^, Platform::Object> ^contextData); 
    ```

  * Here is the code sample for this method:

    ```js
    varADB = ADBMobile;
    varcontextData = newWindows.Foundation.Collections.PropertySet();
    contextData["quantity"]=3; 
    ADB.Analytics.trackTimedActionUpdate("cartToCheckout",contextData);
    ```

* **TrackTimedActionExistsAsync (winJS: trackTimedActionExistsAsync)**

  Returns true if the given timed action exists and false if it does not exist. 

  * Here is the syntax for this method:

    ```csharp
    static Windows::Foundation::IAsyncOperation<bool> ^TrackTimedActionExistsAsync(Platform::String ^action); 
    ```

  * Here is the code sample for this method:

    ```js
    ADBMobile.Analytics.trackTimedActionExistsAsync("signUp").then(function(exists){ 
        actionExists = exists; 
    });
    ```

* **TrackTimed​ActionEnd (winJS: trackTimed​ActionEnd)**

  End a timed action. 

  * Here is the syntax for this method:

    ```csharp
    static void TrackTimedActionEnd(Platform::String ^action);
    ```

  * Here is the code sample for this method:

    ```js
    varADB = ADBMobile; 
    ADB.Analytics.trackTimedActionEnd("cartToCheckout"); 
    ```

* **ClearTrackingQueue (winJS: clearTrackingQueue)**

  Clears all stored hits from the Analytics tracking queue.

  * Here is the syntax for this method:

    ```csharp
    static void ClearTrackingQueue();
    ```

  * Here is the code sample for this method:

    ```js
    ADBMobile.Analytics.clearTrackingQueue();
    ```

* **GetQueueSizeAsync (winJS: getQueueSizeAsync)**

  Returns the number of hits currently stored in the Analytics queue. 

  * Here is the syntax for this method:

    ```csharp
    static Windows::Foundation::IAsyncOperation<int> ^GetQueueSizeAsync();
    ```

  * Here is the code sample for this method:

    ```js
    varqueueSize;
    ADBMobile.Analytics.getQueueSizeAsync().then(function(size){ 
        queueSize=size;
    });
    ```
