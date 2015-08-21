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
/*
 * Adobe Tracking - Analytics
 *
 * import ADBMobile.h so we can use methods from the SDK
 */
#import "ADBMobile.h"
#define debug

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
    
	_storyboard = [UIStoryboard storyboardWithName:self.storyboardName bundle:nil];
	
	_locationManager = [[CLLocationManager alloc] init];
	[_locationManager setDelegate:self];
	[_locationManager setDesiredAccuracy:kCLLocationAccuracyBest];
	[_locationManager setPausesLocationUpdatesAutomatically:NO];
	[_locationManager startUpdatingLocation];
    
    if ([application respondsToSelector:@selector(registerUserNotificationSettings:)]) {
        // we are in iOS 8 and must ask for permission to show a local notification
        [application registerUserNotificationSettings:[UIUserNotificationSettings
                                                       settingsForTypes:UIUserNotificationTypeAlert | UIUserNotificationTypeBadge | UIUserNotificationTypeSound
                                                       categories:nil]];
    }
    
    return YES;
}

- (NSString *) storyboardName {
	return UI_USER_INTERFACE_IDIOM() == UIUserInterfaceIdiomPhone ? kPhoneStoryboard : kPadStoryboard;
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

@end
