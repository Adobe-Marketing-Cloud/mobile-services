# PhoneGap plug-in methods

You can use Android PhoneGap Plug-in methods to complete a variety of tasks.

In `html` files where you want to use tracking, add the following to the `<head>` tag:

```js
<script type="text/javascript" charset="utf-8" src="ADB_Helper.js"></script>
```

## Configuration methods

* **getPrivacyStatus**

  Returns the privacy status for current user. 
  
  Here are the available statuses: 
  
  * `ADB.optedIn`: The hits are sent immediately. 
  * `ADB.optedOut`: The hits are discarded. 
  * `ADB.optUnknown`: If your report suite **is** timestamp-enabled, hits are saved until the privacy status changes to opt-in (hits are sent) or opt-out (hits are discarded). If your report suite **is not** timestamp-enabled, hits are discarded until the privacy status changes to opt in. 

    The default value is set in the `ADBMobileConfig.json` file. 

  * Here is the code sample for this method:

    ```java
    getPrivacyStatus(function (value) { myTempVal = value; }, function () {myTempVal = null;}); 
    ```

* **setPrivacyStatus**

  Sets the privacy status for the current user to `status`.

  You can set one of the following statuses: 
  
  * `ADB.optedIn`: The hits are sent immediately.  
  * `ADB.optedOut`: The hits are discarded. 
  * `ADB.optUnknown`: If your report suite **is** timestamp-enabled, hits are saved until the privacy status changes to opt-in (hits are sent) or opt-out (hits are discarded). If your report suite **is not** timestamp-enabled, hits are discarded until the privacy status changes to opt in. 

  * Here is the code sample for this method:

    ```java
    ADB.setPrivacyStatus('ADB.optedIn');
    ```

* **getLifetimeValue**

  Returns the lifetime value of the current user. The default value is 0.

  * Here is the code sample for this method:

    ```java
    ADB.getLifetimeValue(function (value) { myTempVal = value }, function () { myTempVal = null; }); 
    ```

* **setDebugLogging**

  Enables (`true`) or disables (`false`) viewing debug information. By default, this variable is `false`.

  * Here is the code sample for this method:

    ```java
    ADB.setDebugLogging(true);
    ```

* **getVersion**

  Gets the library version. 

  * Here is the code sample for this method:

    ```java
    ADB.getVersion(function (value) { versionNum = value }, function () { versionNum = 1.0;});
    ```

* **trackingIdentifier**

  Returns the automatically generated visitor identifier.
  
  This is an app-specific, unique visitor ID that is generated when the app is initially launched and is stored and used from that point. This ID is preserved between app upgrades and is removed when the app is uninstalled.
  
  > **Tip:** If your app upgrades from the Experience Cloud 3.x to 4.x SDK, the previous visitor ID (custom or automatically generated) is retrieved and stored as the custom user identifier. For more information, see `getUserIdentifier` below. This ID preserves visitor data between SDK upgrades. 
  
  For new installations on the 4.x SDK, the user identifier is `null` and tracking identifier is used. 

  * Here is the code sample for this method:

    ```java
    ADB.trackingIdentifier(function (value) { myTempVal = value; }, function () { myTempVal = null; }); 
    ```

* **getUserIdentifier**

  If a customer user identifier has been set, returns this identifier; if the identifier has not been set, returns `null`. The default value is `null`.

  * Here is the code sample for this method:

    ```java
    getUserIdentifier(function(value) { myTempVal = value; }, function () { myTempVal = null; });
    ```

* **setUserIdentifier**

  Sets the user identifier to `identifier`. 

  * Here is the code sample for this method:

    ```java
    ADB.setUserIdentifier('testUser');
    ```

* **setPushIdentifier**

  Sets the device token for push notifications.

    ```java
    getUserIdentifier(function (value) { myTempVal = value; }, function () { myTempVal = null; });
    ``` 

  * Here is the syntax for this method:

    ```java
    ADB.setPushIdentifier(pushIdentifier, success, fail);
    ```

  * Here is the code sample for this method:

    ```java
    ADB.setPushIdentifier('test_push_identifier',function (value) { alert('success'); },function (value) { alert('fail'); }); 
    ```

