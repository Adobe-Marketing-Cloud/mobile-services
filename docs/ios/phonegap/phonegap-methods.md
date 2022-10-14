# PhoneGap plug-in methods

You can use iOS PhoneGap Plug-in methods to complete a variety of tasks.

In `html` files where you want to use tracking, add the following to the `<head>` tag:

```html
<script type="text/javascript" charset="utf-8" src="ADB_Helper.js"></script>
```

## Configuration methods

* **getPrivacyStatus**

  Returns the privacy status for current user. Here are the available statuses: 
  
  * `ADB.optedIn`, where hits are sent immediately. 
  * `ADB.optedOut`, where hits are discarded. 
  * `ADB.optUnknown`If your report suite **is** timestamp-enabled, hits are saved until the privacy status changes to opt-in (hits are sent) or opt-out (hits are discarded). If your report suite **is not** timestamp-enabled, hits are discarded until the privacy status changes to opt in.  
    The default value is set in the `ADBMobileConfig.json` file.

    * Here is the code sample for this method:

      ```javascript
      getPrivacyStatus(function (value){myTempVal = value;},function(){myTempVal = null;});
      ```

* **setPrivacyStatus**

  Sets the privacy status for the current user to `status`. You can set one of the following statuses: 
  * `ADB.optedIn`, where hits are sent immediately.  
  * `ADB.optedOut`, where hits are discarded. 
  * `ADB.optUnknown` - If your report suite **is** timestamp-enabled, hits are saved until the privacy status changes to opt-in (hits are sent) or opt-out (hits are discarded). 
  
    If your report suite **is not** timestamp-enabled, hits are discarded until the privacy status changes to opt in. 
  
  * Here is the code sample for this method:

    ```javascript
      ADB.setPrivacyStatus('ADB.optedIn'); 
    ```

* **getLifetimeValue**

  Returns the lifetime value of the current user. The default value is 0. 

  * Here is the code sample for this method:

    ```javascript
    ADB.getLifetimeValue(function(value){myTempVal = value;},function(){myTempVal = null;});
    ```

* **setDebugLogging**

  Enables (`true`) or disables (`false`) viewing debug information. By default, this variable is `false`.

  * Here is the code sample for this method:

    ```javascript
    ADB.setDebugLogging(true);
    ```

* **getVersion**

  Gets the library version. 

  * Here is the code sample for this method:

    ```javascript
    ADB.getVersion(function(value){versionNum = value;},function(){versionNum=1.0;}); 
    ```

* **trackingIdentifier**

  Returns the automatically generated visitor identifier. This is an app-specific unique visitor ID that is generated when the app is initially launched and is stored and used from that point forward. This ID is preserved between app upgrades, and is removed when the app is uninstalled.

  > **Tip:** If your app upgrades from the Experience Cloud 3.x to 4.x SDK, the previous visitor ID (custom or automatically generated) is retrieved and stored as the custom user identifier (see `getUserIdentifier` below). This preserves visitor data between upgrades of the SDK. For new installations on the 4.x SDK, the user identifier is `null`, and tracking identifier is used.

  * Here is the code sample for this method:

    ```javascript
     ADB.trackingIdentifier(function(value){myTempVal = value;},function(){myTempVal = null;}); 
    ```

* **getUserIdentifier**

  Returns the custom user identifier if a custom identifier has been set, and returns `null` if a custom identifier has not been set. The default value is `null`.

  * Here is the code sample for this method:

    ```javascript
    getUserIdentifier(function(value){myTempVal = value;},function(){myTempVal = null;}); 
    ```

* **setUserIdentifier**

  Sets the user identifier to `identifier`. 

  * Here is the code sample for this method:

    ```javascript
    ADB.setUserIdentifier('testUser');
    ```

* **setPushIdentifier**

  Sets the device token for push notifications.

  * Here is the syntax for this method:

    ```javascript
    ADB.setPushIdentifier(pushIdentifier,success,fail);
    ```

  * Here is the code sample for this method:

    ```javascript
    ADB.setPushIdentifier('test_push_identifier',function(value){alert('success');},function(value){alert('fail');
    ```

