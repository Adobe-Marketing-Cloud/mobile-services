/*************************************************************************
 *
 * ADOBE CONFIDENTIAL
 * ___________________
 *
 *  Copyright 2016 Adobe Systems Incorporated
 *  All Rights Reserved.
 *
 * NOTICE:  All information contained herein is, and remains
 * the property of Adobe Systems Incorporated and its suppliers,
 * if any.  The intellectual and technical concepts contained
 * herein are proprietary to Adobe Systems Incorporated and its
 * suppliers and are protected by trade secret or copyright law.
 * Dissemination of this information or reproduction of this material
 * is strictly forbidden unless prior written permission is obtained
 * from Adobe Systems Incorporated.
 *
 **************************************************************************/

#import <CoreLocation/CoreLocation.h>
#import "ADBMobile_PhoneGap.h"
#import "ADBMobile.h"

#define STRING [NSString class]
#define NUMBER [NSNumber class]
#define DICTIONARY [NSDictionary class]

@interface ADBBeacon : NSObject
@property (nonatomic, strong) NSUUID *proximityUUID;
@property (nonatomic, strong) NSNumber *major;
@property (nonatomic, strong) NSNumber *minor;
@property (nonatomic) CLProximity proximity;
@end

@implementation ADBBeacon : NSObject
@end

@implementation ADBMobile_PhoneGap

NSString *const VisitorId_Id = @"id";
NSString *const VisitorId_IdType = @"idType";
NSString *const VisitorId_AuthenticationState = @"authenticationState";

- (void)getVersion:(CDVInvokedUrlCommand*)command {
	[self.commandDelegate runInBackground:^{
		CDVPluginResult* pluginResult = nil;
		
		NSString *version = [ADBMobile version];
		
		pluginResult = [CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsString:version];
		[self.commandDelegate sendPluginResult:pluginResult callbackId:command.callbackId];
	}];
}

- (void)getPrivacyStatus:(CDVInvokedUrlCommand*)command; {
	[self.commandDelegate runInBackground:^{
		CDVPluginResult* pluginResult = nil;
		
		int privacyStatus = [ADBMobile privacyStatus];
		switch (privacyStatus) {
			case ADBMobilePrivacyStatusOptIn:
				pluginResult = [CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsString:@"Opted In"];
				break;
			case ADBMobilePrivacyStatusOptOut:
				pluginResult = [CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsString:@"Opted Out"];
				break;
			case ADBMobilePrivacyStatusUnknown:
				pluginResult = [CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsString:@"Opt Unknown"];
				break;
			default:
				pluginResult = [CDVPluginResult resultWithStatus:CDVCommandStatus_NO_RESULT messageAsString:@"Privacy Status was an unknown value"];
				break;
		}
		
		[self.commandDelegate sendPluginResult:pluginResult callbackId:command.callbackId];
	}];
}

- (void)setPrivacyStatus:(CDVInvokedUrlCommand*)command {
	[self.commandDelegate runInBackground:^{
		if(!checkArgsWithTypes(command.arguments, @[@[NUMBER]])) {
			[self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR] callbackId:command.callbackId];
			return;
		}
		
		NSString *privacyStatusString = getArg(command.arguments[0]);
		int privacyStatus = [privacyStatusString intValue];
		CDVPluginResult* pluginResult = nil;
		
		if (privacyStatus >= 1 && privacyStatus <= 3) {
			[ADBMobile setPrivacyStatus:privacyStatus];
			pluginResult = [CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsString:@"Set Opt Status"];
		} else {
			pluginResult = [CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR messageAsString:@"Privacy Status was an unknown value"];
		}
		
		[self.commandDelegate sendPluginResult:pluginResult callbackId:command.callbackId];
	}];
}

- (void)getLifetimeValue:(CDVInvokedUrlCommand*)command {
	[self.commandDelegate runInBackground:^{
		double lifetimeValue = [[ADBMobile lifetimeValue] doubleValue];
		
		CDVPluginResult* pluginResult = [CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsDouble:lifetimeValue];
		[self.commandDelegate sendPluginResult:pluginResult callbackId:command.callbackId];
	}];
}

- (void)getUserIdentifier:(CDVInvokedUrlCommand*)command {
	[self.commandDelegate runInBackground:^{
		NSString *userIdentifier = [ADBMobile userIdentifier];
		
		CDVPluginResult* pluginResult = [CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsString:userIdentifier];
		[self.commandDelegate sendPluginResult:pluginResult callbackId:command.callbackId];
	}];
}

