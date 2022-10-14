# Stand-alone extension implementation

Starting with iOS 10, Apple allows you to create an extension called a stand-alone extension that can be distributed without a containing app. With this extension, you do not need an app group, as there is no containing app with which to share data.

> **Important:** To use stand-alone extensions, you must have Mobile SDK version 4.13.0 or later.

## Configure your stand-alone extension for use with the SDK

To configure your stand-alone extension:

1. Ensure that the `ADBMobileConfig.json` file is a member of your extension's target. 
1. Link the following libraries and frameworks:

    * `AdobeMobileLibrary_Extension.a` 
    * `libsqlite3.tbd` 
    * `SystemConfiguration.framework`

1. In the main view controller of your extension, set the extension type to `ADBMobileAppExtensionTypeStandAlone` in the SDK before completing any SDK-related activities. 

   ```objective-c
   [ADBMobile setAppExtensionType:ADBMobileAppExtensionTypeStandAlone];
   ```

1. Confirm that your app builds without unexpected errors.

## Additional notes

Here is some additional information:

* An additional context data value, `a.RunMode` has been added to indicate whether the data comes from your containing app or your extension:

  * `a.RunMode = Application`
  
     This value means that the hit came from the containing app. 
  * `a.RunMode = Extension`
  
    This value means that the hit came from the extension.

* No lifecycle call is triggered on iOS extension apps.
