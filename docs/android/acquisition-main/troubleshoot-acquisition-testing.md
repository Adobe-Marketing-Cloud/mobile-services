# Troubleshoot Acquisition testing

This topic provides information about how to troubleshoot issues you might face during Acquisition testing.

* If not otherwise specified, the ADBMobileConfig.json file should be placed in the `assets` folder.

  The name is case sensitive, so do not use upper or lower case letters.

* Ensure that `Config.setContext(this.getApplicationContext())` is called from your main activity.

  For more information, see [Configuration methods](../configuration/methods.md).

* Ensure that the required permissions for the Mobile SDK are present in the `AndroidManifest.xml` file:
 
    ```html
    <manifest ..>
    ... 
    <uses-permission android:name="android.permission.INTERNET" />
    <uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />
    </manifest>
    ```

* If the `referrerTimeout` is set to 5 in the ADMobileConfig.json file, you have to send the install intent in a 5-second timeframe after the application was installed and launched for the first time to see the referrer information appended to the install hit. 

  For manual testing, we recommend that you increase the `referrerTimeout` to 10-15 seconds, so that you have sufficient time to send the referrer information before the install hit is processed.

* Run all the steps in [Testing Marketing Link acquisition](t-testing-marketing-link-acquisition.md) and ensure that you execute the `adb shell` command first and then the following:

    ```java
    am broadcast -a com.android.vending.INSTALL_REFERRER -n nl.postnl.app/.tracking.AdobeAcquisitionLinkBroadcastReceiver --es "referrer" "utm_source=adb_acq_v3&utm_campaign=adb_acq_v3&utm_content=<the newly generated id at step #7>"
    ```

> **Important:** To process the referrer intent correctly, you must run these two commands independently. Otherwise `adb` will double escape the referrer information and the data received by the broadcast receiver will be incomplete.
