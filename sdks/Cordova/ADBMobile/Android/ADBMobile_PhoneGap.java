package com.adobe;

import android.location.Location;
import android.net.Uri;

import com.adobe.mobile.Analytics;
import com.adobe.mobile.AudienceManager;
import com.adobe.mobile.Config;
import com.adobe.mobile.MobilePrivacyStatus;
import com.adobe.mobile.Target;
import com.adobe.mobile.TargetLocationRequest;
import com.adobe.mobile.Visitor;
import com.adobe.mobile.Acquisition;
import com.adobe.mobile.VisitorID;

import org.apache.cordova.CallbackContext;
import org.apache.cordova.CordovaInterface;
import org.apache.cordova.CordovaPlugin;
import org.apache.cordova.CordovaWebView;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.Map;

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

public class ADBMobile_PhoneGap extends CordovaPlugin {

    // =====================
    // public Method - all calls filter through this
    // =====================
    @Override
    public boolean execute(String action, JSONArray args, CallbackContext callbackContext) throws JSONException {
        Config.setContext(cordova.getActivity());
        if (action.equals("getVersion")) {
            this.getVersion(callbackContext);
            return true;
        } else if (action.equals("getPrivacyStatus")) {
            this.getPrivacyStatus(callbackContext);
            return true;
        } else if (action.equals("setPrivacyStatus")) {
            this.setPrivacyStatus(args, callbackContext);
            return true;
        } else if (action.equals("getLifetimeValue")) {
            this.getLifetimeValue(callbackContext);
            return true;
        } else if (action.equals("getUserIdentifier")) {
            this.getUserIdentifier(callbackContext);
            return true;
        } else if (action.equals("setUserIdentifier")) {
            this.setUserIdentifier(args, callbackContext);
            return true;
        } else if (action.equals("setPushIdentifier")) {
            this.setPushIdentifier(args, callbackContext);
            return true;
        } else if (action.equals("getDebugLogging")) {
            this.getDebugLogging(callbackContext);
            return true;
        } else if (action.equals("setDebugLogging")) {
            this.setDebugLogging(args, callbackContext);
            return true;
        } else if (action.equals("trackState")) {
            this.trackState(args, callbackContext);
            return true;
        } else if (action.equals("trackAction")) {
            this.trackAction(args, callbackContext);
            return true;
        } else if (action.equals("trackLocation")) {
            this.trackLocation(args, callbackContext);
            return true;
        } else if (action.equals("trackBeacon")) {
            this.trackBeacon(args, callbackContext);
            return true;
        } else if (action.equals("trackingClearCurrentBeacon")) {
            this.trackingClearCurrentBeacon(callbackContext);
            return true;
        } else if (action.equals("trackLifetimeValueIncrease")) {
            this.trackLifetimeValueIncrease(args, callbackContext);
            return true;
        } else if (action.equals("trackTimedActionStart")) {
            this.trackTimedActionStart(args, callbackContext);
            return true;
        } else if (action.equals("trackTimedActionUpdate")) {
            this.trackTimedActionUpdate(args, callbackContext);
            return true;
        } else if (action.equals("trackTimedActionEnd")) {
            this.trackTimedActionEnd(args, callbackContext);
            return true;
        } else if (action.equals("trackingTimedActionExists")) {
            this.trackingTimedActionExists(args, callbackContext);
            return true;
        } else if (action.equals("trackingIdentifier")) {
            this.trackingIdentifier(callbackContext);
            return true;
        } else if (action.equals("trackingClearQueue")) {
            this.trackingClearQueue(callbackContext);
            return true;
        } else if (action.equals("trackingGetQueueSize")) {
            this.trackingGetQueueSize(callbackContext);
            return true;
        } else if (action.equals("trackingSendQueuedHits")) {
            this.trackingSendQueuedHits(callbackContext);
            return true;
        } else if (action.equals("targetLoadRequest")) {
            this.targetLoadRequest(args, callbackContext);
            return true;
        } else if (action.equals("targetLoadRequestWithName")){
            this.targetLoadRequestWithName(args, callbackContext);
            return true;
        } else if (action.equals("targetLoadRequestWithNameWithLocationParameters")){
            this.targetLoadRequestWithNameWithLocationParameters(args, callbackContext);
            return true;
        } else if (action.equals("targetLoadOrderConfirmRequest")) {
            this.targetLoadOrderConfirmRequest(args, callbackContext);
            return true;
        } else if (action.equals("targetClearCookies")) {
            this.targetClearCookies(callbackContext);
            return true;
        } else if (action.equals("targetSessionID")) {
            this.targetSessionID(args, callbackContext);
            return true;
        } else if (action.equals("targetPcID")) {
            this.targetPcID(args, callbackContext);
            return true;
        } else if (action.equals("targetSetThirdPartyID")) {
            this.targetSetThirdPartyID(args, callbackContext);
            return true;
        } else if (action.equals("targetThirdPartyID")) {
            this.targetGetThirdPartyID(args, callbackContext);
            return true;
        } else if (action.equals("acquisitionCampaignStartForApp")) {
            this.acquisitionCampaignStartForApp(args, callbackContext);
            return true;
        } else if (action.equals("audienceGetVisitorProfile")) {
            this.audienceGetVisitorProfile(callbackContext);
            return true;
        } else if (action.equals("audienceGetDpuuid")) {
            this.audienceGetDpuuid(callbackContext);
            return true;
        } else if (action.equals("audienceGetDpid")) {
            this.audienceGetDpid(callbackContext);
            return true;
        } else if (action.equals("audienceSetDpidAndDpuuid")) {
            this.audienceSetDpidAndDpuuid(args, callbackContext);
            return true;
        } else if (action.equals("audienceSignalWithData")) {
            this.audienceSignalWithData(args, callbackContext);
            return true;
        } else if (action.equals("audienceReset")) {
            this.audienceReset(callbackContext);
            return true;
        } else if (action.equals("visitorGetMarketingCloudId")) {
            this.visitorGetMarketingCloudId(callbackContext);
            return true;
        } else if (action.equals("visitorSyncIdentifierWithType")) {
            this.visitorSyncIdentifierWithType(args, callbackContext);
            return true;
        } else if (action.equals("visitorSyncIdentifiers")) {
            this.visitorSyncIdentifiers(args, callbackContext);
            return true;
        } else if (action.equals("visitorSyncIdentifiersWithAuthenticationState")){
            this.visitorSyncIdentifiersWithAuthenticationState(args, callbackContext);
            return true;
        } else if (action.equals("visitorGetIDs")) {
            this.visitorGetIDs(args, callbackContext);
            return true;
        } else if (action.equals("visitorAppendToURL")) {
            this.visitorAppendToURL(args, callbackContext);
            return true;
        } else if (action.equals("collectPII")) {
            this.collectPII(args,callbackContext);
            return true;
        } else if (action.equals("trackAdobeDeepLink")){
            this.trackAdobeDeepLink(args,callbackContext);
            return true;
        }

        return false;
    }

