# Adobe Mobile class and method reference

Classes and methods provided by the BlackBerry library.

 The SDK currently has support for Adobe Analytics, and methods are in separate classes based on the solution. 

## SDK settings

* **getPrivacyStatus**

  Returns the enum representation of the privacy status for current user.

  * ADBMobilePrivacyStatusOptIn - hits are sent immediately.
  * ADBMobilePrivacyStatusOptOut - hits are discarded.
  * ADBMobilePrivacyStatusUnknown - If your report suite is timestamp-enabled, hits are saved until the privacy status changes to opt-in (then hits are sent) or opt-out (then hits are discarded). If your report suite is not timestamp-enabled, hits are discarded until the privacy status changes to opt in.  
  
    The default value is set in the `ADBMobileConfig.json` file. 

  * Here is the syntax for this method:

    ```cpp
    static ADBMobilePrivacyStatus getPrivacyStatus();
    ```

  * Here is the code sample for this method:

    ```cpp
    ADBMobilePrivacyStatus privacyStatus = ADBMobile::getPrivacyStatus();
    ```

* **setPrivacyStatus**

  Sets the privacy status for the current user to `status`. Set to one of the following values:
  
  * `ADBMobilePrivacyStatusOptIn` - hits are sent immediately.
  * `ADBMobilePrivacyStatusOptOut` - hits are discarded.  
  * `ADBMobilePrivacyStatusUnknown` - If your report suite is timestamp-enabled, hits are saved until the privacy status changes to opt-in (then hits are sent) or opt-out (then hits are discarded). If your report suite is not timestamp-enabled, hits are discarded until the privacy status changes to opt in. 

  * Here is the syntax for this method:

    ```cpp
    static void setPrivacyStatus(ADBMobilePrivacyStatus status);
    ```

  * Here is the code sample for this method:

    ```cpp
    ADBMobile::setPrivacyStatus(ADBMobilePrivacyStatusOptIn);
    ```

* **getUserIdentifier**

  Returns the user identifier if a custom identifier has been set. Returns `null` if a custom identifier is not set. The default value is `null`.

  * Here is the syntax for this method:

    ```cpp
    static QString getUserIdentifier();
    ```

  * Here is the code sample for this method:

    ```cpp
    QString userId = ADBMobile::getUserIdentifier(); 
    ```

* **setUserIdentifier**

  Sets the user identifier to `identifier`.

  * Here is the syntax for this method:

    ```cpp
    static void setUserIdentifier(QString identifier);
    ```

  * Here is the code sample for this method:

    ```cpp
    ADBMobile::setUserIdentifier("billybob");
    ```

* **getDebugLogging**

  Returns the current debug logging preference. The default value is `false`.

  * Here is the syntax for this method:

    ```cpp
    static bool getDebugLogging();
    ```

  * Here is the code sample for this method:

    ```cpp
     bool debugging = ADBMobile::getDebugLogging(); 
    ```

* **setDebugLogging**

  Sets the debug logging preference to `debugLogging`.

  * Here is the syntax for this method:

    ```cpp
    static void setDebugLogging(bool debugLogging);
    ```

  * Here is the code sample for this method:

    ```cpp
      ADBMobile::setDebugLogging(true); 
    ```

* **collectLifecycleData**

  Indicates to the SDK that lifecycle data should be collected for use across all solutions in the SDK. For more information, see [Lifecycle Metrics](/docs/blackberry/metrics.md). 

  * Here is the syntax for this method:

    ```cpp
    static void collectLifecycleData();
    ```

  * Here is the code sample for this method:

    ```cpp
    ApplicationUI::ApplicationUI(bb::cascades::Application *app):  QObject(app)  { 
    //... 
    ADBMobile::collectLifecycleData(); 
    }
    ```

## Analytics methods

Each of these methods is used to send data into your Adobe Analytics report suite. 

