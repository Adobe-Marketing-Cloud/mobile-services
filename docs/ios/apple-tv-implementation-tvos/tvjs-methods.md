# TVJS methods

Here is a list of TVJS methods that are provided by the tvOS library.

## Configuration methods

* **version**

  Returns the current version of the Adobe Mobile library.

  * Here is the syntax for this method:

    ```objective-c
    version()
    ```

  * Here is the code sample for this method:

    ```objective-c
    var sdkVersion = ADBMobile.version();
    ```

  * Returns: `String`

* **privacyStatus**

  Returns the NSUInteger representation of the privacy status enum for current user.

  Here are the options:

  * `ADBMobilePrivacyStatusOptIn`: Hits are sent immediately.
  * `ADBMobilePrivacyStatusOptOut`: Hits are discarded.
  * `ADBMobilePrivacyStatusUnknown`: If offline tracking is enabled, hits are saved until the privacy status changes to opt-in (hits are sent) or opt-out (hits are discarded).
  
    If offline tracking is not enabled, hits are discarded until the privacy status changes to opt-in. THe default value is set in the `ADBMobileConfig.json` file.

  * Here is the syntax for this method:

    ```objective-c
    privacyStatus()
    ```

  * Here is the code sample for this method:

    ```objective-c
    var privacyStatus = ADBMobile.privacyStatus();
    ```

  * Returns: `Number`

* **setPrivacyStatus**

  Sets the privacy status for the current user to one of the following values:

  * `ADBMobilePrivacyStatusOptIn`: Hits are sent immediately.
  * `ADBMobilePrivacyStatusOptOut`: Hits are discarded.
  * `ADBMobilePrivacyStatusUnknown`: If offline tracking is enabled, hits are saved until the privacy status changes to opt-in (hits are sent), or opt-out (hits are discarded).
  
  If offline tracking is not enabled, hits are discarded until the privacy status changes to opt-in.

  * Here is the syntax for this method:

    ```objective-c
    setPrivacyStatus(privacyStatus)
    ```

  * Here is the code sample for this method:

    ```objective-c
    ADBMobile.setPrivacyStatus(ADBMobilePrivacyStatusOptIn);
    ```

* **lifetimeValue**

  Returns the lifetime value of the current user. The default value is `0`.

  * Here is the syntax for this method:

    ```objective-c
    lifetimeValue()
    ```

  * Here is the code sample for this method:

    ```objective-c
    var ltv = ADBMobile.lifetimeValue();
    ```

  * Returns: `Number`

* **userIdentifier**

  Returns the user identifier if a custom identifier has been set. Returns nil if a custom identifier is not set. The default is `nil`.

  > **Important:** If your app upgrades from the Experience Cloud 3.x to 4.x SDK, the previous custom or automatically generated visitor ID is retrieved and stored as the custom user identifier. This preserves visitor data between SDK upgrades. For new installations on the 4.x SDK, user identifier is nil until set.

  * Here is the syntax for this method:

    ```objective-c
    userIdentifier()
    ```

  * Here is the code sample for this method:

    ```objective-c
    var uid = ADBMobile.userIdentifier();
    ```

  * Returns: `String`

* **setUserIdentifier**

  Sets the user identifier.

  * Here is the syntax for this method:

    ```objective-c
    setUserIdentifier(userId)
    ```

  * Here is the code sample for this method:

    ```objective-c
    ADBMobile.setUserIdentifier(‘myUserId’);
    ```

  * Returns: N/A

  * Parameter:  `userID`

    * Type: String
    * New identifier for this user.

* **setAdvertisingIdentifier**

  Sets the IDFA in the SDK, and if it has been set in the SDK, the IDFA is sent in lifecycle. The IDFA can also be accessed in Signals (Postbacks).

  > **Important:** Retrieve the IDFA from Apple APIs only if you are using an ad service. If you retrieve IDFA, and are not using it properly, your app might be rejected.

  * Here is the syntax for this method:

    ```objective-c
    setAdvertisingIdentifier(idfa)
    ```

  * Here is the code sample for this method:

    ```objective-c
    ADBMobile.setAdvertisingIdentifier(‘myIdfa’);
    ```

  * Returns: N/A
  * Parameter: `idfa`
    * Type: `String`
    * IDFA retrieved from Apple API.

