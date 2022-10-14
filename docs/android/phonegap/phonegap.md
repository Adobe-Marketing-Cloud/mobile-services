# PhoneGap plug-in overview

This plug-in allows you to send Android AppMeasurement calls from your PhoneGap project. To create a PhoneGap project, see [PhoneGap](https://helpx.adobe.com/experience-manager/6-4/mobile/using/phonegap.html).

## New Adobe Experience Platform Mobile SDK Release

Looking for information and documentation related to the Adobe Experience Platform Mobile SDK? Click [here](https://aep-sdks.gitbook.io/docs/) for our latest documentation.

As of September 2018, we released a new, major version of the SDK. These new Adobe Experience Platform Mobile SDKs are configurable through [Experience Platform Launch](https://www.adobe.com/experience-platform/launch.html).

* To get started, go to Adobe Experience Platform Launch.
* To see what is in the Experience Platform SDK repositories, go to [Github: Adobe Experience Platform SDKs](https://github.com/Adobe-Marketing-Cloud/acp-sdks).


## Install the plug-in using npm

Run the following command:

```java
cordova plugin add adobe-mobile-services
```

## Manually install the plug-in

## Include the Plug-in

1. Drag the `ADBMobile_PhoneGap.java` file to your `src` folder.

   To move this file, click **OK**. 

1. Drag the `ADB_Helper.js` file into the folder that contains the `index.html` file 

   To move this file, click **OK**. 

1. In the `res/xml` folder, open the `config.xml` file and register an new plugin by adding the following:

   ```xml
   <feature name="ADBMobile_PhoneGap"> 
     <param name="android-package" value="[YOUR_PACKAGE_NAME].ADBMobile_PhoneGap" /> 
   </feature>
   ```

   For example, if your package is named `com.example.phonegaptest`, your `android-package` value would be the following: 

   ```xml
   <param name="android-package" value="com.example.phonegaptest.ADBMobile_PhoneGap" />
   ```

## Include the AppMeasurement library

1. To download the AppMeasurement library, see [Get the SDK](/docs/android/getting-started/dev-qs.md). 
1. Drag the `adobeMobileLibrary.jar` file to your `src` folder.

   To move this file, click **OK**. 

1. Right-click the `adobeMobileLibrary.jar` file and select **Add as Library**. 
1. Based on the requirements of your project, enter the name, level, and location for the library. 
1. Drag the `ADBMobileConfig.json` file to your `assets` folder in the application root. 
1. Confirm that you have selected the root application and **not** an application in an application.

   To move this file, click **OK**.

## Add app permissions

The AppMeasurement library requires the following permissions to send data and record offline tracking calls:

* `INTERNET` 
* `ACCESS_NETWORK_STATE`

To add these permissions, add the following lines to your `AndroidManifest.xml` file, which is in the application project directory:

```xml
<uses-permission android:name="android.permission.INTERNET" /> 
<uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />
```

To enable in-app messaging:

Update AndroidManifest.xml to declare the full screen activity and enable the Message Notification Handler:

```java
<activity  
android:name="com.adobe.mobile.MessageFullScreenActivity"  
android:theme="@android:style/Theme.Translucent.NoTitleBar" /> 
<receiver android:name="com.adobe.mobile.MessageNotificationHandler" />
```

If you select modal layout when you create a message in Adobe mobile services, select one of the following themes:

* `Theme.Translucent.NoTitleBar.Fullscreen` 
* `Theme.Translucent.NoTitleBar` 
* `Theme.Translucent`

For example:

```java
<activity 
android:name="com.adobe.mobile.MessageFullScreenActivity" 
android:theme="@android:style/Theme.Translucent.NoTitleBar.Fullscreen" 
android:windowSoftInputMode="adjustUnspecified|stateHidden" /> 
<receiver android:name="com.adobe.mobile.MessageNotificationHandler" />
```

## Implement custom tracking

In `html` files, add the following to the `<head>` tag where you want to use tracking:

```
<script type="text/javascript" charset="utf-8" src="ADB_Helper.js"></script>
```