* **keepLifecycleSessionAlive**

  Sets the preference of lifecycle session keep alive. 
  
  > **Important:** Calling `keepLifecycleSessionAlive` prevents your app from launching a new session the next time it is resumed from background. You should only use this method if your app registers for notifications in the background.

  * Here is the code sample for this method:

    ```javascript
    ADB.keepLifecycleSessionAlive();
    ```

* **trackingSendQueuedHits**

  Forces the library to send all queued hits regardless of current batch options.

  * Here is the code sample for this method:

    ```javascript
    ADB.trackingSendQueuedHits();
    ```

* **trackingGetQueueSize**

  Gets or sets the number of stored tracking calls in the offline queue. 

  * Here is the code sample for this method:

    ```javascript
    ADB.trackingGetQueueSize(function(value){myTempVal = value;},function(){myTempVal = null;}); 
    ```

* **trackingClearQueue**

  Removes all stored tracking calls from the offline queue. 

  > **Caution:** Use caution when clearing the queue manually as it cannot be reversed. 

  * Here is the code sample for this method:

    ```javascript
    ADB.trackingClearQueue(function(value){myTempVal = value;},function(){myTempVal = null;}); 
    ```

* **keepLifecycleSessionAlive**

  Indicates to the SDK that your next resume from background should not start a new session, regardless of the value of lifecycle session timeout in your config file. 

  > **Important:** Important:  this method is intended to be used for apps that register for notifications while in background and should only be called from your code that runs while your app is in the background. 

  * Here is the code sample for this method:

    ```javascript
    ADB.keepLifecycleSessionAlive();
    ```

* **collectLifecycleData**

  Indicates to the SDK that lifecycle data should be collected for use across all solutions in the SDK. For more information, see [Lifecycle metrics](/docs/ios/metrics.md).

  * Here is the code sample for this method:

    ```javascript
    ADB.collectLifecycleData(); 
    ```


## PII methods

* **collectPII**

  Submits a PII collection request.

  * Here is the syntax for this method:

    ```javascript
    ADB.collectPII(piiData,success,fail); 
    ```

  * Here is the code sample for this method:

    ```javascript
    ADB.collectPII({'k1':'v1','k2':'v2','k3':'v3'}, function (value) { alert('success'); },function (value) { alert('fail'); });
    ```

## Tracking methods

* **trackAdobeDeepLink**

  Tracks an Adobe Deep Link click-through. 
  
  > **Tip:** If the Lifecycle call is a launch event, the Adobe Link data will be appended, otherwise an extra call will be sent.

  * Here is the syntax for this method:

    ```javascript
    ADB.trackAdobeDeepLink(deeplinkURL,success,fail);
    ```

  * Here is the code sample for this method:

    ```javascript
    ADB.trackAdobeDeepLink('xyz-deeplink-url',function(value){alert('success');},function(value){alert('fail');}); 
    ```

* **trackPushMessageClickthrough**

  Tracks a push message click-through.

  * Here is the syntax for this method:

    ```javascrpt
    ADB.trackPushMessageClickthrough(userInfo,success,fail); 
    ```

  * Here is the code sample for this method:

    ```javascript
    ADB.trackPushMessageClickthrough({'k1':'v1','k2':'v2','k3':'v3'},function(value){alert('success');},function(value){alert('fail');}); 
    ```

* **trackLocalNotificationClickThrough**

  Tracks a local notification message click-through.

  * Here is the syntax for this method:

    ```javascript
    ADB.trackLocalNotificationClickThrough(userInfo,success,fail); 
    ```

  * Here is the code sample for this method:

    ```javascript
    ADB.trackLocalNotificationClickThrough({'k1':'v1','k2':'v2','k3':'v3'},function(value){alert('success');},function(value){alert('fail');}); 
    ```

* **trackState**

  Tracks an app state with optional context data. States are the views that are available in your app, such as `home dashboard`, `app settings`, `cart`, and so on. These states are similar to pages on a website, and `trackState` calls increment page views. cData is a JSON object with key-value pairs to send in context data.

  * Here is the syntax for this method:

    ```javascript
    ADB.trackState(stringstateName[,JSONcData]); 
    ```

  * Here are the code samples for this method:

    ```javascript
    ADB.trackState("loginpage");
    ```

    ```javascript
      ADB.trackState("loginpage",{"user":"john","remember":"true"});
    ```

