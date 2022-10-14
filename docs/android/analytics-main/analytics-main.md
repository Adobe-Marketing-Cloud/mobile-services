# Analytics overview

The information in this section helps you use the Android SDK with Adobe Analytics.

## New Adobe Experience Platform Mobile SDK Release

Looking for information and documentation related to the Adobe Experience Platform Mobile SDK? Click [here](https://aep-sdks.gitbook.io/docs/) for our latest documentation.

As of September 2018, we released a new, major version of the SDK. These new Adobe Experience Platform Mobile SDKs are configurable through [Experience Platform Launch](https://www.adobe.com/experience-platform/launch.html).

* To get started, go to Adobe Experience Platform Launch.
* To see what is in the Experience Platform SDK repositories, go to [Github: Adobe Experience Platform SDKs](https://github.com/Adobe-Marketing-Cloud/acp-sdks).

## Generating Analytics tracking identifiers

In the SDKs, identifiers are used to track users, and here is the hierarchy of identifiers:

1. Custom Visitor Identifier (VID)
1. Analytics Tracking Identifier (AID)
1. Experience Cloud Identifier (MID)

> **Tip:** The correct acronym for Experience Cloud Identifier is ECID. Although the SDKs still use MID, it is the old name.

The AID, which is also sometimes referred to as the Tracking Identifier, is generated by the SDK when the app is not configured to use an MID. The value persists between launches and app upgrades in `SharedPreferences`. If the user deletes the app from their device and then re-installs the app, or if the app developer clears out SharedPreferences, a new identifier is generated by the SDK. This process results in a new user in Analytics reporting.

For users in an app that introduces Identity service support (MID), existing AID values are sent with Analytics hits, and the Analytics hit contains an AID and an MID. For new users in an app with Identity service support, the Analytics requests contain only an MID. For more information about identifying visitors, see [Unique visitors](https://experienceleague.adobe.com/docs/analytics/components/metrics/unique-visitors.html) in the Adobe Analytics documentation.