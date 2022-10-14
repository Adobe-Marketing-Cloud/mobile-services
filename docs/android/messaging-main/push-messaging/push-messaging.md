# Push messaging

Adobe Mobile and the Adobe Mobile SDK allow you to send push messages to your users. The SDK also allows you to easily report users who have opened your app after clicking through a push message.

To use push messaging, you **must** have SDK version 4.6 or later.

> **Important:** Do not manually set the Experience Cloud ID inside your app. This causes the creation of a new unique user that will not receive push messages because of its opt-in status. For example, a user has opted-in to receive push messages logs in to your app. After logging in, if you manually set the ID inside your app, a new unique user is created who has not opted to receive push messages. This new user will not receive your push messages.
>
>Moving your app to a new report suite is not supported. If you migrate to a new report suite, your push configuration can break, and messages might not be sent.

## Enable push messaging

> **Tip:** If your app is already set up to use messaging through Firebase Cloud Messaging (FCM), some of the following steps might already be completed.

1. Verify that the `ADBMobileConfig.json` file contains the required settings for push messaging.

   The `"marketingCloud"` object must have its `"org"` property configured for push messaging. 

   ```js
   "marketingCloud": { 
     "org": <org-id-string> 
    }
   ```

1. Obtain the registration ID/token by using the Firebase Cloud Messaging (FCM) API.

    * For more information about setting up FCM, see [Set Up a Firebase Cloud Messaging Client App on Android](https://firebase.google.com/docs/cloud-messaging/android/client).

    ```js
    String token = FirebaseInstanceId.getInstance().getToken();
    ```

1. The registration ID/token must be passed to the SDK by using the `Config.setPushIdentifier(final String registrationId)` method.

   ```js
   Config.setPushIdentifier(token); // token was obtained in step 2
   ```

1. Enable reporting by passing your activity in the `collectLifecycleData` method.

   Here are the requirements to enable push click-through reporting:

    * In your implementation of `FireBaseMessageService`, the Bundle object that contains the message data, which is passed into the `onMessageReceived` method with the RemoteMessage object, must be added to the Intent that is used to open the target activity on a click-through. This can be done using the `putExtras` method. For more information, see [putExtras](https://developer.android.com/reference/android/content/Intent.html#putExtras(android.os.Bundle))). 


   ```java
   Intent intent = new Intent(this, MainActivity.class);
      intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
   // get the bundle from the RemoteMessage object
      intent.putExtras(message.toIntent().getExtras());
   ```

    * In the target activity of the clickthrough, the activity must be passed into the SDK with the `collectLifecycleData` call.
   
      Remember the following information:
   
      * Use `Config.collectLifecycleData(this)` or `Config.collectLifecycleData(this, contextData)`. 
   
      * Do **not** use `Config.collectLifecycleData()`.