- (void)setUserIdentifier:(CDVInvokedUrlCommand*)command {
	[self.commandDelegate runInBackground:^{
		if(!checkArgsWithTypes(command.arguments, @[@[STRING]])) {
			[self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR] callbackId:command.callbackId];
			return;
		}
		
		NSString* userIdentifier = getArg(command.arguments[0]);
		[ADBMobile setUserIdentifier:userIdentifier];
		
		[self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_OK] callbackId:command.callbackId];
	}];
}

- (void)setPushIdentifier:(CDVInvokedUrlCommand*)command {
	[self.commandDelegate runInBackground:^{
		if(!checkArgsWithTypes(command.arguments, @[@[STRING]])) {
			[self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR] callbackId:command.callbackId];
			return;
		}
		
		NSString* pushIdStr = getArg(command.arguments[0]);
		NSData* pushIdentifier = nil;
		
		//hex NSString to NSData
		if(pushIdStr != nil && [pushIdStr length]/2 == 32) {
			char buffer[3];
			buffer[2] = '\0';
			char *bytes = malloc([pushIdStr length]/2);
			char *bytes_ptr = bytes;
			for (int i = 0; i < [pushIdStr length]; i += 2) {
				buffer[0] = [pushIdStr characterAtIndex: i];
				buffer[1] = [pushIdStr characterAtIndex: i+1];
				char *b2 = NULL;
				*bytes_ptr++ = strtol(buffer, &b2, 16);
			}
			
			pushIdentifier = [NSData dataWithBytesNoCopy:bytes length:[pushIdStr length]/2 freeWhenDone:YES];
		}
		
		[ADBMobile setPushIdentifier:pushIdentifier];
		
		[self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_OK] callbackId:command.callbackId];
	}];
}

- (void)trackPushMessageClickthrough:(CDVInvokedUrlCommand*)command {
	[self.commandDelegate runInBackground:^{
		if(!checkArgsWithTypes(command.arguments, @[@[DICTIONARY]])) {
			[self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR] callbackId:command.callbackId];
			return;
		}
		
		NSDictionary * userInfo = getArg(command.arguments[0]);
		[ADBMobile trackPushMessageClickThrough:userInfo];
		
		[self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_OK] callbackId:command.callbackId];
	}];
}

- (void)trackLocalNotificationClickThrough:(CDVInvokedUrlCommand*)command{
    [self.commandDelegate runInBackground:^{
        if(!checkArgsWithTypes(command.arguments, @[@[DICTIONARY]])) {
            [self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR] callbackId:command.callbackId];
            return;
        }
        
        NSDictionary * userInfo = getArg(command.arguments[0]);
        [ADBMobile trackLocalNotificationClickThrough:userInfo];
        
        [self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_OK] callbackId:command.callbackId];
    }];
}

- (void)trackAdobeDeepLink:(CDVInvokedUrlCommand*)command{
    
    [self.commandDelegate runInBackground:^{
        if(!checkArgsWithTypes(command.arguments, @[@[STRING]])) {
            [self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR] callbackId:command.callbackId];
            return;
        }
        NSString *urlString = getArg(command.arguments[0]);
        NSURL *url = [NSURL URLWithString:urlString];
        [ADBMobile trackAdobeDeepLink:url];
        
        [self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_OK] callbackId:command.callbackId];
    }];
}

- (void)getDebugLogging:(CDVInvokedUrlCommand*)command {
	[self.commandDelegate runInBackground:^{
		BOOL debugLogging = [ADBMobile debugLogging];
		
		CDVPluginResult* pluginResult = [CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsBool:debugLogging];
		[self.commandDelegate sendPluginResult:pluginResult callbackId:command.callbackId];
	}];
}

- (void)setDebugLogging:(CDVInvokedUrlCommand*)command {
	[self.commandDelegate runInBackground:^{
		if(!checkArgsWithTypes(command.arguments, @[@[STRING, NUMBER]])) {
			[self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR] callbackId:command.callbackId];
			return;
		}
		
		id debugLoggingString = getArg(command.arguments[0]);
		[ADBMobile setDebugLogging:[debugLoggingString boolValue]];
		
		CDVPluginResult* pluginResult = [CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsString:@"Set DebugLogging"];
		[self.commandDelegate sendPluginResult:pluginResult callbackId:command.callbackId];
	}];
}

- (void)keepLifecycleSessionAlive:(CDVInvokedUrlCommand*)command {
	[self.commandDelegate runInBackground:^{
		[ADBMobile keepLifecycleSessionAlive];
		
		CDVPluginResult* pluginResult = [CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsString:@"Keeping lifecycle session alive"];
		[self.commandDelegate sendPluginResult:pluginResult callbackId:command.callbackId];
	}];
}

