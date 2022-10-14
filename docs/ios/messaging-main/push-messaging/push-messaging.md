# Push messaging

Adobe Mobile and the Adobe Mobile SDK allow you to send push messages to your users. The SDK also allows you to easily report users who have opened your app as a result of clicking through a push message.

> **Important:** The information in this topic is a suggestion for a possible implementation. We strongly recommend that you review Apple's iOS documentation to determine the best implementation for your app. Your implementation should be determined by the frameworks that you are using, and the versions of iOS that your app will target.

To use push messaging, you **must** have SDK version 4.6 or later.

> **Important:** Do not manually set the Experience Cloud ID inside your app. This causes the creation of a new unique user that will not receive push messages because of its opt-in status. For example, suppose a user that has opt-ed in to receive push messages logs in to your app. After logging in, if you manually set the ID inside your app, a new unique user is created that has not opted to receive push messages. This new user will not receive your push messages.

## Prerequisites

* Add the library to your project and implement lifecycle metrics. 

  For more information, see [Lifecycle metrics](/docs/ios/metrics.md). 


* The SDK must be enabled for the ID Service.
  For more information, see [Configure SDK ID Service Options](https://experienceleague.adobe.com/docs/mobile-services/using/manage-app-settings-ug/configuring-app/t-config-visitor.html).

> **Important:** Moving your app to a new report suite is not supported. If you migrate to a new report suite, your push configuration can break, and messages might not be sent.

## Enabling push messaging

1. Verify that the `ADBMobileConfig.json` file contains the required settings for push messaging.

   The `"marketingCloud"` object must have its `"org"` property configured for push messaging.

   ```objective-c
   "marketingCloud": { 
       "org": "3CE342C92046435B0A490D4C@AdobeOrg" 
   }
   ```

1. Import the library in your `AppDelegate`. 

   ```objective-c
   #import "ADBMobile.h"
   ```

1. To determine the settings for which your app needs to ask for permission, review [Configuring Remote Notification Support](https://developer.apple.com/library/content/documentation/NetworkingInternet/Conceptual/RemoteNotificationsPG/HandlingRemoteNotifications.html#//apple_ref/doc/uid/TP40008194-CH6-SW1).

   Here is an example of a possible implementation that is asking for permission to use Alerts, Badges, Sounds, and Remote notification:

   ```objective-c
   // iOS 10 and newer 
   if (NSClassFromString(@"UNUserNotificationCenter")) { 
       UNUserNotificationCenter *center = [UNUserNotificationCenter currentNotificationCenter];   
       [center requestAuthorizationWithOptions:(UNAuthorizationOptionAlert + UNAuthorizationOptionSound + UNAuthorizationOptionBadge) 
           completionHandler:^(BOOL granted, NSError * _Nullable error) { 
           if (granted) { NSLog(@"authorization given"); } 
           else { NSLog(@"authorization rejected"); } 
           if (error) { NSLog(@"error during authorization: %@", error.localizedDescription); } 
       }]; 
       // have to ask for permission for remote notifications separately  
       [application registerForRemoteNotifications]; 
       // make this class the delegate for user notification handling  
       center.delegate = self; 
   } 
   // iOS 8.0 to iOS 9.3.5 
   else if ([application respondsToSelector:@selector(registerUserNotificationSettings:)]) { 
   #pragma GCC diagnostic push 
   #pragma GCC diagnostic ignored "-Wdeprecated-declarations" 
       UIUserNotificationTypetypes = UIUserNotificationTypeAlert | UIUserNotificationTypeBadge| UIUserNotificationTypeSound; 
       UIUserNotificationSettings *settings = [UIUserNotificationSettings settingsForTypes:types categories:nil]; 
       [application registerUserNotificationSettings:settings]; 
       // have to ask for permission for remote notifications separately  
       [application registerForRemoteNotifications]; 
   } 
   // older than iOS 8.0  
   else { 
       [application registerForRemoteNotificationTypes:UIRemoteNotificationTypeAlert | UIRemoteNotificationTypeBadge| UIRemoteNotificationTypeSound];  
   #pragma GCC diagnostic pop 
   }
   ```

1. The push token must be passed to the SDK using the `setPushIdentifier:` method in ADBMobile class.

   ```objective-c
   - (void) application:(UIApplication *)application didRegisterForRemoteNotificationsWithDeviceToken:(NSData *)deviceToken { 
       ... 
       [ADBMobile setPushIdentifier:deviceToken]; 
       ... 
   }
   ```

1. To determine the correct implementation for your environment, go to [UserNotifications](https://developer.apple.com/documentation/usernotifications).

   This step helps you enable push reporting by passing the `userInfo` dictionary to the SDK when the user opens the app by using click-through of a push message.

   The following code sample is an example of a possible implementation:

   ```objective-c
   // device running < iOS 7 
   - (void)application:(UIApplication *)application didReceiveRemoteNotification:(NSDictionary *)userInfo { 
       // only send the hit if the app is inactive 
       if (application.applicationState == UIApplicationStateInactive) {  
           [ADBMobile trackPushMessageClickThrough:userInfo]; 
       } 
   } 
   // device running between iOS 7 and iOS 9.3.5 
   - (void)application:(UIApplication *)application didReceiveRemoteNotification:(NSDictionary *)userInfo fetchCompletionHandler:(void (^)(UIBackgroundFetchResult)) completionHandler { 
       // only send the hit if the app is inactive 
       if (application.applicationState == UIApplicationStateInactive) { 
           // only run this code if the UNUserNotificationCenterclass is not available or its delegate is not set (pre iOS 10) 
           if (!NSClassFromString(@"UNUserNotificationCenter") || ![UNUserNotificationCenter currentNotificationCenter].delegate) {  
               [ADBMobiletrackPushMessageClickThrough:userInfo]; 
           } 
       } 
       completionHandler(UIBackgroundFetchResultNoData); 
   } 
   // device running >= iOS 10 
   - (void) userNotificationCenter:(UNUserNotificationCenter *)center didReceiveNotificationResponse:(UNNotificationResponse *)response withCompletionHandler:(void (^)(void))completionHandler { 
       if ([response.notification.request.trigger isKindOfClass:UNPushNotificationTrigger.class]) { 
           [ADBMobile trackPushMessageClickThrough:response.notification.request.content.userInfo]; 
       } 
       completionHandler(); 
   }
   ```

1. To keep your estimated push audience accurate, notify the SDK when a user manually disables push messaging for your app by calling `[ADBMobile setPushIdentifier: nil]` in the `applicationDidBecomeActive:` method in your `AppDelegate`.

   ```objective-c
   // device running < iOS 7 
   - (void)application:(UIApplication *)application didReceiveRemoteNotification:(NSDictionary *)userInfo { 
       // only send the hit if the app is inactive 
       if (application.applicationState == UIApplicationStateInactive) {  
           [ADBMobile trackPushMessageClickThrough:userInfo]; 
       } 
   } 
   // device running between iOS 7 and iOS 9.3.5 
   - (void)application:(UIApplication *)application didReceiveRemoteNotification:(NSDictionary *)userInfo fetchCompletionHandler:(void (^)(UIBackgroundFetchResult)) completionHandler { 
       // only send the hit if the app is inactive 
       if (application.applicationState == UIApplicationStateInactive) { 
           // only run this code if the UNUserNotificationCenterclass is not available or its delegate is not set (pre iOS 10) 
           if (!NSClassFromString(@"UNUserNotificationCenter") || ![UNUserNotificationCenter currentNotificationCenter].delegate) {  
               [ADBMobiletrackPushMessageClickThrough:userInfo]; 
           } 
       } 
       completionHandler(UIBackgroundFetchResultNoData); 
   } 
   // device running >= iOS 10 
   - (void) userNotificationCenter:(UNUserNotificationCenter *)center didReceiveNotificationResponse:(UNNotificationResponse *)response withCompletionHandler:(void (^)(void))completionHandler { 
       if ([response.notification.request.trigger isKindOfClass:UNPushNotificationTrigger.class]) { 
           [ADBMobile trackPushMessageClickThrough:response.notification.request.content.userInfo]; 
       } 
       completionHandler(); 
   }
   ```

## Example

The following is an example of what an `AppDelegate.m` implementation might look like:

```objective-c
#import "AppDelegate.h" 
#import "ADBMobile.h" 
 
@implementation AppDelegate 
  
- (BOOL)application:(UIApplication *)application didFinishLaunchingWithOptions:(NSDictionary *)launchOptions { 
    if (NSClassFromString(@"UNUserNotificationCenter")) { 
        UNUserNotificationCenter *center = [UNUserNotificationCenter currentNotificationCenter]; 
        [center requestAuthorizationWithOptions:(UNAuthorizationOptionAlert + UNAuthorizationOptionSound + UNAuthorizationOptionBadge) 
                              completionHandler:^(BOOL granted, NSError * _Nullable error) {  
            if (granted) { NSLog(@"authorization given"); } 
            else { NSLog(@"authorization rejected"); } 
            if (error) { NSLog(@"error during authorization: %@", error.localizedDescription); } 
        }]; 
        center.delegate = self; 
        [application registerForRemoteNotifications]; 
    } 
    else if ([application respondsToSelector:@selector(registerUserNotificationSettings:)]) { 
#pragma GCC diagnostic push 
#pragma GCC diagnostic ignored "-Wdeprecated-declarations"  
        UIUserNotificationType types = UIUserNotificationTypeAlert | UIUserNotificationTypeBadge| UIUserNotificationTypeSound; 
        UIUserNotificationSettings *settings = [UIUserNotificationSettings settingsForTypes:types categories:nil]; 
        [application registerUserNotificationSettings:settings];  
        [application registerForRemoteNotifications]; 
    } 
    else { 
        [application registerForRemoteNotificationTypes:UIRemoteNotificationTypeAlert| UIRemoteNotificationTypeBadge| UIRemoteNotificationTypeSound]; 
#pragma GCC diagnostic pop 
    } 
 
    return YES; 
} 
 
- (void) applicationDidBecomeActive:(UIApplication *)application {  
    if (NSClassFromString(@"UNUserNotifcationCenter")) { 
        UNUserNotificationCenter *center = [UNUserNotificationCenter currentNotificationCenter]; 
        [center getNotificationSettingsWithCompletionHandler:^(UNNotificationSettings * _Nonnull settings) { 
            if (settings.authorizationStatus != UNAuthorizationStatusAuthorized) {  
                [ADBMobile setPushIdentifier:nil]; 
            } 
        }]; 
    } 
#pragma GCC diagnostic push 
#pragma GCC diagnostic ignored "-Wdeprecated-declarations"  
    else if ([application respondsToSelector:@selector(isRegisteredForRemoteNotifications)]) { 
        if (![application isRegisteredForRemoteNotifications]) {  
            [ADBMobile setPushIdentifier:nil]; 
        } 
    } 
    else if ([application enabledRemoteNotificationTypes] == UIRemoteNotificationTypeNone) { 
        [ADBMobile setPushIdentifier:nil]; 
    } 
#pragma GCC diagnostic pop 
} 
 
- (void) application:(UIApplication *)application didRegisterForRemoteNotificationsWithDeviceToken:(NSData *)deviceToken { 
    [ADBMobile setPushIdentifier:deviceToken]; 
} 
 
- (void) application:(UIApplication *)application didFailToRegisterForRemoteNotificationsWithError:(NSError *)error { 
    [ADBMobile setPushIdentifier:nil]; 
} 
 
- (void) application:(UIApplication *)application didReceiveRemoteNotification:(NSDictionary *)userInfo { 
    if (application.applicationState == UIApplicationStateInactive) {  
        [ADBMobile trackPushMessageClickThrough:userInfo];  
    } 
} 
 
- (void) application:(UIApplication *)application didReceiveRemoteNotification:(NSDictionary *)userInfo fetchCompletionHandler:(void (^)(UIBackgroundFetchResult))completionHandler { 
    if (application.applicationState == UIApplicationStateInactive) {  
        if (!NSClassFromString(@"UNUserNotificationCenter") || ![UNUserNotificationCenter currentNotificationCenter].delegate) {  
            [ADBMobile trackPushMessageClickThrough:userInfo]; 
        } 
    } 
 
    completionHandler(UIBackgroundFetchResultNoData); 
} 
 
- (void) userNotificationCenter:(UNUserNotificationCenter *)center didReceiveNotificationResponse:(UNNotificationResponse *)response withCompletionHandler:(void (^)(void))completionHandler { 
    if ([response.notification.request.trigger isKindOfClass:UNPushNotificationTrigger.class]) { 
        [ADBMobile trackPushMessageClickThrough:response.notification.request.content.userInfo]; 
    } 
 
    completionHandler(); 
} 
 
@end
```