    // =====================
    // Analytics/Config Methods
    // =====================
    private void getVersion(final CallbackContext callbackContext) {
        cordova.getThreadPool().execute(new Runnable() {
            @Override
            public void run() {
                String version = Config.getVersion();
                callbackContext.success(version);
            }
        });
    }

    private void getPrivacyStatus(final CallbackContext callbackContext) {
        cordova.getThreadPool().execute(new Runnable() {
            @Override
            public void run() {
                switch (Config.getPrivacyStatus()) {
                    case MOBILE_PRIVACY_STATUS_OPT_IN:
                        callbackContext.success("Opted In");
                        break;
                    case MOBILE_PRIVACY_STATUS_OPT_OUT:
                        callbackContext.success("Opted Out");
                        break;
                    case MOBILE_PRIVACY_STATUS_UNKNOWN:
                        callbackContext.success("Opt Unknown");
                        break;
                    default:
                        callbackContext.error("Privacy Status was an unknown value");
                }
            }
        });
    }

    private void setPrivacyStatus(JSONArray args, final CallbackContext callbackContext) throws JSONException {
        final int status = args.getInt(0);

        cordova.getThreadPool().execute(new Runnable() {
            @Override
            public void run() {
                switch (status) {
                    case 1:
                        Config.setPrivacyStatus(MobilePrivacyStatus.MOBILE_PRIVACY_STATUS_OPT_IN);
                        callbackContext.success("Privacy status set to opted in");
                        break;
                    case 2:
                        Config.setPrivacyStatus(MobilePrivacyStatus.MOBILE_PRIVACY_STATUS_OPT_OUT);
                        callbackContext.success("Privacy status set to opted out");
                        break;
                    case 3:
                        Config.setPrivacyStatus(MobilePrivacyStatus.MOBILE_PRIVACY_STATUS_UNKNOWN);
                        callbackContext.success("Privacy status set to unknown");
                        break;
                    default:
                        callbackContext.error("Privacy Status was an unknown value");
                }
            }
        });
    }

    private void getLifetimeValue(final CallbackContext callbackContext) {
        cordova.getThreadPool().execute(new Runnable() {
            @Override
            public void run() {
                BigDecimal ltValue = Config.getLifetimeValue();
                callbackContext.success(ltValue.toString());
            }
        });
    }

    private void getUserIdentifier(final CallbackContext callbackContext) {
        cordova.getThreadPool().execute((new Runnable() {
            @Override
            public void run() {
                String UserIdentifier = Config.getUserIdentifier();
                callbackContext.success(UserIdentifier);
            }
        }));
    }

    private void setUserIdentifier(JSONArray args, final CallbackContext callbackContext) throws JSONException {
        final String userIdentifier = args.getString(0);

        cordova.getThreadPool().execute(new Runnable() {
            @Override
            public void run() {
                Config.setUserIdentifier(userIdentifier);
                callbackContext.success();
            }
        });
    }

    private void setPushIdentifier(JSONArray args, final CallbackContext callbackContext) throws JSONException {
        final String pushIdentifier = args.getString(0);

        cordova.getThreadPool().execute(new Runnable() {
            @Override
            public void run() {
                Config.setPushIdentifier(pushIdentifier);
                callbackContext.success();
            }
        });
    }

    private void getDebugLogging(final CallbackContext callbackContext) {
        cordova.getThreadPool().execute(new Runnable() {
            @Override
            public void run() {
                boolean debugLogging = Config.getDebugLogging();
                callbackContext.success(debugLogging ? "true" : "false");
            }
        });
    }