- (void)collectLifecycleData:(CDVInvokedUrlCommand*)command {
	[self.commandDelegate runInBackground:^{
        [ADBMobile collectLifecycleData];
		[self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsString:@"Collecting Lifecycle"] callbackId:command.callbackId];
	}];
}

- (void)setAppGroup:(CDVInvokedUrlCommand*)command {
    [self.commandDelegate runInBackground:^{
        if(!checkArgsWithTypes(command.arguments, @[@[STRING]])) {
            [self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR] callbackId:command.callbackId];
            return;
        }
        NSString* appGroup = getArg(command.arguments[0]);
        [ADBMobile setAppGroup:appGroup];
        [self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_OK] callbackId:command.callbackId];
    }];
}

- (void)syncSettings:(CDVInvokedUrlCommand*)command {
    [self.commandDelegate runInBackground:^{
        if(!checkArgsWithTypes(command.arguments, @[@[DICTIONARY]])) {
            [self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR] callbackId:command.callbackId];
            return;
        }
        NSDictionary *settings = getArg(command.arguments[0]);
        BOOL syncSettingsResult = [ADBMobile syncSettings:settings];

        CDVPluginResult* pluginResult = [CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsBool:syncSettingsResult];
        [self.commandDelegate sendPluginResult:pluginResult callbackId:command.callbackId];
    }];
}

- (void)initializeWatch:(CDVInvokedUrlCommand*)command {
    [self.commandDelegate runInBackground:^{
        [ADBMobile initializeWatch];
        [self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_OK] callbackId:command.callbackId];
    }];
}

- (void)collectPII:(CDVInvokedUrlCommand*)command{    
    
    [self.commandDelegate runInBackground:^{

        if(!checkArgsWithTypes(command.arguments, @[@[DICTIONARY]])) {
            [self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR] callbackId:command.callbackId];
            return;
        }
    
        NSDictionary *piiData = command.arguments[0];
        //ToDo(Prerna): test for individual fields data type
        [ADBMobile collectPII:piiData];
        CDVPluginResult *pluginResult = [CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsString:@"Collecting Pii"];
        [self.commandDelegate sendPluginResult:pluginResult callbackId:command.callbackId];
    }];
}

- (void)trackState:(CDVInvokedUrlCommand*)command {
	[self.commandDelegate runInBackground:^{
		if(!checkArgsWithTypes(command.arguments, @[@[STRING, DICTIONARY], @[STRING, DICTIONARY]])
		   || ([command.arguments[0] isKindOfClass:DICTIONARY] && command.arguments[1] != (id)[NSNull null])
		   || [command.arguments[1] isKindOfClass:STRING]) {
			[self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR] callbackId:command.callbackId];
			return;
		}
		
		id firstArg = getArg(command.arguments[0]);
		id secondArg = getArg(command.arguments[1]);

		//allows the ADB.trackState(cData) call
		if([firstArg isKindOfClass:DICTIONARY]) {
			[ADBMobile trackState:nil data:firstArg];
		}
		else {
			[ADBMobile trackState:firstArg data:secondArg];
		}
		
		[self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_OK] callbackId:command.callbackId];
	}];
}

- (void)trackAction:(CDVInvokedUrlCommand*)command {
	[self.commandDelegate runInBackground:^{
		if(!checkArgsWithTypes(command.arguments, @[@[STRING, DICTIONARY], @[STRING, DICTIONARY]])
		   || ([command.arguments[0] isKindOfClass:DICTIONARY] && command.arguments[1] != (id)[NSNull null])
		   || [command.arguments[1] isKindOfClass:STRING]) {
			[self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR] callbackId:command.callbackId];
			return;
		}
		
		id firstArg = getArg(command.arguments[0]);
		id secondArg = getArg(command.arguments[1]);
		
		//allows the ADB.trackAction(cData) call
		if([firstArg isKindOfClass:DICTIONARY]) {
			[ADBMobile trackAction:nil data:firstArg];
		}
		else {
			[ADBMobile trackAction:firstArg data:secondArg];
		}
		
		[self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_OK] callbackId:command.callbackId];
	}];
}

- (void)trackActionFromBackground:(CDVInvokedUrlCommand*)command {
	[self.commandDelegate runInBackground:^{
		if(!checkArgsWithTypes(command.arguments, @[@[STRING, DICTIONARY], @[STRING, DICTIONARY]])
		   || ([command.arguments[0] isKindOfClass:DICTIONARY] && command.arguments[1] != (id)[NSNull null])
		   || [command.arguments[1] isKindOfClass:STRING]) {
			[self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR] callbackId:command.callbackId];
			return;
		}
		
		id firstArg = getArg(command.arguments[0]);
		id secondArg = getArg(command.arguments[1]);
		
		//allows the ADB.trackActionFromBackground(cData) call
		if([firstArg isKindOfClass:DICTIONARY]) {
			[ADBMobile trackActionFromBackground:nil data:firstArg];
		}
		else {
			[ADBMobile trackActionFromBackground:firstArg data:secondArg];
		}
		
		[self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_OK] callbackId:command.callbackId];
	}];
}

