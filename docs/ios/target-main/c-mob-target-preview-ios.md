# Target Preview on iOS

Target Preview allows you to easily perform end-to-end QA for Target activities and preview these activities on your device.

For more information on how to set up and use Target Preview, see [Target mobile preview](https://experienceleague.adobe.com/docs/target/using/implement-target/mobile-apps/target-mobile-preview.html) in the Adobe Target documentation.

> **Important:** To use Target Preview, you need SDK version 4.14.0 or later.

## Target Preview method

* **setPreviewRestartDeeplink**

  Sets an app deeplink that will be triggered when preview selections are applied in the Preview mode. 

  * Here is the syntax for this method:

    ```objective-c
     + (void) targetPreviewRestartDeepLink:(nullable NSString *)callbackURL;
    ```

  * Here is the code sample for this method:

    ```objective-c
    [ADBMobile targetPreviewRestartDeepLink:@"myapp://myhost"]; 
    ```