    private void setDebugLogging(JSONArray args, final CallbackContext callbackContext) throws JSONException {
        final boolean status = args.getBoolean(0);

        cordova.getThreadPool().execute(new Runnable() {
            @Override
            public void run() {
                Config.setDebugLogging(status);
                callbackContext.success("Set DebugLogging");
            }
        });
    }

    private void trackState(final JSONArray args, final CallbackContext callbackContext) {
        cordova.getThreadPool().execute(new Runnable() {
            @Override
            public void run() {
                String state = null;
                HashMap<String, Object> cData = null;

                try {
                    if (!args.get(0).equals(null) && args.get(0).getClass() == String.class) {
                        state = args.getString(0);
                    } else if (!args.get(0).equals(null)) {
                        JSONObject cDataJSON = args.getJSONObject(0);
                        if (!cDataJSON.equals(null) && cDataJSON.length() > 0) {
                            cData = GetHashMapFromJSON(cDataJSON);
                        }
                    }
                    if (!args.get(1).equals(null)) {
                        JSONObject cDataJSON = args.getJSONObject(1);
                        if (!cDataJSON.equals(null) && cDataJSON.length() > 0) {
                            cData = GetHashMapFromJSON(cDataJSON);
                        }
                    }
                } catch (JSONException e) {
                    e.printStackTrace();
                    callbackContext.error(e.getMessage());
                    return;
                }

                Analytics.trackState(state, cData);
                callbackContext.success();
            }
        });
    }

    private void trackAction(final JSONArray args, final CallbackContext callbackContext) {
        cordova.getThreadPool().execute(new Runnable() {
            @Override
            public void run() {
                String action = null;
                HashMap<String, Object> cData = null;

                try {
                    // set appState if passed in
                    if (!args.get(0).equals(null) && args.get(0).getClass() == String.class) {
                        action = args.getString(0);
                    } else if (!args.get(0).equals(null)) {
                        // else set cData if it is passed in alone
                        JSONObject cDataJSON = args.getJSONObject(0);
                        if (!cDataJSON.equals(null) && cDataJSON.length() > 0) {
                            cData = GetHashMapFromJSON(cDataJSON);
                        }
                    }
                    // set cData if it is passed in along with action
                    if (!args.get(1).equals(null)) {
                        JSONObject cDataJSON = args.getJSONObject(1);
                        if (!cDataJSON.equals(null) && cDataJSON.length() > 0) {
                            cData = GetHashMapFromJSON(cDataJSON);
                        }
                    }
                } catch (JSONException e) {
                    e.printStackTrace();
                    callbackContext.error(e.getMessage());
                    return;
                }

                Analytics.trackAction(action, cData);
                callbackContext.success();
            }
        });
    }

    private void trackLocation(final JSONArray args, final CallbackContext callbackContext) {
        cordova.getThreadPool().execute(new Runnable() {
            @Override
            public void run() {
                Location location = new Location("New Location");
                HashMap<String, Object> cData = null;

                try {
                    location.setLatitude(Double.parseDouble(args.getString(0)));
                    location.setLongitude(Double.parseDouble(args.getString(1)));

                    // set cData if it is passed in along with action
                    if (!args.get(2).equals(null)) {
                        JSONObject cDataJSON = args.getJSONObject(2);
                        if (!cDataJSON.equals(null) && cDataJSON.length() > 0)
                            cData = GetHashMapFromJSON(cDataJSON);
                    }
                } catch (JSONException e) {
                    e.printStackTrace();
                    callbackContext.error(e.getMessage());
                    return;
                } catch (NumberFormatException e) {
                    e.printStackTrace();
                    callbackContext.error(e.getMessage());
                    return;
                }

                Analytics.trackLocation(location, cData);
                callbackContext.success();
            }
        });
    }

    private void trackBeacon(final JSONArray args, final CallbackContext callbackContext) {
        cordova.getThreadPool().execute(new Runnable() {
            @Override
            public void run() {
                try {
                    HashMap<String, Object> cData = null;
                    String uuid = args.getString(0);
                    String major = args.getString(1);
                    String minor = args.getString(2);
                    int proxInt = Integer.parseInt(args.getString(3));
                    Analytics.BEACON_PROXIMITY prox = proxInt >= 0 && proxInt < Analytics.BEACON_PROXIMITY.values().length ?
                            Analytics.BEACON_PROXIMITY.values()[proxInt] : Analytics.BEACON_PROXIMITY.values()[0];


                    // set cData if it is passed in along with action
                    if (!args.get(4).equals(null)) {
                        JSONObject cDataJSON = args.getJSONObject(4);
                        if (!cDataJSON.equals(null) && cDataJSON.length() > 0)
                            cData = GetHashMapFromJSON(cDataJSON);
                    }

                    Analytics.trackBeacon(uuid, major, minor, prox, cData);
                    callbackContext.success();
                } catch (JSONException e) {
                    e.printStackTrace();
                    callbackContext.error(e.getMessage());
                } catch (NumberFormatException e) {
                    e.printStackTrace();
                    callbackContext.error(e.getMessage());
                }
            }
        });
    }