- (void)trackLocation:(CDVInvokedUrlCommand *)command {
	[self.commandDelegate runInBackground:^{
		if(!checkArgsWithTypes(command.arguments, @[@[STRING, NUMBER], @[STRING, NUMBER], @[DICTIONARY]])) {
			[self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR] callbackId:command.callbackId];
			return;
		}
		
		double latitude = [getArg(command.arguments[0]) doubleValue];
		double longitude = [getArg(command.arguments[1]) doubleValue];
		NSDictionary *cData = getArg(command.arguments[2]);
		
		CDVPluginResult* pluginResult = nil;
		
		if(NSClassFromString(@"CLLocation")) {
			id location = [[NSClassFromString(@"CLLocation") alloc] initWithLatitude: latitude longitude: longitude];
			[ADBMobile trackLocation:location data:cData];
			
			pluginResult = [CDVPluginResult resultWithStatus:CDVCommandStatus_OK];
		} else {
			pluginResult = [CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR messageAsString:@"CLLocation could not be found"];
		}
		
		[self.commandDelegate sendPluginResult:pluginResult callbackId:command.callbackId];
	}];
}

- (void)trackBeacon:(CDVInvokedUrlCommand *)command {
	[self.commandDelegate runInBackground:^{
		CDVPluginResult* pluginResult = nil;
		if(!NSClassFromString(@"CLLocation")) {
			pluginResult = [CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR messageAsString:@"CLLocation could not be found"];
			[self.commandDelegate sendPluginResult:pluginResult callbackId:command.callbackId];
			return;
		}
		
		if(!checkArgsWithTypes(command.arguments, @[@[STRING], @[STRING, NUMBER], @[STRING, NUMBER], @[NUMBER], @[DICTIONARY]])) {
			[self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR] callbackId:command.callbackId];
			return;
		}
		
		NSString* uuid = getArg(command.arguments[0]);
		NSNumber* major = getArg(command.arguments[1]);
		NSNumber* minor = getArg(command.arguments[2]);
		NSNumber* proximity = getArg(command.arguments[3]);
		NSDictionary* cData = getArg(command.arguments[4]);
		
		ADBBeacon *beacon = [[ADBBeacon alloc] init];
		
		NSNumberFormatter * formatter = [[NSNumberFormatter alloc] init];
		[formatter setNumberStyle:NSNumberFormatterNoStyle];
		
		[beacon setProximityUUID:[[NSUUID alloc] initWithUUIDString:uuid]];
		[beacon setProximity:(CLProximity)((NSNumber*)proximity).intValue];
		[beacon setMajor: [major isKindOfClass: STRING] ? [formatter numberFromString:(NSString*)major] : major];
		[beacon setMinor: [minor isKindOfClass: STRING] ? [formatter numberFromString:(NSString*)minor] : minor];
		
		[ADBMobile trackBeacon:(CLBeacon *)beacon data:cData];
		
		[self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_OK] callbackId:command.callbackId];
	}];
}

- (void)trackingClearCurrentBeacon:(CDVInvokedUrlCommand*)command {
	[self.commandDelegate runInBackground:^{
		[ADBMobile trackingClearCurrentBeacon];
		
		CDVPluginResult* pluginResult = [CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsString:@"Current beacon cleared."];
		[self.commandDelegate sendPluginResult:pluginResult callbackId:command.callbackId];
	}];
}

- (void)trackLifetimeValueIncrease:(CDVInvokedUrlCommand*)command {
	[self.commandDelegate runInBackground:^{
		if(!checkArgsWithTypes(command.arguments, @[@[STRING, NUMBER], @[DICTIONARY]])) {
			[self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR] callbackId:command.callbackId];
			return;
		}
		
		id amount = getArg(command.arguments[0]);
		NSDictionary *cData = getArg(command.arguments[1]);
		
		if ([amount isKindOfClass:[NSString class]]) {
			amount = [NSDecimalNumber decimalNumberWithString:amount];
		} else {
			amount = [NSDecimalNumber decimalNumberWithDecimal:[amount decimalValue]];
		}
		
		[ADBMobile trackLifetimeValueIncrease:amount data:cData];
		
		[self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_OK] callbackId:command.callbackId];
	}];
}

