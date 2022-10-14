# iOS SDK 4.x for Experience Cloud Solutions

iOS SDK 4.x for Experience Cloud Solutions lets you measure native Apple iPhone and iPad applications, deliver targeted content within your apps, and leverage and collect audience data through Audience Manager.

> **Important:** Starting with version 4.21.0, the iOS SDK has a minimum required version of Xcode 12. If you are using Cocoapods to manage dependencies in your app, the Adobe SDK requires version 1.10.0 or newer of Cocoapods.

If using 4.21.0 or newer, read the documentation with the following changes in mind:

* Any time a binary library file is mentioned, its XCFramework replacement should be used instead:
    * `AdobeMobileLibrary.a` > `AdobeMobile.xcframework`
    * `AdobeMobileLibrary_Extension.a` > `AdobeMobileExtension.xcframework`
    * `AdobeMobileLibrary_Watch.a` > `AdobeMobileWatch.xcframework`
    * `AdobeMobileLibrary_TV.a` > `AdobeMobileTV.xcframework`
* If manually adding the Adobe XCFrameworks to your project, ensure that they are not embedded.

> **Important:** The Adobe Analytics Mobile Marketing Add-on SKU is required to enable Mobile Services access to mobile acquisition, deep linking, geolocation, and mobile messaging capabilities. For more information, contact your Adobe CSM.

> **Important:** The iOS SDK 4.x for Experience Cloud Solutions is now supports [iOS 13 and Xcode 11](https://developer.apple.com/ios/). To ensure seamless compatibility, use the latest versions of the 4.x iOS SDKs. For more information about the latest version, see the [release notes](/docs/ios/rel-notes.md).

## New Adobe Experience Platform Mobile SDK Release

Looking for information and documentation related to the Adobe Experience Platform Mobile SDK? Click [here](https://aep-sdks.gitbook.io/docs/) for our latest documentation.

As of September 2018, we released a new, major version of the SDK. These new Adobe Experience Platform Mobile SDKs are configurable through [Experience Platform Launch](https://www.adobe.com/experience-platform/launch.html).

* To get started, go to Adobe Experience Platform Launch.
* To see what is in the Experience Platform SDK repositories, go to [Github: Adobe Experience Platform SDKs](https://github.com/Adobe-Marketing-Cloud/acp-sdks).

Some information to remember:

* iOS 8 or later is supported

  For iOS 11 or later, you **must** have SDK version 4.13.8 or later.

* In version 4.2 of this SDK and later, all hits are now sent using HTTP POST.

  This has no impact on the data that is collected or reported, but you need to use a packet analyzer that supports inspecting POST data to view hits.

* If you are upgrading from a previous version (2.x or 3.x), see the [4.x Migration Guide](/docs/ios/getting-started/migration-v3.md).

## Adobe Mobile User Documentation

Adobe Mobile services provides a UI that brings together mobile marketing capabilities for mobile applications from across the Adobe Experience Cloud. Initially, the Mobile service provides seamless integration of app analytics and targeting capabilities from the Adobe Analytics, Adobe Audience Manager, and Adobe Target solutions, and Adobe Experience Platform Identity Service.

To learn more about the Mobile Services UI and read the user documentation, see [Adobe Mobile Services](https://experienceleague.adobe.com/docs/mobile-services/using/home.html).

## Using Bloodhound

> **Important:** As of **April 30, 2017**, Adobe Bloodhound has been sunset. Starting on May 1, 2017, no additional enhancements and no additional Engineering or Adobe Expert Care support will be provided.
