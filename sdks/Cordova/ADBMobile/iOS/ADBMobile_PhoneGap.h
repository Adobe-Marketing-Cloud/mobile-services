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
#import <Foundation/Foundation.h>
#import <Cordova/CDV.h>

FOUNDATION_EXPORT NSString *const VisitorId_Id;
FOUNDATION_EXPORT NSString *const VisitorId_IdType;
FOUNDATION_EXPORT NSString *const VisitorId_AuthenticationState;

@interface ADBMobile_PhoneGap : CDVPlugin

- (void)getVersion:(CDVInvokedUrlCommand*)command;
- (void)getPrivacyStatus:(CDVInvokedUrlCommand*)command;
- (void)setPrivacyStatus:(CDVInvokedUrlCommand*)command;
- (void)getLifetimeValue:(CDVInvokedUrlCommand*)command;
- (void)getUserIdentifier:(CDVInvokedUrlCommand*)command;
- (void)setUserIdentifier:(CDVInvokedUrlCommand*)command;
- (void)setPushIdentifier:(CDVInvokedUrlCommand*)command;
- (void)getDebugLogging:(CDVInvokedUrlCommand*)command;
- (void)setDebugLogging:(CDVInvokedUrlCommand*)command;
- (void)keepLifecycleSessionAlive:(CDVInvokedUrlCommand*)command;
- (void)collectLifecycleData:(CDVInvokedUrlCommand*)command;
- (void)setAppGroup:(CDVInvokedUrlCommand*)command __deprecated_msg("Extensions/Watch not supported.");
- (void)syncSettings:(CDVInvokedUrlCommand*)command __deprecated_msg("Extensions/Watch not supported.");
- (void)initializeWatch:(CDVInvokedUrlCommand*)command __deprecated_msg("Watch not supported.");
- (void)collectPII:(CDVInvokedUrlCommand*)command;
- (void)trackState:(CDVInvokedUrlCommand*)command;
- (void)trackAction:(CDVInvokedUrlCommand*)command;
- (void)trackActionFromBackground:(CDVInvokedUrlCommand*)command;
- (void)trackLocation:(CDVInvokedUrlCommand*)command;
- (void)trackBeacon:(CDVInvokedUrlCommand*)command;
- (void)trackPushMessageClickthrough:(CDVInvokedUrlCommand*)command;
- (void)trackLocalNotificationClickThrough:(CDVInvokedUrlCommand*)command;
- (void)trackingClearCurrentBeacon:(CDVInvokedUrlCommand*)command;
- (void)trackLifetimeValueIncrease:(CDVInvokedUrlCommand*)command;
- (void)trackTimedActionStart:(CDVInvokedUrlCommand*)command;
- (void)trackTimedActionUpdate:(CDVInvokedUrlCommand*)command;
- (void)trackingTimedActionExists:(CDVInvokedUrlCommand*)command;
- (void)trackTimedActionEnd:(CDVInvokedUrlCommand*)command;
- (void)trackingIdentifier:(CDVInvokedUrlCommand*)command;
- (void)trackingSendQueuedHits:(CDVInvokedUrlCommand*)command;
- (void)trackingClearQueue:(CDVInvokedUrlCommand*)command;
- (void)trackingGetQueueSize:(CDVInvokedUrlCommand*)command;
- (void)trackAdobeDeepLink:(CDVInvokedUrlCommand*)command;
- (void)targetLoadRequestWithNameWithLocationParameters:(CDVInvokedUrlCommand*)command;
- (void)targetLoadRequestWithName:(CDVInvokedUrlCommand*)command;
- (void)targetLoadRequest:(CDVInvokedUrlCommand*)command;
- (void)targetLoadOrderConfirmRequest:(CDVInvokedUrlCommand*)command;
- (void)targetClearCookies:(CDVInvokedUrlCommand*)command;
- (void)targetSessionID:(CDVInvokedUrlCommand*)command;
- (void)targetPcID:(CDVInvokedUrlCommand*)command;
- (void)targetSetThirdPartyID:(CDVInvokedUrlCommand*)command;
- (void)targetThirdPartyID:(CDVInvokedUrlCommand*)command;
- (void)acquisitionCampaignStartForApp:(CDVInvokedUrlCommand*)command;
- (void)audienceGetVisitorProfile:(CDVInvokedUrlCommand*)command;
- (void)audienceGetDpuuid:(CDVInvokedUrlCommand*)command;
- (void)audienceGetDpid:(CDVInvokedUrlCommand*)command;
- (void)audienceSetDpidAndDpuuid:(CDVInvokedUrlCommand*)command;
- (void)audienceSignalWithData:(CDVInvokedUrlCommand*)command;
- (void)audienceReset:(CDVInvokedUrlCommand*)command;
- (void)visitorGetMarketingCloudId:(CDVInvokedUrlCommand*)command;
- (void)visitorSyncIdentifiers:(CDVInvokedUrlCommand*)command;
- (void)visitorSyncIdentifiersWithAuthenticationState:(CDVInvokedUrlCommand*)command;
- (void)visitorSyncIdentifierWithType:(CDVInvokedUrlCommand*)command;
- (void)visitorAppendToURL:(CDVInvokedUrlCommand*)command;
- (void)visitorGetIDs:(CDVInvokedUrlCommand*)command;

@end
