# Apple Watch implementation with WatchOS 2

Starting with WatchOS 2, your WatchKit Extensions can run on an Apple Watch. Applications that run in this environment require the `WatchConnectivity` framework to share data with their containing iOS app.

> **Tip:** Starting with `AdobeMobileLibrary` v4.6.0, `WatchConnectivity` is supported.

## New Adobe Experience Platform Mobile SDK Release

Looking for information and documentation related to the Adobe Experience Platform Mobile SDK? Click [here](https://aep-sdks.gitbook.io/docs/) for our latest documentation.

As of September 2018, we released a new, major version of the SDK. These new Adobe Experience Platform Mobile SDKs are configurable through [Experience Platform Launch](https://www.adobe.com/experience-platform/launch.html).

* To get started, go to Adobe Experience Platform Launch.
* To see what is in the Experience Platform SDK repositories, go to [Github: Adobe Experience Platform SDKs](https://github.com/Adobe-Marketing-Cloud/acp-sdks).

## Getting started

> **Important:** Ensure that you have a project with at least the following targets: 
>
>* The containing app 
>* The WatchKit app 
>* The WatchKit extension 
>

For more information about developing WatchKit apps, see [The Watch App Architecture](https://developer.apple.com/library/ios/documentation/General/Conceptual/WatchKitProgrammingGuide/DesigningaWatchKitApp.html#//apple_ref/doc/uid/TP40014969-CH3-SW1).

## Configure the containing app

Complete the following steps in your Xcode project:

1. Drag the `AdobeMobileLibrary` folder into your project. 
1. Ensure that the `ADBMobileConfig.json` file is a member of the containing app’s target. 
1. In the **Build Phases** tab of your containing app’s target, expand the **Link Binary with Libraries** section and add the following libraries:

    * `AdobeMobileLibrary.a` 
    * `libsqlite3.tbd` 
    * `SystemConfiguration.framework`

1. In your class that implements the `UIApplicationDelegate` protocol, add the `WCSessionDelegate` protocol.

   ```objective-c
   #import <WatchConnectivity/WatchConnectivity.h> 
   @interface AppDelegate : UIResponder <UIApplicationDelegate, WCSessionDelegate>
   ```

1. In the implementation file of your app delegate class, import the `AdobeMobileLibrary`.

   ```objective-c
   #import "ADBMobile.h"
   ```

1. Before making a call to the `ADBMobile` library, in `application:didFinishLaunchingWithOptions:` of your app delegate, configure your `WCSession`.

   ```objective-c
   // check for session availability 
   if ([WCSession isSupported]) { 
       WCSession *session = [WCSession defaultSession]; 
       session.delegate = self; 
       [session activateSession]; 
   }
   ```

1. In your app delegate, implement the `session:didReceiveMessage:` and `session:didReceiveUserInfo:` methods.

   `syncSettings:` is called in the `ADBMobile` library, which returns a bool that indicates whether the dictionary was meant for consumption by the `ADBMobile` library. If it returns `No`, the message was not initiated from the Adobe SDK.

   ```objective-c
   - (void) session:(WCSession *)session didReceiveMessage:(NSDictionary<NSString *,id> *)message { 
       // pass message to ADBMobile 
       if (![ADBMobile syncSettings:message]) { 
           // handle your own custom messages 
       } 
   } 
   - (void) session:(WCSession *)session didReceiveUserInfo:(NSDictionary<NSString *,id> *)userInfo { 
       // pass userInfo to ADBMobile 
       if (![ADBMobile syncSettings:userInfo]) { 
           // handle your own custom messages 
       } 
   } 
   ```

## Configure the WatchKit extension

1. Ensure that the `ADBMobileConfig.json` file is a member of your WatchKit extension’s target. 
1. In the **Build Phases** tab of your WatchKit extension’s target, expand the **Link Binary with Libraries** section and add the following libraries:

    * `AdobeMobileLibrary_Watch.a`
    * `libsqlite3.tbd`

1. In your class that implements the `WKExtensionDelegate` protocol, import `WatchConnectivity` and add the `WCSessionDelegate` protocol.

   ```objective-c
   #import <WatchConnectivity/WatchConnectivity.h> 
   @interface ExtensionDelegate : NSObject <WKExtensionDelegate, WCSessionDelegate>
   ```

1. In the implementation file of your extension delegate class, import the `AdobeMobileLibrary`.

   ```objective-c
   #import "ADBMobile.h"
   ```

1. In `applicationDidFinishLaunching` of your extension delegate, configure your `WCSession` before making any calls to the `ADBMobile` library.

   ```objective-c
   // check for session availability 
   if ([WCSession isSupported]) { 
       WCSession *session = [WCSession defaultSession]; 
       session.delegate = self; 
       [session activateSession]; 
   }
   ```

1. In `applicationDidFinishLaunching` of your extension delegate, initialize the watch app for the SDK.

   ```objective-c
   [ADBMobile initializeWatch];
   ```

1. In your extension delegate, implement the `session:didReceiveMessage:` and `session:didReceiveUserInfo:` methods.

   `syncSettings:` is called in the `ADBMobile` library, which returns a bool that indicates whether the dictionary was meant for consumption by the `ADBMobile` library. If it returns `NO`, the message was not initiated from the Adobe SDK.

   ```objective-c
   - (void) session:(WCSession *)session didReceiveMessage:(NSDictionary<NSString *,id> *)message { 
       // pass message to ADBMobile 
       if (![ADBMobile syncSettings:message]) { 
           // handle your own custom messages 
       } 
   } 
   - (void) session:(WCSession *)session didReceiveUserInfo:(NSDictionary<NSString *,id> *)userInfo { 
       // pass userInfo to ADBMobile 
       if (![ADBMobile syncSettings:userInfo]) { 
           // handle your own custom messages 
       } 
   } 
   ```

## Additional Information

Remember the following information:

* For WatchKit apps, `a.RunMode` will be set to `Extension`. 
* Because WatchKit apps run on the watch, the apps will correctly report their names in `a.AppID`. 
* No lifecycle call is triggered on WatchOS2 apps.
