# Testing legacy acquisition

The following information helps you roundtrip a legacy acquisition campaign link on an Android device.

If the mobile app is not yet in Google Play, you can select any mobile app as a destination when creating the campaign link. This only affects the app to which the acquisition server redirects you, after you click the acquisition link, and not the ability to test the acquisition link. Query string parameters are passed to the Google Play store, which are passed to the app at install as part of a campaign broadcast. Roundtrip mobile app acquisition testing requires the simulation of this type of broadcast.

The app must be freshly installed, or have data cleared in **Settings**, each time a test is run. This ensures that the initial lifecycle metrics that are associated with the campaign query string parameters are sent when the app is first launched. 

1. In the Mobile Services UI, generate a legacy acquisition campaign URL.

   For more information, see [Use legacy Acquisition links](https://experienceleague.adobe.com/docs/mobile-services/using/acquisition-main-ug/create-manage-link-destination/legacy-acquisition-links/c-use-legacy-acquisition-links.html).
1. Connect the device to a computer, launch ADB Shell, and launch the application on the device.
1. Send a broadcast using the following format:

   ```
   am broadcast -a com.android.vending.INSTALL_REFERRER -n com.example.adobetesttapp/com.google.analytics.tracking.android.CampaignTrackingReceiver --es "referrer" "utm_source=testSource&utm_medium=testMedium&utm_term=testTerm&utm_content=testContent&utm_campaign=testCampaign&trackingcode=trackingvalue"
   ```

1. Complete the following steps:
   1. Replace `com.example.adobetesttapp.com` with your application's reverse DNS entry.
   1. Update the receiver reference with the campaign tracking receiver location reference in your app.
   1. Replace values that are associated with `utm_source`, `utm_medium`, `utm_term`, `utm_content`, `utm_campaign`, and so on, with appropriate values.

If the broadcast is successful, a response similar to the one below is displayed:

```
Broadcasting: Intent { act=com.android.vending.INSTALL_REFERRER cmp=com.example.analyticsecommtest/com.google.analytics.tracking.android.AnalyticsReceiver has extras) } Broadcast completed: result=0
```

You will also see an image request sent to Adobe's data collection servers. If the SDK waits for the complete duration of the referrer timeout, which you set in step 1, with an image request that does not include campaign parameters, the broadcast failed.