- (void)trackTimedActionStart:(CDVInvokedUrlCommand*)command {
	[self.commandDelegate runInBackground:^{
		if(!checkArgsWithTypes(command.arguments, @[@[STRING], @[DICTIONARY]])) {
			[self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR] callbackId:command.callbackId];
			return;
		}
		
		NSString* action = getArg(command.arguments[0]);
		NSDictionary *cData = getArg(command.arguments[1]);
		
		[ADBMobile trackTimedActionStart:action data:cData];
		
		[self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_OK] callbackId:command.callbackId];
	}];
}

- (void)trackTimedActionUpdate:(CDVInvokedUrlCommand*)command {
	[self.commandDelegate runInBackground:^{
		if(!checkArgsWithTypes(command.arguments, @[@[STRING], @[DICTIONARY]])) {
			[self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR] callbackId:command.callbackId];
			return;
		}
		
		NSString* action = getArg(command.arguments[0]);
		NSDictionary *cData = getArg(command.arguments[1]);
		
		[ADBMobile trackTimedActionUpdate:action data:cData];
		
		[self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_OK] callbackId:command.callbackId];
	}];
}

- (void)trackingTimedActionExists:(CDVInvokedUrlCommand*)command {
	[self.commandDelegate runInBackground:^{
		if(!checkArgsWithTypes(command.arguments, @[@[STRING]])) {
			[self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR] callbackId:command.callbackId];
			return;
		}
		
		NSString* action = getArg(command.arguments[0]);
		BOOL exists = [ADBMobile trackingTimedActionExists:action];
		
		CDVPluginResult* pluginResult = [CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsBool:exists];
		[self.commandDelegate sendPluginResult:pluginResult callbackId:command.callbackId];
	}];
}

- (void)trackTimedActionEnd:(CDVInvokedUrlCommand*)command {
	[self.commandDelegate runInBackground:^{
		if(!checkArgsWithTypes(command.arguments, @[@[STRING]])) {
			[self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR] callbackId:command.callbackId];
			return;
		}
		
		NSString* action = getArg(command.arguments[0]);
		[ADBMobile trackTimedActionEnd:action logic:nil];
		
		[self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_OK] callbackId:command.callbackId];
	}];
}

- (void)trackingIdentifier:(CDVInvokedUrlCommand*)command {
	[self.commandDelegate runInBackground:^{
		NSString *trackingIdentifier = [ADBMobile trackingIdentifier];
		
		CDVPluginResult* pluginResult = [CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsString:trackingIdentifier];
		[self.commandDelegate sendPluginResult:pluginResult callbackId:command.callbackId];
	}];
}

- (void)trackingSendQueuedHits:(CDVInvokedUrlCommand*)command {
	[self.commandDelegate runInBackground:^{
		[ADBMobile trackingSendQueuedHits];
		
		[self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_OK] callbackId:command.callbackId];
	}];
}

- (void)trackingClearQueue:(CDVInvokedUrlCommand*)command {
	[self.commandDelegate runInBackground:^{
		[ADBMobile trackingClearQueue];
		
		[self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_OK] callbackId:command.callbackId];
	}];
}

- (void)trackingGetQueueSize:(CDVInvokedUrlCommand*)command {
	[self.commandDelegate runInBackground:^{
		int size = (int)[ADBMobile trackingGetQueueSize];
		
		CDVPluginResult* pluginResult = [CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsInt:size];
		[self.commandDelegate sendPluginResult:pluginResult callbackId:command.callbackId];
	}];
}

- (void)targetLoadRequestWithName:(CDVInvokedUrlCommand*)command {

    [self.commandDelegate runInBackground:^{
    
        if(!checkArgsWithTypes(command.arguments, @[@[STRING], @[STRING], @[DICTIONARY],  @[DICTIONARY],  @[DICTIONARY]])){
            [self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR] callbackId:command.callbackId];
            return;
        }
        
        NSString* name = getArg(command.arguments[0]);
        NSString* defaultContent = getArg(command.arguments[1]);
        NSDictionary *profileParameters = getArg(command.arguments[2]);
        NSDictionary *orderParameters = getArg(command.arguments[3]);
        NSDictionary *mboxParameters = getArg(command.arguments[4]);

        void (^callbackBlock)(NSString *content) = ^(NSString *content){
            CDVPluginResult* pluginResult = [CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsString:content];
            [self.commandDelegate sendPluginResult:pluginResult callbackId:command.callbackId];
        };
        
        [ADBMobile targetLoadRequestWithName:name defaultContent:defaultContent profileParameters:profileParameters orderParameters:orderParameters mboxParameters:mboxParameters callback:callbackBlock];
    }];
}

