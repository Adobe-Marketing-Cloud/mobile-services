# Configuration methods

Here is the list of methods that are provided by the Android library.

## Initial configuration

The following method must be called once in the `onCreate` method of your main activity: 

* `setContext`
  Here is the code sample for this method:

  ```java
   @Override
   public void onCreate(BundlesavedInstanceState){
     super.onCreate(savedInstanceState)
     setContentView(R.layout.main);
     Config.setContext(this.getApplicationContext());
   }
  ```

## SDK settings (Config Class)

* **registerAdobeDataCallback**

  * Registers an object that implements the `AdobeDataCallback` interface. The overwritten "call" method will be invoked with a `Config.MobileDataEvent` value and the associated data in a `Map<String, Object>` for the triggering event. For more details about which events will trigger this callback, see *MobileDataEventEnum* at the bottom of this topic. 

    > **Tip:** This method requires version 4.9.0 or later. 

  * Here is the syntax for this method:

    ```java
    public static void registerAdobeDataCallback(final AdobeDataCallback&amp;nbsp;callback);
    ```

  * Here is the code sample for this method:

    ```java
      Config.registerAdobeDataCallback(new Config.AdobeDataCallback() {
        @Override
        public void call(Config.MobileDataEvent event, Map<String, Object> contextData) {
            // handle each event type accordingly 
            if (event == Config.MobileDataEvent.MOBILE_EVENT_ACQUISITION_INSTALL) {
                 // do something with acquisition data found in contextData parameter
                 HashMap<String, Object> acquisitionData = new HashMap<String, Object>(contextData);
            }
        }
    });
    ```

* **getVersion**

  * Returns the current version of the Adobe Mobile library.
  * Here is the syntax for this method:

    ```java
    public static String getVersion();
    ```

  * Here is a code example for this method:

    ```java
    String libraryVersion = Config.getVersion(); 
    ```

* **getPrivacyStatus**

  * Returns the enum representation of the privacy status for current user.
  
    Here are the privacy status values: 

    * `MOBILE_PRIVACY_STATUS_OPT_IN`, where the hits are sent immediately.  
    * `MOBILE_PRIVACY_STATUS_OPT_OUT`, where the its are discarded.  
    * `MOBILE_PRIVACY_STATUS_UNKNOWN`, where if your report suite is timestamp enabled, hits are saved until the privacy status changes to opt-in (hits are sent) or opt-out (hits are discarded).

      If your report suite is not timestamp enabled, hits are discarded until the privacy status changes to opt in. The default value is set in the `ADBMobileConfig.json` file. 

  * Here is the syntax for this method:

      ```java
      public static MobilePrivacyStatus getPrivacyStatus(); 
      ```

  * Here is a code sample for this method:

    ```java
    MobilePrivacyStatus privacyStatus Config.getPrivacyStatus();
    ```

* **setPrivacyStatus**

  * Sets the privacy status for the current user to `status`. 
  
    You can set the privacy status to one of the following values: 
    * `MOBILE_PRIVACY_STATUS_OPT_IN`, where the hits are sent immediately. These hits are sent immediately.  
    * `MOBILE_PRIVACY_STATUS_OPT_OUT`, where the its are discarded. These hits are discarded.  
    * `MOBILE_PRIVACY_STATUS_UNKNOWN`, where if your report suite is timestamp enabled, hits are saved until the privacy status changes to opt-in (hits are sent) or opt-out (hits are discarded).
    If your report suite is not timestamp enabled, hits are discarded until the privacy status changes to opt in. 

  * Here is the syntax for this method:

    ```java
    public static void setPrivacyStatus(MobilePrivacyStatus status); 
    ```

  * Here is a code sample for this method:

    ```java
    Config.setPrivacyStatus(MobilePrivacyStatus.MOBILE_PRIVACY_STATUS_OPT_IN); 
    ```

