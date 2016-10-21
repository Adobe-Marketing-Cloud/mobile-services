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
var ADB = (function () {
	var ADB = (typeof exports !== 'undefined') && exports || {};

	ADB.doNothing = function () {};

	var PLUGIN_NAME = "ADBMobile_PhoneGap";

	ADB.optedIn		= 1;
	ADB.optedOut	= 2;
	ADB.optUnknown	= 3;

	ADB.beaconUnknown	= 0;
	ADB.beaconImmediate	= 1;
	ADB.beaconNear		= 2;
	ADB.beaconFar		= 3;

	ADB.mobileVisitorAuthenticationStateUnknown			= 0;
	ADB.mobileVisitorAuthenticationStateAuthenticated	= 1;
	ADB.mobileVisitorAuthenticationStateLoggedOut		= 2;
           
	ADB.visitorID_idType = "idType";
	ADB.visitorID_id = "id";
	ADB.visitorID_authenticationState = "authenticationState";

	ADB.getVersion = function(success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "getVersion", []);
	};

	ADB.getPrivacyStatus = function(success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "getPrivacyStatus", []);
	};

	ADB.setPrivacyStatus = function (privacyStatus, success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "setPrivacyStatus", [privacyStatus]);
	};

	ADB.getLifetimeValue = function(success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "getLifetimeValue", []);
	};

	ADB.getUserIdentifier = function(success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "getUserIdentifier", []);
	};

	ADB.setUserIdentifier = function (userIdentifier, success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "setUserIdentifier", [userIdentifier]);
	};

	ADB.setPushIdentifier = function (pushIdentifier, success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "setPushIdentifier", [pushIdentifier]);
	};

	ADB.getDebugLogging = function(success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "getDebugLogging", []);
	};

	ADB.setDebugLogging = function(debugLogging, success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "setDebugLogging", [debugLogging]);
	};

	ADB.keepLifecycleSessionAlive = function(success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "keepLifecycleSessionAlive", []);
	};

	ADB.collectLifecycleData = function(success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "collectLifecycleData", []);
	};

	ADB.collectPII = function(piiData, success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "collectPII", [piiData]);
	}

	ADB.trackState = function(stateName, cData, success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "trackState", [stateName, cData]);
	};

	ADB.trackAction = function(action, cData, success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "trackAction", [action, cData]);
	};

	ADB.trackActionFromBackground = function(action, cData, success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "trackActionFromBackground", [action, cData]);
	};

	ADB.trackLocation = function(lat, long, cData, success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "trackLocation", [lat, long, cData]);
	};

	ADB.trackBeacon = function(uuid, major, minor, proximity, cData, success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "trackBeacon", [uuid, major, minor, proximity, cData]);
	};

	ADB.clearCurrentBeacon = function(success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "trackingClearCurrentBeacon", []);
	};

	ADB.trackAdobeDeepLink = function(deeplinkURL, success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "trackAdobeDeepLink", [deeplinkURL]);
	}
	
	ADB.trackLifetimeValueIncrease = function(amount, cData, success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "trackLifetimeValueIncrease", [amount, cData]);
	};

	ADB.trackTimedActionStart = function(action, cData, success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "trackTimedActionStart", [action, cData]);
	};

	ADB.trackTimedActionUpdate = function(action, cData, success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "trackTimedActionUpdate", [action, cData]);
	};

	ADB.trackTimedActionEnd = function(action, success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "trackTimedActionEnd", [action]);
	};

	ADB.trackingTimedActionExists = function(success, fail, action) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "trackingTimedActionExists", [action]);
	};

	ADB.trackingIdentifier = function(success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "trackingIdentifier", []);
	};

	ADB.trackingSendQueuedHits = function() {
		return cordova.exec(ADB.doNothing, ADB.doNothing, "ADBMobile_PhoneGap", "trackingSendQueuedHits", []);
	};

	ADB.trackingClearQueue = function() {
		return cordova.exec(ADB.doNothing, ADB.doNothing, "ADBMobile_PhoneGap", "trackingClearQueue", []);
	};

	ADB.trackingGetQueueSize = function(success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "trackingGetQueueSize", []);
	};

	ADB.targetLoadRequest = function(success, fail, name, defaultContent, parameters) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "targetLoadRequest", [name, defaultContent, parameters]);
	};

	ADB.targetLoadRequestWithName = function(success, fail, name, defaultContent, profileParameters, orderParameters, mboxParameters) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "targetLoadRequestWithName", [name, defaultContent, profileParameters, orderParameters, mboxParameters]);
	}

	ADB.targetLoadRequestWithNameWithLocationParameters = function(success, fail, name, defaultContent, profileParameters, orderParameters, mboxParameters, requestLocationParameters) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "targetLoadRequestWithNameWithLocationParameters", [name, defaultContent, profileParameters, orderParameters, mboxParameters, requestLocationParameters]);
	}

	ADB.targetSessionID = function(success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "targetSessionID", []);
	}

	ADB.targetPcID = function(success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "targetPcID", []);
	}

	ADB.targetSetThirdPartyID = function(thirdPartyID, success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "targetSetThirdPartyID", [thirdPartyID]);
	}

	ADB.targetThirdPartyID = function(success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "targetThirdPartyID", []);
	}

	ADB.targetLoadOrderConfirmRequest = function(success, fail, name, orderId, orderTotal, productPurchaseId, parameters) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "targetLoadOrderConfirmRequest", [name, orderId, orderTotal, productPurchaseId, parameters]);
	};

	ADB.targetClearCookies = function() {	
		return cordova.exec(ADB.doNothing, ADB.doNothing, "ADBMobile_PhoneGap", "targetClearCookies", []);
	};

	ADB.acquisitionCampaignStartForApp = function(appId, data, success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "acquisitionCampaignStartForApp", [appId, data]);
	};

	ADB.audienceGetVisitorProfile = function(success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "audienceGetVisitorProfile", []);
	};

	ADB.audienceGetDpuuid = function(success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "audienceGetDpuuid", []);
	};

	ADB.audienceGetDpid = function(success, fail) {	
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "audienceGetDpid", []);
	};

	ADB.audienceSetDpidAndDpuuid = function(dpid, dpuuid, success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "audienceSetDpidAndDpuuid", [dpid, dpuuid]);
	};	

	ADB.audienceSignalWithData = function(success, fail, data) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "audienceSignalWithData", [data]);
	};	

	ADB.audienceReset = function() {	
		return cordova.exec(ADB.doNothing, ADB.doNothing, "ADBMobile_PhoneGap", "audienceReset", []);
	};

	ADB.visitorAppendToURL = function(urlToAppend, success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "visitorAppendToURL", [urlToAppend]);
	}

	ADB.visitorGetMarketingCloudId = function(success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "visitorGetMarketingCloudId", []);
	};	

	ADB.visitorSyncIdentifiers = function(identifiers, success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "visitorSyncIdentifiers", [identifiers]);
	};

	ADB.visitorSyncIdentifierWithType = function(identifierType, identifier, authenticationState, success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "visitorSyncIdentifierWithType", [identifierType, identifier, authenticationState]);
	}

	ADB.visitorSyncIdentifiersWithAuthenticationState = function(identifiers, authenticationState, success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "visitorSyncIdentifiersWithAuthenticationState", [identifiers, authenticationState]);
	}
          
	ADB.visitorGetIDs = function(success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "visitorGetIDs", []);
	}

	/*
	*	iOS methods
	*/
	ADB.trackPushMessageClickthrough = function(userInfo, success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "trackPushMessageClickthrough", [userInfo]);
	};
	
	ADB.setAppGroup = function(appGroup, success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "setAppGroup", [appGroup]);
	};

	ADB.syncSettings = function(settings, success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "syncSettings", [settings]);
	};

	ADB.initializeWatch = function() {
		return cordova.exec(ADB.doNothing, ADB.doNothing, "ADBMobile_PhoneGap", "initializeWatch", []);
	};

	ADB.trackLocalNotificationClickThrough = function(userInfo, success, fail) {
		return cordova.exec(success, fail, "ADBMobile_PhoneGap", "trackLocalNotificationClickThrough", [userInfo]);
	}

	return ADB;
}());

module.exports = ADB;
