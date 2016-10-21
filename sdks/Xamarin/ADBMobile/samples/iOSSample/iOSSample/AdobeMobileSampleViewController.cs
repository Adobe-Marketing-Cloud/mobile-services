using System;
using System.Drawing;

using Foundation;
using UIKit;
using Com.Adobe.Mobile;

namespace AdobeMobileSample
{
	public partial class AdobeMobileSampleViewController : UIViewController
	{
		public AdobeMobileSampleViewController(IntPtr handle) : base(handle)
		{
		}

		public override void DidReceiveMemoryWarning()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning();

			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle
		UITableView table;
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			NSDictionary cData = NSDictionary.FromObjectAndKey(NSObject.FromObject("val1"), NSObject.FromObject("key1"));
			ADBMobile.CollectLifecycleDataWithAdditionalData(cData);

			table = new UITableView(View.Bounds); // defaults to Plain style
			string[] tableItems = new string[] {
				//config
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
				//Analytics
				"trackState",
				"trackAction",
				"trackActionFromBackground",
				"trackLocation",
				"trackBeacon",
				"trackingClearCurrentBeacon",
				"trackLifetimeValueIncrease",
				"trackTimedActionStart",
				"trackTimedActionUpdate",
				"trackTimedActionEnd",
				"trackingTimedActionExists",
				"trackingIdentifier",
				"trackingSendQueuedHits",
				"trackingClearQueue",
				"trackingGetQueueSize",
				//Media
				"mediaCreateSettingsWithName",
				"mediaAdCreateSettingsWithName",
				"mediaOpenWithSettings",
				"mediaClose",
				"mediaPlay",
				"mediaComplete",
				"mediaStop",
				"mediaClick",
				"mediaTrack",
				//Target
				"targetLoadRequest",
				"targetCreateRequestWithName",
				"targetCreateOrderConfirmRequestWithName",
				"targetClearCookies",
				//AAM
				"audienceVisitorProfile",
				"audienceDpid",
				"audienceDpuuid",
				"audienceSetDpid",
				"audienceReset",
				"visitorMarketingCloudID",
				"visitorSyncIdentifiers",
				//4.13.0 Update
				"setAdvertisingIdentifier",
				"setPushIdentifier",
				"setAppGroup",
				"setAppExtensionType",
				"registerAdobeDataCallback",
				"trackPushMessageClickthrough",
				"trackLocalNotificationClickthrough",
				"trackAdobeDeepLink",
				"acquisitionCampaignStartForApp",
				"targetLoadRequestWithRequestLocation",
				"targetThirdPartyId",
				"targetSetThirdPartyId",
				"targetPcID",
				"targetSessionID",
				"visitorSyncIdentifiers",
				"visitorSyncIdentifiersAuthState",
				"visitorSyncIdentifierWithTypeAuthState",
				"visitorGetIDs",
				"visitorAppendToURL"
				};

