/*************************************************************************

ADOBE SYSTEMS INCORPORATED
Copyright 2015 Adobe Systems Incorporated
All Rights Reserved.

NOTICE:  Adobe permits you to use, modify, and distribute this file in accordance with the
terms of the Adobe license agreement accompanying it.  If you have received this file from a
source other than Adobe, then your use, modification, or distribution of it requires the prior
written permission of Adobe.
 
**************************************************************************/

#import "NSString+Color.h"

@implementation NSString (Color)

// returns a UIColor given rgb in ###### format
- (UIColor *)color {
	unsigned value = 0;
	
	NSScanner *scanner = [NSScanner scannerWithString: self];
	
	if([self hasPrefix: @"#"]) {
		[scanner setScanLocation: 1];
	}

	if(![scanner scanHexInt: &value]) {
		return [UIColor whiteColor];
	}

	float red = ((float)((value & 0xFF0000) >> 16))/255.0f;
	float green = ((float)((value & 0xFF00) >> 8))/255.0f;
	float blue = ((float)(value & 0xFF))/255.0f;
	
	return [UIColor colorWithRed: red green: green blue: blue alpha: 1.0f];
}

@end
