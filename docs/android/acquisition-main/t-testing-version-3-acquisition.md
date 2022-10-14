# Testing V3 acquisition

This information helps you roundtrip a version 3 acquisition campaign link on an Android device.

> **Important:** Acquisition in V3 refers to the acquisition links that you create with the Acquisition Builder in the Adobe Mobile Services UI. To use this feature, you must upgrade to Android SDK 4.x for Experience Cloud Solutions 4.6.0 or later.

If the mobile app is not yet in Google Play, when creating the campaign link, you can select any mobile app as a destination. This only affects the app to which the acquisition server redirects you after you click the acquisition link, but does not affect the ability to test the link. Query string parameters are passed to the Google Play store, which are passed to the app at install as part of a campaign broadcast. Roundtrip mobile app acquisition testing requires the simulation of this type of broadcast.

> **Important:** If you are implementing by using the Google Play Install Referrer APIs, you cannot test acquisition before your app is in the Google Play store.

The app must be freshly installed, or have data cleared in **Settings**, each time a test is run. This ensures that the initial lifecycle metrics that are associated with the campaign query string parameters are sent when the app is first launched.

1. Complete the prerequisite tasks in [Mobile App Acquisition](/docs/android/acquisition-main/acquisition.md) and ensure that you have correctly implemented the broadcast receiver for `INSTALL_REFERRER`.

1. In the Adobe Mobile Services UI, click  **Acquisition** > **Marketing Links Builder** and generate an Acquisition Marketing Link URL that sets Google Play as the destination for Android devices.

   For more information, see [Marketing Links Builder](https://experienceleague.adobe.com/docs/mobile-services/using/acquisition-main-ug/create-manage-link-destination/marketing-links-builder/c-marketing-links-builder.html).

   For example, `https://c00.adobe.com/v3/<appid>/start?a_i_id=iostestapp&a_g_id=com.adobe.android&a_dd=g&ctxa.referrer.campaign.name=name&ctxa.referrer.campaign.trackingcode=trackingcode`.

   > **Tip:** If you refer to both Android and iOS apps in the acquisition link, use Google Play as the default store.

2. Open the generated link in a desktop browser.

    You should be redirected to a page with a URL similar to the following example:
   `https://play.google.com/store/apps/details?id=com.adobe.android&referrer=utm_campaign%3Dadb_acq_v3%26utm_source%3Dadb_acq_v3%26utm_content%3D91b52ce097b1464b9b47cb2995c493cc6ab2c3a3`

3. Copy the unique ID after `utm_content%3D`.

   In the previous example, the ID is `91b52ce097b1464b9b47cb2995c493cc6ab2c3a3`.

4. Construct the acquisition end link by using the unique ID from step 3 by using the following format:

   `https://c00.adobe.com/v3/<appid>/end?a_ugid=<unique id>`.

   For example, `https://c00.adobe.com/v3/<appid>/end?a_ugid=91b52ce097b1464b9b47cb2995c493cc6ab2c3a3`.

5. Open the link in a desktop browser.

   You should be see the `contextData` in the JSON response:

   `{"fingerprint":"228d7e6058b1d731dc7a8b8bd0c15e1d78242f31","timestamp":1457989293,"appguid":"","contextData":{"a.referrer.campaign.name":"name","a.referrer.campaign.trackingcode":"trackingcode"}}.`

   If you do not see `contextData`, or some of the string is missing, ensure that the acquisition URL follows the format in [Create Acquisition Link Manually](https://experienceleague.adobe.com/docs/mobile-services/using/acquisition-main-ug/create-manage-link-destination/marketing-links-builder/c-marketing-links-builder.html).
6. Repeat step 3 to obtain a new unique ID.
7. Verify that the following settings in your config file are correct:

    | Setting | Value |
    |--- |--- |
    |acquisition|The server should be `c00.adobe.com`.   *`appid`*  should equal the `appid`  in your acquisition link.|
    |analytics|For testing purposes, set the referrer timeout to allow for adequate time (60 seconds or more) to manually send the broadcast. You can restore the original timeout setting after testing.|

8. Connect the device to a computer, uninstall, and install the app again.
9. Launch ADB Shell and launch the application on the device.
10. Send a broadcast by using the following `adb` command:

   `am broadcast -a com.android.vending.INSTALL_REFERRER -n com.adobe.android/com.adobe.android.YourBroadcastReceiver --es "referrer" "utm_source=adb_acq_v3&utm_campaign=adb_acq_v3&utm_content=<unique id get on step 5>"`

11. Complete the following steps:
   1. Replace `com.adobe.android` with your application's package name.
   2. Update the receiver reference with that of the location of the campaign tracking receiver in your app
   3. Replace values that are associated with `utm_content`.

   If the broadcast is successful, you can expect a response similar to the following example:

   ```
   Broadcasting: Intent
   { act=com.android.vending.INSTALL_REFERRER cmp=com.adobe.adms.tests/.ReferralReceiver (has extras) }
   Broadcast completed: result=0
   ```

12. (Optional) You can enable debug logging of the SDK to obtain additional information.

   If everything works correctly, you should see following logs:

  `"Analytics - Received referrer information(<referrer content>)"   "Analytics - Trying to fetch referrer data from (acquisition end url)"; "Analytics - Received Referrer Data(<A JSON Response>)"`

   If you do not see the above logs, verify that you completed steps 6 to 12.

   The following table contains additional information about the possible errors:

  | Error | Description|
  |--- |--- |
  |Analytics - Unable to decode response(*String*).|The response is malformed.|
  |Analytics - Unable to parse response (*a JSON Response*).|The JSON string is malformed.|
  |Analytics - Unable to parse acquisition service response (no contextData parameter in response).|There in no  contextData  parameter in the response.|
  |Analytics - Acquisition referrer data was not complete (no `a.referrer.campaign.name` in context data), ignoring.|`a.referrer.campaign.name`  is not included in  contextData.|
  |Analytics - Acquisition referrer timed out.|Failed to get the response in the time defined by `referrerTimeout`. Increase the value and try again.  You should also ensure that you have opened the acquisition link before installing the app.|

Remember the following information:

* Hits sent from the app can be monitored by using HTTP monitoring tools to verify the acquisition attribution.
* For more information about how to broadcast `INSTALL_REFERRER`, see [Testing Google Play Campaign Measurement](https://developers.google.com/analytics/solutions/testing-play-campaigns) in the Google Developers guide.

* A bug fix was released for acquisition on Android 4.8.2.

  Before testing, upgrade the SDK to the latest version.

* You can use the provided `acquisitionTest.jar` Java tool to help you get the unique ID and broadcast install referrer, which in turn, helps you obtain the information in steps 3 to 12.

  **Install the Java Tool**

To install the Java tool:

1. Download the [`acquisitionTester.zip`](/docs/android/assets/acquisitionTester.zip) file.

1. Extract the .jar file.

    You can run the file on the command line.

    For example:

    ```java
    java -jar acquisitionTester.jar -a com.adobe.test -r com.adobe.test.ReferrerReceiver -l "https://c00.adobe.com/v3/appid/start?a_i_id=123456&a_g_id=com.adobe.test&a_dd=i&ctxa.referrer.campaign.name=name&ctxa.referrer.campaign.trackingcode=1234
    ```