			table.Source = new TableSource(tableItems);
			Add(table);
			// Perform any additional setup after loading the view, typically from a nib.
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
		partial void UIButton5_TouchUpInside(UIButton sender)
		{
			ADBMobile.TrackState("test", null);
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

			public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
			{
				Console.WriteLine("Row value " + indexPath);

				switch (indexPath.Row)
				{
					//							Config
					//							"version",
					//							"privacyStatus",
					//							"setPrivacyStatus - in",
					//							"setPrivacyStatus - out",
					//							"setPrivacyStatus - unknown",
					//							"lifetimeValue",
					//							"userIdentifier",
					//							"setUserIdentifier",
					//							"debugLogging",
					//							"setDebugLogging - true",
					//							"setDebugLogging - false",
					//							"keepLifecycleSessionAlive",
					case 0:
						new UIAlertView("Version", ADBMobile.Version(), null, "OK", null).Show();
						break;
					case 1:
						new UIAlertView("PrivacyStatus", ADBMobile.PrivacyStatus().ToString(), null, "OK", null).Show();
						break;
					case 2:
						ADBMobile.SetPrivacyStatus(ADBMobilePrivacyStatus.OptIn);
						break;
					case 3:
						ADBMobile.SetPrivacyStatus(ADBMobilePrivacyStatus.OptOut);
						break;
					case 4:
						ADBMobile.SetPrivacyStatus(ADBMobilePrivacyStatus.Unknown);
						break;
					case 5:
						new UIAlertView("LifetimeValue", ADBMobile.LifetimeValue().ToString(), null, "OK", null).Show();
						break;
					case 6:
						new UIAlertView("UserIdentifier", ADBMobile.UserIdentifier(), null, "OK", null).Show();
						break;
					case 7:
						ADBMobile.SetUserIdentifier("customUserIdentifier");
						break;
					case 8:
						new UIAlertView("DebugLogging", ADBMobile.DebugLogging().ToString(), null, "OK", null).Show();
						break;
					case 9:
						ADBMobile.SetDebugLogging(true);
						break;
					case 10:
						ADBMobile.SetDebugLogging(false);
						break;
					case 11:
						ADBMobile.KeepLifecycleSessionAlive();
						break;
					//	Analytics
					case 12://				"trackState",
						ADBMobile.TrackState("stateName", cData);
						break;
					case 13://				"trackAction",
						ADBMobile.TrackAction("actionName", cData);
						break;
					case 14://				"trackActionFromBackground",
						ADBMobile.TrackActionFromBackground("actionNameFromBackground", cData);
						break;
					case 15: //				"trackLocation",
						CoreLocation.CLLocation l = new CoreLocation.CLLocation(111.111, 44.156);
						ADBMobile.TrackLocation(l, null);
						break;
					case 16: //				"trackBeacon", //doesn't work on iOS 10
						//CoreLocation.CLBeacon b = new CoreLocation.CLBeacon();
						//b.SetValueForKey(new NSNumber(1), new NSString("major"));
						//b.SetValueForKey(new NSNumber(1), new NSString("minor"));
						//b.SetValueForKey(new NSNumber(1), new NSString("proximity"));
						//b.SetValueForKey(new NSUuid("5a2bf809-992f-42c2-8590-6793ecbe2437"), new NSString("proximityUUID"));

						//ADBMobile.TrackBeacon(b, null);
						break;
					case 17: // trackingClearCurrentBeacon
						ADBMobile.TrackingClearCurrentBeacon();
						break;
					case 18: // trackLifetimeValueIncrease
						ADBMobile.TrackLifetimeValueIncrease(new NSDecimalNumber(10.4), cData);
						break;
					case 19: // trackTimedActionStart
						ADBMobile.TrackTimedActionStart("timedAction", cData);
						break;
					case 20: // trackTimedActionUpdate
						NSDictionary updatedData = NSDictionary.FromObjectAndKey(NSObject.FromObject("val2"), NSObject.FromObject("key2"));
						ADBMobile.TrackTimedActionUpdate("timedAction", updatedData);
						break;
					case 21: // trackTimedActionEnd
						ADBMobile.TrackTimedActionEnd("timedAction", (double arg1, double arg2, NSMutableDictionary arg3) =>
						{
							return true;
						});
						break;
					case 22: // trackTimedActionExists
						new UIAlertView("TrackingTimedActionExists", ADBMobile.TrackingTimedActionExists("timedAction").ToString(), null, "OK", null).Show();
						break;
					case 23: // trackIdentifier
						new UIAlertView("TrackingIdentifier", ADBMobile.TrackingIdentifier(), null, "OK", null).Show();
						break;
					case 24: // trackSendQueuedHits
						ADBMobile.TrackingSendQueuedHits();
						break;
					case 25: // trackingClearQueue
						ADBMobile.TrackingClearQueue();
						break;
					case 26: // trackingGetQueueSize
						new UIAlertView("TrackingGetQueueSize", ADBMobile.TrackingGetQueueSize().ToString(), null, "OK", null).Show();
						break;
					//	Media
					case 27: // mediaCreateSettingsWithName
						settings = ADBMobile.MediaCreateSettings("name1", 10, "playerName1", "playerID1");
						settings.Milestones = "25,50,75";
						break;
					case 28: // mediaAdCreateSettingsWithName
						ADBMediaSettings adSettings = ADBMobile.MediaAdCreateSettings("adName1", 2, "playerName1", "name1", "podName1", 4, "CPM1");
						break;
					case 29: // mediaOpenWithSettings
						ADBMobile.MediaOpenWithSettings(settings, (state) =>
						{
							Console.WriteLine(state.Name);
						});
						break;
					case 30: //	mediaClose
						if (settings.Name != null)
						{
							ADBMobile.MediaClose(settings.Name);
						}
						break;
					case 31: //	mediaPlay
						if (settings.Name != null)
						{
							ADBMobile.MediaPlay(settings.Name, 0);
						}
						break;
					case 32: // mediaComplete
						if (settings.Name != null)
						{
							ADBMobile.MediaComplete(settings.Name, 5);
						}
						break;
					case 33: // mediaStop
						if (settings.Name != null)
						{
							ADBMobile.MediaStop(settings.Name, 3);
						}
						break;
					case 34: // mediaClick
						if (settings.Name != null)
						{
							ADBMobile.MediaClick(settings.Name, 3);
						}
						break;
					case 35: // mediaTrack
						if (settings.Name != null)
						{
							ADBMobile.MediaTrack(settings.Name, null);
						}
						break;
						// Target
					case 36: //	targetLoadRequest
						ADBMobile.TargetLoadRequest(req, (context) =>
						{
							Console.WriteLine(context);
						});
						break;
					case 37: //					"targetCreateRequestWithName",
						NSDictionary dict = NSDictionary.FromObjectAndKey(NSObject.FromObject("value2"), NSObject.FromObject("key1"));
						req = ADBMobile.TargetCreateRequest("iOSTest", "defGal", dict);
						break;
					case 38: //					"targetCreateOrderConfirmRequestWithName",
						ADBMobile.TargetCreateOrderConfirmRequest("myOrder", "12345", "29.41", "cool stuff", null);
						break;
					case 39: //					"targetClearCookies",
						ADBMobile.TargetClearCookies();
						break;
						// AAM
					case 40: //					"audienceVisitorProfile",
						new UIAlertView("AudienceVisitorProfile", ADBMobile.AudienceVisitorProfile() != null ? ADBMobile.AudienceVisitorProfile().ToString() : "null", null, "OK", null).Show();
						break;
					case 41: //					"audienceDpid",
						new UIAlertView("AudienceDpid", ADBMobile.AudienceDpid(), null, "OK", null).Show();
						break;
					case 42: //					"audienceDpuuid",
						new UIAlertView("AudienceDpuuid", ADBMobile.AudienceDpuuid(), null, "OK", null).Show();
						break;
					case 43: //					"audienceSetDpid",
						ADBMobile.AudienceSetDpidAndDpuuid("testDppid", "testDpuuid");
						break;
					case 44: //					"audienceSignalWithData",
						//					"audienceReset",
						ADBMobile.AudienceReset();
						break;
					case 45:
						//					"visitorMarketingCloudID",
						new UIAlertView("VisitorMarketingCloudID", ADBMobile.VisitorMarketingCloudID(), null, "OK", null).Show();
						break;
					case 46:
						//					"visitorSyncIdentifiers",
						NSDictionary vidDict = NSDictionary.FromObjectAndKey(NSObject.FromObject("value2"), NSObject.FromObject("pushID"));
						ADBMobile.VisitorSyncIdentifiers(vidDict);
						break;
					case 47: // "setAdvertisingIdentifier",
						ADBMobile.SetAdvertisingIdentifier("testAdid");
						break;
					case 48: // "setPushIdentifier",
						ADBMobile.SetPushIdentifier(NSData.FromString("testPushId"));
						break;
					case 49: // "setAppGroup",
						ADBMobile.SetAppGroup("testAppGroup");
						break;
					case 50: // "setAppExtensionType"
						ADBMobile.SetAppExtensionType(ADBMobileAppExtensionType.Regular);
						break;
					case 51: // "registerAdobeDataCallback"
						ADBMobile.RegisterAdobeDataCallback((adobeMobileDataEvent, callbackData) =>
						{
							Console.WriteLine("event: " + adobeMobileDataEvent + "\ndata: " + callbackData);
						});
						break;
					case 52: // "trackPushMessageClickthrough"
						ADBMobile.TrackPushMessageClickThrough(NSDictionary.FromObjectAndKey(NSObject.FromObject("97f8db20-bb28-4c1a-8cda-78c6ba98f87d"), NSObject.FromObject("adb_m_id")));
						break;
					case 53: // "trackLocalNotificationClickthrough"
						ADBMobile.TrackLocalNotificationClickThrough(NSDictionary.FromObjectAndKey(NSObject.FromObject("97f8db20-bb28-4c1a-8cda-78c6ba98f87d"), NSObject.FromObject("adb_m_id")));
						break;
					case 54: // "trackAdobeDeepLink"
						ADBMobile.TrackAdobeDeepLink(NSUrl.FromString("http://adobe.com?a.deeplink.id=12345678"));
						break;
					case 55: // "acquisitionCampaignStartForApp"
						ADBMobile.AcquisitionCampaignStartForApp("com.adobe.test", NSDictionary.FromObjectAndKey(NSObject.FromObject("value"), NSObject.FromObject("key")));
						break;
					case 56: // "targetLoadRequestWithRequestLocation"
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
					case 57: // "targetThirdPartyId"
						new UIAlertView("target thirdPartyId", ADBMobile.TargetThirdPartyID(), null, "OK", null).Show();
						break;
					case 58: // "targetSetThirdPartyId"
						ADBMobile.TargetSetThirdPartyID("testThirdPartyId");
						break;
					case 59: // "targetPcID"
						new UIAlertView("target PcID", ADBMobile.TargetPcID(), null, "OK", null).Show();
						break;
					case 60: // "targetSessionID"
						new UIAlertView("target SessionID", ADBMobile.TargetSessionID(), null, "OK", null).Show();
						break;
					case 61: // "visitorSyncIdentifiers"
						ADBMobile.VisitorSyncIdentifier("idType", "identifier0", ADBMobileVisitorAuthenticationState.Authenticated);
						break;
					case 62: // "visitorSyncIdentifiersAuthState"
						ADBMobile.VisitorSyncIdentifiers(NSDictionary.FromObjectAndKey(NSObject.FromObject("value"), NSObject.FromObject("key")));
						break;
					case 63: // "visitorSyncIdentifierWithTypeAuthState"
						ADBMobile.VisitorSyncIdentifiers(NSDictionary.FromObjectAndKey(NSObject.FromObject("value"), NSObject.FromObject("key")), ADBMobileVisitorAuthenticationState.Unknown);
						break;
					case 64: // "visitorGetIDs"
						new UIAlertView("visitor ids", ADBMobile.VisitorGetIDs().ToString(), null, "OK", null).Show();
						break;
					case 65: // "visitorAppendToURL"
						new UIAlertView("visitor appendToURL", ADBMobile.VisitorAppendToURL(NSUrl.FromString("http://adobe.com")).ToString(), null, "OK", null).Show();
						break;
					default:
						new UIAlertView("Option Invalid", "Could not find the API!", null, "OK", null).Show();
						break;
				}

				tableView.DeselectRow(indexPath, true); // normal iOS behaviour is to remove the blue highlight
			}

		}
	}
}