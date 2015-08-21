/*************************************************************************

ADOBE SYSTEMS INCORPORATED
Copyright 2015 Adobe Systems Incorporated
All Rights Reserved.

NOTICE:  Adobe permits you to use, modify, and distribute this file in accordance with the
terms of the Adobe license agreement accompanying it.  If you have received this file from a
source other than Adobe, then your use, modification, or distribution of it requires the prior
written permission of Adobe.
 
**************************************************************************/

#pragma mark - Imports

#import <QuartzCore/QuartzCore.h>
#import "GalleryViewController.h"
#import "GalleryItem.h"
#import "AppDelegate.h"
#import "ADBMobile.h"
#import "ADBS7ImageView.h"

#pragma mark - Class constants

#define kTransparencyNone		1.0f
#define kTransparencyHalf		0.5f
#define kTransparencyFull		0.0f

#define kViewCornerRadius		5.0f
#define kFadeAnimationDuration	0.3f
#define kFadeAnimationDelay		0.0f

#define kMboxSuccessEvent		@"gallerysuccess"

#define kTARGET_DEFAULT			@"none"
#define kURL_DEFAULT			@"http://yodawg.mobi/store"
#define kURL_BOGO				@"http://yodawg.mobi/store/bogo"
#define kURL_50_OFF				@"http://yodawg.mobi/store/50off"
#define kMBOX_ORDER_CONFIRM		@"orderConfirm"

#define kGalleryItemsCount		_galleryItems.count
#define kGalleryItemCell		@"GalleryItemCell"

#define kS7ImageListPath		@"imagelist"
#define kPListResourceType		@"plist"
#define kS7Name					@"name"
#define kS7Description			@"description"
#define kS7Asset				@"asset"
#define kS7Params				@"s7parameters"

#pragma mark
@implementation GalleryViewController {}

#pragma mark - ViewController delegate methods

- (void) viewDidLoad {
    [super viewDidLoad];
	
	/*
	 * Adobe Tracking - Analytics
	 *
	 * call to trackState:data: for view states report
	 * trackState:data: increments the page view
	 */
	[ADBMobile trackState:@"Gallery" data:nil];
	
	// make backgrounds look nice
	[self roundCornersForView:self.viewInfoBackground];
	[self roundCornersForView:self.viewProgressBackground];
	
	// initilize gallery
	[self createGalleryItems];
	
	// show first image by default
	[self showFirstGalleryItem];
	
	// add the buy button on the nav controller
	UIBarButtonItem *btnBuy = [[UIBarButtonItem alloc] initWithTitle:@"$"
															   style:UIBarButtonItemStylePlain
															  target:self
															  action:@selector(btnBuyPressed:)];
	UIFont *font = [UIFont fontWithName:@"Helvetica-Bold" size:24.0];
	NSDictionary *attributes = @{NSFontAttributeName:font};
	[btnBuy setTitleTextAttributes:attributes forState:UIControlStateNormal];
	self.navigationItem.rightBarButtonItem = btnBuy;
	
	// init web url string
	_webURL = kURL_DEFAULT;
	
	// check for special offer
	[self checkForSpecialOffer];
}

#pragma mark - EngineeringViewController delegate methods

- (void) createGalleryItems{
	_galleryItems = [@[] mutableCopy];
    
    NSString *imageListFile = [[NSBundle mainBundle] pathForResource:kS7ImageListPath ofType:kPListResourceType];
	
    for (NSDictionary *d in [NSArray arrayWithContentsOfFile:imageListFile]) {
        [_galleryItems addObject:[[GalleryItem alloc] initWithTitle:d[kS7Name] description:d[kS7Description] asset:d[kS7Asset] params:d[kS7Params]]];
	}
}

- (void) showFirstGalleryItem {
	if (!_currentIndex) {
		_currentIndex = 0;
		
		[self updateGalleryItemInEngineeringView];
	}
}

- (void) showNextGalleryItem {
	// don't allow them to go past the last item in the array
	if (_currentIndex == _galleryItems.count - 1)
		return;
	
	_currentIndex++;
	[self updateGalleryItemInEngineeringView];
}

- (void) showPreviousGalleryItem {
	// don't allow them to go below the first item in the array
	if (_currentIndex == 0)
		return;
	
	_currentIndex--;
	[self updateGalleryItemInEngineeringView];
}

- (void) updateGalleryItemText {
    _lblProgress.text = [NSString stringWithFormat:@"%ld of %lu", _currentIndex+1, (unsigned long)kGalleryItemsCount];
}

- (void) updateGalleryItemInEngineeringView {
	// get the current item and update the view controller
	[self setGalleryItem:[_galleryItems objectAtIndex:_currentIndex]];
	
    [self performSelectorOnMainThread:@selector(updateGalleryItemText) withObject:nil waitUntilDone:NO];
	
	// handle animations to show new gallery item
	_imgGallery.alpha = 0.8f;
	if (_infoVisible) {
		_viewInfoBackground.alpha = 0.0f;
		_lblInfo.alpha = 0.0f;
	}
	
	if (_infoVisible) {
		[UIView animateWithDuration:0.3f delay:0 options:UIViewAnimationOptionAllowUserInteraction animations:^() {
			_imgGallery.alpha = 0.5f;
		} completion:nil];
		[UIView animateWithDuration:1.0f delay:0 options:UIViewAnimationOptionAllowUserInteraction animations:^() {
			_viewInfoBackground.alpha = 1.0f;
			_lblInfo.alpha = 1.0f;
		} completion:nil];
	}
	else {
		[UIView animateWithDuration:0.3f delay:0 options:UIViewAnimationOptionAllowUserInteraction animations:^() {
			_imgGallery.alpha = 1.0f;
		} completion:nil];
	}
}