    private void trackingClearCurrentBeacon(final CallbackContext callbackContext) {
        cordova.getThreadPool().execute(new Runnable() {
            @Override
            public void run() {
                Analytics.clearBeacon();
                callbackContext.success();
            }
        });
    }

    private void trackLifetimeValueIncrease(final JSONArray args, final CallbackContext callbackContext) {
        cordova.getThreadPool().execute(new Runnable() {
            @Override
            public void run() {
                BigDecimal amount = null;
                HashMap<String, Object> cData = null;

                try {
                    amount = new BigDecimal(args.getString(0));

                    // set cData
                    if (!args.get(1).equals(null)) {
                        JSONObject cDataJSON = args.getJSONObject(1);
                        if (!cDataJSON.equals(null) && cDataJSON.length() > 0) {
                            cData = GetHashMapFromJSON(cDataJSON);
                        }
                    }
                } catch (JSONException e) {
                    e.printStackTrace();
                    callbackContext.error(e.getMessage());
                    return;
                } catch (NumberFormatException e) {
                    e.printStackTrace();
                    callbackContext.error(e.getMessage());
                    return;
                }
                Analytics.trackLifetimeValueIncrease(amount, cData);
                callbackContext.success();
            }
        });
    }

    private void trackTimedActionStart(final JSONArray args, final CallbackContext callbackContext) {
        cordova.getThreadPool().execute(new Runnable() {
            String action = null;
            HashMap<String, Object> cData = null;

            @Override
            public void run() {
                try {
                    // set appState if passed in
                    if (!args.get(0).equals(null) && args.get(0).getClass() == String.class) {
                        action = args.getString(0);
                    } else if (!args.get(0).equals(null)) {
                        // else set cData if it is passed in alone
                        JSONObject cDataJSON = args.getJSONObject(0);
                        if (!cDataJSON.equals(null) && cDataJSON.length() > 0) {
                            cData = GetHashMapFromJSON(cDataJSON);
                        }
                    }

                    // set cData if it is passed in along with action
                    if (!args.get(1).equals(null)) {
                        JSONObject cDataJSON = args.getJSONObject(1);
                        if (!cDataJSON.equals(null) && cDataJSON.length() > 0) {
                            cData = GetHashMapFromJSON(cDataJSON);
                        }
                    }
                } catch (JSONException e) {
                    e.printStackTrace();
                    callbackContext.error(e.getMessage());
                    return;
                }
                Analytics.trackTimedActionStart(action, cData);
                callbackContext.success();
            }
        });
    }

    private void trackTimedActionUpdate(final JSONArray args, final CallbackContext callbackContext) {
        cordova.getThreadPool().execute(new Runnable() {
            String action = null;
            HashMap<String, Object> cData = null;

            @Override
            public void run() {
                try {
                    // set appState if passed in
                    if (!args.get(0).equals(null) && args.get(0).getClass() == String.class) {
                        action = args.getString(0);
                    } else if (!args.get(0).equals(null)) {
                        // else set cData if it is passed in alone
                        JSONObject cDataJSON = args.getJSONObject(0);
                        if (!cDataJSON.equals(null) && cDataJSON.length() > 0)
                            cData = GetHashMapFromJSON(cDataJSON);
                    }
                    // set cData if it is passed in along with action
                    if (!args.get(1).equals(null)) {
                        JSONObject cDataJSON = args.getJSONObject(1);
                        if (!cDataJSON.equals(null) && cDataJSON.length() > 0)
                            cData = GetHashMapFromJSON(cDataJSON);
                    }
                } catch (JSONException e) {
                    e.printStackTrace();
                    callbackContext.error(e.getMessage());
                    return;
                }

                Analytics.trackTimedActionUpdate(action, cData);
                callbackContext.success();
            }
        });
    }

    private void trackingTimedActionExists(final JSONArray args, final CallbackContext callbackContext) throws JSONException {
        final String action = args.getString(0);

        cordova.getThreadPool().execute(new Runnable() {
            @Override
            public void run() {
                boolean exists = Analytics.trackingTimedActionExists(action);
                callbackContext.success(exists ? "true" : "false");
            }
        });
    }

    private void trackTimedActionEnd(final JSONArray args, final CallbackContext callbackContext) throws JSONException {
        final String action = args.getString(0);

        cordova.getThreadPool().execute(new Runnable() {
            @Override
            public void run() {
                Analytics.trackTimedActionEnd(action, null);
                callbackContext.success();
            }
        });
    }

    private void trackingIdentifier(final CallbackContext callbackContext) {
        cordova.getThreadPool().execute(new Runnable() {
            @Override
            public void run() {
                String trackingIdentifier = Analytics.getTrackingIdentifier();
                callbackContext.success(trackingIdentifier);
            }
        });
    }

    private void trackingClearQueue(final CallbackContext callbackContext) {
        cordova.getThreadPool().execute(new Runnable() {
            @Override
            public void run() {
                Analytics.clearQueue();
                callbackContext.success();
            }
        });
    }

    private void trackingGetQueueSize(final CallbackContext callbackContext) {
        cordova.getThreadPool().execute(new Runnable() {
            @Override
            public void run() {
                long size = Analytics.getQueueSize();
                callbackContext.success(String.valueOf(size));
            }
        });
    }