- (void)targetLoadRequestWithNameWithLocationParameters:(CDVInvokedUrlCommand*)command {
    
    [self.commandDelegate runInBackground:^{
        
        if(!checkArgsWithTypes(command.arguments, @[@[STRING], @[STRING], @[DICTIONARY],  @[DICTIONARY],  @[DICTIONARY], @[DICTIONARY]])){
            
            [self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR] callbackId:command.callbackId];
            return;
        }
        
        NSString* name = getArg(command.arguments[0]);
        NSString* defaultContent = getArg(command.arguments[1]);
        NSDictionary *profileParameters = getArg(command.arguments[2]);
        NSDictionary *orderParameters = getArg(command.arguments[3]);
        NSDictionary *mboxParameters = getArg(command.arguments[4]);
        NSDictionary *requestLocationParameters = getArg(command.arguments[5]);
        
        void (^callbackBlock)(NSString *content) = ^(NSString *content){
            CDVPluginResult* pluginResult = [CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsString:content];
            [self.commandDelegate sendPluginResult:pluginResult callbackId:command.callbackId];
        };
        
        [ADBMobile targetLoadRequestWithName:name defaultContent:defaultContent profileParameters:profileParameters orderParameters:orderParameters mboxParameters:mboxParameters requestLocationParameters:requestLocationParameters callback:callbackBlock];
        
    }];
}

- (void)targetLoadRequest:(CDVInvokedUrlCommand*)command {
    
    [self.commandDelegate runInBackground:^{
		
        if(!checkArgsWithTypes(command.arguments, @[@[STRING], @[STRING], @[DICTIONARY]]) )
        {
            [self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR] callbackId:command.callbackId];
            return;
        }
        
        NSString* name = getArg(command.arguments[0]);
        NSString* defaultContent = getArg(command.arguments[1]);
        NSDictionary *parameters = getArg(command.arguments[2]);
        
        void (^callbackBlock)(NSString *content) = ^(NSString *content){
            CDVPluginResult* pluginResult = [CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsString:content];
            [self.commandDelegate sendPluginResult:pluginResult callbackId:command.callbackId];
        };
        
        ADBTargetLocationRequest *request = [ADBMobile targetCreateRequestWithName:name defaultContent:defaultContent parameters:parameters];
        [ADBMobile targetLoadRequest:request callback:callbackBlock];
	}];
}

- (void)targetLoadOrderConfirmRequest:(CDVInvokedUrlCommand*)command {
	[self.commandDelegate runInBackground:^{
		if(!checkArgsWithTypes(command.arguments, @[@[STRING], @[STRING], @[STRING, NUMBER], @[STRING], @[DICTIONARY]])) {
			[self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR] callbackId:command.callbackId];
			return;
		}
		
		NSString* name = getArg(command.arguments[0]);
		NSString* orderId = getArg(command.arguments[1]);
		NSString* orderTotal = getArg(command.arguments[2]);
		NSString* productPurchaseId = getArg(command.arguments[3]);
		NSDictionary *parameters = getArg(command.arguments[4]);
		
		ADBTargetLocationRequest *request = [ADBMobile targetCreateOrderConfirmRequestWithName:name orderId:orderId orderTotal:orderTotal productPurchasedId:productPurchaseId parameters:parameters];
		
		[ADBMobile targetLoadRequest:request callback:^(NSString *content) {
			CDVPluginResult* pluginResult = [CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsString:content];
			[self.commandDelegate sendPluginResult:pluginResult callbackId:command.callbackId];
		}];
	}];
}

- (void)targetClearCookies:(CDVInvokedUrlCommand*)command {
	[self.commandDelegate runInBackground:^{
		[ADBMobile targetClearCookies];
		
		[self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_OK] callbackId:command.callbackId];
	}];
}

- (void)targetSessionID:(CDVInvokedUrlCommand*)command{

    [self.commandDelegate runInBackground:^{
        NSString *targetSessionId = [ADBMobile targetSessionID];
        [self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsString:targetSessionId] callbackId:command.callbackId];
    }];
}

- (void)targetPcID:(CDVInvokedUrlCommand*)command{
    
    [self.commandDelegate runInBackground:^{
        NSString *targetPcID = [ADBMobile targetPcID];
        [self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsString:targetPcID] callbackId:command.callbackId];
    }];
}

- (void)targetSetThirdPartyID:(CDVInvokedUrlCommand*)command{
    [self.commandDelegate runInBackground:^{
        
        if(!checkArgsWithTypes(command.arguments, @[@[STRING]])) {
            [self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR] callbackId:command.callbackId];
            return;
        }
        
        NSString *thirdPartyID = command.arguments[0];
        [ADBMobile targetSetThirdPartyID:thirdPartyID];
        [self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_OK] callbackId:command.callbackId];
    }];
}