* **trackState**

  Tracks an app state with optional context data. States are the views that are available in your app, such as "home dashboard", "app settings", "cart", and so on. These states are similar to pages on a website, and `trackState` calls increment page views. 
  
  > **Tip:** This is the only tracking call that increments page views. 

  * Here is the syntax for this method:

    ```cpp
    static void trackState(QString state, QHash<QString, QString> contextData = QHash<QString, QString>()); 
    ```

  * Here is the code sample for this method:

    ```cpp
       ADBMobile::trackState("loginScreen", null);
    ```

* **trackAction**

  Tracks an action in your app. Actions are the things that happen in your app that you want to measure, such as "logons", "banner taps", "feed subscriptions", and other metrics. 

  * Here is the syntax for this method:

    ```cpp
    static void trackAction(QString action, QHash<QString, QString> contextData = QHash<QString, QString>()); 
    ```

  * Here is the code sample for this method:

    ```cpp
      ADBMobile::trackAction("heroBannerTouched", null); 
    ```

* **trackLocation**

  Sends the current x y coordinates. Replace event with the event that is received from the subscriber to BPS. 

  * Here is the syntax for this method:

    ```cpp
    static void trackLocation(bps_event_t *geoEvent, QHash<QString, QString> contextData = QHash<QString, QString> ());
    ```

  * Here is the code sample for this method:

    ```cpp
      ADBMobile::trackLocation(event, null);
    ```

## `ADBMobileConfig.json` config file reference

The `ADBMobileConfig.json` file must be placed in the *assets* folder.

* **rsids**

  (Required) One or more report suites to receive Analytics data. Multiple report suite IDs should be comma-separated with no space between. 

  Here are the code sample for this variable:

  ```js
  "rsids" : "rsid"
  ```

  ```js
  "rsids" : "rsid1,rsid2"
  ```

* **server**

  (Required). Analytics server. This variable should be populated with the server domain, without an `https://` or `https://` protocol prefix. The protocol prefix is handled automatically by the library based on the `ssl`  variable. If `ssl` is `true`, a secure connection is made to this server. If `ssl` is `false`, a non-secure connection is made to this server. 

* **charset**

  Defines the character set you are using for the data sent to Analytics. The charset is used to convert incoming data into UTF-8 for storage and reporting. 

* **ssl**

  Enables (`true`) or disables (`false`) sending measurement data via SSL (HTTPS). The default value is `false`. 

* **offlineEnabled**

  When enabled (`true`), hits are queued while the device is offline and sent later when the device is online. Your report suite must be timestamp-enabled to use offline tracking. 
  
  > **Tip:** If timestamps are enabled on your report suite, your `offlineEnabled` configuration property *must* be `true`. if your report suite is not timestamp enabled, your `offlineEnabled` configuration property *must* be false. If this is not configured correctly, data will be lost. If you are not sure if a report suite is timestamp enabled, contact [Enterprise Support](https://helpx.adobe.com/contact/enterprise-support.ec.html). 
  
  If you are currently reporting AppMeasurement data to a report suite that also collects data from JavaScript, you might need to set up a separate report suite for mobile data, or include a custom timestamp on all JavaScript hits using the `s.timestamp` variable. 

  The default value is `false`.

* **lifecycleTimeout**

  Specifies the length of time, in seconds, that must elapse between app launches before the launch is considered a new session. This timeout also applies when your application is sent to the background and reactivated. The time that your app spends in the background is not included in the session length. 
  
  The default value is 300 seconds.

* **batchLimit**

  Maximum number of offline hits stored in the queue. The default value is 0 (No limit).

* **privacyDefault**

  * `optedin` - hits are sent immediately.  
  * `optedout` - hits are discarded.  
  * `optunknown` - If your report suite is timestamp-enabled, hits are saved until the privacy status changes to opt-in (then hits are sent) or opt-out (then hits are discarded). 
  
    If your report suite is not timestamp-enabled, hits are discarded until the privacy status changes to opt in.  

  This variable sets the initial value only. If this value is ever set or changed in code, then the new value is used going forward until it is changed, or the app is uninstalled and then reinstalled.

  The default value is `optedin`.

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
    } 
}
```
