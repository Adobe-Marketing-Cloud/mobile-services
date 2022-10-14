# Mobile app acquisition

Acquisition links with unique tracking codes can be generated in Adobe Mobile services. When a user downloads and runs an app from the App store after clicking on the generated link, the SDK automatically collects and sends the acquisition data to Adobe Mobile services.

## New Adobe Experience Platform Mobile SDK Release

Looking for information and documentation related to the Adobe Experience Platform Mobile SDK? Click [here](https://aep-sdks.gitbook.io/docs/) for our latest documentation.

As of September 2018, we released a new, major version of the SDK. These new Adobe Experience Platform Mobile SDKs are configurable through [Experience Platform Launch](https://www.adobe.com/experience-platform/launch.html).

* To get started, go to Adobe Experience Platform Launch.
* To see what is in the Experience Platform SDK repositories, go to [Github: Adobe Experience Platform SDKs](https://github.com/Adobe-Marketing-Cloud/acp-sdks).

> **Important:** To use Acquisition, you **must** have SDK version 4.1 or later.

Acquisition links must be created in Adobe Mobile services. For more information, see [Acquisition](https://experienceleague.adobe.com/docs/mobile-services/using/acquisition-main-ug/acquisition-main.html).

**In SDK versions 4.18.0 and later**:

Starting on March 1, 2020, Google is deprecating the install_referrer intent broadcast mechanism. For more information, see [Still Using InstallBroadcast? Switch to the Play Referrer API by March 1, 2020](https://android-developers.googleblog.com/2019/11/still-using-installbroadcast-switch-to.html). To continue collecting install referrer information from the Google Play store, update your application to use SDK version 4.18.0 or newer.

With the deprecation, instead of creating a `BroadcastReceiver`, you need to collect the install referrer URL from a new Google API and pass the resulting URL to the SDK.

1. Add the Google Play Install Referrer package to your gradle file's dependencies:

   `implementation 'com.android.installreferrer:installreferrer:1.1'`

2. To retrieve the referrer URL from the Install Referrer API, complete the steps in [Getting the install referrer](https://developer.android.com/google/play/installreferrer/library#install-referrer).

3. Pass the referrer URL to the SDK:

   `Analytics.processGooglePlayInstallReferrerUrl(referrerUrl);`

> **Important:** To avoid unnecessary API calls in your app, Google recommends that you only invoke the API once immediately after install.

To decide the best way to use the Google Play Install Referrer APIs in your app, see Google's documentation. Here is an example of how to use the Adobe SDK with the Google Play Install Referrer APIs:

```java
void handleGooglePlayReferrer() {
    // Google recommends only calling this API the first time you need it:
    // https://developer.android.com/google/play/installreferrer/library#install-referrer

    // Store a boolean in SharedPreferences to ensure we only call it once.
    final SharedPreferences prefs = getSharedPreferences("acquisition", 0);
    if (prefs != null) {
        if (prefs.getBoolean("referrerHasBeenProcessed", false)) {
            return;
        }
    }

    final InstallReferrerClient referrerClient = InstallReferrerClient.newBuilder(getApplicationContext()).build();
    referrerClient.startConnection(new InstallReferrerStateListener() {
        private boolean complete = false;

        @Override
        public void onInstallReferrerSetupFinished(int responseCode) {
            switch (responseCode) {
                case InstallReferrerClient.InstallReferrerResponse.OK:
                    // connection is established
                    complete();
                    try {
                        final ReferrerDetails details = referrerClient.getInstallReferrer();                        

                        // pass the install referrer url to the SDK
                        Analytics.processGooglePlayInstallReferrerUrl(details.getInstallReferrer());

                    } catch (final RemoteException ex) {
                        Log.w("Acquisition - RemoteException while retrieving referrer information (%s)", ex.getLocalizedMessage() == null ? "unknown" : ex.getLocalizedMessage());
                    } finally {
                        referrerClient.endConnection();
                    }
                    break;
                case InstallReferrerClient.InstallReferrerResponse.FEATURE_NOT_SUPPORTED:
                case InstallReferrerClient.InstallReferrerResponse.SERVICE_UNAVAILABLE:
                default:
                    // API not available in the Play Store app - nothing to do here
                    complete();
                    referrerClient.endConnection();
                    break;
            }
        }

        @Override
        public void onInstallReferrerServiceDisconnected() {
            if (!complete) {
                // something went wrong trying to get a connection, try again
                referrerClient.startConnection(this);
            }
        }

        void complete() {
            complete = true;
            SharedPreferences.Editor editor = getSharedPreferences("acquisition", 0).edit();
            editor.putBoolean("referrerHasBeenProcessed", true);
            editor.apply();
        }
    });
}
```

**In SDK versions 4.13.1 and later**:

If you cannot use the acquisition links that are created in Adobe Mobile Services, the acquisition data can still be collected and sent by the SDK by using Google Play Acquisition.

To collect acquisition data from a standard Google Play Acquisition campaign:

* Use the standard Google Play Store acquisition method.

  Custom acquisition data can be used with the standard Google Play Acquisition key value pairs.

* When the user downloads and runs an app as the result of a Google Play store acquisition, the data from the referrer will be collected and sent to Adobe Mobile Services.

  * The data is stored and available in the `AdobeDataCallback` instance that was registered earlier with the SDK.

      For more information, see [Configuration Methods](/docs/android/configuration/methods.md).

  * The `MobileDataEvent.MOBILE_EVENT_ACQUISITION_INSTALL` or the `MobileDataEvent.MOBILE_EVENT_ACQUISITION_LAUNCH` event type are used.

  * Custom keys that were part of the acquisition data from Google Play will be name-spaced with " `a.acquisition.custom.`"

If you are using the Acquisition links that were created on Adobe Mobile Services, add custom data to the acquisition link by completing the following tasks:

1. Prefix an acquisition variable with " `adb`".

   When the SDK receives the acquisition data from Adobe Mobile Services at the first launch, the data is stored and is available in the `AdobeDataCallback` instance that was registered earlier with the SDK. For more information, see [Configuration Methods](/docs/android/configuration/methods.md).

1. The `MobileDataEvent.MOBILE_EVENT_ACQUISITION_INSTALL` or the `MobileDataEvent.MOBILE_EVENT_ACQUISITION_LAUNCH` event type will be used.

1. The custom data keys are prefixed with "`a.acquisition.custom.`"

> **Tip:** If you are sending data to multiple report suites, use the acquisition data from the app that is associated with the first report suite in your list of report suite IDs.

The updates in this section enable the SDK to send acquisition data from an acquisition link.

## Tracking mobile acquisition

1. Add the library to your project and implement lifecycle.

   For more information, see *Add the SDK and Config File to your IntelliJ IDEA or Eclipse Project* in [Core implementation and lifecycle](/docs/android/getting-started/dev-qs.md).

1. Import the library:

   ```java
   import com.adobe.mobile.*;
   ```

1. Implement the `BroadcastReceiver` for the referrer:

   ```java
   package com.your.package.name;  // replace with your app package name

   import android.content.BroadcastReceiver;
   import android.content.Context;
   import android.content.Intent;

   public class GPBroadcastReceiver extends BroadcastReceiver {
     @Override
     public void onReceive(Context c, Intent i) {
      com.adobe.mobile.Analytics.processReferrer(c, i);
     }
   }
   ```

1. Update `AndroidManifest.xml` to enable the `BroadcastReceiver` that was created in the previous step:

   ```xml
   <receiver android:name="com.your.package.name.GPBroadcastReceiver" android:exported="true">
    <intent-filter>
     <action android:name="com.android.vending.INSTALL_REFERRER" />
    </intent-filter>
   </receiver>
   ```

1. Verify that the `ADBMobileConfig.json` file contains the required acquisition settings:

   ```xml
   "acquisition": {
      "server": "c00.adobe.com",
      "appid": "0652024f-adcd-49f9-9bd7-2552a4565d2f"
   },
   "analytics": {
     "referrerTimeout": 5,
     ...
   ```

   > **Important:** If you are sending data to multiple report suites, use the acquisition settings (acquisition server and appid) from the app that is associated with the first report suite in your list of report suite IDs.

   The `acquisition` settings are generated by Adobe Mobile services and should not be changed. For more information about how to download a customized `ADBMobileConfig.json` file with the `acquisition` settings pre-configured, see [Before You Start](/docs/android/getting-started/requirements.md).

After these settings are enabled, after the initial launch of the app, acquisition data is sent automatically with the initial lifecycle call.

> **Caution:** `referrerTimeout` must be set to a value higher than 0 to enable app acquisition.
