/*************************************************************************

ADOBE SYSTEMS INCORPORATED
Copyright 2015 Adobe Systems Incorporated
All Rights Reserved.

NOTICE:  Adobe permits you to use, modify, and distribute this file in accordance with the
terms of the Adobe license agreement accompanying it.  If you have received this file from a
source other than Adobe, then your use, modification, or distribution of it requires the prior
written permission of Adobe.
 
**************************************************************************/

#import <UIKit/UIKit.h>
#import <CoreLocation/CoreLocation.h>

#define kPhoneStoryboard @"MainStoryboard_iPhone"
#define kPadStoryboard @"MainStoryboard_iPad"

@interface AppDelegate : UIResponder <UIApplicationDelegate, CLLocationManagerDelegate>

@property (strong, nonatomic) UIWindow *window;
@property (strong, nonatomic) UIStoryboard *storyboard;
@property (strong, nonatomic) CLLocationManager *locationManager;
@property (readonly) NSString *storyboardName;

@end