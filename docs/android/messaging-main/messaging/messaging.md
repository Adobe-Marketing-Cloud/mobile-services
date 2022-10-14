# In-app messaging

You can deliver in-app messages that are triggered from any analytics data or event. After the implementation, messages are dynamically delivered to the app and do not require a code update.

## New Adobe Experience Cloud SDK Release

Looking for information and documentation related to the Adobe Experience Platform Mobile SDK? Click [here](https://aep-sdks.gitbook.io/docs/) for our latest documentation.

> **Important:** As of September 2018, we released a new, major version of the SDK. These new Adobe Experience Platform Mobile SDKs are configurable through [Experience Platform Launch](https://www.adobe.com/experience-platform/launch.html).

* To get started, go to [Launch](https://launch.adobe.com/).
* To see what is in the Experience Platform SDK repositories, go to [Github: Adobe Experience Platform SDKs](https://github.com/Adobe-Marketing-Cloud/acp-sdks).

> **Important:**  If you are using the Adobe Experience Platform Mobile SDKs with Adobe Launch, you **must** also install the Adobe Analytics Mobile Services extension to use Adobe Mobile Services features such as in-app messaging and push notifications. For more information see [Adobe Analytics - Mobile Services](https://aep-sdks.gitbook.io/docs/using-mobile-extensions/adobe-analytics-mobile-services). For more information about using push messaging and in-app messaging with the Experience Cloud SDKs, see [Set up push messaging](https://aep-sdks.gitbook.io/docs/using-mobile-extensions/adobe-analytics-mobile-services#set-up-push-messaging) and [Set up in-app messaging](https://aep-sdks.gitbook.io/docs/using-mobile-extensions/adobe-analytics-mobile-services#set-up-in-app-messaging).

> **Important:** To use in-app messaging, you **must** have SDK version 4.2 or later.

You can create messages and the rules in Adobe Mobile services that define when messages are displayed. For more information, see [Create an in-app message](https://experienceleague.adobe.com/docs/mobile-services/using/messaging-ug/inapp-messages/t-in-app-message.html). To display in-app messages, updates must be made to the SDK. You can complete these steps even if you have not yet defined any messages. After you define messages, they will be delivered dynamically to your app and displayed without an app store update.

## Enabling in-app messaging

1. Add the library to your project and implement lifecycle.

    For more information, see *Add the SDK and Config File to your IntelliJ IDEA or Eclipse Project* in [Core implementation and lifecycle](/docs/android/getting-started/dev-qs.md). 

1. Update the `AndroidManifest.xml` file to declare the full screen activity and enable the Message Notification Handler:

   ```java
   <activity  
   android:name="com.adobe.mobile.MessageFullScreenActivity"  
   android:theme="@android:style/Theme.Translucent.NoTitleBar" /> 
   <receiver android:name="com.adobe.mobile.MessageNotificationHandler" />
   ```

   If you selected a modal layout, select one of the following themes for the message:

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

1. Import the library: 

   ```java
   import com.adobe.mobile.*;
   ```

1. In each `collectLifecycleData` call, pass `this` to provide a reference to your current activity: 

   ```java
   @Override 
   public void onResume() { 
       Config.collectLifecycleData(this); 
   }
   ```

1. Verify that the `ADBMobileConfig.json` file contains the required settings for in-app messaging.

   > **Important:** `messages` or `remotes` is required.

   For in-app messages to be dynamically updated on launch, the `remotes` object must be present and properly configured: 

   ```js
   "messages": [ 
       { 
           "messageId": "de45c43c-37bf-441f-8cbd-cc3ba3469ebe", 
           "template": "fullscreen", 
           "showOffline": false, 
           "showRule": "always", 
           "endDate": 2524730400, 
           "startDate": 0, 
           "audiences": [], 
           "triggers": [], 
           "payload": { // contents change depending on template 
               "html": "<html>html code goes here</html>" 
           }, 
       }, 
       … 
   ] 
   "remotes" : { 
       "analytics.poi": "https://assets.adobedtm.com/…/yourfile.json", 
       "messages": "https://assets.adobedtm.com/…/yourfile.json" 
   }
   ```

   If this object is not configured, download an updated `ADBMobileConfig.json` file from Adobe Mobile services. For more information, see [Before You Start](/docs/android/getting-started/requirements.md).

## Tracking in-app messages

The Android Mobile SDKs track the following metrics for your in-app messages:

* For full screen and alert style in-app messages:

  * **Impressions**: when user triggers an in-app message. 
  * **Click throughs**: when user presses **Click through**. 
  * **Cancels**: when user presses **Cancel**.

* For custom, full screen in-app messages, the HTML content in the message needs to include the correct code to notify the SDK tracking about the following buttons:

  * **Click-through** (redirect) example tracking: 
  
    `adbinapp://confirm/?url=https://www.yoursite.com` 
  * **Cancel** (close) example tracking: 
  
    `adbinapp://cancel`

## Local fallback image

When creating a full-screen message, you can optionally specify a fallback image. If your message cannot retrieve its intended image from the web, the SDK attempts to load the image with the same name from your application’s assets folder. This allows you to show your message in its original form, even if the user is offline, or the predetermined image is unreachable.

> **Important:** The fallback image asset name is specified when you configure the message in Adobe Mobile services, and you need to ensure that the specified resource is available.

## Configuring notification icons

The following methods allow you to configure the small and large icons that appear in the notification area, and the large icon that is displayed when notifications appear in the notification drawer. 

* **Config.setSmallIconResourceId(int resourceId)**

  Set the small icon that will be used for notifications that are created by the SDK. This icon appears in the status bar and is the secondary image that is displayed shown when the user sees the complete notification in the notification center. 

  * Here is the syntax for this method:

    ```java
    public static void setSmallIconResourceId(final int resourceId); 
    ```

  * Here is the code example for this method:

    ```java
    Config.setSmallIconResourceId(R.drawable.appIcon);
    ```

* **Config.setLargeIconResourceId(int resourceId)** 

  Set the large icon that will be used for notifications that are created by the SDK. This icon is the primary image that is displayed when the user sees the complete notification in the notification center.

  * Here is the syntax for this method:

    ```java
    public static void setLargeIconResourceId(final int resourceId); 
    ```

  * Here is the code sample for this method:

    ```java
    Config.setLargeIconResourceId(R.drawable.appIcon); 
    ```