* **setDebugLogging**

  Sets the debug logging preference.

  * Here is the syntax for this method:

    ```objective-c
    setDebugLogging(logging)
    ```

  * Here is the code sample for this method:

    ```objective-c
    `ADBMobile.setDebugLogging(true);
    ```

  * Returns: N/A
  * Parameters: `logging`
    * Type: `Bool`
    * Value indicating whether the Adobe SDK should log to the debug console.


## Analytics methods

* **trackStateData**

  Tracks an app state with optional context data. States are the views that are available in your app, such as home dashboard , app settings , cart, and so on. These states are similar to pages on a website, and trackState calls increment page views.

  If the state is empty, it displays as app name app version (build) in reports. If you see this value in reports, ensure you set the state in each trackState call.

  > **Tip:** This is the only tracking call that increments page views.

  * Here is the syntax for this method:

    ```objective-c
    trackStateData(stateName [, contextData])
    ```

    * Returns: N/A
    * Parameter: `stateName`
      * Type: `String`
      * Page state name

    * Parameter: `contextData`
      * Type: Object
      * Additional context data for this hit.


  * Here is the code sample for this method:

    ```objective-c
    ADBMobile.trackStateData(‘homepage’, {‘userid’:12345});
    ```

* **trackActionData**

  Tracks an action in your app. Actions are the things that happen in your app that you want to measure, such as logons, banner taps, feed subscriptions, and other metrics.

  * Here is the syntax for this method:

    ```objective-c
    trackActionData(actionName [, contextData])
    ```

    * Returns: N/A
    * Parameters: `actionName`
      * Type: String
      * Name of the action being tracked.

    * Parameter: `contextData`
      * Type: Object
      * Additional context data for this hit.

  * Here is the code sample for this method:

    ```objective-c
    ADBMobile.trackActionData(‘likeClicked’, {‘imageName’:’funnyKitty’});
    ```

* **trackLocationWithLatLonData**

  Sends the current latitude and longitude coordinates.

  Also uses points of interest (POI) that are defined in the `ADBMobileConfig.json` file to determine whether the location that you entered as a parameter is in any of your POIs. If the current coordinates are in a defined POI, a context data variable is populated and sent with the `trackLocation` call.

  * Here is the syntax for this method:

    ```objective-c
    trackLocationWithLatLonData(lat, lon [, contextData]);
    ```

    * Returns: N/A
    * Parameter: `lat`
      * Type: Number
      * Latitude of the location.

    * Parameter: `lon`
      * Type: Number
      * Longitude of the location.

    * Parameter: `contextData`
      * Type: Object
      * Additional context data for this hit.

  * Here is the code sample for this method:

    ```objective-c
    ADBMobile.trackLocationWithLatLonData(43.36, -116.12, null);
    ```

* **trackLifetimeValueIncreaseJsData**

  Adds an amount to the user's lifetime value.

  * Here is the syntax for this method:

    ```objective-c
    trackLifetimeValueIncreaseJsData(increaseAmount)
    ```

    * Returns: N/A
    * Parameter: `increaseAmount`
      * Type: Number
      * Amount to add to the user's current lifetime value.

  * Here is the code sample for this method:

    ```objective-c
    ADBMobile.trackLifetimeValueIncreaseJsData(5);
    ```

* **trackTimedActionStartData**

  Start a timed action with name action. If you call this method for an action that has already started, the previous timed action is overwritten.

  > **Tip:** This call does not send a hit.

  * Here is the syntax for this method:

    ```objective-c
    trackTimedActionStartData(name [, contextData])
    ```

    * Returns: N/A
    * Parameter: `name`
      * Type: String
      * Name of the timed action being started.
    * Parameter: `contextData`
      * Type: Object
      * Additional context data for this hit.

  * Here is the code sample for this method:

    ```objective-c
    ADBMobile.trackTimedActionStartData(‘level1’, {‘userId’:42423});
    ```

* **trackTimedActionUpdateData**

  Pass in data to update the context data that is associated with the given action.

  The data passed in is appended to the existing data for the given action, and if the same key is already defined for action, the data is overwritten.

  > **Tip:** This call does not send a hit.

  * Here is the syntax for this method:

    ```objective-c
    trackTimedActionUpdateData(name [, contextData])
    ```

    * Returns: N/A
    * Parameter: `name`
      * Type: String
      * Name of the timed action being updated.

    * Parameter: `contextData`
      * Type: Object
      * Additional context data for this hit.

  * Here is the code sample for this method:

    ```objective-c
    ADBMobile.trackTimedActionUpdateData(‘level1’);
    ```

* **trackTimedActionEndJsLogic**

  End a timed action.

  If you provide a callback function, you can access the final time values. If no callback is provided, or if the callback returns true, the Adobe SDK automatically sends a hit. When a false is returned from the callback, the timed action hit is suppressed.

  * Here is the syntax for this method:

    ```objective-c
    trackTimedActionEndJsLogic(name [, callback])
    ```

    * Returns: N/A  
    * Parameters: `name`
      * Type: String
      * Name of the timed action being ended

    * Parameter: `callback`
      * Type: `function(inAppDuration, totalDuration, data)`
      * Callback method that will have `inAppDuration` (number), `totalDuration` (number), and `data` (context data object) in its parameters.

        You can suppress the final hit from being sent by the SDK by returning `false` in your callback function.

    * Here is the code sample for this method: 

      ```objective-c
      ADBMobile.trackTimedActionEndJsLogic(‘level1’, 
      function(inAppDuration, totalDuration, data) {
          // do something with final values
          return true;
          });
      ```

* **trackingTimedActionExistsJs**

  Returns whether a timed action is in progress.

  * Here is the syntax for this method:

    ```objective-c
    trackingTimedActionExistsJs(name)
    ```

    * Returns: Bool
    * Parameter: `name`
      * Type: `String`
      * Name of the timed action for which you need to check existence.

  * Here is the code sample for this method:
  

    ```objective-c
    var actionExists = ADBMobile.trackTimedActionExistsJs(‘level1’);
    ```

* **trackingIdentifier**

  Returns the automatically generated visitor identifier.

  This is an app-specific unique visitor ID that is generated by Adobe’s servers. If Adobe's servers cannot be reached at the time of generation, the ID is generated by using Apple's CFUUID. The value is generated at the initial launch and is stored and used from that point. This ID is preserved between app upgrades, is saved and restored during the standard application back up process, and is removed when the app is uninstalled.

  > **Tip:** If your app upgrades from the Experience Cloud 3.x to 4.x SDK, the previous custom or automatically generated visitor ID is retrieved and stored as the custom user identifier. This preserves visitor data between SDK upgrades. For new installations on the 4.x SDK, the user identifier is `nil`, and the tracking identifier is used. For more information, see the userIdentifier row below.

  * Here is the syntax for this method:

    ```objective-c
    trackingIdentifier()
    ```

    * Returns: `String`
    * Parameters: None

  * Here is the code sample for this method:

    ```objective-c
    var trackingId = ADBMobile.trackingIdentifier();
    ```

* **trackingSendQueuedHits**

  Forces the library to send all hits in the offline queue no matter how many are currently queued.

  * Here is the syntax for this method:

    ```objective-c
    trackingSendQueuedHits()
    ```

    * Returns: N/A
    * Parameters: None

  * Here is the code sample for this method:
  

    ```objective-c
    ADBMobile.trackingSendQueuedHits();
    ```

* **trackingClearQueue**

  Clears all hits from the offline queue.

  * Here is the syntax for this method:

    ```objective-c
    trackingClearQueue()
    ```

    * Returns: N/A
    * Parameters: None

  * Here is the code sample for this method:

    ```objective-c
    ADBMobile.trackingClearQueue();
    ```

* **trackingGetQueueSize**

  Retrieves the number of hits currently in the offline queue.

  * Here is the syntax for this method:

    ```objective-c
    trackingGetQueueSize()
    ```

    * Returns: Number
    * Parameters: None

  * Here is the code sample for this method:

    ```objective-c
    var queueSize = ADBMobile.trackingGetQueueSize();
    ```

## Audience Manager methods

* **audienceVisitorProfile**

  Returns the visitor profile that was most recently obtained.

  Returns null if no signal has been submitted yet. The visitor profile is saved in `NSUserDefaults` for easy access across multiple launches of your app.

  * Here is the syntax for this method:

    ```objective-c
    audienceVisitorProfile()
    ```

    * Returns: Object
    * Parameters: None

  * Here is the code sample for this method:

    ```objective-c
    var profile = ADBMobile.audienceVisitorProfile();
    ```

* **audienceDpid**

  Returns the current DPID.

  * Here is the syntax for this method:

    ```objective-c
    audienceDpid()
    ```

    * Returns: String
    * Parameters: None

  * Here is the code sample for this method:

    ```objective-c
    var dpid = ADBMobile.audienceDpid();
    ```

* **audienceDpuuid**

  Returns the current DPUUID.

  * Here is the syntax for this method:
  
    ```objective-c
    audienceDpuuid()
    ```

    * Returns: `String`
    * Parameters: None

  * Here is the code sample for this method:
  
    ```objective-c
    var dpuuid = ADBMobile.audienceDpuuid();
    ```

* **audienceSetDpidDpuuid**

  Sets the dpid and dpuuid, and if they are set, they are sent with each signal.

  * Here is the syntax for this method:

    ```objective-c
    audienceSetDpidDpuuid(dpid, dpuuid)
    ```

    * Returns: N/A
    * Parameter: `dpid`
      * Type: `String`
      * Audience Manager data provider ID.
    * Parameter: `dpuuid` 
      * Type: `String`
      * Identifier for the user and data provider combination.

  * Here is the code sample for this method:

    ```objective-c
    ADBMobile.audienceSetDpidDpuuid(‘myDpid’, ‘userDpuuid’);
    ```

* **audienceSignalWithDataJsCallback**

  Sends Audience Manager a signal with traits and gets the matching segments that are returned in a callback function.

  * Here is the syntax for this method:

    ```objective-c
    audienceSignalWithDataJsCallback(traits [, callback])
    ```

    * Parameter: `traits` 
      * Type: Object
      * Traits dictionary for this user.

    * Parameter: `callback` 
      * Type: function(profile)
      * The profile returned from Audience Manager in the parameter for the callback function.

  * Here is the code sample for this method: 

    ```objective-c
    ADBMobile.audienceSignalWithDataJsCallback({‘trait’:’something’}, 
    function(profile) {
        //do something with the user’s segments found in profile
         });
    ```

* **audienceReset**

  Resets the Audience Manager UUID and purges the current visitor profile.

  * Here is the code sample for this method:

    ```objective-c
    audienceReset()
    ```

    * Returns: N/A
    * Parameter: None

  * Here is the code sample for this method:
  
    ```objective-c
    ADBMobile.audienceReset();
    ```

## ID Service methods

* **visitorMarketingCloudID**

  Retrieves the Experience Cloud ID from the ID service.

  * Here is the syntax for this method:

    ```objective-c
    visitorMarketingCloudID()
    ```

    * Returns: String
    * Parameters: None

  * Here is the code sample for this method:
  
    ```objective-c
    var mcid = ADBMobile.visitorMarketingCloudID();
    ```

* **visitorSyncIdentifiers**

  In addition to the Experience Cloud ID, you can set additional customer IDs to be associated with each visitor. The Visitor API accepts multiple Customer IDs for the same visitor, with a customer type identifier to separate the scope of the different customer IDs. This method corresponds to setCustomerIDs in the JavaScript library.

  * Here is the syntax for this method:
  
    ```objective-c
    visitorSyncIdentifiers(identifiers)
    ```

    * Returns: N/A
    * Parameter: `identifiers`

      * Type: `Object`
      * Identifiers to sync to the ID service for this user.

  * Here is the code sample for this method:
  
    ```objective-c
    ADBMobile.visitorSyncIdentifiers({‘idType’:’idValue’});
    ```

* **visitorSyncIdentifiersAuthenticationState**

  Synchronizes the provided identifiers to the ID service.

  * Here is the syntax for this method:

    ```objective-c
    visitorSyncIdentifiersAuthenticationState(identifiers, authState)
    ```

    * Returns: N/A
    * Parameters: `identifiers`
      * Type: `Object`
      * Identifiers to sync to the ID service for this user.

    * Parameter: `authState`
      * Type: ADBMobileVisitorAuthenticationState
      * Authentication state of the user, and possible values include:
        * `ADBMobileVisitorAuthenticationStateUnknown`
        * `ADBMobileVisitorAuthenticationStateAuthenticated`
        * `ADBMobileVisitorAuthenticationStateLoggedOut`

  * Here is the code sample for this method:

    ```objective-c
    ADBMobile.visitorSyncIdentifiersAuthenticationState({'myIdType':'valueForUser'}, ADBMobileVisitorAuthenticationStateLoggedOut)
    ```

* **visitorSyncIdentifierWithTypeIdentifierAuthenticationState**

  Synchronizes the provided identifier type and value to the ID service.

  * Here is the syntax for this method:

    ```objective-c
    visitorSyncIdentifierWithTypeIdentifierAuthenticationState(idType, identifier, authState)
    ```

    * Return: N/A
    * Parameter: `idType`
      * Type: `String`
      * Type of identifier you are syncing.
    * Parameter: `identifier`
      * Type: `String`
      * Value of the identifier you are syncing.
    * Parameter: `authState`
      * Type: ADBMobileVisitorAuthenticationState
        Authentication state of the user. Possible values include:
        * `ADBMobileVisitorAuthenticationStateUnknown`
        * `ADBMobileVisitorAuthenticationStateAuthenticated`
        * `ADBMobileVisitorAuthenticationStateLoggedOut`

  * Here is the code sample for this method:
  
    ```objective-c
    ADBMobile.visitorSyncIdentifierWithTypeIdentifierAuthenticationState('myIdType', 'valueForUser', 
    ADBMobileVisitorAuthenticationStateAuthenticated);
    ```

* **visitorGetIDsJs**

  Retrieves an array of read-only ADBVisitorID objects. The following code sample is an example of a VisitorID object:

    ```js
    {
        idType: "abc",
        authenticationState: 1, 
        identifier: "123"
    }
    ```

  * Here is the syntax for this method: 
  
    ```objective-c
    visitorGetIDsJs()
    ```

    * Returns: `Array [Object]`

    * Parameters: None

  * Here is the code sample for this method:
  
    ```objective-c
    var myVisitorIds = ADBMobile.visitorGetIDsJs();
    ```

## Target methods

* **targetThirdPartyID**

  Returns the third-party ID.

  * Here is the syntax for this method:

    ```objective-c
    targetThirdPartyID()
    ```

    * Returns: `String`
    * Parameters: None

  * Here is the code sample for this method:

    ```objective-c
    var thirdPartyID = ADBMobile.targetThirdPartyID();
    ```

* **targetSetThirdPartyID**

  Sets the third-party ID.

  * Here is the syntax for this method:

    ```objective-c
    targetSetThirdPartyID(thirdPartyID)
    ```

    * Returns: N/A
    * Parameters: `thirdPartyID`
      * Type: `String`
      * Third-party ID to use for target requests.

  * Here is the code sample for this method:

  ```objective-c
  ADBMobile.targetSetThirdPartyID(‘thirdPartyID’);
  ```

* **targetPcID**

  Returns the PcID.

  * Here is the syntax for this method:

    ```objective-c
    targetPcID()
    ```

    * Returns: `String`
    * Parameters: None

  * Here is the code sample for this method:

    ```objective-c
    var pcID = ADBMobile.targetPcID();
    ```

* **targetSessionID**

  Returns the session ID.

  * Here is the syntax for this method:
  
    ```objective-c
    targetSessionID()
    ```

    * Returns: `String`
    * Parameters: None

  * Here is the code sample for this method:
  
    ```objective-c
    var sessionID = ADBMobile.targetSessionID();
    ```
