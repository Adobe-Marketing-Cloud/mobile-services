# Troubleshooting Acquisition testing

Here are some issues you might face when testing Acquisition and some possible solutions:

* If not otherwise specified, the ADBMobileConfig.json file should be placed in the assets folder.

* The name is case sensitive, so do not provide a name in lower-case letters.  

  You need to ensure that `Config.setContext(this.getApplicationContext())` is called from the main activity. For more information, see [Configuration methods](../configuration/methods.md).

* There are a few user permissions missing from the provided AndroidManifest.xml file, these are required to send data and record offline tracking calls:

  ```html
  <manifest..>
  ... 
  <uses-permission android:name="android.permission.INTERNET" />
  <uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />
  </manifest>
  ```

* In your configuration, if the referrer timeout is set to `referrerTimeout: 5`, this means that you need to send the install intent in a 5-second timeframe after the application was installed and launched for the first time to see the referrer information appended to the install hit. 

  For manual testing, increase the `referrerTimeout` to 10-15 seconds, so that there is enough time to send the referrer information before the install hit is processed.

* It is important to run all the steps in [Testing Marketing Link acquisition](t-t-testing-marketing-link-acquisition.md) in order and make sure you execute `adb` shell and then the following:

  ```java
  am broadcast -a com.android.vending.INSTALL_REFERRER -n 
  nl.postnl.app/.tracking.AdobeAcquisitionLinkBroadcastReceiver --es "referrer"
  "utm_source=adb_acq_v3&utm_campaign=adb_acq_v3&utm_content=<the newly generated id at step #7>"
  ```

> **Important:** You must run these two commands independently to process the referrer intent correctly.  Otherwise, `adb` double escapes the referrer information, and the data received by the broadcast receiver will be incomplete.
