# Tracking third-party deferred deep links

Use the iOS SDK to implement tracking of third-party deferred deep links.

## Classic Adobe Mobile SDK deep linking

The Adobe Mobile SDK currently supports deep linking where the app developer is expected to call the `trackAdobeDeepLink` API and pass the deep linking URL, which is the fingerprinter URL that is generated in Adobe Mobile Services during configuration. The SDK pings the fingerprinter to get acquisition data and appends it to the install/launch analytics calls context data as a part of lifecycle. In addition, the SDK also appends the deeplink data from the deeplink URL parameters. For more information on deep linking, see [Tracking Deep Links](/docs/ios/acquisition-main/tracking-deep-links/tracking-deep-links.md).

## Facebook deep linking

An ad creator can create an ad on Facebook as a deep link. When users click the ad on Facebook, it goes directly to the information in which they are interested in the app. The deep link, is **not** a fingerprinter URL. However, during ad configuration, there is an option to provide a third-party deep link URL. An app developer who is using the Experience Cloud Mobile SDKs and services is expected to enter the Mobile Services configured fingerprinter URL in this field. If everything is set up correctly, the Facebook SDK passes this URL to the application when the app is installed or launched.

## Setting up the SDKs

1. Set up the Facebook SDK.

    For more information, see the following:

    * [Getting Started with the Facebook SDK for iOS](https://developers.facebook.com/docs/ios/getting-started) 
    * [Deeplinking Setup](https://developers.facebook.com/docs/app-ads/deep-linking#os)

1. To set up the SDK, call `trackAdobeDeepLink` and pass the URL to the SDKs:

   ```objective-c
   - (BOOL)application:(UIApplication *)application openURL:(NSURL *)url sourceApplication:(NSString *)sourceApplication annotation:(id)annotation 
   { 
     [ADBMobile trackAdobeDeepLink:url]; 
     return YES; 
   }
   ```

   > **Tip:** Ensure that the deep link URL has a key with the name `a.deeplink.id`. No URL parameters will be appended to the context data if the URL missed the `a.deeplink.id` parameter.

If the application is set up as described above, the current AMSDK version will work fine and append the deep link data to install/launch analytics calls correctly.

## Enable the feature in a sample application

1. Register a URL scheme.

   Ensure that you registered a URL scheme, which is the same as the deep link URL.

   ```objective-c
   <key>CFBundleURLTypes</key> 
       <array> 
           <dict> 
               <key>CFBundleURLSchemes</key> 
               <array> 
                   <string>sampleapptest</string> 
               </array> 
           </dict> 
       </array>
   ```

1. Link the Facebook SDKs.

   ![Facebook assets](assets/link-fb-sdk.jpg)

1. Edit `AppDelegate`.

    1. Import the headers.

       ```objective-c
       /************************************************************************* 
       ADOBE SYSTEMS INCORPORATED 
       Copyright 2015 Adobe Systems Incorporated 
       All Rights Reserved. 
       NOTICE:  Adobe permits you to use, modify, and distribute this file in accordance with the 
       terms of the Adobe license agreement accompanying it.  If you have received this file from a 
       source other than Adobe, then your use, modification, or distribution of it requires the prior 
       written permission of Adobe. 

       **************************************************************************/ 

       #import "AppDelegate.h" 
       #import "GalleryViewController.h" 
       #import "SimpleTrackingController.h" 
       #import "PostbackController.h" 
       #import "InAppMessageViewController.h" 
       #import "LifetimeValueController.h" 
       #import "LocationTargetingController.h" 
       #import "MediaViewController.h" 
       #import "TimedActionController.h"

       // Uncomment after including the facebook sdks. 
       @import FBSDKCoreKit; 
       @import Bolts;
       ```

    1. Add the handle for deferred deep linking.

       ```objective-c
       - (BOOL) application:(UIApplication *)application didFinishLaunchingWithOptions:(NSDictionary *)launchOptions { 
           /* 
            * Adobe Tracking - Analytics 
            * 
            * turn on debug logging for the ADBMobile SDK 
            * enable the collection of lifecycle data 
            */ 
               if (launchOptions[UIApplicationLaunchOptionsURLKey] == nil) { 
                   if (NSClassFromString(@"FBSDKAppLinkUtility") != nil) 
                   { 
                       [NSClassFromString(@"FBSDKAppLinkUtility") performSelector:@selector(fetchDeferredAppLink:) withObject:^(NSURL *url, NSError *error) { 
                           if (error) { 
                               NSLog(@"Received error while fetching deferred app link %@", error); 
                           } 
                           if (url) { 
                               [[UIApplication sharedApplication] openURL:url]; 
                           } 
                       }]; 
                   } 
           } 
           ..... 
           ..... 
           return YES; 
       }
       ```

    1. Call the `trackAdobeDeepLink` API and pass the deep link URL to the SDK.

       ```objective-c
       - (BOOL)application:(UIApplication *)app openURL:(NSURL *)url options:(NSDictionary<NSString *, id> *)options { 
           [self handleDeepLink:url]; 

           return YES; 
       }
       ```
