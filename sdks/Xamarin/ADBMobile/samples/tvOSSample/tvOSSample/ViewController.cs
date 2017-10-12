using System;
using Foundation;
using UIKit;
using Com.Adobe.Mobile;

namespace tvOSSample
{
	public partial class ViewController : UIViewController
	{
		public ViewController(IntPtr handle) : base(handle)
		{
		}

		#region View lifecycle
		UITableView table;
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			table = new UITableView(View.Bounds); // defaults to Plain style
			string[] tableItems = new string[] {
				"version",
				"privacyStatus",
				"setPrivacyStatus - in",
				"setPrivacyStatus - out",
				"setPrivacyStatus - unknown",
				"lifetimeValue",
				"userIdentifier",
				"setUserIdentifier",
				"debugLogging",
				"setDebugLogging - true",
				"setDebugLogging - false",
				"keepLifecycleSessionAlive",
				"trackState",
				"trackAction",
				"trackActionFromBackground",
				"trackLocation",
				"installTVMLHooks",
				"trackLifetimeValueIncrease",
				"trackTimedActionStart",
				"trackTimedActionUpdate",
				"trackTimedActionEnd",
				"trackingTimedActionExists",
				"trackingIdentifier",
				"trackingSendQueuedHits",
				"trackingClearQueue",
				"trackingGetQueueSize",
				"mediaCreateSettingsWithName",
				"mediaAdCreateSettingsWithName",
				"mediaOpenWithSettings",
				"mediaClose",
				"mediaPlay",
				"mediaComplete",
				"mediaStop",
				"mediaClick",
				"mediaTrack",
				"targetLoadRequest",
				"targetCreateRequestWithName",
				"targetCreateOrderConfirmRequestWithName",
				"targetClearCookies",
				"audienceVisitorProfile",
				"audienceDpid",
				"audienceDpuuid",
				"audienceSetDpid",
				"audienceSignalWithData",
				"audienceReset",
				"visitorMarketingCloudID",
				"visitorSyncIdentifiers",
				"setAdvertisingIdentifier",
				"setAdvertisingIdentiferNull",
				"setPushIdentifier",
				"setPushIdentifierNull",
				"setAppGroup",
				"setAppGroupNull",
				"setAppExtensionTypeRegular",
				"setAppExtensionTypeStandalone",
				"registerAdobeDataCallback",
				"trackPushMessageClickthrough",
				"trackLocalNotificationClickthrough",
				"trackAdobeDeepLink",
				"acquisitionCampaignStartForApp",
				"targetLoadRequestWithProfileOrderMboxParameters",
				"targetLoadRequestWithRequestLocation",
				"targetThirdPartyId",
				"targetSetThirdPartyId",
				"targetSetThirdPartyIdNull",
				"targetPcID",
				"targetSessionID",
				"visitorSyncIdentifiers",
				"visitorSyncIdentifiersAuthState",
				"visitorSyncIdentifierWithTypeAuthState",
				"visitorGetIDs",
				"visitorAppendToURL",
				"collectPII"
				};