    private void trackingSendQueuedHits(final CallbackContext callbackContext) {
        cordova.getThreadPool().execute(new Runnable() {
            @Override
            public void run() {
                Analytics.sendQueuedHits();
                callbackContext.success("Analytics: sent all hits in queue");
            }
        });
    }

    // =====================
    // Target
    // =====================
    private void targetLoadRequest(final JSONArray args, final CallbackContext callbackContext) {
        cordova.getThreadPool().execute(new Runnable() {
            @Override
            public void run() {
                try {
                    String name = args.getString(0);
                    String defaultContent = args.getString(1);
                    HashMap<String, Object> params = null;

                    // set params
                    if (!args.get(2).equals(null)) {
                        JSONObject cDataJSON = args.getJSONObject(2);
                        if (!cDataJSON.equals(null) && cDataJSON.length() > 0) {
                            params = GetHashMapFromJSON(cDataJSON);
                        }
                    }

                    TargetLocationRequest request = Target.createRequest(name, defaultContent, params);

                    Target.loadRequest(request, new Target.TargetCallback<String>() {
                        @Override
                        public void call(String s) {
                            callbackContext.success(s);
                        }
                    });

                } catch (JSONException e) {
                    e.printStackTrace();
                    callbackContext.error(e.getMessage());
                }
            }
        });
    }

    private void targetLoadOrderConfirmRequest(final JSONArray args, final CallbackContext callbackContext) {
        cordova.getThreadPool().execute(new Runnable() {
            @Override
            public void run() {
                HashMap<String, Object> params = null;
                String name = null;
                String orderID = null;
                String orderTotal = null;
                String productPurchaseID = null;

                try {
                    name = args.getString(0);
                    orderID = args.getString(1);
                    orderTotal = args.getString(2);
                    productPurchaseID = args.getString(3);

                    // set params
                    if (!args.get(4).equals(null)) {
                        JSONObject cDataJSON = args.getJSONObject(4);
                        if (!cDataJSON.equals(null) && cDataJSON.length() > 0) {
                            params = GetHashMapFromJSON(cDataJSON);
                        }
                    }
                } catch (JSONException e) {
                    e.printStackTrace();
                    callbackContext.error(e.getMessage());
                    return;
                }

                TargetLocationRequest request = Target.createOrderConfirmRequest(name, orderID, orderTotal, productPurchaseID, params);
                Target.loadRequest(request, new Target.TargetCallback<String>() {
                    @Override
                    public void call(String s) {
                        callbackContext.success(s);
                    }
                });
            }
        });
    }

    private void targetClearCookies(final CallbackContext callbackContext) {
        cordova.getThreadPool().execute(new Runnable() {
            @Override
            public void run() {
                Target.clearCookies();
                callbackContext.success("Target: cleared cookies");
            }
        });
    }

    // =====================
    // Acquisition
    // =====================
    private void acquisitionCampaignStartForApp(final JSONArray args, final CallbackContext callbackContext) {
        cordova.getThreadPool().execute(new Runnable() {
            @Override
            public void run() {
                String appId = null;
                HashMap<String, Object> data = null;
                try {
                    if (!args.get(0).equals(null) && args.get(0).getClass() == String.class) {
                        appId = args.getString(0);
                    }

                    if (!args.get(1).equals(null)) {
                        JSONObject dataJSON = args.getJSONObject(1);
                        if (!dataJSON.equals(null) && dataJSON.length() > 0) {
                            data = GetHashMapFromJSON(dataJSON);
                        }
                    }
                } catch (JSONException e) {
                    e.printStackTrace();
                    callbackContext.error(e.getMessage());
                    return;
                }

                Acquisition.campaignStartForApp(appId, data);
                callbackContext.success();
            }
        });
    }

    // =====================
    // Audience Manager
    // =====================
    private void audienceGetVisitorProfile(final CallbackContext callbackContext) {
        cordova.getThreadPool().execute(new Runnable() {
            @Override
            public void run() {
                HashMap<String, Object> profile = AudienceManager.getVisitorProfile();
                callbackContext.success(profile == null ? new JSONObject() : new JSONObject(profile));
            }
        });
    }

    private void audienceGetDpuuid(final CallbackContext callbackContext) {
        cordova.getThreadPool().execute(new Runnable() {
            @Override
            public void run() {
                String dpuuid = AudienceManager.getDpuuid();
                callbackContext.success(dpuuid);
            }
        });
    }

    private void audienceGetDpid(final CallbackContext callbackContext) {
        cordova.getThreadPool().execute(new Runnable() {
            @Override
            public void run() {
                String dpid = AudienceManager.getDpid();
                callbackContext.success(dpid);
            }
        });
    }

    private void audienceSetDpidAndDpuuid(JSONArray args, final CallbackContext callbackContext) throws JSONException {
        final String dpid = args.getString(0);
        final String dpuuid = args.getString(1);

        cordova.getThreadPool().execute(new Runnable() {
            @Override
            public void run() {
                AudienceManager.setDpidAndDpuuid(dpid, dpuuid);
                callbackContext.success();
            }
        });
    }

