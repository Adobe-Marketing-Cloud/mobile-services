# iOS extension implementation

You can use the iOS extension helps you collect usage data from your Apple Watch Apps (WatchOS 1), Today Widgets, Photo Editing widgets, and other iOS extension apps.

## New Adobe Experience Platform Mobile SDK Release

Looking for information and documentation related to the Adobe Experience Platform Mobile SDK? Click [here](https://aep-sdks.gitbook.io/docs/) for our latest documentation.

As of September 2018, we released a new, major version of the SDK. These new Adobe Experience Platform Mobile SDKs are configurable through [Experience Platform Launch](https://www.adobe.com/experience-platform/launch.html).

* To get started, go to Adobe Experience Platform Launch.
* To see what is in the Experience Platform SDK repositories, go to [Github: Adobe Experience Platform SDKs](https://github.com/Adobe-Marketing-Cloud/acp-sdks).

## Recommendations for using the iOS SDK instead of your wrapper

> **Important:** We strongly recommend that you use the iOS SDK rather than your wrapper.

Apple provides a set of APIs that lets the Watch app communicate with the containing app by sending requests to the containing app and receiving the responses. Although you can send tracking data as a dictionary from the Watch app to the containing app and call any tracking method on the containing app to send the data, this solution has limitations.

In most cases when a user is using the Watch app, the containing app is running in the background, and it is only safe to call `TrackActionInBackground`, `TrackLocation`, and `TrackBeacon`. Calling other tracking methods interferes with lifecycle data, so you should use only these three methods to send the data from Watch app.

Even if these three tracking methods meet your requirements, use the iOS SDK, because the SDK for the Watch app includes all Mobile features except in-app messaging.

## Getting started

> **Important:** Ensure that you have a project with at least the following targets: 
>
>* One target to contain the app. 
>* One target for the extension. 
>

If you are working on a WatchKit app, you should have a third target. For more information on developing for Apple Watch, see [Developing for Apple Watch](https://developer.apple.com/library/ios/documentation/General/Conceptual/WatchKitProgrammingGuide/index.html#//apple_ref/doc/uid/TP40014969-CH8-SW1).

## Configure the containing app

Complete the following steps in your Xcode project:

1. Drag the AdobeMobileLibrary folder into your project. 
1. Ensure that the `ADBMobileConfig.json` file is a member of the containing app's target. 
1. On the **Build Phases** tab of your containing app's target, expand the **Link Binary with Libraries** section and add the following libraries:

    * `AdobeMobileLibrary.a` 
    * `libsqlite3.dylib` 
    * `SystemConfiguration.framework`

1. Open the **Capabilities** tab of the containing app's target, enable **App Groups**, and add a new app group (for example, `group.com.adobe.testAp`). 

1. In your application delegate, set the app group in `application:didFinishLaunchingWithOptions` before making any interactions with the Adobe Mobile library:

   ```objective-c
   [ADBMobile 
         setAppGroup:@"group.com.adobe.testApp"];
   ```

1. Confirm that your app builds without unexpected errors.

## Configure the extension

1. Ensure that the `ADBMobileConfig.json` file is a member of the extension's target. 
1. On the **Build Phases** tab of your extension’s target, expand the **Link Binary with Libraries** section and add the following libraries:

    * `AdobeMobileLibrary_Extension.a` 
    * `libsqlite3.dylib` 
    * `SystemConfiguration.framework`

1. Open the **Capabilities** tab of the extension's target, enable **App Groups**, and select the app group that you added in step 4 of *Configuring the Containing App* above. 

1. In your InterfaceController, set the app group in `awakeWithContext:` before making any other interactions with the Adobe Mobile library:

   ```objective-c
   [ADBMobile 
         setAppGroup:@"group.com.adobe.testApp"];
   ```

1. Confirm that your app builds without unexpected errors.

## Additional notes

Here is some information to remember:

* An additional context data value, `a.RunMode` has been added to indicate whether the data comes from your containing app or your extension:

  * `a.RunMode = Application`
  
    This value means that the hit came from the containing app. 
  * `a.RunMode = Extension` 

    This value means that the hit came from the extension.

* If you upgrade from a older version of the SDK, when the containing app is launched, Adobe automatically migrates all the user defaults and cached files from the containing app's folder to the app group's shared folder. 
* If the containing app is never launched, hits from the extension are discarded. 
* The version number and build number must be the same between your containing app and the extension app. 
* No lifecycle call is triggered on iOS extension apps.