			table.Source = new TableSource(tableItems);
			Add(table);
		}
		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
		}

		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
		}

		public override void ViewDidDisappear(bool animated)
		{
			base.ViewDidDisappear(animated);
		}
		#endregion

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		public class TableSource : UITableViewSource
		{
			string[] tableItems;
			string cellIdentifier = "TableCell";
			NSDictionary cData;
			ADBMediaSettings settings;
			ADBTargetLocationRequest req;

			public TableSource(string[] items)
			{
				tableItems = items;
				cData = NSDictionary.FromObjectAndKey(NSObject.FromObject("val1"), NSObject.FromObject("key1"));

			}
			public override nint RowsInSection(UITableView tableview, nint section)
			{
				return tableItems.Length;
			}
			public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
			{
				UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);

				// if there are no cells to reuse, create a new one
				if (cell == null)
					cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);
				cell.TextLabel.Text = tableItems[indexPath.Row];
				return cell;
			}

			public void ShowAlert(string title, string message)
			{
				UIAlertController uiAlertController = UIAlertController.Create(title != null ? title : "(null)", message != null ? message : "(null)", UIAlertControllerStyle.Alert);
				UIAlertAction uiAlertAction = UIAlertAction.Create("ok", UIAlertActionStyle.Default, null);
				uiAlertController.AddAction(uiAlertAction);
				UIViewController viewController = UIApplication.SharedApplication.KeyWindow.RootViewController;
				viewController.PresentViewController(uiAlertController, true, null);
			}

			public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
			{
				switch (indexPath.Row)
				{
					case 0: // "version"
						ShowAlert("version", ADBMobile.Version());
						break;
					case 1: // "privacyStatus"
						ShowAlert("privacy status", ADBMobile.PrivacyStatus().ToString());
						break;
					case 2: // "setPrivacyStatus - in"
						ADBMobile.SetPrivacyStatus(ADBMobilePrivacyStatus.OptIn);
						break;
					case 3: // "setPrivacyStatus - out"
						ADBMobile.SetPrivacyStatus(ADBMobilePrivacyStatus.OptOut);
						break;
					case 4: // "setPrivacyStatus - unknown"
						ADBMobile.SetPrivacyStatus(ADBMobilePrivacyStatus.Unknown);
						break;
					case 5: // "lifetimeValue"
						ShowAlert("lifetime value", ADBMobile.LifetimeValue().ToString());
						break;
					case 6: // "userIdentifier"
						ShowAlert("user identifier", ADBMobile.UserIdentifier());
						break;
					case 7: // "setUserIdentifier"
						ADBMobile.SetUserIdentifier("imBatman");
						break;
					case 8: // "debugLogging"
						ShowAlert("debug logging", ADBMobile.DebugLogging().ToString());
						break;
					case 9: // "setDebugLogging - true"
						ADBMobile.SetDebugLogging(true);
						break;
					case 10: //	"setDebugLogging - false"
						ADBMobile.SetDebugLogging(false);
						break;
					case 11: //	"keepLifecycleSessionAlive"
						ADBMobile.KeepLifecycleSessionAlive();
						break;
					case 12: //	"trackState"
						ADBMobile.TrackState("testState1", cData);
						break;
					case 13: // "trackAction"
						ADBMobile.TrackAction("testAction1", cData);
						ADBMobile.TrackAction("testAction1", null);
						ADBMobile.TrackAction(null, cData);
						ADBMobile.TrackAction(null, null);
						break;
					case 14: // "trackActionFromBackground"
						ADBMobile.TrackActionFromBackground("testAction1", cData);
						break;
					case 15: // "trackLocation"
						CoreLocation.CLLocation l = new CoreLocation.CLLocation(111.111, 44.156);
						ADBMobile.TrackLocation(l, null);
						break;
					case 16: // "installTVMLHooks"
						ADBMobile.InstallTVMLHooks(null);
						break;
					case 17: // "trackLifetimeValueIncrease"
						ADBMobile.TrackLifetimeValueIncrease(new NSDecimalNumber(10.4), cData);
						break;
					case 18: // "trackTimedActionStart"
						ADBMobile.TrackTimedActionStart("timedAction1", cData);
						break;
					case 19: // "trackTimedActionUpdate"
						NSDictionary updatedData = NSDictionary.FromObjectAndKey(NSObject.FromObject("val2"), NSObject.FromObject("key2"));
						ADBMobile.TrackTimedActionUpdate("timedAction1", updatedData);
						break;
					case 20: // "trackTimedActionEnd"
						ADBMobile.TrackTimedActionEnd("timedAction1", (double arg1, double arg2, NSMutableDictionary arg3) =>
						{
							return true;
						});
						break;
					case 21: // "trackingTimedActionExists"
						ShowAlert("timed action exists", ADBMobile.TrackingTimedActionExists("timedAction1").ToString());
						break;
					case 22: // "trackingIdentifier"
						ShowAlert("tracking identifier", ADBMobile.TrackingIdentifier());
						break;
					case 23: // "trackingSendQueuedHits"
						ADBMobile.TrackingSendQueuedHits();
						break;
					case 24: // "trackingClearQueue"
						ADBMobile.TrackingClearQueue();
						break;
					case 25: // "trackingGetQueueSize"
						ShowAlert("tracking queue size", ADBMobile.TrackingGetQueueSize().ToString());
						break;
					case 26: // "mediaCreateSettingsWithName"
						settings = ADBMobile.MediaCreateSettings("name1", 10, "playerName1", "playerID1");
						settings.Milestones = "25,50,75";
						break;
					case 27: // "mediaAdCreateSettingsWithName"
						ADBMobile.MediaAdCreateSettings("adName1", 2, "playerName1", "name1", "podName1", 4, "CPM1");
						break;
					case 28: // "mediaOpenWithSettings"
						ADBMobile.MediaOpenWithSettings(settings, (state) =>
						{
							Console.WriteLine(state.Name);
						});
						break;
					case 29: // "mediaClose"
						ADBMobile.MediaClose(settings.Name);
						break;
					case 30: // "mediaPlay"
						ADBMobile.MediaPlay(settings.Name, 0);
						break;
					case 31: // "mediaComplete"
						ADBMobile.MediaComplete(settings.Name, 5);
						break;
					case 32: // "mediaStop"
						ADBMobile.MediaStop(settings.Name, 3);
						break;
					case 33: // "mediaClick"
						ADBMobile.MediaClick(settings.Name, 3);
						break;
					case 34: // "mediaTrack"
						ADBMobile.MediaTrack(settings.Name, null);
						break;
					case 35: // "targetLoadRequest"
						ADBMobile.TargetLoadRequest(req, (context) =>
						{
							Console.WriteLine(context);
						});
						break;
					case 36: //	"targetCreateRequestWithName"
						NSDictionary dict = NSDictionary.FromObjectAndKey(NSObject.FromObject("value2"), NSObject.FromObject("key1"));
						req = ADBMobile.TargetCreateRequest("iOSTest", "defGal", dict);
						break;
					case 37: //	"targetCreateOrderConfirmRequestWithName"
						ADBMobile.TargetCreateOrderConfirmRequest("myOrder", "12345", "29.41", "cool stuff", null);
						break;
					case 38: //	"targetClearCookies"
						ADBMobile.TargetClearCookies();
						break;
					case 39: // "audienceVisitorProfile"
						ShowAlert("audience visitor profile", ADBMobile.AudienceVisitorProfile().ToString());
						break;
					case 40: //	"audienceDpid"
						ShowAlert("audience dpid", ADBMobile.AudienceDpid());
						break;
					case 41: // "audienceDpuuid"
						ShowAlert("audience dpuuid", ADBMobile.AudienceDpuuid());
						break;
					case 42:    //	"audienceSetDpid"
						ADBMobile.AudienceSetDpidAndDpuuid("testDpid", "testDpuuid");
						break;
					case 43:    //	"audienceSignalWithData",
						NSDictionary audienceData = NSDictionary.FromObjectAndKey(NSObject.FromObject("value2"), NSObject.FromObject("key1"));
						ADBMobile.AudienceSignalWithData(audienceData, (context) =>
						{
							Console.WriteLine(context);
						});
						break;
					case 44: // "audienceReset"
						ADBMobile.AudienceReset();
						break;
					case 45: // "visitorMarketingCloudID"
						ShowAlert("visitor mcid", ADBMobile.VisitorMarketingCloudID());
						break;

					case 46: // "visitorSyncIdentifiers"
						NSDictionary vidDict = NSDictionary.FromObjectAndKey(NSObject.FromObject("value2"), NSObject.FromObject("pushID"));
						ADBMobile.VisitorSyncIdentifiers(vidDict);
						break;
					case 47: // "setAdvertisingIdentifier",
						ADBMobile.SetAdvertisingIdentifier("testAdid");
						break;
					case 48: // "setAdvertisingIdentiferNull",
						ADBMobile.SetAdvertisingIdentifier(null);
						break;
					case 49: // "setPushIdentifier",
						ADBMobile.SetPushIdentifier(NSData.FromString("testPushId"));
						break;
					case 50: // "setPushIdentifierNull",
						ADBMobile.SetPushIdentifier(null);
						break;
					case 51: // "setAppGroup",
						ADBMobile.SetAppGroup("testAppGroup");
						break;
					case 52: // "setAppGroupNull"
						ADBMobile.SetAppGroup(null);
						break;
					case 53: // "setAppExtensionTypeRegular"
						ADBMobile.SetAppExtensionType(ADBMobileAppExtensionType.Regular);
						break;
					case 54: // "setAppExtensionTypeStandalone"
						ADBMobile.SetAppExtensionType(ADBMobileAppExtensionType.StandAlone);
						break;
					case 55: // "registerAdobeDataCallback"
						ADBMobile.RegisterAdobeDataCallback((adobeMobileDataEvent, callbackData) =>
						{
							ShowAlert("adobe data callback", "event: " + adobeMobileDataEvent + "\ndata: " + callbackData);
						});
						break;
					case 56: // "trackPushMessageClickthrough"
						ADBMobile.TrackPushMessageClickThrough(NSDictionary.FromObjectAndKey(NSObject.FromObject("value"), NSObject.FromObject("key")));
						break;
					case 57: // "trackLocalNotificationClickthrough"
						ADBMobile.TrackLocalNotificationClickThrough(NSDictionary.FromObjectAndKey(NSObject.FromObject("value"), NSObject.FromObject("key")));
						break;
					case 58: // "trackAdobeDeepLink"
						ADBMobile.TrackAdobeDeepLink(NSUrl.FromString("http://adobe.com"));
						break;
					case 59: // "acquisitionCampaignStartForApp"
						ADBMobile.AcquisitionCampaignStartForApp("com.adobe.test", NSDictionary.FromObjectAndKey(NSObject.FromObject("value"), NSObject.FromObject("key")));
						break;
					case 60: // "targetLoadRequestWithProfileOrderMboxParameters"
						ADBMobile.TargetLoadRequest("someMbox",
													"defaultContent",
													NSDictionary.FromObjectAndKey(NSObject.FromObject("value"), NSObject.FromObject("key")),
													NSDictionary.FromObjectAndKey(NSObject.FromObject("value"), NSObject.FromObject("key")),
													NSDictionary.FromObjectAndKey(NSObject.FromObject("value"), NSObject.FromObject("key")),
													(context) =>
						{
							Console.WriteLine(context);
						});
						break;
					case 61: // "targetLoadRequestWithRequestLocation"
						ADBMobile.TargetLoadRequest("someMbox",
													"defaultContent",
													NSDictionary.FromObjectAndKey(NSObject.FromObject("value"), NSObject.FromObject("key")),
													NSDictionary.FromObjectAndKey(NSObject.FromObject("value"), NSObject.FromObject("key")),
													NSDictionary.FromObjectAndKey(NSObject.FromObject("value"), NSObject.FromObject("key")),
													NSDictionary.FromObjectAndKey(NSObject.FromObject("value"), NSObject.FromObject("key")),
													(context) =>
						 {
							 Console.WriteLine(context);
						 });
						break;
					case 62: // "targetThirdPartyId"
						ShowAlert("target thirdPartyId", ADBMobile.TargetThirdPartyID());
						break;
					case 63: // "targetSetThirdPartyId"
						ADBMobile.TargetSetThirdPartyID("testThirdPartyId");
						break;
					case 64: // "targetSetThirdPartyIdNull"
						ADBMobile.TargetSetThirdPartyID(null);
						break;
					case 65: // "targetPcID"
						ShowAlert("target PcID", ADBMobile.TargetPcID());
						break;
					case 66: // "targetSessionID"
						ShowAlert("target SessionID", ADBMobile.TargetSessionID());
						break;
					case 67: // "visitorSyncIdentifiers"
						ADBMobile.VisitorSyncIdentifier("idType", "identifier0", ADBMobileVisitorAuthenticationState.Authenticated);
						break;
					case 68: // "visitorSyncIdentifiersAuthState"
						ADBMobile.VisitorSyncIdentifiers(NSDictionary.FromObjectAndKey(NSObject.FromObject("value"), NSObject.FromObject("key")));
						break;
					case 69: // "visitorSyncIdentifierWithTypeAuthState"
						ADBMobile.VisitorSyncIdentifiers(NSDictionary.FromObjectAndKey(NSObject.FromObject("value"), NSObject.FromObject("key")), ADBMobileVisitorAuthenticationState.Unknown);
						break;
					case 70: // "visitorGetIDs"
						ShowAlert("visitor ids", ADBMobile.VisitorGetIDs().ToString());
						break;
					case 71: // "visitorAppendToURL"
						ShowAlert("visitor appendToURL", ADBMobile.VisitorAppendToURL(NSUrl.FromString("http://adobe.com")).ToString());
						break;
					case 72: // "collectPII"
						NSDictionary<NSString, NSString> data = (Foundation.NSDictionary<Foundation.NSString, Foundation.NSString>)NSDictionary.FromObjectAndKey(NSObject.FromObject("value"), NSObject.FromObject("key"));
						ADBMobile.CollectPII(data);
						break;
				}

				tableView.DeselectRow(indexPath, true); // normal iOS behaviour is to remove the blue highlight
			}

		}
	}
}

