# Apple Search Ads

The Adobe SDK leverages Apple's Search Ads App Attribution APIs to enable developers and marketers to track and attribute app downloads that originate from Search Ads campaigns in the Apple App Store. For more information about Search Ad campaigns, see [Apple Search Ads](https://searchads.apple.com).

## Benefits

Here are some benefits to using Apple ads:

* Easily measure the effectiveness of your Search Ads app download campaigns by adding a few lines of code to your app. 
* Developers can access the date/time of the download and the bidded keyword that drove the conversion.

## Implementing Apple Ads

> **Tip:** To implement Apple Ads, you must have iOS SDK version 4.13.2 or later.

To enable your app for Search Ad attribution:

1. Implement the Adobe SDK version 4.13.2 or above.

   For more information, see [Core implementation and lifecycle](/docs/ios/getting-started/dev-qs.md). 

1. Add the iAd framework to the Xcode project file for your app.

## Reporting on Search Ads Attribution

1. Apple Search Ads attribution data is provided in the acquisition name, the source, and the term values.

   If attribution = `true`, all of the `iad-*` fields will be included in the lifecycle hit.

   In addition, the following values will be mapped from the `"iad"` dictionary to our typical acquisition context data fields:

    * `"iad-campaign-id"` --> `"a.referrer.campaign.trackingcode"`
    * `"iad-campaign-name"` --> `"a.referrer.campaign.name"`
    * `"iad-adgroup-id"` --> `"a.referrer.campaign.content"`
    * `"iad-keyword"` --> `"a.referrer.campaign.term"`

   This mapping ensures that the values are available in our standard reporting.
