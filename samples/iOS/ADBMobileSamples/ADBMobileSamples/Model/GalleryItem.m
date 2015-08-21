/*************************************************************************

ADOBE SYSTEMS INCORPORATED
Copyright 2015 Adobe Systems Incorporated
All Rights Reserved.

NOTICE:  Adobe permits you to use, modify, and distribute this file in accordance with the
terms of the Adobe license agreement accompanying it.  If you have received this file from a
source other than Adobe, then your use, modification, or distribution of it requires the prior
written permission of Adobe.
 
**************************************************************************/

#import "GalleryItem.h"

@implementation GalleryItem

- (id)initWithTitle:(NSString *)title description:(NSString *)description asset:(NSString *)asset params:(NSString *)params{
	self = [super init];
	if (self){
		self.title = title;
		self.theDescription = description;
		self.assetName = asset;
        self.s7params = params;
		
		self.liked = [[NSUserDefaults standardUserDefaults] boolForKey:self.title];
	}
	return self;
}

- (void)setLiked:(BOOL)liked{
	_liked = liked;
	[[NSUserDefaults standardUserDefaults] setBool:liked forKey:self.title];
}

@end
