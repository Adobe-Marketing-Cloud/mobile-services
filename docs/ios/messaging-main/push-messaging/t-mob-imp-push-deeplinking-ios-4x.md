# Implement push messaging with deep linking

After you configure the deep linking URL in the Adobe Mobile Services UI, this URL will be in the push payload with the `adb_deeplink` key.

1. In AppDelegate, you can get the deep link URL back and handle it on your own in the following locations:

    * In `application:didFinishLaunchingWithOptions`:

      If the app is not running when a push click through happens, you can get the push payload from `launchOptions`, and deep link URL is in the payload dictionary by the `adb_deeplink` key. 

    * The delegate methods for Remote Notification

      In the `didReceiveRemoteNotification:` application or in the `didReceiveRemoteNotification:fetchCompletionHandler:` application, you can get the URL by accessing the `userInfo` dictionary with the `adb_deeplink` key. 
 
    * The delegate methods for `UNUserNotificationCenter`

      In the `userNotificationCenter:didReceiveNotificationResponse:withCompletionHandler:` method, you can get the push payload from the `userInfo` dictionary, in the `adb_deeplink` key.

For example: 

```objective-c
- (BOOL) application:(UIApplication *)application didFinishLaunchingWithOptions:(NSDictionary *)launchOptions {
    NSDictionary *remoteNotification = launchOptions[UIApplicationLaunchOptionsRemoteNotificationKey]; 
    if (remoteNotification && [remoteNotification isKindOfClass:[NSDictionary class]]) { 
        NSString *deeplink = remoteNotification[@"adb_deeplink"]; 
        // handle deep link url 
    }
    return YES; 
} 
  
// app target < iOS 7 
- (void) application:(UIApplication *)application didReceiveRemoteNotification:(NSDictionary *)userInfo { 
    // only send the hit if the app is not active 
    if (application.applicationState == UIApplicationStateInactive) { 
        [ADBMobile trackPushMessageClickThrough:userInfo]; 
        NSString *deeplink = userInfo[@"adb_deeplink"]; 
        // handle deep link url 
    } 
} 
  
// app target >= iOS 7 
- (void)application:(UIApplication *)application didReceiveRemoteNotification:(NSDictionary *)userInfo fetchCompletionHandler:(void (^)(UIBackgroundFetchResult))completionHandler { 
    if (application.applicationState == UIApplicationStateInactive) { 
        [ADBMobile trackPushMessageClickThrough:userInfo]; 
        NSString *deeplink = userInfo[@"adb_deeplink"]; 
        // handle deep link url 
    } 
    ... 
} 
 
// if using UNUserNotificationCenterDelegate and device is running iOS 10 or newer 
- (void) userNotificationCenter:(UNUserNotificationCenter *)center didReceiveNotificationResponse:(UNNotificationResponse *)response withCompletionHandler:(void (^)(void))completionHandler { 
    if ([response.notification.request.trigger isKindOfClass:UNPushNotificationTrigger.class]) { 
        [ADBMobile trackPushMessageClickThrough:response.notification.request.content.userInfo]; 
        NSString *deeplink = response.notification.request.content.userInfo[@"adb_deeplink"]; 
        // handle deep link url  
    } 
    ... 
}
```
