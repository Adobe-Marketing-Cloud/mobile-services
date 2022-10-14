# Xamarin components for Experience Cloud Solutions 4.x SDK

This topic describes how to get started using Xamarin components for Mobile solutions 4.x SDK.

Last Updated: **January 10, 2019**

## Getting Started

> **Important:** Adobe Mobile SDK is no longer available in the Xamarin Components Store or in the NuGet Gallery. To download the Xamarin components, go to [GitHub](https://github.com/Adobe-Marketing-Cloud/mobile-services).

## Android

Import the ADBMobile Component to your Xamarin.Android project:

1. Open your Xamarin project 
1. Open **References** dialog and click the **.Net Assembly** tab. 
1. Select `ADBMobile.XamarinAndroidBinding.dll` from the **lib/Android** folder. 
1. Add your `ADBMobileConfig.json` file to the **Assets** folder of your project. 
1. Add permissions for:

   * `INTERNET` 
   * `ACCESS_NETWORK_STATE`

   ```java
    <uses-permission android:name="android.permission.INTERNET" />
    <uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />
   ```

1. If you are using In-app messaging, add the following activity and receiver :

   ```java
    <activity 
    android:name="com.adobe.mobile.MessageFullScreenActivity" 
    android:theme="@android:style/Theme.Translucent.NoTitleBar" />
    <receiver android:name="com.adobe.mobile.MessageNotificationHandler" />
   ```

1. If you are using acquisition, add the following receiver :

   ```java
    <receiver android:name="com.your.package.name.GPBroadcastReceiver" android:exported="true">
    <intent-filter>
        <action android:name="com.android.vending.INSTALL_REFERRER" />
    </intent-filter>
    </receiver>
   ```

## iOS

Import the ADBMobile Component to your Xamarin.iOS project:

1. Open your Xamarin project. 
1. Open **References** dialog and click the **.Net Assembly** tab. 
1. Select `ADBMobile.XamarinIOSBinding.dll` from the **lib/ios-unified** folder. 
1. Add your `ADBMobileConfig.json` file to the project.