* **keepLifecycleSessionAlive**

  Sets the preference of lifecycle session keep alive.

  > **Important:** Calling `keepLifecycleSessionAlive` prevents your app from launching a new session the next time it is resumed from background. You should only use this method if your app registers for notifications in the background. 

  * Here is the code sample for this method:

    ```js
    ADB.keepLifecycleSessionAlive(); 
    ```

* **trackingSendQueuedHits**

  Forces the library to send all queued hits regardless of current batch options. 

  * Here is the code sample for this method:

    ```js
    ADB.trackingSendQueuedHits();
    ```

* **trackingGetQueueSize** 

  Gets or sets the number of stored tracking calls in the offline queue. 

  * Here is the code sample for this method:

    ```js
    ADB.trackingGetQueueSize(function (value) { myTempVal = value;}, function () { myTempVal = null;}); 
    ```

* **trackingClearQueue**

  Removes all stored tracking calls from the offline queue.

  > **Warning:** Be careful when clearing the queue manually, because it cannot be reversed. 

  * Here is the code sample for this method:

    ```js
    ADB.trackingClearQueue(function (value) { myTempVal = value; }, function () { myTempVal = null; }); 
    ```

## PII methods

* **collectPII**

  Submits a PII collection request.

  * Here is the syntax for this method:

  ```javascript
  ADB.collectPII(piiData,success, fail);
  ```

  * Here is the code sample for this method:

    ```javascript
    ADB.collectPII({'k1':'v1','k2':'v2','k3':'v3'}, function (value) { alert('success') },function (value) { alert('fail') ;});
    ```

## Tracking methods

* **trackAdobeDeepLink**

  Tracks an Adobe Deep Link click-through.

  > **Tip:** If the Lifecycle call is a launch event, the Adobe Link data will be appended, otherwise an extra call will be sent. 

  * Here is the syntax for this method:

    ```js
    ADB.trackAdobeDeepLink(deeplinkURL, success, fail); 
    ```

  * Here is the code sample for this method:

    ```js
    ADB.trackAdobeDeepLink('xyz-deeplink-url',function (value) { alert('success'); },function (value) { alert('fail') }); 
    ```

* **trackState**

  Tracks an app state with optional context data. States are the views that are available in your app, such as such as `home dashboard`, `app settings`, `cart`, and so on. These states are similar to pages on a website, and `trackState` calls increment page views. 
  
  `cData`: JSON object with key-value pairs to send in context data. 

  * Here is the syntax for this method:

    ```js
    ADB.trackState(string stateName[,JSON cData]);
    ```

  * Here are code samples for this method:

    ```js
      ADB.trackState("login&amp;nbsp;page"); 
    ```

    ```js
      ADB.trackState("login page", {"user":"john","remember":"true"});
    ```

* **trackAction**

  Tracks an action in your app. Actions include `logins`, `banner taps`, `feed subscriptions`, and other metrics that occur in your app and that you want to measure. 

  * Here is the syntax for this method:

    ```js
    ADB.trackAction(string action[,JSON cData]); 
    ```

  * Here are the code samples for this method:

    ```js
      ADB.trackAction("login");
    ```

    ```js
      ADB.trackAction("login", {"user":"john","remember":"true"}); 
    ```

* **trackLocation**

  Sends the current x y coordinates. Also uses points of interest defined in the `ADBMobileConfig.json` file to determine if the location provided as a parameter is within any of your POI. If the current coordinates are within a defined POI, a context data variable is populated and sent with the `trackLocation` call.

  * Here is the syntax for this method:

    ```java
    ADB.trackLocation(x, y[,JSON cData]); 
    ```

  * Here is the code sample for this method:

    ```java
    ADB.trackLocation('40.431596', '-111.893713'); 
    ```

* **trackLifetime​ValueIncrease**

  Adds `amount` to the user's lifetime value. 

  * Here is the syntax for this method:

    ```java
    ADB.trackLifetimeValueIncrease(amount[,JSON cData]); 
    ```

  * Here is the code sample for this method:

    ```java
    ADB.trackLifetimeValueIncrease('10.01'); 
    ```

