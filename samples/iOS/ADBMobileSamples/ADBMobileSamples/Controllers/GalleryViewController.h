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

@class GalleryItem, ADBS7ImageView, AppDelegate;

@interface GalleryViewController : UIViewController <UIGestureRecognizerDelegate>

@property (weak) AppDelegate *appDelegate;

@property (strong) NSMutableArray *galleryItems;

@property (nonatomic, strong) GalleryItem *galleryItem;

@property (weak) IBOutlet ADBS7ImageView *imgGallery;

@property (weak) IBOutlet UIImageView *imgBanner;
@property (weak) NSString *webURL;

@property (weak) IBOutlet UIView *viewProgressBackground;
@property (weak) IBOutlet UILabel *lblProgress;

@property (weak) IBOutlet UIView *viewInfoBackground;
@property (weak) IBOutlet UILabel *lblInfo;

@property (weak) IBOutlet UISwipeGestureRecognizer *swipeLeftRecognizer;
@property (weak) IBOutlet UISwipeGestureRecognizer *swipeRightRecognizer;
@property (weak) IBOutlet UITapGestureRecognizer *tapRecognizer;

@property NSInteger currentIndex;

@property BOOL infoVisible;

@end