- (void)targetThirdPartyID:(CDVInvokedUrlCommand*)command{
    [self.commandDelegate runInBackground:^{
        
        NSString *thirdPartyID = [ADBMobile targetThirdPartyID];
        [self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsString:thirdPartyID] callbackId:command.callbackId];
    }];

}

- (void)acquisitionCampaignStartForApp:(CDVInvokedUrlCommand*)command {
	[self.commandDelegate runInBackground:^{
		if(!checkArgsWithTypes(command.arguments, @[@[STRING], @[DICTIONARY]])) {
			[self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR] callbackId:command.callbackId];
			return;
		}
		
		NSString* appId = getArg(command.arguments[0]);
		NSDictionary *data = getArg(command.arguments[1]);
		
		[ADBMobile acquisitionCampaignStartForApp:appId data:data];
		
		[self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_OK] callbackId:command.callbackId];
	}];
}

- (void)audienceGetVisitorProfile:(CDVInvokedUrlCommand*)command {
	[self.commandDelegate runInBackground:^{
		NSDictionary* visitorProfile = [ADBMobile audienceVisitorProfile];
		
		CDVPluginResult* pluginResult = [CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsDictionary:visitorProfile];
		[self.commandDelegate sendPluginResult:pluginResult callbackId:command.callbackId];
	}];
}

- (void)audienceGetDpuuid:(CDVInvokedUrlCommand*)command {
	[self.commandDelegate runInBackground:^{
		NSString* dpuuid = [ADBMobile audienceDpuuid];
		
		CDVPluginResult* pluginResult = [CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsString:dpuuid];
		[self.commandDelegate sendPluginResult:pluginResult callbackId:command.callbackId];
	}];
}

- (void)audienceGetDpid:(CDVInvokedUrlCommand*)command {
	[self.commandDelegate runInBackground:^{
		NSString* dpid = [ADBMobile audienceDpid];
		
		CDVPluginResult* pluginResult = [CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsString:dpid];
		[self.commandDelegate sendPluginResult:pluginResult callbackId:command.callbackId];
	}];
}

- (void)audienceSetDpidAndDpuuid:(CDVInvokedUrlCommand*)command {
	[self.commandDelegate runInBackground:^{
		if(!checkArgsWithTypes(command.arguments, @[@[STRING], @[STRING]])) {
			[self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR] callbackId:command.callbackId];
			return;
		}
		
		NSString* dpid = getArg(command.arguments[0]);
		NSString* dpuuid = getArg(command.arguments[1]);
		
		[ADBMobile audienceSetDpid:dpid dpuuid:dpuuid];
		
		[self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_OK] callbackId:command.callbackId];
	}];
	
}

- (void)audienceSignalWithData:(CDVInvokedUrlCommand*)command {
	[self.commandDelegate runInBackground:^{
		if(!checkArgsWithTypes(command.arguments, @[@[DICTIONARY]])) {
			[self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR] callbackId:command.callbackId];
			return;
		}
		
		NSDictionary *data = getArg(command.arguments[0]);
		
		[ADBMobile audienceSignalWithData:data callback:^(NSDictionary *response) {
			CDVPluginResult* pluginResult = [CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsDictionary:response];
			[self.commandDelegate sendPluginResult:pluginResult callbackId:command.callbackId];
		}];
	}];
}

- (void)audienceReset:(CDVInvokedUrlCommand*)command {
	[self.commandDelegate runInBackground:^{
		[ADBMobile audienceReset];
		
		[self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_OK] callbackId:command.callbackId];
	}];
}

- (void)visitorGetMarketingCloudId:(CDVInvokedUrlCommand*)command {
	[self.commandDelegate runInBackground:^{
		NSString* visitorMCID = [ADBMobile visitorMarketingCloudID];
		
		CDVPluginResult* pluginResult = [CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsString:visitorMCID];
		[self.commandDelegate sendPluginResult:pluginResult callbackId:command.callbackId];
	}];
}

- (void)visitorSyncIdentifierWithType:(CDVInvokedUrlCommand*)command {
    [self.commandDelegate runInBackground:^{
        
        if(!checkArgsWithTypes(command.arguments, @[@[STRING], @[STRING],@[NUMBER]]))
        {
            [self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR] callbackId:command.callbackId];
            return;
        }
        
        CDVPluginResult* pluginResult = nil;
        NSString *identifierType = getArg(command.arguments[0]);
        NSString *identifier = getArg(command.arguments[1]);
        NSString *authStateString = getArg(command.arguments[2]);
        int authState = [authStateString intValue];
        
        if (authState >= 0 && authState <= 2)
        {
            [ADBMobile visitorSyncIdentifierWithType:identifierType identifier:identifier authenticationState:authState];
            pluginResult = [CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsString:@"visitorSyncIdentifierWithType"];
        }
        else
        {
            pluginResult = [CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR messageAsString:@"AuthenticationState was an unknown value"];
        }
        
        [self.commandDelegate sendPluginResult:pluginResult callbackId:command.callbackId];
    
    }];
}


