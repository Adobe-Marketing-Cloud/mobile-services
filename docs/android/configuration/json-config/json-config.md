# ADBMobile JSON config file

This information helps you understand the variables in the ADBMobile.json config file.

## `ADBMobileConfig.json` config file reference

The same config file can be used for your app across multiple platforms:

> **Tip:** In **Android**, the `ADBMobileConfig.json` file must be placed in the `assets` folder.

Here is a list of the variables in the JSON file and the minimum SDK version you need for each variable:

* **acquisition**
  * Minimum SDK version: 4.1
  * Enables mobile app acquisition.
    * `server`, which is the acquisition server that is checked at the initial launch for an acquisition referrer. 
    * `appid`, which is the generated ID that uniquely identifies this app on the acquisition server.  

  If this section is missing, enable Mobile App acquisition and download the SDK configuration file again. For more information, see *referrerTimeout* in this list of variables. 

* **analyticsForwardingEnabled**
  * Minimum SDK version is 4.8.0.
  * The default value is `false`. 
  
    The property in the `audienceManager` object. If Audience Manager is configured, and `analyticsForwardingEnabled` is set to `true`, all Analytics traffic is also forwarded to Audience Manager.

* **backdateSessionInfo**
  * Minimum SDK version: 4.6.
  * Enables/disables the ability for the Adobe SDK to backdate session info hits. 
  
    Session info hits currently consist of crashes and session length and can be enabled or disabled.
  
    **Enabling or Disabling Hits**

    * If you set the value to `false`, the hits are **disabled**. The SDK returns to its pre-4.1 behavior of lumping the session information for the previous session with the first hit of the subsequent session. The Adobe SDK also attaches the session info to the current lifecycle, which avoids the creation of an inflated visit. Because inflated visits are no longer created, an immediate drop in visit counts occurs. 

    * If you do not provide a value, the default value is `true`, and hits are **enabled**. When the hits are enabled, the Adobe SDK backdates the session info hit to 1 second after the final hit in the previous session. This means that crash and session data will correlate with the correct date on which they occurred. One side effect is that the SDK might create a visit for the backdated hit. One hit is backdated on every new launch of the application. 

      > **Important:** Backdated session hit information is sent in a session info server call and additional server calls might apply. 

* **batchLimit**
  * Minimum SDK version: 4.1
  * Threshold for number of hits to be sent in consecutive calls. 
  
    For example, if `batchLimit` is set to 10, each hit before the 10th hit will be stored in the queue. When the 10th hit comes in, all 10 hits will be sent consecutively. 
  
    Remember the following information:  

    * Default value is `0`, which means that batching not enabled. 
    * Requires `offlineEnabled = true`. 

* **charset**
  * Minimum SDK version: 4.0 
  * Defines the character set that you are using for the data that is sent to Analytics. 
  
    The charset is used to convert incoming data into UTF-8 for storage and reporting. 

* **clientCode**
  * Minimum SDK version: 4.0
  * Your assigned client code.
  
    > **Important:** This variable is required by Target. 

* **coopUnsafe**
  * Minimum SDK version:  4.16.1
  * The Boolean property of the `marketingCloud` object that, when set to `true`, causes the device to be opted-out of the Experience Cloud's Device Co-Op. 
  * Default value is `false`. 
  * This setting is used **only** for Device Co-op provisioned customers.  

  For Device Co-op members who require this value set to `true`, you need to work with the Co-op team to request a blocklist flag on your Device Co-op account. There is no self-service path to enabling these flags. 

  Remember the following information:

  * When `coopUnsafe` is set to `true`, `coop_unsafe=1` will always be appended to Audience Manager and Visitor ID hits.
  * If you enable Analytics server-side forwarding to Audience Manager, you will also see `coop_unsafe=1` Analytics hits. 

* **environmentId**
  * Minimum SDK version: 4.14
  * The ID of the environment you want to use. 
  
    You can specify a valid ID (`environmentId=8`), and if `environmentId` is not included, the default Production environment is used. 

* **lifecycleTimeout**
  * Minimum SDK version: 4.0
  * Default value is 300 seconds. 
  
    Specifies the length of time, in seconds, that must elapse between the time the app launches but before the launch is considered to be a new session. This timeout also applies when your application is sent to the background and reactivated.

    The time that your app spends in the background is not included in the session length. 

* **messages**

  * Minimum SDK version: 4.2 
  * Generated automatically by Adobe Mobile services, defines the settings for in-app messaging. For more information, see the *Messages Description* section below. 

* **offlineEnabled**

  * Minimum SDK version: 4.0 
  * When enabled, hits are queued while the device is offline and sent later when the device is online. 
  
    Your report suite must be timestamp-enabled to use offline tracking.
  
    The default value is `false`. 
  
    > **Important:** If timestamps are enabled on your report suite, your `offlineEnabled` configuration property **must** be true. if your report suite is not timestamp enabled, your `offlineEnabled` configuration property **must** be false. 
    >
    >If this is not configured correctly, data will be lost. If you are not sure whether a report suite is timestamp enabled, contact Customer Care or download the configuration file from Adobe Mobile services. 
  
    If you are currently reporting AppMeasurement data to a report suite that also collects data from JavaScript, you might need to set up a separate report suite for mobile data or include a custom timestamp on all JavaScript hits that use the `s.timestamp` variable. 