* **trackAction**

  Tracks an action in your app. Actions are the things that happen in your app that you want to measure, include `logins`, `banner taps`, `feed subscriptions` and other metrics. 

  * Here is the syntax for this method:

    ```javascript
    ADB.trackAction(stringaction[,JSONcData]);
    ```

  * Here are the code samples for this method:

    ```javascript
    ADB.trackAction("login");
    ```

    ```javascript
    ADB.trackAction("login",{"user":"john","remember":"true"})
    ```

* **trackActionFromBackground**

  Tracks an action that occurred in the background. This suppresses lifecycle events from firing in certain scenarios. 

  * Here is the syntax for this method:

    ```javascript
    ADB.trackActionFromBackground(stringaction[,JSONcData]); 
    ```

  * Here are the code samples for this method:

    ```javascript
    ADB.trackActionFromBackground("login");
    ```

    ```javascript
    ADB.trackActionFromBackground("login",{"user":"john","remember":"true"});
    ```

* **trackLocation**

  Sends the current x and y coordinates. Also uses the points of interest that were defined in the `ADBMobileConfig.json` file to determine if the location provided as a parameter is within any of your POIs. If the current coordinates are within a defined POI, a context data variable is populated and sent with the `trackLocation` call. 

  * Here is the syntax for this method:

    ```javascript
     ADB.trackLocation(x,y[,JSONcData]);
    ```

  * Here is the code sample for this method:

    ```javascript
    ADB.trackLocation('40.431596','-111.893713');
    ```

* **trackLifetime​ValueIncrease**

  Adds `amount` to the user's lifetime value.

  * Here is the syntax for this method:

    ```java
    ADB.trackLifetimeValueIncrease(amount[,JSONcData]);
    ```

  * Here is the code sample for this method:

    ```java
    ADB.trackLifetimeValueIncrease('10.01');
    ```

* **trackTimed​ActionStart**

  Start a timed action with name `action`. If you call this method for an action that has already started, the previous timed action is overwritten. 
  
  > **Tip:** This call does not send a hit.

  * Here is the syntax for this method:

    ```java
    ADB.trackTimedActionStart(action[,JSONcData]);
    ```

  * Here is the code sample for this method:

    ```java
    ADB.trackTimedActionStart("cartToCheckout"); 
    ```

* **trackTimed​ActionUpdate**

  Pass in `cData` to update the context data associated with the given `action`. The `cData` passed in is appended to the existing data for the given action, and overwrites the data if the same key is already defined for `action`. 
  
  > **Tip:** This call does not send a hit.

  * Here is the syntax for this method:

    ```java
    ADB.trackTimedActionUpdate(Stringaction[,JSONcData]);
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

  Returns whether or not a timed action is in progress.

  * Here is the syntax for this method:

    ```java
    ADB.trackingTimedActionExists(function(value){myTempVal = value;},function(){myTempVal = null;});
    ```


## Target methods

* **targetLoadRequest**

  Sends request to your configured `Target` server and returns the string value of the offer.

  * Here is the syntax for this method:

    ```java
    ADB.targetLoadRequest(success,fail,name,defaultContent,parameters); 
    ```

  * Here is the code sample for this method:

    ```java
    ADB.targetLoadRequest(function (value)
    {myTempVal = value;},function() {myTempVal = null;},'bannerOffer','none',{'hp':'hp_val_new','hp.company':'adobe','hp.val2':'hp_val2'}); 
    ```

* **targetLoadOrderConfirmRequest**

  Sends a request to your configured Target server.

  * Here is the syntax for this method:

    ```java
    ADB.targetLoadOrderConfirmRequest(success,fail,name,orderId,orderTotal,productPurchaseId,parameters); 
    ```

  * Here is the code sample for this method:

    ```java
    ADB.targetLoadRequest(function(value){myTempVal=value;}
    ,function()
    {myTempVal = null; }
    ,'name','orderId','total','purchaseId'
    ,{'hp':'hp_val_new','hp.company':'adobe','hp.val2':'hp_val2'}
    ); 
    ```

* **targetClearCookies**

  Clears the Target cookies from shared cookie storage. 

  * Here is the code sample for this method:

    ```java
    ADB.targetClearCookies();
    ```

* **targetLoadRequestWithNameWithLocationParameters**

  Processes a Target service request. 

  * Here is the syntax for this method:

    ```java
    ADB.targetLoadRequestWithNameWithLocationParameters(success,fail,name,defaultContent,profileParameters,orderParameters,mboxParameters,requestLocationParameters
    ); 
    ```

  * Here is the code sample for this method:

    ```java
    ADB.targetLoadRequestWithNameWithLocationParameters(function(){alert('success');},function(){alert('fail');},'bannerOffer','none',{'hp':'hp_val_new','hp.company':'adobe','hp.val2':'hp_val2'},{'hp':'hp_val_new','hp.company':'adobe','hp.val2':'hp_val2'},{'hp':'hp_val_new','hp.company':'adobe','hp.val2':'hp_val2'},{'hp':'hp_val_new','hp.company':'adobe','hp.val2':'hp_val2'}); 
    ```

* **targetLoadRequestWithName**

  Processes a Target service request. 

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
    ADB.targetSessionID(success,fail); 
    ```

  * Here is the code sample for this method:

    ```java
      ADB.targetSessionID(function(value){alert(value);},function(value){alert('fail');}); 
    ```

