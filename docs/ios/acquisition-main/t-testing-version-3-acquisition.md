# Testing V3 acquisition

This information helps you roundtrip a V3 acquisition campaign link based on a device fingerprint.

> **Important:** V3 Acquisition refers to the acquisition links that you create with the Acquisition Builder in the Adobe Mobile Services UI. To use this feature, you must upgrade to iOS SDK version 4.6.0 or later.

If the mobile app is not yet in the App Store, when you create the campaign link, select any mobile app as a destination. This only affects the app to which the acquisition server redirects you after you click the acquisition link, but does not affect the ability to test the link. 

1. Complete the prerequisite tasks in [Mobile App Acquisition](/docs/ios/acquisition-main/acquisition.md).
1. Navigate to the **Acquisition Builder** in the Adobe Mobile Services UI and generate an acquisition campaign URL.

   For example:

   ```
   https://c00.adobe.com/v3/<appid>/start?a_i_id=iostestapp&a_g_id=com.adobe.android&a_dd=i&ctxa.referrer.campaign.name=name&ctxa.referrer.campaign.trackingcode=trackingcode
   ```

   If you refer to both iOS and Android apps in the acquisition link, use the Apple Store as the default store. 
1. Open the generated link in a desktop browser and go to `https://c00.adobe.com/v3/<appid>/end`.

   You should see the `contextData` in the JSON response:

   ```js
   {"fingerprint":"228d7e6058b1d731dc7a8b8bd0c15e1d78242f31","timestamp":1457989293,"appguid":"","contextData":{"a.referrer.campaign.name":"name","a.referrer.campaign.trackingcode":"trackingcode"}}.
   ```

   If you do not see `contextData`, or some of it is missing, ensure that the acquisition URL follows the format that is specified in [Create Acquisition Link Manually](https://experienceleague.adobe.com/docs/mobile-services/using/acquisition-main-ug/create-manage-link-destination/legacy-acquisition-links/acquisition-link-manual.html).
1. Verify that the following settings in your config file are correct:

    | Setting | Value |
    |--- |--- |
    |acquisition|The server should be  `c00.adobe.com`. *`appid`* should equal the *`appid`* in your acquisition link.|
    |analytics|`referrerTimeout` should have a value greater than 0.|

1. (Conditional) If the `ssl` setting in your app's config file is true, update your acquisition link to use the HTTPS protocol.
1. Click the generated link from the mobile device on which you plan to install the app.

   Adobe's servers ( `c00.adobe.com`) store the fingerprint and redirect to the App Store. The app does not need to be downloaded for testing.
1. Launch the application for the first time from the same mobile device that you used in step 6.

   You can delete and install the app again, if necessary.
1. (Optional) You can enable debug logging of the SDK to obtain additional information.

   If everything works correctly, you should see following logs:

   `"Analytics - Trying to fetch referrer data from <acquisition end url>"`
   `"Analytics - Received Referrer Data(<Json Object>)"`

   If you do not see the above logs, ensure that you have completed steps 4 and 5.

   Here is some information about possible errors:

   * `Analytics - Unable to retrieve acquisition service response (<error message>)`
      A network error occurred.

   * `Analytics - Unable to parse acquisition service response (<error message>)`

     The response is not in the correct format.

   * `Analytics - Unable to parse acquisition service response (no contextData parameter in response)`

     There is no `contextData` parameter in the response.

   * `Analytics - Acquisition referrer data was not complete, ignoring`

     `a.referrer.campaign.name` is not included in `contextData`.

   * `Analytics - Acquisition referrer timed out`

     Failed to get the response in the time that is defined by `referrerTimeout`. Increase the value and try again. You should also ensure that you opened the acquisition link before installing the app and that you are using the same network when you click the URL and open the app.

     Remember the following information:

     * The acquisition server provides an attribution match that is based on the IP address and user-agent information that is recorded in the link click (step 6) and when the app is launched (step 7).

        You should be on the same network when you click the URL and when you open the app.

     * By using HTTP monitoring tools, hits sent from the app can be monitored to provide verification of the acquisition attribution.

       You should see one `/v3/<appid>/start` request and one `/v3/<appid>/end` request sent to the acquisition server. Variations in the user-agent sent might cause attribution to fail.

       > **Tip:** Ensure that `https://c00.adobe.com/v3/<appid>/start` and `https://c00.adobe.com/v3/<appid>/end` have the same user-agent values.

     * The acquisition link and the hit from the SDK should be using the same HTTP/HTTPS protocol.

       If they are using different protocols (for example, the link uses HTTP and the SDK uses HTTPS), the IP address might differ for each request (on some carriers), and the attribution might fail.