* **org**

  * Minimum SDK version: 4.3
  * Specifies the Experience Cloud org ID for the ID service.

* **poi**
  * Minimum SDK version: 4.0
  * Each point of interest (POI) array holds the POI name, latitude, longitude, and radius in meters for the area of the point. 
  
    The POI name can be any string. When a `trackLocation` call is sent, if the current coordinates are within a defined POI, a context data variable is populated and sent with the `trackLocation` call. 

    ```javascript
    "poi": [
               ["san francisco",37.757144,-122.44812,7000]
               ["santa cruz",36.972935,-122.01725,600]
           ]
    ```

    Starting in version 4.2, POIs are defined in the Adobe Mobile interface and synchronized dynamically to the app configuration file. This synchronization requires the `analytics.poi` setting: 

    ```javascript
      "analytics.poi": `https://assets.adobedtm.com/`
    …/yourfile.json"`,
    ```

    If this setting is not configured, the `ADBMobile.json` file must be updated to include this line. To download an updated configuration file, see [Before you Start](/docs/android/getting-started/requirements.md).

* **postback**
  * Minimum SDK version: 4.6
  * Here is the definition for the "callback" message template:

    ```javascript
    "payload":{
      "templateurl":"", //required will be token-expanded prior to being sent
      "templatebody":"", //optional - if this length > 0 POST will be used as transport method. This is a base64 encoded blob, which will be decoded and token-expanded prior to being sent.
      "contenttype": "", // optional - if this is length > 0 and POST type is selected this will be set as the Content-Type header.  if this is not supplied for a POST request, the default will be "application/x-www-form-urlencoded"
      "timeout": 0 // optional - number of seconds to wait before timing out.  Default is 2.}
    ```

    The `payload` object in the code is a sample payload for a message definition that goes in the `ADBMobileConfig.json` file. For more information, see [Postbacks](/docs/android/analytics-main/postbacks/postbacks.md).

* **privacyDefault**
  * Minimum SDK version: 4.0 
  * The default value is `optedin`. 
    * For `optedin`, the hits are sent immediately. 
    * For `optedout`, the hits are discarded. 
    * For `optunknown`, if your report suite is timestamp-enabled, hits are saved until the privacy status changes to opt-in (hits are sent) or opt-out (hits are discarded). 

    If your report suite is not timestamp-enabled, hits are discarded until the privacy status changes to `optedin`.  This only sets the initial value. If this value is set or changed in code, the new value is used until it is changed again, or when the app is uninstalled and reinstalled.

* **referrerTimeout**
  * Minimum SDK version: 4.1
  * Number of seconds the SDK waits for acquisition referrer data on the initial launch before timing out. If you are using acquisition, we recommend a 5-second timeout. 

    > **Important:** This variable is required by Acquisition. If the variable is set to `0` or is not included, the SDK does not wait for acquisition data, and acquisition metrics are not tracked.  

* **remotes**
  * Minimum SDK version: 4.2
  * Configured automatically and defines the Adobe-hosted endpoints for dynamic configuration files. 
  
    The last update time of each configuration file is checked against the current version at each launch, and the updates are downloaded and saved. 
    * `analytics.poi` is the endpoint for hosted POI configuration.  
    * `messages` is the endpoint for hosted in-app message configuration. 

* **rsids**
  * Minimum SDK version: 4.0
  * One or more report suites to receive Analytics data. Multiple report suite IDs should be comma-separated with no space between. 

    ```javascript
      "rsids" "rsid"
    ```

    ```javascript
      "rsids" "rsid1,rsid2"
    ```

    > **Important:** This variable is required by Analytics. 

* **server**
  * Minimum SDK version: 4.0
  * The Analytics or Audience Management server, based on the parent node. This variable should be populated with the server domain, without an `https://` or `https://` protocol prefix. This prefix is handled automatically by the library and is based on the `ssl` variable. If `ssl` is `true`, a secure connection is made to this server. If `ssl` is `false`, a non-secure connection is made to this server. 

* **ssl**
  * Minimum SDK version: 4.0
  * The default value is `false`. 
  
    Enables (`true`) or disables (`false`) the ability to send measurement data by using SSL (HTTPS). 

    The definition for the "callback" message template is shown below:

    ```javascript
    "payload": {
        "templateurl":"",//required-will be token-expanded prior to being sent 
        "templatebody": "", //optional - if this length >  0 POST will be used& as transport method. This is a base64 encoded blob, which will be  decoded and token-expanded prior to being sent.
        "contenttype": "" // optional - if this is length > 0 POST type is selected this will be set as the Content-Type header. if this is not supplied for a POST request, the default will be "application/x-www-form-urlencoded"
        "timeout": 0 // optional - number of seconds to wait before timing& out. Default is 2.}
    ```

* **timeout**
  * Minimum SDK version: 4.0 
  * Determines how long Target waits for a response.


## Sample `ADBMobileConfig.json` file

Here is a sample `ADBMobileConfig.json` file:

```js
 { 
    "version": "2014-08-05T19:18:28.169Z", 
    "marketingCloud" : { 
        "org": "016D5C175213CCA80A490D05@AdobeOrg", 
        "coopUnsafe": false 
    }, 
    "target": { 
        "clientCode": "", 
        "timeout": 5, 
        "environmentId": 8 
    }, 
    "audienceManager": { 
        "server": "", 
        "analyticsForwardingEnabled": false 
    }, 
    "acquisition": { 
        "server": "c00.adobe.com", 
        "appid": "10a77a60192fbb628376e1b1daeeb65debf934e2c807e067ceb2963a41b165ee" 
    }, 
    "analytics": { 
        "rsids": "coolApp", 
        "server": "my.CoolApp.com", 
        "ssl": true, 
        "offlineEnabled": true, 
        "charset": "UTF-8", 
        "lifecycleTimeout": 300, 
        "privacyDefault": "optedin", 
        "batchLimit": 0, 
        "referrerTimeout": 5, 
        "poi": [ 
            ["san francisco",37.757144,-122.44812,7000],  
            ["santa cruz",36.972935,-122.01725,600] 
        ] 
    }, 
    "messages": [ 
        { 
            "messageId": "cb426565-a563-497a-a889-9dbeb451f8ae", 
            "template": "fullscreen", 
            "payload": { 
                 "html": "<!DOCTYPE html><html><head><meta charset=\"utf-8\" /><title></title><style></style></head><body><iframe src=\"https://www.adobe.com/\" frameborder=\"0\"></iframe></body></html>" 
            }, 
            "showOffline": false, 
            "showRule": "always", 
            "endDate": 2524730400, 
            "startDate": 0, 
            "audiences": [], 
            "triggers": [ 
                { 
                    "key": "pev2", 
                    "matches": "eq", 
                    "values": [ 
                        "AMACTION:custom" 
                    ] 
                } 
            ] 
        } 
    ], 
    "remotes": { 
        "analytics.poi": "https://assets.adobedtm.com/staging/42a6fc9b77cd9f29082cf19b787bae75b7d1f9ca/scripts/satellite-53e0faadc2f9ed92bc00003b.json", 
        "messages": "https://assets.adobedtm.com/staging/42a6fc9b77cd9f29082cf19b787bae75b7d1f9ca/scripts/satellite-53e0f9e2c2f9ed92bc000032.json" 
    } 
}
```

## Messages description

The messages node is generated automatically by Adobe Mobile services and typically does not need to be manually changed. The following description is provided for troubleshooting purposes:

* "messageId" 
* Generated ID, required 
* "template"
  * "alert", "fullscreen", or "local" 
  * required

* "showOffline"
  * true or false 
  * default is false

* "showRule"
  * "always", "once", or "untilClick" 
  * required

* "endDate"
  * number of seconds since Jan 1, 1970 
  * default is 2524730400

* "startDate"
  * number of seconds since Jan 1, 1970 
  * default is 0

* "payload"
  * "html" 
    * fullscreen template only, required 
    * html defining the message
  * "image"
    * fullscreen only, optional 
    * url to the image to be used for a fullscreen image

  * "altImage"
    * fullscreen only, optional 
    * name of the bundled image to use if the url specified in
      * image 
      * is unreachable

  * "title"
    * fullscreen and alert, required 
    * title text for a fullscreen or alert message
  * "content"
    * alert and local notification, required 
    * sub-text for an alert message, or notification text for a local notification message
  * "confirm"
    * alert, optional 
    * text used in the confirm button
  * "cancel"
    * alert, required 
    * text used in the cancel button
  * "url"
    * alert, optional 
    * url action to load if the confirm button is clicked
  * "wait"
    * local notification, required 
    * amount of time to wait (in seconds) to post the local notification after matching its criteria

* "audiences"
  * array of objects that defines how the message should be shown 
  * "key"
    * variable name to look for in the hit, required
* "matches"
  * type of matcher used when doing the comparison 
  * eq = equals 
  * ne = does not equal 
  * co = contains 
  * nc = does not contain 
  * sw = starts with 
  * ew = ends with 
  * ex = exists 
  * nx = does not exist 
  * lt = less than 
  * le = less than or equals 
  * gt = greater than 
  * ge = greater than or equals
* "values"
  * an array of values used to match against the value of the variable named in
    * key
    * with the matcher type in
    * matches
* "triggers"
  * same as audiences, but this is the action instead of the audience 
  * "key" 
  * "matches" 
  * "values"
