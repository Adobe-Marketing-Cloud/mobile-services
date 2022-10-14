# In-app messaging

This information helps you use in-app messaging in your iOS apps.

 To use in-app messaging, you **must** have SDK version 4.2 or later.

Some information to remember:

* Messages and the rules that define when messages are displayed are created in Adobe Mobile services. For more information, see [Create an in-app message](https://experienceleague.adobe.com/docs/mobile-services/using/messaging-ug/inapp-messages/t-in-app-message.html).
* The updates described in this section must be made to the SDK to display in-app messages.

  > **Tip:** You can complete these steps even if you do not have any messages defined. After you define messages, they are delivered dynamically to your app and displayed without an app store update.

## Enabling in-app messages

1. Add the library to your project and implement lifecycle.

   For more information, see *Add the SDK and Config File to your Project* in [Core Implementation and Lifecycle](/docs/ios/getting-started/requirements.md).

1. Import the library:

   ```objective-c
   #import "ADBMobile.h"
   ```

1. Verify that the `ADBMobileConfig.json` file contains the required settings for In-App messaging. 
1. For in-app messages to be updated dynamically on launch, the `remotes` object must be present and properly configured:

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

   > **Tip:** `messages` or `remotes` is required.

   If these objects are not configured, download an updated `ADBMobileConfig.json` file from Adobe Mobile services. For more information, see [Core Implementation and Lifecycle](/docs/ios/getting-started/requirements.md).

## Tracking in-app messages

The iOS Mobile Services SDKs track the following metrics for your in-app messages:

* For full screen and alert style in-app messages:

  * **Impressions**: when the user triggers an in-app message.
  * **Click throughs**: when the user pushes the **Click-through** button.
  * **Cancels**: when the user pushes the **Cancel** button.

* For custom, full screen in-app messages, the HTML content in the message needs to include the correct code to notify the SDK tracking about the following buttons:

  * **Click-through** (redirect) example tracking: `adbinapp://confirm/?url=https://www.yoursite.com` 
  * **Cancel** (close) example tracking: `adbinapp://cancel`

* For local (remote) notifications:

  * **Impressions**: when user triggers the notification.
  * **Opens**: when user opens app from the notification.

  Here is an example about how to include open tracking:

  ```objective-c
  - (BOOL) application:(UIApplication *)application didFinishLaunchingWithOptions:(NSDictionary *)launchOptions { 
    // handle local notification click-throughs for iOS 10 and older 
    NSDictionary *localNotificationDictionary = launchOptions[UIApplicationLaunchOptionsLocalNotificationKey]; 
    if ([localNotificationDictionary isKindOfClass:[NSDictionary class]]) { 
         [ADBMobile trackLocalNotificationClickThrough:localNotificationDictionary]; 
    } 
  } 
  - (void) application:(UIApplication *)application didReceiveLocalNotification:(UILocalNotification *)notification { 
     [ADBMobile trackLocalNotificationClickThrough:notification.userInfo]; 
  }
  ```

## Local fallback image

When creating a full screen message in Adobe Mobile services, you can optionally specify a fallback image. If your message is unable to retrieve its intended image from the web, the SDK attempts to load the image with the same name from your application bundle. This allows you to display your message in its original form even if the user is offline, or the predetermined image is unreachable.

The fallback image asset name is specified when configuring the message in Adobe Mobile services.

> **Important:** You need to ensure that the specified resource is available.
