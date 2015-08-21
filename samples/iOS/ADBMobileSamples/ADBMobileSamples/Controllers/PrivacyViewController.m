/*************************************************************************

ADOBE SYSTEMS INCORPORATED
Copyright 2015 Adobe Systems Incorporated
All Rights Reserved.

NOTICE:  Adobe permits you to use, modify, and distribute this file in accordance with the
terms of the Adobe license agreement accompanying it.  If you have received this file from a
source other than Adobe, then your use, modification, or distribution of it requires the prior
written permission of Adobe.
 
**************************************************************************/

#import "PrivacyViewController.h"
#import "ADBMobile.h"
#import <QuartzCore/QuartzCore.h>

@implementation PrivacyViewController

- (void) viewDidLoad {
	/*
	 * Adobe Tracking - Analytics
	 *
	 * call to trackState:data: for view states report
	 * trackState:data: increments the page view
	 */
	[ADBMobile trackState:@"Privacy Example" data:nil];
	
	// make our black background rounded
	_blackBackground.layer.cornerRadius = 5;
	_blackBackground.layer.masksToBounds = YES;
}

- (IBAction) setPrivacyOptIn {
	/*
	 * Adobe Tracking - Analytics
	 *
	 * setting privacy status to ADBMobilePrivacyStatusOptIn will send hits immediately
	 */
	[ADBMobile setPrivacyStatus:ADBMobilePrivacyStatusOptIn];
}

- (IBAction) setPrivacyOptOut {
	/*
	 * Adobe Tracking - Analytics
	 *
	 * setting privacy status to ADBMobilePrivacyStatusOptOut will discard all hits immediately
	 */
	[ADBMobile setPrivacyStatus:ADBMobilePrivacyStatusOptOut];
}

- (IBAction) setPrivacyOptUnknown {
	/*
	 * Adobe Tracking - Analytics
	 *
	 * setting privacy status to ADBMobilePrivacyStatusOptUnknown will have different behaviors
	 * if your app is not set to track offline, hits will be discarded immediately
	 * if your app is set to track offline, hits will be retained until the privacy status changes
	 * retained hits will all be sent if next privacy status is set to OptIn
	 * retained hits will all be discarded if next privacy status is set to OptOut
	 */
	[ADBMobile setPrivacyStatus:ADBMobilePrivacyStatusUnknown];
}

- (IBAction) track {
	/*
	 * Adobe Tracking - Analytics
	 *
	 * call to trackAction:data: for privacy status check
	 * trackAction:data: does not increment page views
	 */
	[ADBMobile trackAction:@"privacyStatusCheck" data:nil];
}

@end
