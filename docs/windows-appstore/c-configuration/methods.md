# SDK methods

Classes and methods provided by the Windows 8.1 Universal App Store library.

> **Tip:** When you consume `winmd` methods from winJS (JavaScript), all methods automatically have their first letter lowercased.

* **GetVersion (winJS: getVersion)**

  Returns the current version of the Adobe Mobile library.

  * Here is the syntax for this method:

    ```csharp
    static Platform::String ^GetVersion();
    ```

  * Here is the code sample for this method:

    ```js
    varADB = ADBMobile;var libVersion = ADB.Config.getVersion(); 
    ```

* **GetPrivacyStatusAsync (winJS: getPrivacyStatusAsync)**

  Returns the enum representation of the privacy status for current user.

  * `ADBMobilePrivacyStatusOptIn` - hits are sent immediately.  
  * `ADBMobilePrivacyStatusOptOut` - hits are discarded.  
  * `ADBMobilePrivacyStatusUnknown` - If your report suite is timestamp-enabled, hits are saved until the privacy status changes to opt-in (then hits are sent) or opt-out (then hits are discarded). If your report suite is not timestamp-enabled, hits are discarded until the privacy status changes to opt in. 
  
    The default value is set in the [ADBMobileConfig.json config](/docs/windows-appstore/c-configuration/c.json.md) file.

  * Here is the syntax for this method:

    ```csharp
    static Windows::Foundation::IAsyncOperation<ADBMobilePrivacyStatus> ^getPrivacyStatusAsync(); 
    ```

  * Here are the code samples for this method:

    ```csharp
    public enum class ADBMobilePrivacyStatus : int  {
      ADBMobilePrivacyStatusOptIn = 1, 
      ADBMobilePrivacyStatusOptOut =  2,
      ADBMobilePrivacyStatusUnknown = 3
    };
    ```

    ```js
    var ADB = ADBMobile;
    var status;
    ADB.Config.getPrivacyStatusAsync.then(function(privacyStatus) {
    status = privacyStatus;
    }); 
    ```

* **SetPrivacyStatus (winJS: setPrivacyStatus)**

  Sets the privacy status for the current user to `status`. Set to one of the following values: 
  
  * `ADBMobilePrivacyStatusOptIn` - hits are sent immediately.  
  * `ADBMobilePrivacyStatusOptOut` - hits are discarded. 
  * `ADBMobilePrivacyStatusUnknown` - If your report suite is timestamp-enabled, hits are saved until the privacy status changes to opt-in (then hits are sent) or opt-out (then hits are discarded). If your report suite is not timestamp-enabled, hits are discarded until the privacy status changes to opt in.

  * Here is the syntax for this method:

    ```csharp
    static void SetPrivacyStatus(ADBMobilePrivacyStatus status);
    ```

  * Here is the code sample for this method:

    ```csharp
    public enum class ADBMobilePrivacyStatus : int {
      ADBMobilePrivacyStatusOptIn = 1,
      ADBMobilePrivacyStatusOptOut = 2,
      ADBMobilePrivacyStatusUnknown = 3
      }; 
    ```

    ```js
    var ADB = ADBMobile;
    ADB.Config.setPrivacyStatus(ADB.ADBMobilePrivacyStatus.adbmobilePrivacyStatusOptIn); 
    ```

* **GetLifetimeValue (winJS: getLifetimeValue)**

  Returns the lifetime value of the current user. The default is 0.

  * Here is the syntax for this method:

    ```csharp
    static float GetLifetimeValue();
    ```

  * Here is the code sample for this method:

    ```js
     var ADB = ADBMobile;
     var ltv = ADB.Config.getLifetimeValue(); 
    ```

* **GetUserIdentifier (winJS: getUserIdentifier)**

  Returns the custom user identifier if a custom identifier has been set. Returns null if a custom identifier is not set. The default value is `null`.  
  
  > **Tip:** If your app upgrades from the Experience Cloud 3.x to 4.x SDK, the previous ID (either custom or automatically generated) is retrieved and stored as the custom user identifier. This preserves visitor data between upgrades of the SDK. For new installations on the 4.x SDK, user identifier is `null` until set. 

  * Here is the syntax for this method:

    ```csharp
    static Platform::String^GetUserIdentifier();
    ```

  * Here is the code sample for this method:

    ```js
    var ADB = ADBMobile;
    var userId = ADB.Config.getUserIdentifier(); 
    ```

* **SetUserIdentifier (winJS: setUserIdentifier)**

  Sets the user identifier to `identifier`.

  * Here is the syntax for this method:

    ```csharp
    static void SetUserIdentifier(Platform::String ^userIdentifier);
    ```

  * Here is the code sample for this method:

    ```js
    var ADB = ADBMobile;
    ADB.Config.setUserIdentifier("someUserId"); 
    ```

* **GetDebugLogging (winJS: getDebugLogging)**

  Returns the current debug logging preference. The default value is `false`.

  * Here is the syntax for this method:

    ```csharp
    static bool GetDebugLogging(); 
    ```

  * Here is the code sample for this method:

    ```js
    var ADB = ADBMobile;
    var logging = ADB.Config.getDebugLogging(); 
    ```

* **SetDebugLogging (winJS: setDebugLogging)**

  Sets the debug logging preference to `debugLogging`. Debug logging works only when using the debug version of the library, the release version ignores this setting. 

  * Here is the syntax for this method:

    ```csharp
    static void SetDebugLogging(bool debugLogging); 
    ```

  * Here is the code sample for this method:

    ```js
    var ADB = ADBMobile;
    ADB.Config.setDebugLogging(true); 
    ```

* **CollectLifecycleData (winJS: collectLifecycleData)**

  Indicates to the SDK that lifecycle data should be collected for use across all solutions in the SDK. For more information, see [Lifecycle Metrics](/docs/windows-appstore/metrics.md). 
  
  > **Tip:** Invoke this method in the `onResume()` method in each Activity inside of your application, as shown in the following example. We also recommend passing the Activity or Service as the context object instead of the global Application context.

  * Here is the syntax for this method:

    ```csharp
    static void CollectLifecycleData();
    ```

  * Here is the code sample for this method:

    ```js
    var ADB = ADBMobile;
    ADB.Config.collectLifecycleData(); 
    ```

* **PauseCollecting​LifecycleData (winJS: pauseCollecting​LifecycleData)**

  Indicates to the SDK that your app is paused, so that lifecycle metrics are calculated correctly. For example, on pause collects a timestamp to determine previous session length. This also sets a flag so that lifecycle correctly knows that the app did not crash. For more information, see [Lifecycle Metrics](/docs/windows-appstore/metrics.md). 
  
  > **Tip:** Invoke this method in the `onPause()` methods in each Activity inside Your application, as shown in the example. We also recommend passing the Activity or Service as the context object instead of the global Application context. 

  * Here is the syntax for this method:

    ```csharp
    static void PauseCollectingLifecycleData();
    ```

  * Here is the code sample for this method:

    ```js
    var ADB = ADBMobile;
    ADB.Config.pauseCollectingLifecycleData();
    ```