    private void audienceSignalWithData(final JSONArray args, final CallbackContext callbackContext) {
        cordova.getThreadPool().execute(new Runnable() {
            @Override
            public void run() {
                try {
                    HashMap<String, Object> data = null;

                    // set params
                    if (!args.get(0).equals(null)) {
                        JSONObject dataJSON = args.getJSONObject(0);
                        if (!dataJSON.equals(null) && dataJSON.length() > 0) {
                            data = GetHashMapFromJSON(dataJSON);
                        }
                    }

                    AudienceManager.signalWithData(data, new AudienceManager.AudienceManagerCallback<Map<String, Object>>() {
                        @Override
                        public void call(Map response) {
                            callbackContext.success(response == null ? null : new JSONObject(response));
                        }
                    });

                } catch (JSONException e) {
                    e.printStackTrace();
                    callbackContext.error(e.getMessage());
                }
            }
        });

    }

    private void audienceReset(final CallbackContext callbackContext) {
        cordova.getThreadPool().execute(new Runnable() {
            @Override
            public void run() {
                AudienceManager.reset();
                callbackContext.success("Audience manager reset");
            }
        });
    }

    // =====================
    // VisitorID
    // =====================
    private void visitorGetMarketingCloudId(final CallbackContext callbackContext) {
        cordova.getThreadPool().execute(new Runnable() {
            @Override
            public void run() {
                String visitorMCID = Visitor.getMarketingCloudId();
                callbackContext.success(visitorMCID);
            }
        });
    }

    @SuppressWarnings("unchecked")
    private void visitorSyncIdentifiers(final JSONArray args, final CallbackContext callbackContext) {
        cordova.getThreadPool().execute(new Runnable() {
            @Override
            public void run() {
                HashMap<String, Object> identifiers = null;

                try {
                    if (!args.get(0).equals(null)) {
                        JSONObject identifiersJSON = args.getJSONObject(0);
                        if (!identifiersJSON.equals(null) && identifiersJSON.length() > 0) {
                            identifiers = GetHashMapFromJSON(identifiersJSON);
                        }
                    }
                } catch (JSONException e) {
                    e.printStackTrace();
                    callbackContext.error(e.getMessage());
                    return;
                }

                Map<String, String> ids = (Map) identifiers;
                Visitor.syncIdentifiers(ids);
                callbackContext.success();
            }
        });
    }

    private void collectPII(final JSONArray args, final CallbackContext callbackContext) throws JSONException {

        cordova.getThreadPool().execute((new Runnable() {
            @Override
            public void run() {
                HashMap<String, Object> piiData = null;

                try {
                    if (!args.get(0).equals(null)) {
                        JSONObject piiDataJSON = args.getJSONObject(0);
                        if (!piiDataJSON.equals(null) && piiDataJSON.length() > 0) {
                            piiData = GetHashMapFromJSON(piiDataJSON);
                        }
                    }
                } catch (JSONException e) {
                    e.printStackTrace();
                    callbackContext.error(e.getMessage());
                    return;
                }

                Config.collectPII(piiData);
                callbackContext.success();
            }
        }));

    }

    private void targetLoadRequestWithName(final JSONArray args, final CallbackContext callbackContext) {
        cordova.getThreadPool().execute((new Runnable() {
            @Override
            public void run() {
                try {
                    String name = args.getString(0);
                    String defaultContent = args.getString(1);

                    // set params
                    if (!args.get(2).equals(null) && !args.get(3).equals(null) && !args.get(4).equals(null)) {

                        HashMap<String, Object> profileParameters = null;
                        HashMap<String, Object> orderParameters = null;
                        HashMap<String, Object> mboxParameters = null;
                        HashMap<String, Object> requestLocationParameters = null;

                        JSONObject profileParametersJSON = args.getJSONObject(2);
                        if (!profileParametersJSON.equals(null) && profileParametersJSON.length() > 0) {
                            profileParameters = GetHashMapFromJSON(profileParametersJSON);
                        }

                        JSONObject orderParametersJSON = args.getJSONObject(3);
                        if (!orderParametersJSON.equals(null) && orderParametersJSON.length() > 0) {
                            orderParameters = GetHashMapFromJSON(orderParametersJSON);
                        }

                        JSONObject mboxParametersJSON = args.getJSONObject(4);
                        if ( !mboxParametersJSON.equals(null) && mboxParametersJSON.length() > 0) {
                            mboxParameters = GetHashMapFromJSON(mboxParametersJSON);
                        }

                        Target.loadRequest(name,defaultContent,profileParameters,orderParameters,mboxParameters,new Target.TargetCallback<String>() {
                            @Override
                            public void call(String s) {
                                callbackContext.success(s);
                            }
                        });
                    }
                    else {
                        callbackContext.error("parameters cant be null");
                    }

                } catch (JSONException e) {
                    e.printStackTrace();
                    callbackContext.error(e.getMessage());
                }
            }
        }));
    }