* **getLifetimeValue**

  * Returns the lifetime value of the current user. The default value is `0`. 

  * Here is the syntax for this method:

    ```java
    public static BigDecimal getLifetimeValue();
    ```

  * Here is a code sample for this method:

    ```java
    BigDecimal currentLifetimeValue Config.getLifetimeValue(); 
    ```

* **getUserIdentifier**

  * If a custom identifier has been set, the custom user identifier is returned. If a custom identifier has not been set, it returns `null`. The default value is `null`. 
  
    > **Tip:** If your app upgrades from the Experience Cloud 3.x to the 4.x SDK, the previous custom or automatically generated visitor ID is retrieved and stored as the custom user identifier. This preserves visitor data between SDK upgrades. For new installations on the 4.x SDK, until it is set, the user identifier is `null`. 

  * Here is the syntax for this method:

    ```java
    public static String&amp getUserIdentifier();
    ```

  * Here the code sample for this method:

    ```java
    String userId = Config.getUserIdentifier();
    ```

* **setUserIdentifier**

  * Sets the user identifier to `identifier`. 
  * Here is the syntax for this method:

    ```java
    public static void setUserIdentifer(String identifier);
    ```

  * Here is the code sample for this method:

    ```java
    Config.setUserIdentifier("billybob"); 
    ```

* **getDebugLogging**

  * Returns the current debug logging preference. The default value is `false`.
  * Here is the syntax for this method:
  
    ```java
    public static Boolean getDebugLogging(); 
    ```

  * Here is the code sample for this method:

    ```java
    Boolean debugging = Config.getDebugLogging(); 
    ```

* **setDebugLogging**
  * Sets the debug logging preference to `debugLogging`.
  * Here is the syntax for this method:

    ```java
    public static void setDebugLogging(Boolea debugLogging);
    ```

  * Here is the code sample for this method:

    ```java
    Config.setDebugLogging(true);
    ```

* **collectLifecycleData**
  * Indicates to the SDK that lifecycle data should be collected for use across all solutions in the SDK. For more information, see [Lifecycle Metrics](/docs/android/configuration/methods.md).
  
  * Here is the syntax for this method:

    ```java
    public static void collectLifecycleData(final Activity activity,final Map<String, Object>contextData); 
    ```

  * Here is the code sample for this method:

    ```java
    @Override
    protectedvoid  onResume()  {
      super.onResume();
      Config.collectLifecycleData(this);
      } 
    ```

    With extra context data:

    ```java
    @Override
    public  void  onResume()  {
      HashMap<String, Object> contextData = new HashMap<String, Object>();
      contextData.put("myapp.category", "Game");        Config.collectLifecycleData(this, contextData);} 
    ```

* **collectLifecycleData (Activity activity)**

  * (**Version 4.2 or later**) Indicates to the SDK that lifecycle data should be collected for use across all solutions in the SDK. For more information, see [Lifecycle Metrics](/docs/android/metrics.md).
  * Here is the syntax for this method:

      ```java
      public static void collectLifecycleData(final Activity activity);
      ```

  * Here is the code sample for this method:

      ```java
      @Overrideprotected void onResume() {
        super.onResume()
        // assume being called in an Activity class Config.collectLifecycleData(this);
        } 
      ```

* **pauseCollecting​LifecycleData**

  * Indicates to the SDK that your app is paused, so that lifecycle metrics are calculated correctly. For example, `onPause` collects a timestamp to determine the previous session length. This also sets a flag so that lifecycle knows that the app did not crash. For more information, see [Lifecycle Metrics](/docs/android/metrics.md). 

  * Here is the syntax for this method:

    ```java
    public static void pauseCollectingLifecycleData(); 
    ```

  * Here is the code sample for this method:

    ```java
    @Override
    protected void onPause() {
      super.onPause();
      Config.pauseCollectingLifecycleData();
    } 
    ```