* **targetPcID**

  Gets the value of the `PcID` cookie returned for this visitor by the Target server. 

  * Here is the syntax for this method:

    ```java
    ADB.targetPcID(success,fail);
    ```

  * Here is the code sample for this method:

    ```java
    ADB.targetPcID(function(value){alert(value);},function(value){alert('fail');});
    ```

* **targetSetThirdPartyID**

  Sets the custom visitor ID for Target.

  * Here is the syntax for this method:

    ```java
    ADB.targetSetThirdPartyID(thirdPartyID,success,fail); 
    ```

  * Here is the code sample for this group:

    ```java
    ADB.targetSetThirdPartyID('test-third-party-id',function(value){alert('success');},function(value){alert('fail');}); 
    ```

* **targetThirdPartyID**

  Gets the custom visitor ID for Target.

  * Here is the syntax for this method:

    ```java
    ADB.targetThirdPartyID(success,fail); 
    ```

  * Here is the code sample for this method:

    ```java
    ADB.targetThirdPartyID(function(value){alert(value);},function(value){alert('fail');}); 
    ```

## Acquisition methods

* **acquisitionCampaignStartForApp**

  Allows developers to start an app acquisition campaign as if the user had clicked a link. This is helpful for creating manual acquisition links and handling the app store redirect yourself (such as with an `SKStoreView`).

  * Here is the syntax for this method:

    ```java
    ADB.acquisitionCampaignStartForApp(appId,data,success,fail); 
    ```

  * Here is the code sample for this method:

    ```java
    ADB.acquisitionCampaignStartForApp('0652024f-adcd-49f9-9bd7-2552a4564d2f',{'extraDataKey':'extraDataValue'},success,fail); 
    ```


## Advertising identifier

In the `AppDelegate` generated by Cordova, call `[ADBMobile setAdvertisingIdentifier:]` in the `application:didFinishLaunchingWithOptions:` delegate method. For more information, see [Configuration Methods](/docs/ios/configuration/sdk-methods.md).

## Audience Manager methods

* **audienceGetVisitorProfile**

  Gets the visitor’s profile.

  * Here is the syntax for this method:

    ```java
    ADB.audienceGetVisitorProfile();
    ```

  * Here is the code sample for this method:

    ```java
    ADB.audienceGetVisitorProfile(function(value){profile = value;},function(){profile = null;}); 
    ```

* **audienceGetDpuuid**

  Returns the DPUUID. 

  * Here is the syntax for this method:

    ```java
    ADB.audienceGetDpuuid(success,fail);
    ```

  * Here is the code sample for this method:

    ```java
     ADB.audienceGetDpuuid(function(value){dpuuid=value;},function(){dpuuid=null;}); 
    ```

