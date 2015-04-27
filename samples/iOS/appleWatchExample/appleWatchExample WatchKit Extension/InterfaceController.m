/*************************************************************************

ADOBE SYSTEMS INCORPORATED
Copyright 2015 Adobe Systems Incorporated
All Rights Reserved.

NOTICE:  Adobe permits you to use, modify, and distribute this file in accordance with the
terms of the Adobe license agreement accompanying it.  If you have received this file from a
source other than Adobe, then your use, modification, or distribution of it requires the prior
written permission of Adobe.

**************************************************************************/

#import "InterfaceController.h"
#import "ADBMobile.h"

@implementation InterfaceController

- (void)awakeWithContext:(id)context {
    [super awakeWithContext:context];

	// set your AppGroup in ADBMobile
    [ADBMobile setAppGroup:@"group.adb.appleWatchExample"];

	// turn on logging in ADBMobile
	[ADBMobile setDebugLogging:YES];
}

- (IBAction) trackStateExample {
	// send a trackState call
	NSDictionary *contextData = @{@"origin":@"watchApp"};
	[ADBMobile trackState:@"watchAppMainPage" data:contextData];
}

- (IBAction) trackActionExample {
	// send a trackAction call
	NSDictionary *contextData = @{@"origin":@"watchApp"};
	[ADBMobile trackAction:@"trackExamplePushed" data:contextData];
}

@end