- (void)visitorSyncIdentifiersWithAuthenticationState:(CDVInvokedUrlCommand*)command {

    [self.commandDelegate runInBackground:^{
        
        if(!checkArgsWithTypes(command.arguments, @[@[DICTIONARY], @[NUMBER]]))
        {
            [self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR] callbackId:command.callbackId];
            return;
        }
        
        CDVPluginResult* pluginResult = nil;
        
        NSDictionary *firstArg = getArg(command.arguments[0]);
        int authState = [getArg(command.arguments[1]) integerValue];
        
        if (authState >= 0 && authState <= 2)
        {
            [ADBMobile visitorSyncIdentifiers:firstArg authenticationState:authState];
            pluginResult = [CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsString:@"visitorSyncIdentifiers"];
        }
        else
        {
            pluginResult = [CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR messageAsString:@"AuthenticationState was an unknown value"];
        }
        
        [self.commandDelegate sendPluginResult:pluginResult callbackId:command.callbackId];
    }];
}

- (void)visitorSyncIdentifiers:(CDVInvokedUrlCommand*)command {
	[self.commandDelegate runInBackground:^{
        
        if(!checkArgsWithTypes(command.arguments, @[@[DICTIONARY]]))
        {
            [self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR] callbackId:command.callbackId];
            return;
        }
        
        [ADBMobile visitorSyncIdentifiers:getArg(command.arguments[0])];
        [self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsString:@"visitorSyncIdentifiers"] callbackId:command.callbackId];
    }];
}


- (void)visitorAppendToURL: (CDVInvokedUrlCommand*)command{
    
    [self.commandDelegate runInBackground:^{
        if(!checkArgsWithTypes(command.arguments, @[@[STRING]])) {
            [self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_ERROR] callbackId:command.callbackId];
            return;
        }
        
        NSString *visitorUrlString = getArg(command.arguments[0]);
        NSURL *visitorUrl = [NSURL URLWithString:visitorUrlString];
        NSString *finalURLString = [[ADBMobile visitorAppendToURL:visitorUrl] absoluteString];
        [self.commandDelegate sendPluginResult:[CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsString:finalURLString] callbackId:command.callbackId];
    }];
}

- (void)visitorGetIDs:(CDVInvokedUrlCommand*)command{
    [self.commandDelegate runInBackground:^{
        NSArray *visitorIdJSONArray = [self visitorGetIDsJs];
        CDVPluginResult* pluginResult = [CDVPluginResult resultWithStatus:CDVCommandStatus_OK messageAsArray:visitorIdJSONArray];
        [self.commandDelegate sendPluginResult:pluginResult callbackId:command.callbackId];
    }];
}

/*
 * Helper functions
 */

static BOOL checkArgsWithTypes(NSArray* arguments, NSArray* types) {
	if(!arguments || !types || [arguments count] != [types count]) {
		return NO;
	}
	
	int types_index = 0;
	for(id argument in arguments) {
		if(argument == (id)[NSNull null]) {
			types_index++;
			continue;
		}
		
		NSArray* allowedTypesForArgument = types[types_index];
		BOOL foundTypeMatch = NO;
		for(id allowedType in allowedTypesForArgument) {
			foundTypeMatch |= [argument isKindOfClass:allowedType];
			if(foundTypeMatch) { break; }
		}
		
		if(!foundTypeMatch) { return NO; }
		types_index++;
	}
	
	return YES;
}

- (nullable NSArray *) visitorGetIDsJs{
    NSArray* visitorIDs = [ADBMobile visitorGetIDs];
    NSMutableArray* visitorIDsJSArray = [NSMutableArray array];
    for(ADBVisitorID* visitorID in visitorIDs){
        NSDictionary* dict = @{VisitorId_IdType: visitorID.idType?:@"", VisitorId_Id: visitorID.identifier?:@"", VisitorId_AuthenticationState: [NSNumber numberWithInt:visitorID.authenticationState]};
        [visitorIDsJSArray addObject:dict];
    }
    return visitorIDsJSArray;
}

static id getArg(id argument) { return argument == (id)[NSNull null] ? nil : argument; }

@end