    private void targetLoadRequestWithNameWithLocationParameters(final JSONArray args, final CallbackContext callbackContext) {
        cordova.getThreadPool().execute((new Runnable() {
            @Override
            public void run() {
                try {
                    String name = args.getString(0);
                    String defaultContent = args.getString(1);

                    // set params
                    if (!args.get(2).equals(null) && !args.get(3).equals(null) && !args.get(4).equals(null) && !args.get(5).equals(null)) {

                        HashMap<String, Object> profileParameters = null;
                        HashMap<String, Object> orderParameters = null;
                        HashMap<String, Object> mboxParameters = null;
                        HashMap<String, Object> requestLocationParameters = null;

                        JSONObject profileParametersJSON = args.getJSONObject(2);
                        if (!profileParametersJSON.equals(null) && profileParametersJSON.length() > 0) {
                            profileParameters = GetHashMapFromJSON(profileParametersJSON);
                        }

                        JSONObject orderParametersJSON = args.getJSONObject(3);
                        if (!orderParametersJSON.equals(null) && orderParametersJSON.length() > 0) {
                            orderParameters = GetHashMapFromJSON(orderParametersJSON);
                        }

                        JSONObject mboxParametersJSON = args.getJSONObject(4);
                        if (!mboxParametersJSON.equals(null) && mboxParametersJSON.length() > 0) {
                            mboxParameters = GetHashMapFromJSON(mboxParametersJSON);
                        }

                        JSONObject requestLocationParametersJSON = args.getJSONObject(5);
                        if (!requestLocationParametersJSON.equals(null) && requestLocationParametersJSON.length() > 0) {
                            requestLocationParameters = GetHashMapFromJSON(requestLocationParametersJSON);
                        }

                        Target.loadRequest(name,defaultContent,profileParameters,orderParameters,mboxParameters,requestLocationParameters,new Target.TargetCallback<String>() {
                            @Override
                            public void call(String s) {
                                callbackContext.success(s);
                            }
                        });
                    }
                    else {
                        callbackContext.error("parameters cant be null");
                    }

                } catch (JSONException e) {
                    e.printStackTrace();
                    callbackContext.error(e.getMessage());
                }
            }
        }));
    }

    private void targetSessionID(final JSONArray args, final CallbackContext callbackContext) {
        cordova.getThreadPool().execute((new Runnable() {
            @Override
            public void run() {
                String sessionId = Target.getSessionID();
                callbackContext.success(sessionId);
            }
        }));
    }

    private void targetPcID(final JSONArray args, final CallbackContext callbackContext) {
        cordova.getThreadPool().execute((new Runnable() {
            @Override
            public void run() {
                String pcID = Target.getPcID();
                callbackContext.success(pcID);
            }
        }));
    }

    private void targetSetThirdPartyID(final JSONArray args, final CallbackContext callbackContext) {
        cordova.getThreadPool().execute((new Runnable() {
            @Override
            public void run() {
                try {
                    String thirdPartyID = args.getString(0);
                    Target.setThirdPartyID(thirdPartyID);
                    callbackContext.success();

                } catch (JSONException e) {
                    e.printStackTrace();
                    callbackContext.error(e.getMessage());
                }
            }
        }));
    }

    private void targetGetThirdPartyID(final JSONArray args, final CallbackContext callbackContext) {

        cordova.getThreadPool().execute((new Runnable() {
            @Override
            public void run() {
                String thirdPartyID = Target.getThirdPartyID();
                callbackContext.success(thirdPartyID);
            }
        }));
    }

    private void visitorSyncIdentifierWithType(final JSONArray args, final CallbackContext callbackContext) {

        cordova.getThreadPool().execute((new Runnable() {
            @Override
            public void run() {
                try {
                    String identifierType = args.getString(0);
                    String identifier = args.getString(1);
                    int authenticationStateVal = args.getInt(2);

                    if(authenticationStateVal >= 0 && authenticationStateVal <= 2){
                        VisitorID.VisitorIDAuthenticationState authenticationState = VisitorID.VisitorIDAuthenticationState.VISITOR_ID_AUTHENTICATION_STATE_UNKNOWN;

                        switch (authenticationStateVal){

                            case 0:
                                authenticationState = VisitorID.VisitorIDAuthenticationState.VISITOR_ID_AUTHENTICATION_STATE_UNKNOWN;
                                break;
                            case 1:
                                authenticationState = VisitorID.VisitorIDAuthenticationState.VISITOR_ID_AUTHENTICATION_STATE_AUTHENTICATED;
                                break;
                            case 2:
                                authenticationState = VisitorID.VisitorIDAuthenticationState.VISITOR_ID_AUTHENTICATION_STATE_LOGGED_OUT;
                                break;
                        }

                        Visitor.syncIdentifier(identifierType, identifier, authenticationState);
                        callbackContext.success();
                    } else{
                        callbackContext.error("Invalid Authentication State");
                    }

                } catch (JSONException e) {
                    e.printStackTrace();
                    callbackContext.error(e.getMessage());
                }
            }
        }));
    }