* **audienceGetDpid**

  Returns the DPID. 

  * Here is the syntax for this method:

    ```java
     ADB.audienceGetDpid(success,fail);
    ```

  * Here is the code sample for this method:

    ```java
    ADB.audienceGetDpid(function(value){dpid = value;},function(){dpid = null;}); 
    ```

* **audienceSetDpidAndDpuuid**

  Sets the DPID and DPUUID.

  * Here is the syntax for this method:

    ```java
    ADB.audienceSetDpidAndDpuuid(dpid,dpuuid,success,fail);
    ```

  * Here are the code samples for this method:

    ```java
    ADB.audienceSetDpidAndDpuuid(‘dpid’,‘dpuuid’,function(){…},function(){…});
    ```

    ```java
    ADB.audienceSetDpidAndDpuuid(‘dpid’,‘dpuuid’);
    ```

* **audienceSignalWithData**

  Processes an Audience Manager service request. 

  * Here is the syntax for this method:

    ```java
    ADB.audienceSignalWithData(success,fail,data);
    ```

  * Here are the code samples for this method:

    ```java
    ADB.audienceSignalWithData(function(){},function(){},{‘key1’:’value1’,‘key2’:‘value2’});
    ```

     ```java
     ADB.audienceSignalWithData({‘key1’:’value1’,‘key2’:‘value2’}); 
     ```

* **audienceReset**

  Resets audience manager UUID and purges current visitor profile.

  * Here is the code sample for this method:

    ```java
    ADB.audienceReset(); 
    ```

## ID Service methods

* **visitorGetMarketingCloudId**

  Returns the Experience Cloud ID from the ID service. 

  * Here is the syntax for this method:

    ```java
    ADB.visitorGetMarketingCloudId(success,fail);
    ```

  * Here is the code sample for this method:

    ```java
    ADB.visitorGetMarketingCloudId(function(value){mcid=value;},function(){mcid=null;}); 
    ```

* **visitorSyncIdentifiers**

  Synchronizes the provided identifiers with the ID service.

  * Here is the syntax for this method:

    ```java
    ADB.visitorSyncIdentifiers(identifiers,success,fail);
    ```

  * Here are the code samples for this method:

    ```java
    ADB.visitorSyncIdentifiers({‘key_id_1’:’value_id_1’},function(){…},function(){…})) 
    ```

    ```java
    ADB.visitorSyncIdentifiers({‘key_id_1’:‘value_id_1’});
    ```

* **visitorSyncIdentifiersWithAuthenticationState**

  Synchronizes the provided identifiers to the visitor ID service.

  * Here is the syntax for this method:

    ```java
    ADB.visitorSyncIdentifiersWithAuthenticationState(identifiers,authenticationState,success,fail); 
    ```

  * Here is the code sample for this method:

    ```java
    ADB.visitorSyncIdentifiersWithAuthenticationState({'k1':'v1','k2':'v2','k3':'v3'},ADB.mobileVisitorAuthenticationStateAuthenticated,function(value){alert('success');},function(value){alert('fail');});
    ```

* **visitorSyncIdentifierWithType**

  Synchronizes the provided identifier to the visitor ID service.

  * Here is the syntax for this method:

    ```java
    ADB.visitorSyncIdentifierWithType(identifierType,identifier,authenticationState,success,fail); 
    ```

  * Here is the code sample for this method:

    ```java
    ADB.visitorSyncIdentifierWithType('test-identifier-type','test-identifier',ADB.mobileVisitorAuthenticationStateAuthenticated,function(value){alert('success');},function(value){alert('fail');}); 
    ```

* **visitorAppendToURL**

  Appends visitor identifiers to the given URL.

  * Here is the syntax for this method:

    ```java
    ADB.visitorAppendToURL(urlToAppend,success,fail);
    ```

  * Here is the code sample for this method:

    ```java
    ADB.visitorAppendToURL('test_visitor_url',function(value){alert(value);},'');
    ```

* **visitorGetIDs**

  Returns all `visitorIDs` that have been synced.

  * Here is the syntax for this method:

    ```java
    ADB.visitorGetIDs(success,fail)
    ```

  * Here is the code sample for this method:

    ```java
    ADB.visitorGetIDs(function(value){alert(value);},function(value){alert('fail');}); 
    ```