* **setSmallIconResourceId(int resourceId)**

  * (**Version 4.2 or later**) Sets the small icon that will be used for notifications that were created by the SDK. This icon will appear in the status bar and will be the secondary image that is displayed when the user sees the complete notification in the notification center.
  * Here is the syntax for this method:

    ```java
    public static void setSmallIconResourceId(final int resourceId); 
    ```

  * Here is the code sample for this method:

    ```java
    Config.setSmallIconResourceId(R.drawable.appIcon);
    ```

* **setLargeIconResourceId(int resourceId)**

  * (**Version 4.2 or later**) Sets the large icon that will be used for notifications that were created by the SDK. This icon will be the primary image that is displayed when the user sees the complete notification in the notification center. 
  * Here is the syntax for this method:

    ```java
    public static void setLargeIconResourceId(final int  resourceId);
    ```

  * Here is the code sample for this method:

    ```Java
    Config.setLargeIconResourceId(R.drawable.appIcon);
    ```

* **overrideConfigStream(InputStream configInput)**

  * (**Version 4.2 or later**) Allows you to load a different ADBMobile JSON config file when the application starts. The different configuration is used until the application is closed. 
  * Here is the syntax for this method:

    ```java
    public static void overrideConfigStream(final InputStream configInput);
    ```

  * Here is the code sample for this method:

    ```java
     try {
        InputStream configInput = getAssets().open("ExampleJSONFile.json") 
        Config.overrideConfigStream(configInput)
        } catch (IOException ex) { 
        //do something with the exception if needed
    }
    ``` 

* **setPushIdentifier**

  * Sets the device token for push notifications. 
  * Here is the syntax for this method:

    ```java
    public static void setPushIdentifier(final String registrationId); 
    ```

  * Here is the code sample for this method:

    ```java
    ...// note the code to retreive the push token must run in the background
    InstanceID instanceID= InstanceID.getInstance(getApplicationContext());String token=instanceID.getToken("835015092242", GoogleCloudMessaging.INSTANCE_ID_SCOPE null);Config.setPushIdentifier(token);
    ...
    ```

* **submitAdvertisingIdentifierTask**

  * Provides a Callable to the SDK that returns the string of the Advertising Identifier that is returned from Google Play Services. The SDK runs this task on a background thread and sets an internal variable for the Advertising Identifier that is based on the value returned from the Callable. 
  
    > **Important:** If you want to use the Advertising Identifier in Acquisition or Lifecycle, call it before calling `Config.collectLifecycleData`.

    * Here is the syntax for this method:

      ```java
      public static void submitAdvertisingIdentifierTask(final Callable<String> task); 
      ```

    * Here is the code sample for this method:
  
      ```java
      @Override
      public void  onResume() {
          super.onResume();
          final  Callable<String>; task = new Callable<String>(){
              @Override
              public String call() throws Exception {
                 AdvertisingIdClient.Info idInfo;
                 String adid = null;
                 Context appContext = CLASSNAME.this.getApplicationContext();
                 try {
                      idInfo = AdvertisingIdClient.getAdvertisingIdInfo(appContext);
                      if (idInfo != null) { 
                          adid = idInfo.getId();
                      } 
                 } catch  (Exception ex) {
                     Log.e("Error",  ex.getLocalizedMessage());
                 }
                 return  adid;
              }
        };
        Config.submitAdvertisingIdentifierTask(task); 
        Config.collectLifecycleData(this);
      }
      ```


## AdobeDataCallback Interface

```java
public interface AdobeDataCallback {  
    void call(MobileDataEvent event, Map<String, Object> contextData);  
} 
```

## MobileDataEvent Enum

```java
public enum MobileDataEvent {  
    MobileDataEvent.MOBILE_EVENT_LIFECYCLE, // triggers on a lifecycle hit  
    MobileDataEvent.MOBILE_EVENT_ACQUISITION_INSTALL, // triggers on a app install that has acquisition data  
    MobileDataEvent.MOBILE_EVENT_ACQUISITION_LAUNCH // triggers on launch when the device previously installed via acquisition  
}
```