* **trackTimed​ActionStart**

  Start a timed action with the name `action`. 
  
  If you call this method for an action that has already started, the previous timed action is overwritten. 
  
  > **Tip:** This call does not send a hit. 

  * Here is the syntax for this method:

    ```java
    ADB.trackTimedActionStart(action[,JSON cData]);
    ```

  * Here is the code sample for this method:

    ```java
    ADB.trackTimedActionStart("cartToCheckout"); 
    ```

* **trackTimed​ActionUpdate**

  Pass in `cData` to update the context data that is associated with the `action`>. 
  
  The `cData` that is passed is appended to the existing data for the action and, if the same key is already defined for `action`, overwrites the data.

  * Here is the syntax for this method:

    ```java
    ADB.trackTimedActionUpdate(String action[,JSON cData]);
    ```

  * Here is the code sample for this method:

    ```java
    ADB.trackTimedActionUpdate("cartToCheckout",{'SampleContextDataKey3':'SampleContextDataVal3','SampleContextDataKey4':'SampleContextDataVal4'});
    ```

* **trackTimed​ActionEnd**

  End a timed action. 

  * Here is the code sample for this method:

    ```java
    ADB.trackTimedActionEnd("cartToCheckout"); 
    ```

* **trackingTimedActionExists**

  Returns whether a timed action is in progress. 

  * Here is the syntax for this method:

    ```java
    ADB.trackingTimedActionExists(function (value) { myTempVal = value }, function () { myTempVal = null; }); 
    ```

## Beacon methods

* **trackBeacon**

  Tracks when a user enters the proximity of a beacon. 

  * Here is the syntax for this method:

    ```js
    ADB.trackBeacon(uuid, major, minor, proximity, cData) 
    ```

  * Here is the code sample for this method:

    ```js
    ADB.trackBeacon('2F234454-CF6D-4A0F-ADF2-F4911BA9FFA6', 1, 2, 
    ADB.beaconUnknown, {'hp':'hp_val','hp.company':'adobe'}
    ```

* **clearCurrentBeacon**

  Clears the beacon data after a user leaves the proximity of the beacon. 

  * Here is the syntax for this method:

    ```js
    ADB.clearCurrentBeacon(success, fail)
    ```

  * Here is the code sample for this method:

    ```js
    ADB.clearCurrentBeacon(); 
    ```

## Target methods

* **targetLoadRequest**

  Sends a request to your configured `Target` server and returns the string value of the offer. 

  * Here is the syntax for this method:

    ```java
    ADB.targetLoadRequest(success, fail, name, defaultContent, parameters);
    ```

  * Here is the code sample for this method:

    ```java
    ADB.targetLoadRequest(function&nbsp;(value)
    {myTempVal = value }, function () { myTempVal = null;},'bannerOffer', 'none', {'hp':'hp_val_new','hp.company':'adobe', 'hp.val2':'hp_val2'}); 
    ```

* **targetLoadOrderConfirmRequest**
  
  Sends a request to your configured `Target` server.

  * Here is the syntax for this method:

    ```java
    ADB.targetLoadOrderConfirmRequest(success, fail name orderId, orderTotal, productPurchaseId, parameters); 
    ```

  * Here is the syntax for this method:

    ```java
    ADB.targetLoadRequest(function (value) { myTempVal = value }
    , function ()
    { myTempVal = null; } 
    , 'name' 'orderId' 'total', 'purchaseId',
    {'hp':'hp_val_new','hp.company':'adobe', 'hp.val2':'hp_val2'}
    ); 
    ```

* **targetClearCookies**

  Clears the `Target`cookies from shared cookie storage. 

  * Here is the code sample for this method:

    ```java
    ADB.targetClearCookies(); 
    ```

* **targetLoadRequestWithNameWithLocationParameters**

  Processes a `Target` service request. 

  * Here is the syntax for this method:

    ```java
    ADB.targetLoadRequestWithNameWithLocationParameters(
      success, fail, name, defaultContent, profileParameters, orderParameters, mboxParameters requestLocationParameters
      ); 
    ```

  * Here is the code sample for this method:

    ```java
    ADB.targetLoadRequestWithNameWithLocationParameters  (function () { alert('success'); }, function () { alert('fail'); }, ;'bannerOffer', 'none', {'hp':'hp_val_new','hp.company':'adobe', 'hp.val2':'hp_val2'}, {'hp':'hp_val_new','hp.company':'adobe', 'hp.val2':'hp_val2'},{'hp':'hp_val_new','hp.company':'adobe', 'hp.val2':'hp_val2'},{'hp':'hp_val_new','hp.company':'adobe', 'hp.val2':'hp_val2'});
    ```

