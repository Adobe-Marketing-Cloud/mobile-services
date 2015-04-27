//
//  ViewController.m
//  appleWatchExample
//
//  Created by Stephen Benedick on 4/24/15.
//  Copyright (c) 2015 adobe. All rights reserved.
//

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