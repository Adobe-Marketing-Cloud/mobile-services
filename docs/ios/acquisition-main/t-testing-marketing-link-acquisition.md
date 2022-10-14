# Testing Marketing Link acquisition

The following instructions help you roundtrip an acquisition campaign with a Marketing Link that is based on a device fingerprint.

1. Complete the prerequisite tasks in [Mobile App Acquisition](/docs/ios/acquisition-main/acquisition.md).
1. In the Adobe Mobile Services UI, click **Marketing Links Builder** and generate an acquisition Marketing Link URL that sets the App Store as the destination for iOS devices.

    For example:

    ```
    https://c00.adobe.com/v3/da120731d6c09658b82d8fac78da1d5fc2d09c48e21b3a55f9e2d7344e08425d/start?a_dl=57477650072932ec6d3a470f
    ```

    For more information, see [Marketing Links Builder](https://experienceleague.adobe.com/docs/mobile-services/using/acquisition-main-ug/create-manage-link-destination/marketing-links-builder/c-marketing-links-builder.html).


1. Open the generated link on the iOS device and open `https://c00.adobe.com/v3/<appid>/end`.

   You should see the contextData in the JSON response:

   ```js
   {"fingerprint":"bae91bb778f0ad52e37f0892961d06ac6a5c935b","endCallbacks":["***"],"timestamp":1464301217,"appguid":"da120731d6c09658b82d8fac78da1d5fc2d09c48e21b3a55f9e2d7344e08425d","contextData":
   {"a.launch.campaign.trackingcode":"twdf4546","a.referrer.campaign.name":"iOS Demo","a.referrer.campaign.trackingcode":"twdf4546"}
   ,"adobeData":{"unique_id":"8c14098d7c79e8a180c15e4b2403549d3cc21ea8","deeplinkid":"57477650072932ec6d3a470f"}}
   ```

1. Verify that the following settings in your config file are correct:

    | Setting | Value |
    |--- |--- |
    |acquisition|The server should be  `c00.adobe.com`. `appid` should equal the  *`appid`* in your acquisition link.|
    |analytics|`referrerTimeout` should have a value greater than 0.|

1. (Conditional) If the SSL setting in your app's config file is `false`, update your acquisition link to use the HTTP protocol instead of HTTPS.
1. Click the generated link from the mobile device on which you want to install the app.

   Adobe's servers (`c00.adobe.com`) store the fingerprint and redirect to the App Store. The app does not need to be downloaded for testing. 
1. Launch the application for the first time from the same mobile device that you used in step 6.

   You can delete and install the app again, if necessary. 
1. (Optional) Enable debug logging of the SDK to obtain additional information.

   If everything works correctly, you should see following logs:

    `"Analytics - Trying to fetch referrer data from <acquisition end url>"`
    `"Analytics - Received Referrer Data(<Json Object>)"`

   If you do not see these logs, verify that you completed steps 4 and 5.

   Here is some information about possible errors: 

   * `Analytics - Unable to retrieve acquisition service response (<error message>)`: 
  
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

* The acquisition server provides an attribution match that based on the IP address and user-agent information that was recorded in the link click (step 6) and when the app is launched (step 7). 

    You should be on the same network when you click the URL and when you open the app. 

* By using HTTP monitoring tools, hits that are sent from the app can be monitored to provide verification of the acquisition attribution. 

    You should see one `/v3/<appid>/start` request and one `/v3/<appid>/end` request that are sent to the acquisition server. 

* Variations in the user-agent sent might cause attribution to fail. 

  Ensure that `https://c00.adobe.com/v3/<appid>/start` and `https://c00.adobe.com/v3/<appid>/end` have the same user-agent values. 

* The acquisition link and the hit from the SDK should be using the same HTTP/HTTPS protocol. 

  If the link and the hit are using different protocols, where for example, the link uses HTTP and the SDK uses HTTPS, the IP address might differ on some carriers for each request. This could cause the attribution to fail. 

* The Marketing Links are cached on the server side with a ten-minutes expiration time. 

  When you make changes to Marketing Links, you should wait about 10 minutes before using the links.