    private void visitorSyncIdentifiersWithAuthenticationState(final JSONArray args, final CallbackContext callbackContext) {

        cordova.getThreadPool().execute((new Runnable() {
            @Override
            public void run() {

                Map<String, String> identifiers = null;
                VisitorID.VisitorIDAuthenticationState authenticationState = VisitorID.VisitorIDAuthenticationState.VISITOR_ID_AUTHENTICATION_STATE_UNKNOWN;

                try {
                    if (!args.get(0).equals(null))
                    {
                        JSONObject identifiersJSON = args.getJSONObject(0);

                        if (identifiersJSON != null && identifiersJSON.length() > 0)
                        {
                            identifiers = (Map) GetHashMapFromJSON(identifiersJSON);
                        }
                    }

                    int authenticationStateVal = 0;
                    try {
                        authenticationStateVal = args.getInt(1);

                        if(authenticationStateVal >= 0 && authenticationStateVal < 3) {

                            switch (authenticationStateVal) {

                                case 0:
                                    authenticationState = VisitorID.VisitorIDAuthenticationState.VISITOR_ID_AUTHENTICATION_STATE_UNKNOWN;
                                    break;
                                case 1:
                                    authenticationState = VisitorID.VisitorIDAuthenticationState.VISITOR_ID_AUTHENTICATION_STATE_AUTHENTICATED;
                                    break;
                                case 2:
                                    authenticationState = VisitorID.VisitorIDAuthenticationState.VISITOR_ID_AUTHENTICATION_STATE_LOGGED_OUT;
                                    break;
                            }
                        }
                    }
                    catch (JSONException e)
                    {
                        e.printStackTrace();
                        callbackContext.error(e.getMessage());
                        return;
                    }

                    Visitor.syncIdentifiers(identifiers, authenticationState);
                    callbackContext.success();

                } catch (JSONException e) {
                    e.printStackTrace();
                    callbackContext.error(e.getMessage());
                }
            }
        }));
    }

    private void visitorGetIDs(final JSONArray args, final CallbackContext callbackContext) {

        cordova.getThreadPool().execute((new Runnable() {
            @Override
            public void run() {
                JSONArray visitorIDSJSONArray = null;
                try {
                    visitorIDSJSONArray = visitorGetIDsJSONArray();
                    if (visitorIDSJSONArray == null){
                        // returning success with null throws exception. Handle by sending empty array.
                        callbackContext.success(new JSONArray());
                    } else {
                        callbackContext.success(visitorIDSJSONArray);
                    }
                } catch (Exception e) {
                    e.printStackTrace();
                    callbackContext.error(e.getMessage());
                }
            }
        }));
    }

    private void visitorAppendToURL(final JSONArray args, final CallbackContext callbackContext) {

        cordova.getThreadPool().execute((new Runnable() {
            @Override
            public void run() {

                try {
                    String urlToAppend = "";
                    if (!args.get(0).equals(null)){
                        urlToAppend = args.getString(0);
                    }
                    String finalURLString = Visitor.appendToURL(urlToAppend);
                    callbackContext.success(finalURLString);
                } catch (JSONException e) {
                    e.printStackTrace();
                    callbackContext.error(e.getMessage());
                }
            }
        }));
    }


    private void trackAdobeDeepLink(final JSONArray args, final CallbackContext callbackContext) throws JSONException {

        cordova.getThreadPool().execute((new Runnable() {
            @Override
            public void run() {
                try {
                    String deepLinkURL = "";
                    if (!args.get(0).equals(null)){
                        deepLinkURL = args.getString(0);
                    }
                    Config.trackAdobeDeepLink(Uri.parse(deepLinkURL));
                    callbackContext.success("track Adobe Link successful!");

                } catch (JSONException e) {
                    e.printStackTrace();
                    callbackContext.error(e.getMessage());
                }
            }
        }));
    }

    // =====================
    // Helpers
    // =====================
    private HashMap<String, Object> GetHashMapFromJSON(JSONObject data) {
        HashMap<String, Object> map = new HashMap<String, Object>();
        @SuppressWarnings("rawtypes")
        Iterator it = data.keys();
        while (it.hasNext()) {
            String n = (String) it.next();
            try {
                map.put(n, data.getString(n));
            } catch (JSONException e) {
                e.printStackTrace();
            }
        }

        HashMap<String, Object> table = new HashMap<String, Object>();
        table.putAll(map);
        return table;
    }

    private JSONArray visitorGetIDsJSONArray() {
        ArrayList<Object> visitoIDsJson = new ArrayList<Object>();
        JSONArray visitorIDSJSONArray = null;

        try {
            ArrayList<VisitorID> visitorIDs = (ArrayList<VisitorID>) Visitor.getIdentifiers();
            if (visitorIDs != null && visitorIDs.size() > 0){
                for (VisitorID vID:visitorIDs){
                    HashMap<Object,Object> vIDMap = new HashMap<Object, Object>();
                    vIDMap.put("idType", (vID.idType != null) ? vID.idType : "");
                    vIDMap.put("id", (vID.id != null) ? vID.id : "");
                    vIDMap.put("authenticationState", vID.authenticationState.toString());
                    visitoIDsJson.add(vIDMap);
                }

                visitorIDSJSONArray = new JSONArray(visitoIDsJson);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }

        return visitorIDSJSONArray;
    }

    // =====================
    // Plugin life cycle events
    // =====================
    @Override
    public void initialize(CordovaInterface cordova, CordovaWebView webView) {
        super.initialize(cordova, webView);
        com.adobe.mobile.Config.setContext(this.cordova.getActivity().getApplicationContext());
        com.adobe.mobile.Config.collectLifecycleData(this.cordova.getActivity());
    }

    @Override
    public void onPause(boolean multitasking) {
        super.onPause(multitasking);
        com.adobe.mobile.Config.pauseCollectingLifecycleData();
    }

    @Override
    public void onResume(boolean multitasking) {
        super.onResume(multitasking);
        com.adobe.mobile.Config.collectLifecycleData(this.cordova.getActivity());
    }
}
