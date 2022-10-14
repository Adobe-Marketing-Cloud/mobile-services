# Apple TV implementation with tvOS

This information helps you implement Apple TV with tvOS.

## New Adobe Experience Platform Mobile SDK Release

Looking for information and documentation related to the Adobe Experience Platform Mobile SDK? Click [here](https://aep-sdks.gitbook.io/docs/) for our latest documentation.

As of September 2018, we released a new, major version of the SDK. These new Adobe Experience Platform Mobile SDKs are configurable through [Experience Platform Launch](https://www.adobe.com/experience-platform/launch.html).

* To get started, go to Adobe Experience Platform Launch.
* To see what is in the Experience Platform SDK repositories, go to [Github: Adobe Experience Platform SDKs](https://github.com/Adobe-Marketing-Cloud/acp-sdks).

## Overview

With Apple TV, you can now create applications to run in the native tvOS environment. You can create a native app by using several frameworks in iOS, or you can create your app by using XML templates and JavaScript.

> **Tip:** tvOS support is available starting in `AdobeMobileLibrary` version 4.7.0.

## Getting started

> **Tip:** We assume that your project has a target that is an Apple TV app that is targeting tvOS. For more information, see [tvOS](https://developer.apple.com/tvos/documentation/).

## Configure a native app for tvOS

Complete the following steps in your Xcode project:

1. Drag the AdobeMobileLibrary folder into your project. 
1. Ensure that the `ADBMobileConfig.json` file is a member of your target. 
1. On the **Build Phases** tab of your tvOS app’s target, expand the **Link Binary with Libraries** section and add the following libraries:

   * `AdobeMobileLibrary_TV.a` 
   * `libsqlite3.0.tbd`
   * `SystemConfiguration.framework`

For information, see the iOS documentation on [iOS](https://developer.apple.com/ios/resources/).

## Configure a TVML/TVJS app for tvOS

1. Drag the `AdobeMobileLibrary` folder into your project. 
1. Ensure that the `ADBMobileConfig.json` file is a member of your target. 
1. On the **Build Phases** tab of your tvOS app’s target, expand the **Link Binary with Libraries** section and add the following libraries:

    * `AdobeMobileLibrary_TV.a` 
    * `libsqlite3.0.tbd` 
    * `SystemConfiguration.framework`

1. In the implementation file of your `TVApplicationControllerDelegate` class, import the SDK.

   ```objective-c
   #import "ADBMobile.h"
   ```

1. In the `application:didFinishLaunchWithOptions:` method of your `TVApplicationControllerDelegate` class, pass your `TVApplicationController` object to the SDK with the `installTVMLHooks:` method.

   The Adobe SDK needs access to your app’s `TVApplicationController` to register itself into the JSContext of your app. This step allows you to call the native methods in the Adobe SDK from your JavaScript files.

   ```objective-c
   [ADBMobile installTVMLHooks:appController];
   ```

1. In your JavaScript files, use the `ADBMobile` object to access the native methods of the Adobe SDK.

   For a complete listing of the available methods, see [TVJS Methods](/docs/ios/apple-tv-implementation-tvos/tvjs-methods.md).
