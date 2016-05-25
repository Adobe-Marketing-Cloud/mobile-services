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

/*
 * Adobe Tracking - Analytics
 *
 * import ADBMobile.h so we can use methods from the SDK
 */
#import "ADBMobile.h"

/*
 * Debug setting
 *
 * uncomment to use ADBMobileConfigBloodhound.json
 */
//#define debug

static NSString *const ACTION_WINK_IDENTIFIER =         @"WINK_IDENTIFIER";
static NSString *const ACTION_SUNGLASSES_IDENTIFIER	=   @"SUNGLASSES_IDENTIFIER";

@implementation AppDelegate

- (BOOL) application:(UIApplication *)application didFinishLaunchingWithOptions:(NSDictionary *)launchOptions {
	/*
	 * Adobe Tracking - Analytics
	 *
	 * turn on debug logging for the ADBMobile SDK
     * enable the collection of lifecycle data
	 */
	
	// switch to determine which config file to use based on run mode
#ifdef debug
	NSString *filePath = [[NSBundle mainBundle] pathForResource:@"ADBMobileConfigBloodhound" ofType:@"json"];
	[ADBMobile overrideConfigPath:filePath];
#endif
	
	[ADBMobile setDebugLogging:YES];
    [ADBMobile collectLifecycleData];
    [ADBMobile registerAdobeDataCallback:^(ADBMobileDataEvent event, NSDictionary * _Nullable adobeData) {
        if (event == ADBMobileDataEventDeepLink) {
            [self handleDeepLink:adobeData[@"link_deferred"]];
        }
    }];
    
	_storyboard = [UIStoryboard storyboardWithName:self.storyboardName bundle:nil];
	
	_locationManager = [[CLLocationManager alloc] init];
	[_locationManager setDelegate:self];
	[_locationManager setDesiredAccuracy:kCLLocationAccuracyBest];
	[_locationManager setPausesLocationUpdatesAutomatically:NO];
	[_locationManager startUpdatingLocation];
	
    [self registerUserNotifications];
	
    return YES;
}

- (void) application:(UIApplication *)application didRegisterForRemoteNotificationsWithDeviceToken:(NSData *)deviceToken {
	[ADBMobile setPushIdentifier:deviceToken];
}

- (void) application:(UIApplication *)application didFailToRegisterForRemoteNotificationsWithError:(NSError *)error {
	[ADBMobile setPushIdentifier:nil];
}

// app target < iOS 7
- (void)application:(UIApplication *)application didReceiveRemoteNotification:(NSDictionary *)userInfo {
	// only send the hit if the app is not active
	if (application.applicationState != UIApplicationStateActive) {
		[ADBMobile trackPushMessageClickThrough:userInfo];
	}
}

// app target >= iOS 7
- (void)application:(UIApplication *)application didReceiveRemoteNotification:(NSDictionary *)userInfo fetchCompletionHandler:(void (^)(UIBackgroundFetchResult))completionHandler {
	// only send the hit if the app is not active
	if (application.applicationState != UIApplicationStateActive) {
		[ADBMobile trackPushMessageClickThrough:userInfo];
	}
	completionHandler(UIBackgroundFetchResultNoData);
}

- (NSString *) storyboardName {
	return UI_USER_INTERFACE_IDIOM() == UIUserInterfaceIdiomPhone ? kPhoneStoryboard : kPadStoryboard;
}

#pragma mark - deep link handlers
- (BOOL)application:(UIApplication *)application handleOpenURL:(NSURL *)url {
    [self handleDeepLink:url];
    
    return YES;
}

- (BOOL)application:(UIApplication *)app openURL:(NSURL *)url options:(NSDictionary<NSString *, id> *)options {
    [self handleDeepLink:url];
    
    return YES;
}

#pragma mark - deep link helpers
- (void) handleDeepLink:(NSURL *) url {
    /*
     Handle your deep link
     */
    [ADBMobile trackAdobeDeepLink:url];
    
    MasterViewController* mainController = (MasterViewController*)  self.window.rootViewController;
    UIStoryboard *mainStoryboard = [UIStoryboard storyboardWithName:@"MainStoryboard_iPhone"
                                                             bundle: nil];
    
    NSString *path = url.path;
    NSDictionary *queryParams = [self parseQueryString:url.query];
    UIViewController *viewController;
    if ([path isEqualToString:@"/GalleryViewController"]) {
        viewController = (GalleryViewController*)[mainStoryboard instantiateViewControllerWithIdentifier: @"GalleryViewController"];
    } else if ([path isEqualToString:@"/SimpleTrackingController"]) {
        viewController = [mainStoryboard instantiateViewControllerWithIdentifier: @"SimpleTrackingController"];
    } else if ([path isEqualToString:@"/LifetimeValueController"]) {
        viewController = [mainStoryboard instantiateViewControllerWithIdentifier: @"LifetimeValueController"];
    } else if ([path isEqualToString:@"/LocationTargetingController"]) {
        viewController = [mainStoryboard instantiateViewControllerWithIdentifier: @"LocationTargetingController"];
    } else if ([path isEqualToString:@"/MediaViewController"]) {
        viewController = [mainStoryboard instantiateViewControllerWithIdentifier: @"MediaViewController"];
    } else if ([path isEqualToString:@"/TimedActionController"]) {
        viewController = [mainStoryboard instantiateViewControllerWithIdentifier: @"TimedActionController"];
    } else if ([path isEqualToString:@"/PostbackController"]) {
        viewController = [mainStoryboard instantiateViewControllerWithIdentifier: @"PostbackController"];
    } else if ([path isEqualToString:@"/InAppMessageViewController"]) {
        viewController = [mainStoryboard instantiateViewControllerWithIdentifier: @"InAppMessageViewController"];
    }
    [mainController presentViewController:viewController animated:NO completion:^{}];
}

