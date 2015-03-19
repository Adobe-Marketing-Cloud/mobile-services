Unity Plugin for Marketing Cloud Solutions 4.x SDK

This Plug-in lets you send Adobe Analytics calls from your Unity applciation.

=================
Getting started
=================

* Download the ADBMobile.unitypackage file from git or developer connection

ADBMobile.unitypackage contents:
Assets
- *ADBMobile
- *Demo
- ADBMobileDemo.cs
- BooDemo.boo
- BooScene.unity
- CSharpScene.unity
- JavaScriptDemo.js
- JavaScriptScene.unity
- SecondScene.unity
- SecondSceneScript.cs
- Plugins
- ADBMobile.cs
- Android
- adobeMobileLibrary-{version}.jar
- AndroidManifest.xml
- assets
- ADBMobileConfig.json
- iOS
- ADBMobile.h
- ADBMobileConfig.json
- ADBMobileWrapper.h
- ADBMobileWrapper.mm
- AdobeMobileLibrary.a

* optional folders
The Demo folder contains Unity scenes and sample code for each of the supported scripting languages.

* Import the ADBMobile Plug-in to your Unity Project

1. Open your Unity Project
2. Double-click on ADBMobile.unitypackage
3. Select all folders you wish to import


============================
Making calls to the library
============================

When you want to make calls to the plugin from your scripts, you must import the namespace.  

C#
using com.adobe.mobile;

javascript
import com.adobe.mobile;

boo
import com.adobe.mobile;

Once you have imported the namespace, you can make calls directly to the plugin via the static methods of the ADBMobile class.


======================
Building your project
======================

* iOS
When you build for iOS, an Xcode Project gets created.  By default, the ADBMobileWrapper.mm and AdobeMobileLibrary.a files will be in your new project's "Libraries" group.  Please perform the following manual steps required to build you app:

1. Add your ADBMobileConfig.json file to the project.  Ensure that it is a member of the build any targets necessary.
2. In the "Build Phases" tab of your project, Add a link to the following libraries:
- SystemConfiguration.framework (this one may be linked already)
- libsqlite3.0.dylib

* Android
When you build for Android, the apk file will already include the ADBMobileConfig.json file in the correct location.  By default, the AndroidManifest.xml file in your /Plugins/Android folder will also be used.  Note, if you need to use your own custom manifest file, the following changes should be added:
- Add permissions for INTERNET and ACCESS_NETWORK_STATE
- <uses-permission android:name="android.permission.INTERNET" />
- <uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />
- Add this activity and receiver if you are using In-app messaging:
- <activity 
android:name="com.adobe.mobile.MessageFullScreenActivity" 
android:theme="@android:style/Theme.Translucent.NoTitleBar" />
- <receiver android:name="com.adobe.mobile.MessageNotificationHandler" />
- Add this receiver if you are using acquisition:
- <receiver android:name="com.your.package.name.GPBroadcastReceiver" android:exported="true">
    <intent-filter>
        <action android:name="com.android.vending.INSTALL_REFERRER" />
    </intent-filter>
</receiver>

====================
Implement Lifecycle
====================

* iOS 
- For iOS, lifecycle metrics will automatically be collected.
* Android
- In your Unity script, you need to set the application context for the Android SDK.  Add the following code to the Awake() function of your FIRST scene:
void Awake()
{
...
ADBMobile.SetContext();
...
}
- To collect lifecycle metrics, add the following code to all of your scene scripts:
void OnEnable()
{
...
ADBMobile.CollectLifecycleData ();
...
}

void OnDisable()
{
...
ADBMobile.PauseCollectingLifecycleData ();
...
}
void OnApplicationPause(bool isPaused)
{
...
if (isPaused) {
ADBMobile.PauseCollectingLifecycleData ();
} 
else {
ADBMobile.CollectLifecycleData();
}
...
}
