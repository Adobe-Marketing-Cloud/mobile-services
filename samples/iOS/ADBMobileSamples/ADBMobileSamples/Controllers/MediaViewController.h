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

@interface MediaViewController : UIViewController

@property (assign) IBOutlet UIView *blackBackground;
@property (weak, nonatomic) IBOutlet UISwitch *swTrackMilestones;
@property (weak, nonatomic) IBOutlet UISwitch *swSegmentByMilestones;
@property (weak, nonatomic) IBOutlet UISwitch *swTrackOffsetMilestones;
@property (weak, nonatomic) IBOutlet UISwitch *swSegmentByOffsetMilestones;
@property (weak, nonatomic) IBOutlet UISwitch *swTrackSeconds;

@end