* **targetLoadRequestWithName**

  Processes a `Target` service request.

  * Here is the syntax for this method:

    ```java
    ADB.targetLoadRequestWithRequestName(success, fail, name, defaultContent, profileParameters, orderParameters, mboxParameters);
    ```

  * Here is the code sample for this method:

    ```java
    ADB.targetLoadRequestWithName(
    function (value){ // handle target success} ,
    function() { // handle target failure }, 
    "mboxName",
    "defaultContent",
    {"profileParameters":"profileParametervalues"}
    {"orderId" : "32FGJ4XK" , "orderTotal" : "123.33" , "purchasedProductIds":"[46,34]" }
    {"mboxParameters":"mboxParametersvalues"}
    );
    ```

* **targetSessionID**

  Gets the value of the `SessionID` cookie returned for this visitor by the Target server. 

  * Here is the syntax for this method:

    ```java
    ADB.targetSessionID (success, fail); 
    ```

  * Here is the code sample for this method:

    ```java
    ADB.targetSessionID(function (value) { alert(value) },function (value){ alert('fail'); });  
    ```

* **targetPcID**

  Gets the value of the `PcID` cookie that is returned for this visitor by the `Target` server.

  * Here is the syntax for this method:

    ```java
    ADB.targetPcID (success, fail); 
    ```

  * Here is the code sample for this method:

    ```java
    ADB.targetPcID(function  (value) { alert(value) },function (value) { alert('fail'); });
    ```

* **targetSetThirdPartyID**
  
  Sets the custom visitor ID for Target.

  * Here is the syntax for this method:

    ```java
    ADB.targetSetThirdPartyID(thirdPartyID, success, fail); 
    ```

  * Here is the code sample for this method:

    ```java
    ADB.targetSetThirdPartyID('test-third-party-id' function (value) { alert('success'); },function (value) { alert('fail'); }); 
    ```

* **targetThirdPartyID**

  Gets the custom visitor ID for Target. 

  * Here is the syntax for this method:

    ```java
    ADB.targetThirdPartyID(success, fail);
    ```

  * Here is code sample for this method:

    ```java
     ADB.targetThirdPartyID(function (value) { alert(value); },function (value) { alert('fail')__;});
    ```

## Acquisition methods

* **acquisitionCampaignStartForApp**

  Sends a request to your configured Target server and returns the string value of the offer. 

  * Here is the syntax for this method:

    ```java
    ADB.acquisitionCampaignStartForApp(appId, data, success, fail); 
    ```

  * Here are the code samples for this method:

    ```java
    ADB.acquisitionCampaignStartForApp("appId", {‘key’:‘value’}, function() {…}, function() {…}));
    ```

    ```java
    ADB.acquisitionCampaignStartForApp("appId", {‘key’:‘value’});  
    ```

## Advertising identifier

In the main activity that is generated by Cordova, call `Config.submitAdvertisingIdentifierTask()` in the `onResume()` method. For more information, see [Configuration Methods](/docs/android/configuration/methods.md).

## Audience Manager methods

* **audienceGetVisitorProfile**

  Gets the visitor’s profile. 

  * Here is the syntax for this method:

    ```java
    ADB.audienceGetVisitorProfile(); 
    ```

  * Here is the code sample for this method:

    ```java
    ADB.audienceGetVisitorProfile(function(value) { profile = value;}, function() { profile = null; }); 
    ```

* **audienceGetDpuuid**

  Returns the DPUUID. 

  * Here is the syntax for this method:

    ```java
    ADB.audienceGetDpuuid(success fail);
    ```

  * Here is the code sample for this method:

    ```java
    ADB.audienceGetDpuuid(function(value) { dpuuid = value;}, function(){dpuuid = null; }); 
    ```

* **audienceGetDpid**

  Returns the DPID. 

  * Here is the syntax for this method:

    ```java
    ADB.audienceGetDpid(success, fail);
    ```

  * Here is the code sample for this method:

    ```java
    ADB.audienceGetDpid(function(value){dpid = value;}, function() {dpid =  null;}); 
    ```

