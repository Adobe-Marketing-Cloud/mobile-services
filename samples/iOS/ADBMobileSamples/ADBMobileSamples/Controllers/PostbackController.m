/*************************************************************************

ADOBE SYSTEMS INCORPORATED
Copyright 2015 Adobe Systems Incorporated
All Rights Reserved.

NOTICE:  Adobe permits you to use, modify, and distribute this file in accordance with the
terms of the Adobe license agreement accompanying it.  If you have received this file from a
source other than Adobe, then your use, modification, or distribution of it requires the prior
written permission of Adobe.
 
**************************************************************************/

#import "PostbackController.h"
#import <QuartzCore/QuartzCore.h>
#import "ADBMobile.h"

NSString *const CUSTOM_KEY1 = @"k1";
NSString *const CUSTOM_KEY2 = @"k2";

@implementation PostbackController
{
}

- (IBAction)sendPostback:(UIButton *)sender
{
    NSMutableDictionary *customData = nil;
    
    if (self.customVal1.text && ![self.customVal1.text isEqualToString:@""])
    {
        customData = [[NSMutableDictionary alloc] init];
        [customData setObject:self.customVal1.text forKey:CUSTOM_KEY1];
    }
    
    if (self.customVal2.text && ![self.customVal2.text isEqualToString:@""])
    {
        if (!customData)
        {
            customData = [[NSMutableDictionary alloc] init];
        }
        
        [customData setObject:self.customVal2.text forKey:CUSTOM_KEY2];
    }
    
    [ADBMobile trackAction:@"test-postback" data:customData];
}

- (void) viewDidLoad
{
    [super viewDidLoad];
}

@end
