//
//  InterfaceController.m
//  appleWatchExample WatchKit Extension
//
//  Created by Stephen Benedick on 4/24/15.
//  Copyright (c) 2015 adobe. All rights reserved.
//

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



