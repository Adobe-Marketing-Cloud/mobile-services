# Getting Started with ADBMobile

See [our documentation](https://marketing.adobe.com/resources/help/en_US/mobile/download_sdk.html) for detailed instructions on how to integrate Adobe Mobile Services depending on your platform.


* Download the components from git or https://components.xamarin.com/ 

* Import the ADBMobile Component to your Xamarin.Android Project

1. Open your Xamarin Project
2. Open References dialog, and then .Net Assemnbly tab
3. Select ADBMobile.XamarinAndroidBinding.dll from the folder lib/Android
4. Add your ADBMobileConfig.json file into the Assets folder of your project. 


* Import the ADBMobile Component to your Xamarin.iOS Project

1. Open your Xamarin Project
2. Open References dialog, and then .Net Assemnbly tab
3. Select ADBMobile.XamarinIOSBinding.dll from the folder lib/ios-unified
4. Add your ADBMobileConfig.json file to the project. 
5. Add permissions for INTERNET and ACCESS_NETWORK_STATE
 <uses-permission android:name="android.permission.INTERNET" />
 <uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />

 Add this activity and receiver if you are using In-app messaging:
<activity 
android:name="com.adobe.mobile.MessageFullScreenActivity" 
android:theme="@android:style/Theme.Translucent.NoTitleBar" />
<receiver android:name="com.adobe.mobile.MessageNotificationHandler" />

 Add this receiver if you are using acquisition:
 <receiver android:name="com.your.package.name.GPBroadcastReceiver" android:exported="true">
    <intent-filter>
        <action android:name="com.android.vending.INSTALL_REFERRER" />
    </intent-filter>
</receiver>

* Get the components from Xamrain Components Store

1. Open your Xamarin Project
2. Select Component and then Get More Components
3. Search Adobe ...., add the component to the current project
4. Add your ADBMobileConfig.json file to the project. 