#pragma mark - Gesture recognizer delegates

- (BOOL) gestureRecognizerShouldBegin:(UIGestureRecognizer *)gestureRecognizer {
	if (gestureRecognizer == _tapRecognizer) {
		[self toggleInfo];
	}
	else if (gestureRecognizer == _swipeLeftRecognizer) {
		[self showNextGalleryItem];
	}
	else if (gestureRecognizer == _swipeRightRecognizer) {
		[self showPreviousGalleryItem];
	}
	
	return YES;
}

#pragma mark - GalleryItem helpers

- (void) setGalleryItem:(GalleryItem *)galleryItem {
	if (galleryItem != _galleryItem){
		_galleryItem = galleryItem;
	}
    self.imgGallery.image = nil;
    [self.imgGallery setS7Params: _galleryItem.s7params];
    [self.imgGallery setS7ResourceName:_galleryItem.assetName];
    
	self.navigationItem.title = _galleryItem.title;
	self.lblInfo.text = _galleryItem.theDescription;
}

- (void) toggleInfo {
	self.infoVisible = !self.infoVisible;
	
	[UIView animateWithDuration:kFadeAnimationDuration
						  delay:kFadeAnimationDelay
						options:UIViewAnimationOptionAllowUserInteraction | UIViewAnimationOptionCurveEaseIn
					 animations:^() {
						 self.viewInfoBackground.alpha = self.infoVisible ? kTransparencyNone : kTransparencyFull;
						 self.lblInfo.alpha = self.infoVisible ? kTransparencyNone : kTransparencyFull;
						 self.imgGallery.alpha = self.infoVisible ? kTransparencyHalf : kTransparencyNone;
					 }
					 completion:nil];
}

#pragma mark - Layout helpers

- (void) roundCornersForView:(UIView *)view {
	view.layer.cornerRadius = kViewCornerRadius;
	view.layer.masksToBounds = YES;
}

- (IBAction) btnBuyPressed:(id)sender {
	CFUUIDRef guidRef = CFUUIDCreate(kCFAllocatorDefault);
	NSString *orderId = (__bridge_transfer NSString *)CFUUIDCreateString(kCFAllocatorDefault, guidRef);
	CFRelease(guidRef);
	
	/* Adobe Tracking - Analytics
	 *
	 * track the revenue produced by this purchase
	 * we are just putting a fake ammount (39.95) to produce data
	 */
	[ADBMobile trackAction:@"Purchase Image" data:@{@"revenue": @39.95,
													@"imageName" : _galleryItem.title}];
	
	/* Adobe Tracking - Target
	 *
	 * create an order confirm request for target
	 */
	ADBTargetLocationRequest *req = [ADBMobile targetCreateOrderConfirmRequestWithName: kMBOX_ORDER_CONFIRM
																			   orderId: orderId
																			orderTotal: @"39.95"
																	productPurchasedId: _galleryItem.title
																			parameters: nil];
	
	/* Adobe Tracking - Target
	 *
	 * send the order confirm request
	 * for an order confirm, we don't care about the callback, so we pass nil
	 */
	[ADBMobile targetLoadRequest: req callback: nil];
	
	[self launchWebStore];
}

- (void) launchWebStore {
	/* Adobe Tracking - Analytics
	 *
	 * attach the trackingIdentifier from analytics sdk to url in our web store
	 */
	NSURL *webStoreUrl = [NSURL URLWithString:[NSString stringWithFormat:@"%@?visitorId=%@&imgName=%@", _webURL, [ADBMobile trackingIdentifier], _galleryItem.assetName]];
	
	[[UIApplication sharedApplication] openURL:webStoreUrl];
}

#pragma mark - Target Methods for Special Offer

- (void) checkForSpecialOffer {
	/* Adobe Tracking - Target
	 *
	 * create a request for our bannerOffer location
	 * default content is nil so we don't apply an image if our request times out
	 */
	ADBTargetLocationRequest *specialRequest = [ADBMobile targetCreateRequestWithName:@"bannerOffer" defaultContent:nil parameters:nil];
	
	/* Adobe Tracking - Target
	 *
	 * send the request to see if the user gets a special offer
	 * on the back end, we are returning an image file in "content", so we will set
	 * the image equal to what gets returned
	 */
	[ADBMobile targetLoadRequest:specialRequest callback:^(NSString *content) {
        [self performSelectorOnMainThread:@selector(updateSpecialOfferImage:) withObject:content waitUntilDone:NO];
		if (content.length) {
			if ([content rangeOfString:@"50"].location != NSNotFound) {
				_webURL = kURL_50_OFF;
			}
			else {
				_webURL = kURL_BOGO;
			}
		}
	}];
}

- (void) updateSpecialOfferImage:(NSString *)content {
    _imgBanner.image = [UIImage imageNamed:content];
}

@end
