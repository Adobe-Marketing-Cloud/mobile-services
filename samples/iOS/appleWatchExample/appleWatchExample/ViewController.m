/*************************************************************************

ADOBE SYSTEMS INCORPORATED
Copyright 2015 Adobe Systems Incorporated
All Rights Reserved.

NOTICE:  Adobe permits you to use, modify, and distribute this file in accordance with the
terms of the Adobe license agreement accompanying it.  If you have received this file from a
source other than Adobe, then your use, modification, or distribution of it requires the prior
written permission of Adobe.

**************************************************************************/

#import "ViewController.h"
#import "ADBMobile.h"

@implementation ViewController

- (IBAction) trackStateExample {
	// send a trackState call
	NSDictionary *contextData = @{@"origin":@"containingApp"};
	[ADBMobile trackState:@"containingAppMainPage" data:contextData];
}

- (IBAction) trackActionExample {
	// send a trackAction call
	NSDictionary *contextData = @{@"origin":@"containingApp"};
	[ADBMobile trackAction:@"trackExamplePushed" data:contextData];
}

@end
