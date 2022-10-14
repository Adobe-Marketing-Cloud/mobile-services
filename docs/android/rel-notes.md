# Release notes

Here is the release notes, known issues, and hot fix information for Android SDK 4.x for Experience Cloud Solutions:

## April 3, 2020: 4.18.2

* In App Messaging - For security reasons, WebViews created by the SDK now set property `setAllowFileAccess` to `false`.

## March 12, 2020: 4.18.1

* Target – Target Session ID is now added as a context data parameter `a.target.sessionId` in the internal Analytics-for-Target hit sent to Adobe Analytics.

## January 16, 2020: 4.18.0

* Acquisition - Added a new API, `Analytics.processGooglePlayInstallReferrerUrl(final String url)`, to support Google Play Install Referrer APIs.

  For more information about the Install Referrer APIs, see [Still Using InstallBroadcast? Switch to the Play Referrer API by March 1, 2020](https://android-developers.googleblog.com/2019/11/still-using-installbroadcast-switch-to.html).

## September 20, 2019: Version 4.17.10

* General: Fixed locale string generation for some regions on Android API level 21 or newer.

## July 18, 2019: Version 4.17.8

* Adobe Target: All requests now include the client and the sessionId in the URL query parameters.
* In-app Messaging: Fixed an issue where, when a message was triggered with an empty clickthrough URL, Android apps crashed.
* Visitor ID Service: The `Visitor.appendToURL` and `Visitor.getUrlVariablesAsync` APIs no longer double-encode their return values.

   The double-encoding was causing the return values from those APIs to be flagged by certain security reviews.

## June 6, 2019: Version 4.17.7

* General - Networking calls on Android API levels lower than 20 will now use TLS 1.1 or TLS 1.2.
* Analytics - Appended push opt-in status to Lifecycle data when push notifications are enabled.

## May 24, 2019: Version 4.17.6

* visitor ID Service - The `setPushIdentifier` API call now sends a sync call to the Visitor ID Service every time it is called. 
* Visitor ID Service - Increased the connect and read timeouts from 2 seconds to 5 seconds.

For more information about the current and past release notes for all solutions, see [Adobe Experience Cloud Release Notes](https://experienceleague.adobe.com/docs/release-notes/experience-cloud/current.html).
