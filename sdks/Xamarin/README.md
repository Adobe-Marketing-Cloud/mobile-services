# Getting Started with ADBMobile

See [our documentation](https://marketing.adobe.com/resources/help/en_US/mobile/download_sdk.html) for detailed instructions on how to integrate Adobe Mobile Services depending on your platform.

Xamarin Components for Experience Cloud Solutions 4.x SDK

This topic describes how to get started using Xamarin components for Mobile solutions 4.x SDK.

Last Updated:January 10, 2019

This section contains the following information:

Important: Adobe Mobile SDK is no longer available in the Xamarin Components Store or in the NuGet Gallery. To download the Xamarin components, go to [GitHub](https://github.com/Adobe-Marketing-Cloud/mobile-services).

Android

Import the ADBMobile Component to your Xamarin.Android Project:

1. Open your Xamarin Project
2. Open References dialog, and then .Net Assembly tab.
3. Select ADBMobile.XamarinAndroidBinding.dll from the folder lib/Android.
4. Add your ADBMobileConfig.json file into the Assets folder of your project. 
5. Add permissions for: INTERNET and ACCESS_NETWORK_STATE

<uses-permission android:name="android.permission.INTERNET" />
<uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />

6. Add the following activity and receiver if you are using In-app messaging:

<activity 
android:name="com.adobe.mobile.MessageFullScreenActivity" 
android:theme="@android:style/Theme.Translucent.NoTitleBar" />
<receiver android:name="com.adobe.mobile.MessageNotificationHandler" />

7. Add the following receiver if you are using acquisition:

<receiver android:name="com.your.package.name.GPBroadcastReceiver" android:exported="true">
<intent-filter>
<action android:name="com.android.vending.INSTALL_REFERRER" />
</intent-filter>
</receiver>


iOS

Import the ADBMobile Component to your Xamarin.iOS Project:

1. Open your Xamarin Project.
2. Open References dialog, and then .Net Assembly tab.
3. Select ADBMobile.XamarinIOSBinding.dll from the folder lib/ios-unified.
4. Add your ADBMobileConfig.json file to the project.
