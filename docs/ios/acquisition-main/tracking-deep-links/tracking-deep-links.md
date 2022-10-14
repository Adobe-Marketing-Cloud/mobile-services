# Tracking deep links

You can use this information to track deep and deferred deep links in your mobile apps by using the Adobe Mobile iOS SDK.

For more information about how marketers use deep linking in their applications, see [Acquisition](/docs/ios/acquisition-main/acquisition.md) in the Mobile Services documentation.

## Tracking deep links

1. Add the SDK to your project and implement Lifecycle metrics.

   For more information, see *Add the SDK and Config File to your Project* in [Core Implementation and Lifecycle](/docs/ios/getting-started/dev-qs.md). 
1. Register the application to handle Inter-App Communications or support Universal Links. 

    For more information, see [Inter-App Communications](https://developer.apple.com/library/ios/documentation/iPhone/Conceptual/iPhoneOSProgrammingGuide/Inter-AppCommunication/Inter-AppCommunication.html#//apple_ref/doc/uid/TP40007072-CH6-SW10) or [Support Universal Links](https://developer.apple.com/library/ios/documentation/General/Conceptual/AppSearch/UniversalLinks.html)

1. Track deep link in openURL.

   Here is a sample track deep link:

   ```objective-c
   - (BOOL)application:(UIApplication *)application handleOpenURL:(NSURL *)url { 
       [ADBMobile trackAdobeDeepLink:url]; 
       /* 
        Handle deep link 
        */ 
       return YES; 
   } 
   - (BOOL)application:(UIApplication *)app openURL:(NSURL *)url options:(NSDictionary<NSString *, id> *)options { 
       [ADBMobile trackAdobeDeepLink:url]; 
       /* 
        Handle deep link 
        */ 

       return YES; 
   }
   ```

The Adobe Mobile SDK can parse key and value pairs of data appended to any deep or Universal Link, provided that the link contains a key with a `a.deeplink.id` label and a corresponding non-null and user generated value. All key and value pairs of data that are appended to the link will be parsed, attached to a lifecycle hit, and sent to Adobe Analytics, provided the link contains the `a.deeplink.id` key and value.

You might also choose to append one or more of the following reserved keys (with user-generated values) to the deep or Universal Link:

* `a.launch.campaign.trackingcode` 
* `a.launch.campaign.source` 
* `a.launch.campaign.medium` 
* `a.launch.campaign.term` 
* `a.launch.campaign.content`

These keys are pre-mapped variables for reporting in Adobe Analytics. For more information on mapping and processing rules, see [Processing Rules and Context Data](/docs/ios/getting-started/proc-rules.md).

### Tracking deferred deep links

1. Register Adobe data callback.

   ```objective-c
   [ADBMobile registerAdobeDataCallback:^(ADBMobileDataEvent event, NSDictionary * _Nullable adobeData) { 
   }];
   ```

1. Handle `ADBMobileDataEventDeepLink` within `AdobeDataCallback`.

   ```objective-c
   [ADBMobile registerAdobeDataCallback:^(ADBMobileDataEvent event, NSDictionary * _Nullable adobeData) { 
       if (event == ADBMobileDataEventDeepLink) { 
           [self handleDeepLink:adobeData[ADBConfigKeyCallbackDeepLink]]; 
       } 
   }];
   ```

## Deep link public information

### Methods

```objective-c
/** 
 * @brief Tracks a Adobe Deep Link click-through 
 * @param url The URL resource received from UIApplication delegate method. 
 * @note Adobe Link data will be appended to the lifecycle call if it is a launch event, otherwise an extra call will be sent. 
 */ 
+ (void) trackAdobeDeepLink:(nullable NSURL *)url;
```

#### Constants

```objective-c
/* 
 * Used within ADBMobileDataCallback 
 * Key for deep link URL. 
 */ 
FOUNDATION_EXPORT NSString *const __nonnull ADBConfigKeyCallbackDeepLink;
```
