/*************************************************************************

ADOBE SYSTEMS INCORPORATED
Copyright 2015 Adobe Systems Incorporated
All Rights Reserved.

NOTICE:  Adobe permits you to use, modify, and distribute this file in accordance with the
terms of the Adobe license agreement accompanying it.  If you have received this file from a
source other than Adobe, then your use, modification, or distribution of it requires the prior
written permission of Adobe.
 
**************************************************************************/

#import <Foundation/Foundation.h>
#import "ADBMobile.h"

@interface GalleryItem : NSObject

@property (strong) NSString *title;
@property (strong) NSString *theDescription;
@property (strong) NSString *assetName;
@property (strong) NSString *s7params;
@property (nonatomic, assign) BOOL liked;

- (id)initWithTitle:(NSString *)title description:(NSString *)description asset:(NSString *)asset params:(NSString *)params;

@end
