# `ADBMobileConfig.json` config file

Information to help you use the `ADBMobile.json` config file.

The SDK currently has support for multiple Adobe Experience Cloud Solutions, including Analytics, Target, and Audience Manager. Methods are prefixed according to the solution. Configuration methods are prefixed with "Config."

* **rsids**

  (Required by Analytics) One or more report suites to receive Analytics data. Multiple report suite IDs should be comma-separated with no space between.

  * Here are the code samples for this variable:

    ```js
    "rsids" : "rsid"
    ```

    ```js
    "rsids" : "rsid1,rsid2"
    ```

* **server**

  (Required by Analytics and Audience Management). Analytics or Audience Management server, based on the parent node. This variable should be populated with the server domain, without an `https://` or `https://` protocol prefix. The protocol prefix is handled automatically by the library based on the `ssl` variable.
  
  If `ssl` is `true`, a secure connection is made to this server. If `ssl` is `false`, a non-secure connection is made to this server.

* **charset**

  Defines the character set you are using for the data sent to Analytics. The charset is used to convert incoming data into UTF-8 for storage and reporting. For more information, see the [charSet](https://experienceleague.adobe.com/docs/analytics/implementation/vars/config-vars/charset.html) variable in the Adobe Analytics documentation.

* **ssl**

  Enables (`true`) or disables (`false`) sending measurement data via SSL (HTTPS). The default value is `false`.

* **offlineEnabled**

  When enabled (true), hits are queued while the device is offline and sent later when the device is online. Your report suite must be timestamp-enabled to use offline tracking.
  
  > **Important:** IIf time stamps are enabled on your report suite, your `offlineEnabled` configuration property *must* be true. if your report suite is not timestamp enabled, your `offlineEnabled` configuration property *must* be false. If this is not configured correctly, data will be lost. If you are not sure if a report suite is timestamp enabled, contact Customer Care. If you are currently reporting AppMeasurement data to a report suite that also collects data from JavaScript, you might need to set up a separate report suite for mobile data, or include a custom timestamp on all JavaScript hits using the `s.timestamp` variable.

* **lifecycleTimeout**

  Specifies the length of time, in seconds, that must elapse between app launches before the launch is considered a new session. This timeout also applies when your application is sent to the background and reactivated. The time that your app spends in the background is not included in the session length. The default value is 300 seconds.

* **batchLimit**

  Send hits in batches. For example, if set to 50, hits are queued until 50 are stored, then all queued hits are sent. Requires `offlineEnabled=true`. The default value is `0` (No batching).

* **privacyDefault**

  * `optedin` - hits are sent immediately.
  * `optedout` - hits are discarded.  
  * `optunknown` - If your report suite is timestamp-enabled, hits are saved until the privacy status changes to opt-in (then hits are sent) or opt-out (then hits are discarded). If your report suite is not timestamp-enabled, hits are discarded until the privacy status changes to opt in.

    The default value is `optedin`.

    > **Tip:** This sets the default value only. If this value is ever set or changed in code, then the value set by the code is saved in local storage and is used going forward until it is changed, or the app is uninstalled and then reinstalled.

* **poi**

  Each POI array holds the POI name, latitude, longitude, and radius (in meters) for the area of the point. The POI name can be any string. When a `trackLocation` call is sent, if the current coordinates are within a defined POI, a context data variable is populated and sent with the `trackLocation` call.

  * Here is the code sample for this variable:

    ```js
    "poi": [
                ["san francisco",37.757144,-122.44812,7000], 
                ["santa cruz",36.972935,-122.01725,600] 
            ]
    ```

* **clientCode**

  (**Required by Target**) Your assigned client code.

* **timeout**

  Determines how long Target waits for a response.

The following is an example of an `ADBMobileConfig.json` file:

```js
{ 
    "version" : "1.0", 
    "analytics" : { 
        "rsids" : "coolApp", 
        "server" : "my.CoolApp.com", 
        "charset" : "UTF-8", 
        "ssl" : true, 
        "offlineEnabled" : true, 
        "lifecycleTimeout" : 5, 
        "privacyDefault" : "optedin", 
        "poi" : [ 
                    ["san francisco",37.757144,-122.44812,7000], 
                    ["santa cruz",36.972935,-122.01725,600] 
                ] 
    }, 
 "target" : { 
  "clientCode" : "myTargetClientCode", 
  "timeout" : 1 
 }, 
 "audienceManager" : { 
  "server" : "myServer.demdex.com" 
 } 
}
```
