# Android Wearables: additional notes

Here is some information to help you configure the Android extension, which allows you to collect data from your Android Wearable app.

* The Adobe Mobile Android Wearables extension requires Android version 4.4 (KitKat) or above. 
* There is one additional context value, `A.RunMode`, which has been added to indicate whether the data comes from the containing app or the extension.

  * `RunMode` = `Application` 
  
     The hit comes from the handheld app.

  * `RunMode` = `Extension`
  
    The hit comes from the wearable app.

* The SDK automatically syncs the `aid`/`vid`/`visitor` `service id`/`privacy` status from the handheld app to the wearable app, so do not call `setPrivacyStatus`/`setUserIdentifier`/`idSync` from the wearable app. 
* [In-app messages](/docs/android/messaging-main/messaging/messaging.md), [Target](/docs/android/target-main/target.md), and [Audience Manager](/docs/android/audience-manager/audiencemgmt.md) are disabled for the wearable app.
