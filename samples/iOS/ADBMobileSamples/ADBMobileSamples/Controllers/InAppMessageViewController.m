/*************************************************************************

ADOBE SYSTEMS INCORPORATED
Copyright 2015 Adobe Systems Incorporated
All Rights Reserved.

NOTICE:  Adobe permits you to use, modify, and distribute this file in accordance with the
terms of the Adobe license agreement accompanying it.  If you have received this file from a
source other than Adobe, then your use, modification, or distribution of it requires the prior
written permission of Adobe.
 
**************************************************************************/

/*
 * Visit https://marketing.adobe.com/resources/help/en_US/mobile/in_app_messaging.html for more information about
 * in-app messaging.
 */

#import "InAppMessageViewController.h"
#import <QuartzCore/QuartzCore.h>
/*
 * Adobe Tracking - Analytics
 *
 * import ADBMobile.h so we can use methods from the SDK
 */
#import "ADBMobile.h"

@implementation InAppMessageViewController

- (void) viewDidLoad {
    /*
     * Adobe Tracking - Analytics
     *
     * call to trackState:data: for view states report
     * trackState:data: increments the page view
     */
    [ADBMobile trackState:@"In-App Message Example" data:nil];
    
    // make our black background rounded
    _backgroundView.layer.cornerRadius = 5;
    _backgroundView.layer.masksToBounds = YES;
}

- (IBAction) showFullscreenMessage {
    /*
     * Adobe Tracking - Analytics
     *
     * triggering an in-app message on a custom state
     */
    [ADBMobile trackState:@"fullscreen example" data:nil];
}

- (IBAction) showAlertMessage {
    /*
     * Adobe Tracking - Analytics
     *
     * triggering an in-app message on a custom action
     */
    [ADBMobile trackAction:@"alert example" data:nil];
}

- (IBAction) showLocalNotificationMessage {
    /*
     * Adobe Tracking - Analytics
     *
     * triggering an in-app message on custom context data
     */
    [ADBMobile trackAction:@"local notification sample" data:@{@"local":@"notification"}];
}

@end
