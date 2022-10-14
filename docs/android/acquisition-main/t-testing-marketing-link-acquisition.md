# Testing Marketing Link acquisition

The following instructions help you roundtrip an acquisition campaign with a Marketing Link on an Android device.

If your mobile app is not yet in Google Play, you can select any mobile app as a destination when creating the Marketing Link. This only affects the app to which the acquisition server redirects you, after you click the acquisition link, and not the ability to test the acquisition link. Query string parameters are passed to the Google Play store, which are passed to the app at install as part of a campaign broadcast. Roundtrip mobile app acquisition testing requires the simulation of this type of broadcast.

The app must be freshly installed, or have data cleared in **Settings**, each time a test is run. This ensures that the initial lifecycle metrics that are associated with the campaign query string parameters are sent when the app is first launched. 

1. Complete the prerequisite tasks in [Mobile app acquisition](/docs/android/acquisition-main/acquisition.md) and ensure that you have correctly implemented the broadcast receiver for `INSTALL_REFERRER`.
1. In the Adobe Mobile Services UI, click  **Acquisition** > **Marketing Links Builder** and generate an Acquisition Marketing Link URL that sets Google Play as the destination for Android devices.

   For more information, see [Marketing Links Builder](https://experienceleague.adobe.com/docs/mobile-services/using/acquisition-main-ug/create-manage-link-destination/marketing-links-builder/c-marketing-links-builder.html).

   For example:

   `https://c00.adobe.com/v3/da120731d6c09658b82d8fac78da1d5fc2d09c48e21b3a55f9e2d7344e08425d/start?a_dl=573e5bb3248a501360c2890b`

2. Open the generated link on the Android device.

   You should be redirected to a page with a URL similar to the following example:

   `https://play.google.com/store/apps/details?id=com.adobe.android&referrer=utm_campaign%3Dadb_acq_v3%26utm_source%3Dadb_acq_v3%26utm_content%3D91b52ce097b1464b9b47cb2995c493cc6ab2c3a3`

3. Copy the unique ID after `utm_content%3D`.

   In the previous example, the ID is `91b52ce097b1464b9b47cb2995c493cc6ab2c3a3`.

   If you cannot get the unique ID on the device, run the following `CURL` command on your desktop to get the unique ID from the response string.

   `curl -A "Mozilla/5.0 (Linux; Android 5.0.2; SAMSUNG SM-T815Y Build/LRX22G) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/44.0.2403.133 Safari/537.36" <Your Marketing Link>`

   For example:

   `curl -A "Mozilla/5.0 (Linux; Android 5.0.2; SAMSUNG SM-T815Y Build/LRX22G) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/44.0.2403.133 Safari/537.36" https://c00.adobe.com/v3/da120731d6c09658b82d8fac78da1d5fc2d09c48e21b3a55f9e2d7344e08425d/start?a_dl=573e5bb3248a501360c2890b`

4. Construct the acquisition end link by using the unique ID from step 3, by using the following format:

   `https://c00.adobe.com/v3/<appid>/end?a_ugid=<unique id>`

   For example, `https://c00.adobe.com/v3/<appid>/end?a_ugid=91b52ce097b1464b9b47cb2995c493cc6ab2c3a3`

5. Open the link in a browser.

   You should be see the `contextData` in the JSON response:

   ```
   {"fingerprint":"44b2f88a062df7e727c047f006deb9971304617b","endCallbacks":["***"],"timestamp":1464301282,"appguid":"da120731d6c09658b82d8fac78da1d5fc2d09c48e21b3a55f9e2d7344e08425d","contextData": 
   {"a.launch.campaign.trackingcode":"trymttvm","a.referrer.campaign.name":"Android Demo","a.referrer.campaign.trackingcode":"trymttvm"} 
   ,"adobeData":{"unique_id":"9a2be52764a8db125c29a8c10f3b1b3d5d8ed915","deeplinkid":"57476c26072932ec6d3a470b"}}.
   ```

6. Repeat step 3 to get a new unique ID.
7. Verify that the following settings in your config file are correct:

    | Setting | Value |
    |--- |--- |
    |acquisition|The server should be `c00.adobe.com`, and      *`appid`*  should equal the `appid` in your acquisition link.|
    |analytics|For testing purposes, set the referrer timeout to allow for adequate time (60 seconds or more) to manually send the broadcast. You can restore the original timeout setting after testing.|

8. Connect the device to a computer, uninstall, and install the app again.
9. Launch ADB Shell and launch the application on the device.

   ```
   adb shell
   ```

10. Send a broadcast by using the following `adb` command:

   ```
   am broadcast -a com.android.vending.INSTALL_REFERRER -n com.adobe.android/com.adobe.android.YourBroadcastReceiver --es "referrer" "utm_source=adb_acq_v3&utm_campaign=adb_acq_v3&utm_content=<unique id get on step 5>"
   ```

11. Replace `com.adobe.android` with your application's package name, update the receiver reference with the reference of the location of the campaign tracking receiver in your app, and replace the values that are associated with `utm_content`.

   If the broadcast is successful, you should expect a response like the following example:

   ```
   Broadcasting: Intent 
   { act=com.android.vending.INSTALL_REFERRER cmp=com.adobe.adms.tests/.ReferralReceiver (has extras) } 
   Broadcast completed: result=0 
   ```

12. (Optional) You can enable debug logging of the SDK to obtain additional information.

   If everything works correctly, you should see following logs:

   ```
   "Analytics - Received referrer information(<referrer content>)" 
   "Analytics - Trying to fetch referrer data from (acquisition end url)"; 
   "Analytics - Received Referrer Data(<A JSON Response>)"
   ```

   If you do not see these logs, verify that you have completed performed steps 6 to 10.

   The following table contains additional information about the possible errors: 

   | Error | Description |
   |--- |--- |
   |Analytics - Unable to decode response(`<string>`).|The response is malformed.|
   |Analytics - Unable to parse response (`a JSON Response`).|The JSON string is malformed.|
   |Analytics - Unable to parse acquisition service response (no `contextData` parameter in response).|There in no  `contextData`  parameter in the response.|
   |Analytics - Acquisition referrer data was not complete (no `a.referrer.campaign.name` in context data), ignoring.|`a.referrer.campaign.name` is not included in contextData.|
   |Analytics - Acquisition referrer timed out.|Failed to get the response in the time defined by `referrerTimeout`. Increase the value and try again.  You should also ensure that you've opened the acquisition link before installing the app.|

Remember the following information: 

* Hits that are sent from the app can be monitored by using HTTP monitoring tools to verify the acquisition attribution. 
* For more information about how to broadcast `INSTALL_REFERRER`, see [Testing Google Play Campaign Measurement](https://developers.google.com/analytics/solutions/testing-play-campaigns) in the Google Developers guide . 
* You can use the provided `acquisitionTest.jar` Java tool to help you get the unique ID and broadcast install referrer, which in turn, helps you obtain the information in steps 3 to 10. 

**Install the Java tool** 

To install the Java tool:

1. Download the [`acquisitionTester.zip`](../assets/acquisitionTester.zip) file.
1. Extract the .jar file.

    You can run the .jar file on the command line.

For example:

```sh
java -jar acquisitionTester.jar -a com.adobe.test -r com.adobe.test.ReferrerReceiver -l "https://c00.adobe.com/v3/appid/start?a_i_id=123456&a_g_id=com.adobe.test&a_dd=i&ctxa.referrer.campaign.name=name&ctxa.referrer.campaign.trackingcode=1234
```

The Marketing Links are cached on the server side with a ten-minutes expiration time. When you make changes to marking links, wait about 10 minutes before the changes take effect before you use the links again.
