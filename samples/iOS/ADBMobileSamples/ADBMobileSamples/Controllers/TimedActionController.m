/*************************************************************************

ADOBE SYSTEMS INCORPORATED
Copyright 2015 Adobe Systems Incorporated
All Rights Reserved.

NOTICE:  Adobe permits you to use, modify, and distribute this file in accordance with the
terms of the Adobe license agreement accompanying it.  If you have received this file from a
source other than Adobe, then your use, modification, or distribution of it requires the prior
written permission of Adobe.
 
**************************************************************************/

#import "TimedActionController.h"
#import "ADBMobile.h"
#import <QuartzCore/QuartzCore.h>

@implementation TimedActionController

- (void) viewDidLoad {
	/*
	 * Adobe Tracking - Analytics
	 *
	 * call to trackState:data: for view states report
	 * trackState:data: increments the page view
	 */
	[ADBMobile trackState:@"Timed Action Example" data:nil];

	// make our black background rounded
	_blackBackground.layer.cornerRadius = 5;
	_blackBackground.layer.masksToBounds = YES;
}

- (void) updateTimeLabel:(UILabel *)label1 label2:(UILabel *)label2 time1:(NSTimeInterval)t1 time2:(NSTimeInterval)t2 {
    
}

- (IBAction) startAction1 {
	/*
	 * Adobe Tracking - Analytics
	 *
	 * start a timed action with name "action1" and no additional context data
	 * note: if you call trackTimedActionStart:data: for an action already running, it will overwrite the existing one
	 */
	[ADBMobile trackTimedActionStart:@"action1" data:nil];
}

- (IBAction) stopAction1 {
	/*
	 * Adobe Tracking - Analytics
	 *
	 * stop a timed action with name "action1"
	 * in the logic: callback, you can manipulate your context data as the NSMutableDictionary data object
	 * you must return YES if you want the SDK to send a hit for this timed action, or NO to suppress the hit
	 */
	[ADBMobile trackTimedActionEnd:@"action1" logic:^BOOL(NSTimeInterval inAppDuration, NSTimeInterval totalDuration, NSMutableDictionary *data) {
        [self performSelectorOnMainThread:@selector(updateAction1Labels:) withObject:@[@(inAppDuration), @(totalDuration)] waitUntilDone:NO];
		
		return YES;
	}];
}

- (void) updateAction1Labels:(NSArray *)newTimes {
    _lblAction1InApp.text = [NSString stringWithFormat:@"%.0f second(s)", [newTimes[0] floatValue]];
    _lblAction1Total.text = [NSString stringWithFormat:@"%.0f second(s)", [newTimes[1] floatValue]];
}

- (IBAction) startAction2 {
	/*
	 * Adobe Tracking - Analytics
	 *
	 * start a timed action with name "action2" and no additional context data
	 * note: if you call trackTimedActionStart:data: for an action already running, it will overwrite the existing one
	 */
	[ADBMobile trackTimedActionStart:@"action2" data:nil];
}

- (IBAction) stopAction2 {
	/*
	 * Adobe Tracking - Analytics
	 *
	 * stop a timed action with name "action2"
	 * in the logic: callback, you can manipulate your context data as the NSMutableDictionary data object
	 * you must return YES if you want the SDK to send a hit for this timed action, or NO to suppress the hit
	 */
	[ADBMobile trackTimedActionEnd:@"action2" logic:^BOOL(NSTimeInterval inAppDuration, NSTimeInterval totalDuration, NSMutableDictionary *data) {
        [self performSelectorOnMainThread:@selector(updateAction2Labels:) withObject:@[@(inAppDuration), @(totalDuration)] waitUntilDone:NO];
		
		return YES;
	}];
}

- (void) updateAction2Labels:(NSArray *)newTimes {
    _lblAction2InApp.text = [NSString stringWithFormat:@"%.0f second(s)", [newTimes[0] floatValue]];
    _lblAction2Total.text = [NSString stringWithFormat:@"%.0f second(s)", [newTimes[1] floatValue]];
}

@end
