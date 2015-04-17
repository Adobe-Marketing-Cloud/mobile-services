using System;
using System.Drawing;

using Foundation;
using UIKit;
using Com.Adobe.Mobile;

namespace AdobeMobileSample
{
	public partial class AdobeMobileSampleViewController : UIViewController
	{
		public AdobeMobileSampleViewController (IntPtr handle) : base (handle)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle
		UITableView table;
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			NSDictionary cData = NSDictionary.FromObjectAndKey (NSObject.FromObject("val1"), NSObject.FromObject("key1"));
			ADBMobile.collectLifecycleDataWithAdditionalData (cData);

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
				"audienceSignalWithData",
				"audienceReset",
				"visitorMarketingCloudID",
				"visitorSyncIdentifiers",

				};

			table.Source = new TableSource(tableItems);
			Add (table);
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}
		#endregion
		partial void UIButton5_TouchUpInside (UIButton sender)
		{
			ADBMobile.TrackState("test", null);
		}

		public class TableSource : UITableViewSource {
			string[] tableItems;
			string cellIdentifier = "TableCell";
			NSDictionary cData;
			ADBMediaSettings settings;
			ADBTargetLocationRequest req;


			public TableSource (string[] items)
			{
				tableItems = items;
				cData = NSDictionary.FromObjectAndKey (NSObject.FromObject("val1"), NSObject.FromObject("key1"));

			}
			public override nint RowsInSection (UITableView tableview, nint section)
			{
				return tableItems.Length;
			}
			public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
			{
				UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);

				// if there are no cells to reuse, create a new one
				if (cell == null)
					cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier);
				cell.TextLabel.Text = tableItems[indexPath.Row];
				return cell;
			}

			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
			{
				switch (indexPath.Row) {
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
					ADBMobile.SetPrivacyStatus (ADBMobilePrivacyStatus.OptIn);
					break;
				case 3:
					ADBMobile.SetPrivacyStatus (ADBMobilePrivacyStatus.OptOut);
					break;
				case 4:
					ADBMobile.SetPrivacyStatus (ADBMobilePrivacyStatus.Unknown);
					break;
				case 5:
					new UIAlertView("LifetimeValue", ADBMobile.LifetimeValue().ToString(), null, "OK", null).Show();
					break;
				case 6:
					new UIAlertView("UserIdentifier", ADBMobile.UserIdentifier(), null, "OK", null).Show();
					break;
				case 7:
					ADBMobile.SetUserIdentifier ("customUserIdentifier");
					break;
				case 8:
					new UIAlertView("DebugLogging", ADBMobile.DebugLogging().ToString(), null, "OK", null).Show();
					break;
				case 9:
					ADBMobile.SetDebugLogging (true);
					break;
				case 10:
					ADBMobile.SetDebugLogging (false);
					break;
				case 11:
					ADBMobile.KeepLifecycleSessionAlive ();
					break;
					//Analytics
					//				"trackBeacon",
					//				"trackingClearCurrentBeacon",
					//				"trackLifetimeValueIncrease",
					//				"trackTimedActionStart",
					//				"trackTimedActionUpdate",
					//				"trackTimedActionEnd",
					//				"trackingTimedActionExists",
					//				"trackingIdentifier",
					//				"trackingSendQueuedHits",
					//				"trackingClearQueue",
					//				"trackingGetQueueSize",
				case 12:
					//				"trackState",
					ADBMobile.TrackState ("stateName", cData);
					break;
				case 13:
					//				"trackAction",
					ADBMobile.TrackAction ("actionName", cData);
					break;
				case 14:
					//				"trackActionFromBackground",
					ADBMobile.TrackActionFromBackground ("actionNameFromBackground", cData);
					break;
				case 15:
					//				"trackLocation",
					CoreLocation.CLLocation l = new CoreLocation.CLLocation (111.111, 44.156);
					ADBMobile.TrackLocation (l, null);
					break;
				case 16:
					CoreLocation.CLBeacon b = new CoreLocation.CLBeacon ();
					b.SetValueForKey (new NSNumber (1), new NSString ("major"));
					b.SetValueForKey (new NSNumber (1), new NSString ("minor"));
					b.SetValueForKey (new NSNumber (1), new NSString ("proximity"));
					b.SetValueForKey (new NSUuid ("5a2bf809-992f-42c2-8590-6793ecbe2437"), new NSString ("proximityUUID"));

					ADBMobile.TrackBeacon (b, null);
					break;
				case 17:
					ADBMobile.TrackingClearCurrentBeacon ();
					break;
				case 18:
					ADBMobile.TrackLifetimeValueIncrease (new NSDecimalNumber(10.4), cData);
					break;
				case 19:
					ADBMobile.TrackTimedActionStart ("timedAction", cData);
					break;
				case 20:
					NSDictionary updatedData = NSDictionary.FromObjectAndKey (NSObject.FromObject ("val2"), NSObject.FromObject ("key2"));
					ADBMobile.TrackTimedActionUpdate ("timedAction", updatedData);
					break;
				case 21:
					ADBMobile.TrackTimedActionEnd ("timedAction", (double arg1, double arg2, NSMutableDictionary arg3) => {
						return true;
					});
					break;
				case 22:
					new UIAlertView("TrackingTimedActionExists", ADBMobile.TrackingTimedActionExists("timedAction").ToString(), null, "OK", null).Show();
					break;
				case 23:
					new UIAlertView("TrackingIdentifier", ADBMobile.TrackingIdentifier(), null, "OK", null).Show();
					break;
				case 24:
					ADBMobile.TrackingSendQueuedHits ();
					break;
				case 25:
					ADBMobile.TrackingClearQueue ();
					break;
				case 26:
					new UIAlertView("TrackingGetQueueSize", ADBMobile.TrackingGetQueueSize().ToString(), null, "OK", null).Show();
					break;
					//					//Media
					//					"mediaCreateSettingsWithName",
				case 27:
					settings = ADBMobile.MediaCreateSettings ("name1", 10, "playerName1", "playerID1");
					settings.Milestones = "25,50,75";
					break;
					//					"mediaAdCreateSettingsWithName",
				case 28:
					ADBMediaSettings adSettings = ADBMobile.MediaAdCreateSettings("adName1", 2, "playerName1", "name1", "podName1", 4, "CPM1");
					break;
					//					"mediaOpenWithSettings",
				case 29:
					ADBMobile.MediaOpenWithSettings (settings, (state) => {
						Console.WriteLine (state.Name);
					});
					break;
					//					"mediaClose",
				case 30:
					ADBMobile.MediaClose (settings.Name);
					break;
					//					"mediaPlay",
				case 31:
					ADBMobile.MediaPlay (settings.Name, 0);
					break;
					//					"mediaComplete",
				case 32:
					ADBMobile.MediaComplete (settings.Name, 5);
					break;
					//					"mediaStop",
				case 33:
					ADBMobile.MediaStop (settings.Name, 3);
					break;
					//					"mediaClick",
				case 34:
					ADBMobile.MediaClick (settings.Name, 3);
					break;
					//					"mediaTrack",
				case 35:
					ADBMobile.MediaTrack (settings.Name, null);
					break;
					//					//Target
					//					"targetLoadRequest",
				case 36:
					ADBMobile.TargetLoadRequest(req,  (context) => {
						Console.WriteLine (context);
					});
					break;
					//					"targetCreateRequestWithName",
				case 37:
					NSDictionary dict = NSDictionary.FromObjectAndKey (NSObject.FromObject ("value2"), NSObject.FromObject ("key1"));
					req = ADBMobile.TargetCreateRequest ("iOSTest", "defGal", dict);
					break;
					//					"targetCreateOrderConfirmRequestWithName",
				case 38:
					ADBMobile.TargetCreateOrderConfirmRequest ("myOrder", "12345", "29.41", "cool stuff", null);
					break;
					//					"targetClearCookies",
				case 39:
					ADBMobile.TargetClearCookies ();
					break;
					//					//AAM
					//					"audienceVisitorProfile",
				case 40:
					new UIAlertView("AudienceVisitorProfile", ADBMobile.AudienceVisitorProfile ().ToString (), null, "OK", null).Show();
					break;
				case 41:
					//					"audienceDpid",
					new UIAlertView("AudienceDpid", ADBMobile.AudienceDpid (), null, "OK", null).Show();
					break;
				case 42:
					//					"audienceDpuuid",
					new UIAlertView("AudienceDpuuid", ADBMobile.AudienceDpuuid (), null, "OK", null).Show();
					break;
				case 43:
					//					"audienceSetDpid",
					ADBMobile.AudienceSetDpidAndDpuuid ("testDppid", "testDpuuid");
					break;
					//					"audienceSignalWithData",
				case 44:
					//					"audienceReset",
					ADBMobile.AudienceReset ();
					break;
				case 45:
					//					"visitorMarketingCloudID",
					new UIAlertView("VisitorMarketingCloudID", ADBMobile.VisitorMarketingCloudID (), null, "OK", null).Show();
					break;
				case 46:
					//					"visitorSyncIdentifiers",
					NSDictionary vidDict = NSDictionary.FromObjectAndKey (NSObject.FromObject ("value2"), NSObject.FromObject ("pushID"));
					ADBMobile.VisitorSyncIdentifiers (vidDict);
					break;
				}
								
				tableView.DeselectRow (indexPath, true); // normal iOS behaviour is to remove the blue highlight
			}

		}
	}
}