* **audienceSetDpidAndDpuuid**

  Sets the DPID and DPUUID. 

  * Here is the syntax for this method:

    ```java
    ADB.audienceSetDpidAndDpuuid(dpid, dpuuid, success, fail); 
    ```

  * Here are the code samples for this method:

    ```java
    ADB.audienceSetDpidAndDpuuid(‘dpid’, ‘dpuuid’, function() {…}, function(){…};
    ``` 

    ```java
    ADB.audienceSetDpidAndDpuuid(‘dpid’, ‘dpuuid’); 
    ```

* **audienceSignalWithData**

  Processes an Audience Manager service request. 

  * Here is the syntax for this method:

    ```java
    ADB.audienceSignalWithData(success, fail, data);
    ```

  * Here are the code samples for this method:

    ```java
     ADB.audienceSignalWithData(function() {}, function() {} {‘key1’: ’value1’ ‘key2’: ‘value2’}); 
    ```

    ```java
    ADB.audienceSignalWithData({‘key1’: ’value1’, ‘key2’:‘value2’}); 
    ```

* **audienceReset**

  Audience Manager UUID and purges the current visitor profile.

  * Here is the code sample for this method:

    ```java
    ADB.audienceReset();
    ```

## ID Service methods

* **visitorGetMarketingCloudId**

  Returns the Experience Cloud ID from the ID Service.

  * Here is the syntax for this method:

    ```java
    ADB.visitorGetMarketingCloudId(success, fail); 
    ```

  * Here is the code sample for this method:

    ```java
    ADB.visitorGetMarketingCloudId(function (value) { mcid = value;},function (){ mcid = null;});
    ```

* **visitorSyncIdentifiers**

  Synchronizes the provided identifiers with the ID Service.

  * Here is the syntax for this method:

    ```java
    ADB.visitorSyncIdentifiers(identifiers, success, fail); 
    ```

  * Here are the code samples for this method:

    ```java
    ADB.visitorSyncIdentifiers({‘key_id_1’:’value_id_1’}, function() {…}, function() {…}));
    ```

    ```java
    ADB.visitorSyncIdentifiers({‘key_id_1’: ‘value_id_1’});  
    ```

* **visitorSyncIdentifiersWithAuthenticationState**

  Synchronizes the provided identifiers to the ID Service.

  * Here is the syntax for this method:

    ```java
    ADB.visitorSyncIdentifiersWithAuthenticationState
    (identifiers, authenticationState, success, fail); 
    ```

  * Here is the code sample for this method:

    ```java
    ADB.visitorSyncIdentifiersWithAuthenticationState({'k1':'v1','k2':'v2','k3':'v3'}, ADB.mobileVisitorAuthenticationStateAuthenticated, function (value) { alert('success'); },function (value) { alert('fail'); }); 
    ```

* **visitorSyncIdentifierWithType**

  Synchronizes the provided identifier to the ID Service.
  
  * Here is the syntax for this method:

    ```java
    ADB.visitorSyncIdentifierWithType(identifierType, identifier authenticationState, success, fail); 
    ```

  * Here is the code sample for this method:

    ```java
    ADB.visitorSyncIdentifierWithType('test-identifier-type', 'test-identifier', ADB.mobileVisitorAuthenticationStateAuthenticated, function (value) { alert('success') },function (value) { alert('fail'); }); 
    ```

* **visitorAppendToURL**

  Appends visitor identifiers to the given URL. 

  * Here is the syntax for this method:

    ```java
     ADB.visitorAppendToURL(urlToAppend, success, fail); 
    ```

  * Here is the code sample for this method:

    ```java
    ADB.visitorAppendToURL('test_visitor_url', function (value) alert(value);},'');
    ```

* **visitorGetIDs**

  Returns all `visitorID`s that have been synced. 

  * Here is the syntax for this method:

    ```java
    ADB.visitorGetIDs (success, fail);
    ```

  * Here is the code sample for this method:

    ```java
    ADB.visitorGetIDs(function (value) { alert(value); },function (value) { alert('fail') ;}); 
    ```