- (NSDictionary *)parseQueryString:(NSString *)query {
    NSMutableDictionary *dict = [[NSMutableDictionary alloc] initWithCapacity:6];
    NSArray *pairs = [query componentsSeparatedByString:@"&"];
    
    for (NSString *pair in pairs) {
        NSArray *elements = [pair componentsSeparatedByString:@"="];
        NSString *key = [[elements objectAtIndex:0] stringByReplacingPercentEscapesUsingEncoding:NSUTF8StringEncoding];
        NSString *val = [[elements objectAtIndex:1] stringByReplacingPercentEscapesUsingEncoding:NSUTF8StringEncoding];
        
        [dict setObject:val forKey:key];
    }
    return dict;
}

- (void) locationManager:(CLLocationManager *)manager didUpdateLocations:(NSArray *)locations {
	CLLocation *currentLocation = [locations lastObject];
	if (currentLocation.horizontalAccuracy <= 100 && currentLocation.verticalAccuracy <= 100) {
		[_locationManager stopUpdatingLocation];
		[self trackCurrentLocation: currentLocation];
	}
}

- (void) trackCurrentLocation:(CLLocation *)location {
	static dispatch_once_t onceToken;
	dispatch_once(&onceToken, ^{
		/*
		 * Adobe Tracking - Analytics
		 *
		 * trackLocation:data: call to get the location of the current user
		 * because the config file has points of interest in it, the SDK will automatically determine
		 * whether the user falls within a point of interest
		 */
		[ADBMobile trackLocation:location data:nil];
	});
}

#pragma mark - message handlers
- (void)application:(UIApplication *)application handleActionWithIdentifier:(nullable NSString *)identifier forLocalNotification:(nonnull UILocalNotification *)notification completionHandler:(nonnull void (^)())completionHandler {
    /* Take action based on action identifier */
    if ([identifier isEqualToString:ACTION_WINK_IDENTIFIER]) {
        [ADBMobile trackAction:ACTION_WINK_IDENTIFIER data:nil];
    } else if ([identifier isEqualToString:ACTION_SUNGLASSES_IDENTIFIER]) {
        [ADBMobile trackAction:ACTION_SUNGLASSES_IDENTIFIER data:nil];
    }
}

#pragma mark - message helpers
- (void)registerUserNotifications {
    if ([[UIApplication sharedApplication] respondsToSelector:@selector(registerUserNotificationSettings:)]) {
        UIMutableUserNotificationAction *winkAction =
        [[UIMutableUserNotificationAction alloc] init];
        winkAction.identifier = ACTION_WINK_IDENTIFIER;
        winkAction.title = @"😉";
        winkAction.activationMode = UIUserNotificationActivationModeBackground;
        winkAction.destructive = NO;
        winkAction.authenticationRequired = NO;
        
        UIMutableUserNotificationAction *sunglassesAction =
        [[UIMutableUserNotificationAction alloc] init];
        sunglassesAction.identifier = ACTION_SUNGLASSES_IDENTIFIER;
        sunglassesAction.title = @"😎";
        sunglassesAction.activationMode = UIUserNotificationActivationModeBackground;
        sunglassesAction.destructive = NO;
        sunglassesAction.authenticationRequired = NO;
        
        UIMutableUserNotificationCategory *inviteCategory =
        [[UIMutableUserNotificationCategory alloc] init];
        
        inviteCategory.identifier = @"EXAMPLE_CATEGORY_TRACK";
        
        [inviteCategory setActions:@[winkAction, sunglassesAction]
                        forContext:UIUserNotificationActionContextDefault];
        
        [inviteCategory setActions:@[winkAction, sunglassesAction]
                        forContext:UIUserNotificationActionContextMinimal];
        
        NSSet *categories = [NSSet setWithObjects:inviteCategory, nil];
        
        UIUserNotificationSettings *settings = [UIUserNotificationSettings settingsForTypes:(UIUserNotificationTypeBadge
                                                                                             |UIUserNotificationTypeSound
                                                                                             |UIUserNotificationTypeAlert)
                                                                                 categories:categories];
        
        [[UIApplication sharedApplication] registerUserNotificationSettings:settings];
    }
    else {
        [[UIApplication sharedApplication] registerForRemoteNotificationTypes:(UIUserNotificationTypeBadge
                                                                               |UIUserNotificationTypeSound
                                                                               |UIUserNotificationTypeAlert)];
    }
}

@end
