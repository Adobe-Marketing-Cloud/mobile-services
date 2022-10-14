# Release notes

Here is the release notes, known issues, and hot fix information for iOS SDKs 4.x for Experience Cloud Solutions:

## April 13, 2021: Version 4.21.2

* Visitor ID Service - Fixed an issue where empty advertising identifiers were synced to the Visitor ID Service.

## January 13, 2021: Version 4.21.1

* General - Fixed an issue that could cause SQLite exceptions during app shut down.

## December 15, 2020: Version 4.21.0

* General - The SDK is now distributed using XCFrameworks in order to support hardware with the new Apple M1 architecture while maintaining support for existing Intel architecture.
  * IMPORTANT: Upgrading to AdobeMobile XCFrameworks requires Xcode 12.0 or newer
  * IMPORTANT: If using Cocoapods, upgrading to AdobeMobile XCFrameworks requires Cocoapods 1.10.0 or newer

## November 4, 2020: Version 4.20.0

* Visitor ID Service - Added device_consent status parameter when setAdvertisingIdentifier is called after ad tracking is enabled/disabled.
* Analytics - Fixed a bug that was delaying Analytics hits from being sent on an install when iAd.framework is linked and the device has "Limited Ad Tracking" enabled.

## July 16, 2020: Version 4.19.3

* General – Fixed a bug that prevented deeplink URLs with multiple equals sign in query param from being properly handled.

## March 24, 2020: Version 4.19.2

* General - Fixed some leaks in Target code.

## March 12, 2020: Version 4.19.1

* General - Resolved a potential crash caused when Swift enums are included in context data for tracking calls.
* Target – Target Session Id will now be added as a context data parameter ‘a.target.sessionId’ in the internal Analytics for Target hit sent to Adobe Analytics.

## Feburary 4, 2020: Version 4.19.0

* Lifecycle - Added a new API, pauseCollectingLifecycleData, to mitigate the abnormal session length data that was reported from some old iOS devices.

## November 8, 2019: Version 4.18.9

* In App Messaging - Fixed a bug where cached or bundled images could not be loaded in the full screen messages.

## September 20, 2019: Version 4.18.8

* In App Messaging:

  * On devices running iOS 10 or newer, the `UserNotifications` framework is now used to schedule local notifications for apps that are linked to the `UserNotifications.framework`.
  * Fullscreen messages now use WKWebViews from `WebKit.framework`, which must be linked in your Xcode project.
  * Fixed a bug where the Push click-through payload could not be used as traits for In-App Messaging.
  * Fixed a crash issue.

* General - Fixed a bug where SDK data was synchronized to the paired watchOS app on every Analytics call.

## August 2, 2019: Version 4.18.7

* Reverted a change that was introduced in version 4.18.6 which, in some environments, caused a crash on devices that were running an iOS version older than 11.0.

* Adobe Target: Added the `requestLocationParameters` property in `ADBTargetRequestObject`, which enables the impressionId to be sent with Target requests.

## July 18, 2019: Version 4.18.6

* Adobe Target: All requests now include the client and the `sessionId` in the URL query parameters.
* Adobe Target: Fixed a memory leak.
* Visitor ID Service: The `visitorAppendToURL` and `visitorGetUrlVariablesAsync` APIs no longer double-encode their return values.

  The double-encoding was causing the return values from those APIs to be flagged by certain security reviews.

## June 5, 2019: Version 4.18.5

* Analytics - Append push opt-in status to Lifecycle data when push notifications are enabled.

## May 24, 2019: Version 4.18.4

* Visitor ID Service - Increased the return timeout for the
`visitorGetUrlVariablesAsync` API to 30 seconds.

* Visitor ID Service - The `setPushIdentifier` API call now sends a sync call to the Visitor ID Service every time it is called.

For more information about the current and past release notes for all solutions, see [Adobe Experience Cloud Release Notes](https://experienceleague.adobe.com/docs/release-notes/experience-cloud/current.html).
