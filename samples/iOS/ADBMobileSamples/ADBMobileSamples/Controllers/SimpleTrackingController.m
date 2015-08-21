/*************************************************************************

ADOBE SYSTEMS INCORPORATED
Copyright 2015 Adobe Systems Incorporated
All Rights Reserved.

NOTICE:  Adobe permits you to use, modify, and distribute this file in accordance with the
terms of the Adobe license agreement accompanying it.  If you have received this file from a
source other than Adobe, then your use, modification, or distribution of it requires the prior
written permission of Adobe.
 
**************************************************************************/

#import "SimpleTrackingController.h"
#import <QuartzCore/QuartzCore.h>
/*
 * Adobe Tracking - Analytics
 *
 * import ADBMobile.h so we can use methods from the SDK
 */
#import "ADBMobile.h"

@implementation SimpleTrackingController

- (void) viewDidLoad {
    /*
     * Adobe Tracking - Analytics
     *
     * call to trackState:data: for view states report
     * trackState:data: increments the page view
     */
	[ADBMobile trackState:@"Simple Tracking Example" data:nil];
	
	// make our black background rounded
	_blackBackground.layer.cornerRadius = 5;
	_blackBackground.layer.masksToBounds = YES;
}

- (IBAction) trackState {
	NSMutableDictionary *contextData = [NSMutableDictionary dictionary];
	if (_txtUserName.text.length) {
		[contextData setObject:_txtUserName.text forKey:@"user.name"];
	}
			
    /*
     * Adobe Tracking - Analytics
     *
     * call to trackState:data: for view states report
     * trackState:data: increments the page view
     */
	[ADBMobile trackState:@"Example State" data:contextData];
}

- (IBAction) trackAction {
	NSMutableDictionary *contextData = [NSMutableDictionary dictionary];
	[contextData setObject:@"Example State" forKey:@"page.name"];
	if (_txtUserName.text.length) {
		[contextData setObject:_txtUserName.text forKey:@"user.name"];
	}

	/*
	 * Adobe Tracking - Analytics
     *
	 * call to trackAction:data: indicating the trackAction button was pushed
	 * trackAction:data: does not increment page view
     * actions are often mapped to events via processing rules
	 */
	[ADBMobile trackAction:@"trackAction:data: button pushed" data:contextData];
}

#pragma mark - UITextFieldDelegate Methods
- (BOOL) textFieldShouldReturn:(UITextField *)textField {
	[textField resignFirstResponder];
	return YES;
}

- (void) touchesEnded:(NSSet *)touches withEvent:(UIEvent *)event {
	if ([_txtUserName isFirstResponder]) {
		[_txtUserName resignFirstResponder];
	}
}

@end
