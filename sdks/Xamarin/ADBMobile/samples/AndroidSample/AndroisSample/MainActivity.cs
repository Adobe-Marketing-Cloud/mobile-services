using System;

using System.Collections.Generic;
using System.IO;
using Android.App;
using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Adobe.Mobile;

namespace AndroidSample
{

	class TimedActionBlock: Java.Lang.Object, Analytics.ITimedActionBlock{
		public Java.Lang.Object Call (long inAppDuration, long totalDuration, IDictionary<string, Java.Lang.Object> contextData){
			return Java.Lang.Boolean.True;
		}
	}

	class TargetCallback: Java.Lang.Object, Target.ITargetCallback{
		public void Call (Java.Lang.Object content)
		{
			Console.WriteLine (content.ToString());
		}
	}
	class AudienceManagerCallback: Java.Lang.Object,  AudienceManager.IAudienceManagerCallback{
		public void Call (Java.Lang.Object content)
		{
			Console.WriteLine (content.ToString());
		}
	}

	class MediaCallback: Java.Lang.Object,   Media.IMediaCallback{
		public void Call (Java.Lang.Object content)
		{
			Console.WriteLine (content.ToString());
		}
	}


	[Activity (Label = "AndroidSample", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : ListActivity
	{
		override protected void  OnResume()
		{
			base.OnResume(); // Always call the superclass first.
			Config.CollectLifecycleData (this);
		}

		override protected void  OnPause()
		{
			base.OnPause(); // Always call the superclass first
			Config.PauseCollectingLifecycleData ();
		}


		string[] items;
		IDictionary<string, Java.Lang.Object> cData = new Dictionary<string, Java.Lang.Object> ();
		MediaSettings settings;


		protected override void OnCreate (Bundle bundle)
		{
			Config.SetContext (Application.Context);
			Config.DebugLogging = (Java.Lang.Boolean)true;

			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			cData.Add ("key1", "val1");


			items = new string[] { 
				"Version",
				"privacyStatus",
				"setPrivacyStatus - in",
				"setPrivacyStatus - out",
				"setPrivacyStatus - unknown",
				"lifetimeValue + 10",
				"userIdentifier",
				"setUserIdentifier - imBatman",
				"debugLogging",
				"setDebugLogging - true",
				"setDebugLogging - false",
				"setSmallIconResourceId",
				"setLargeIconResourceId",
				"overrideConfigStream",
				"TrackState",
				"trackAction",
				"trackLocation",
				"trackBeacon",
				"clearBeacon",
				"trackLifetimeValueIncrease",
				"trackTimedActionStart",
				"trackTimedActionUpdate",
				"trackTimedActionEnd",
				"trackTimedActionExists",
				"TrackingIdentifier",
				"getQueueSize",
				"clearQueue",
				"sendQueuedHits",
				//AAM
				"getDpuuid and getDpid",
				"VisitorProfile",
				"setDpidAndDpuuid",
				"signalWithData",
				"reset",
				//Target
				"targetRequest",
				"orderRequest",
				"clearCookies",
				"getPcID",
				"getSessionID",
				//VisitorID
				"getMarketingCloudId",
				"syncIdentifiers",
				//Media
				"createMediaSettings",
				"createAdSettings",
				"open",
				"close",
				"play",
				"complete",
				"stop",
				"click",
				"track"

			};

			ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, items);
		}

		protected override void OnListItemClick(ListView l, View v, int position, long id)
		{

			switch (position) {
			case 0:
				Android.Widget.Toast.MakeText(this, Config.Version, Android.Widget.ToastLength.Short).Show();
				break;
			case 1:
				Android.Widget.Toast.MakeText(this, Config.PrivacyStatus.ToString(), Android.Widget.ToastLength.Short).Show();
				break;
			case 2:
				Config.PrivacyStatus = MobilePrivacyStatus.MobilePrivacyStatusOptIn;
				break;
			case 3:
				Config.PrivacyStatus = MobilePrivacyStatus.MobilePrivacyStatusOptOut;
				break;
			case 4:
				Config.PrivacyStatus = MobilePrivacyStatus.MobilePrivacyStatusUnknown;
				break;
			case 5:
				Android.Widget.Toast.MakeText(this, Config.LifetimeValue.ToString(), Android.Widget.ToastLength.Short).Show();
				break;
			case 6:
				Android.Widget.Toast.MakeText(this, Config.UserIdentifier, Android.Widget.ToastLength.Short).Show();
				break;
			case 7:
				Config.UserIdentifier = "customUserIdentifier";
				break;
			case 8:
				Android.Widget.Toast.MakeText(this, Config.DebugLogging.ToString(), Android.Widget.ToastLength.Short).Show();
				break;
			case 9:
				Config.DebugLogging = (Java.Lang.Boolean)true;
				break;
			case 10:
				Config.DebugLogging = (Java.Lang.Boolean)false;
				break;
			case 11:
				Config.SetSmallIconResourceId (Resource.Drawable.Icon);
				break;
			case 12:
				Config.SetLargeIconResourceId (Resource.Drawable.Icon);
				break;
			case 13:
				Stream st = Assets.Open("ADBMobileConfig-Another.json");
				Config.OverrideConfigStream (st);
				break;
			case 14:
				var sd = new Dictionary<string, Java.Lang.Object> ();
				sd.Add ("key", (Java.Lang.Object)"value");

				Analytics.TrackState ("stateName", (IDictionary<string, Java.Lang.Object>)sd);
				break;
			case 15:
				Analytics.TrackAction ("actionName", cData);
				break;
			case 16:
				Location loc = new Location(LocationManager.GpsProvider);;
				loc.Latitude = 111;
				loc.Longitude = 44;
				loc.Accuracy = 5;

				Analytics.TrackLocation (loc, cData);
				break;
			case 17:
				Analytics.TrackBeacon ("UUID", "1", "2", Analytics.BEACON_PROXIMITY.ProximityImmediate, cData);
				break;
			case 18:
				Analytics.ClearBeacon ();
				break;
			case 19:
				Analytics.TrackLifetimeValueIncrease (new Java.Math.BigDecimal("1.11"), null);
				break;
			case 20:
				Analytics.TrackTimedActionStart ("timedAction", null);
				break;
			case 21:
				IDictionary<string, Java.Lang.Object> updateCData = new Dictionary<string, Java.Lang.Object> ();
				updateCData.Add ("key", "value");
				Analytics.TrackTimedActionUpdate ("timedAction", (IDictionary<string, Java.Lang.Object>)updateCData);
				break;
			case 22:
				Analytics.TrackTimedActionEnd ("timedAction", new TimedActionBlock());
				break;
			case 23:
				Android.Widget.Toast.MakeText(this, Analytics.TrackingTimedActionExists("timedAction").ToString(), Android.Widget.ToastLength.Short).Show();
				break;
			case 24:
				Android.Widget.Toast.MakeText(this, Analytics.TrackingIdentifier, Android.Widget.ToastLength.Short).Show();
				break;
			case 25:
				Android.Widget.Toast.MakeText(this, Analytics.QueueSize.ToString(), Android.Widget.ToastLength.Short).Show();
				break;
			case 26:
				Analytics.ClearQueue ();
				break;
			case 27:
				Analytics.SendQueuedHits ();
				break;
				// AAM
			case 28:
				Android.Widget.Toast.MakeText(this, AudienceManager.Dpuuid, Android.Widget.ToastLength.Short).Show();
				Android.Widget.Toast.MakeText(this, AudienceManager.Dpid, Android.Widget.ToastLength.Short).Show();
				break;
			case 29:
				Android.Widget.Toast.MakeText(this, AudienceManager.VisitorProfile!=null? AudienceManager.VisitorProfile.ToString():"", Android.Widget.ToastLength.Short).Show();
				break;
			case 30:
				AudienceManager.SetDpidAndDpuuid ("testDppid", "testDpuuid");
				break;
			case 31:
				IDictionary<string, Java.Lang.Object> traits = new Dictionary<string, Java.Lang.Object> ();
				traits.Add ("trait", "b");

				AudienceManager.SignalWithData (traits, new AudienceManagerCallback());
				break;
			case 32:
				AudienceManager.Reset ();
				break;
				//Target
			case 33:
				IDictionary<string, Java.Lang.Object> parameters = new Dictionary<string, Java.Lang.Object> ();
				parameters.Add ("key", "value");
				var req = Target.CreateRequest ("AndroidTest", "defGal", parameters);
				Target.LoadRequest (req, new TargetCallback());
				break;
			case 34:
				var orderConfirm = Target.CreateOrderConfirmRequest ("myOrder", "12345", "29.41", "cool stuff", null);
				Target.LoadRequest (orderConfirm,  new TargetCallback());
				break;
			case 35:
				Target.ClearCookies ();
				break;
			case 36:
				Android.Widget.Toast.MakeText(this, Target.PcID, Android.Widget.ToastLength.Short).Show();
				break;
			case 37:
				Android.Widget.Toast.MakeText(this, Target.SessionID, Android.Widget.ToastLength.Short).Show();
				break;
				//VisitorID
			case 38:
				Android.Widget.Toast.MakeText(this, Visitor.MarketingCloudId, Android.Widget.ToastLength.Short).Show();
				break;
			case 39:
				IDictionary<string, string> ids = new Dictionary<string, string> ();
				ids.Add ("pushID", "value2");
				Visitor.SyncIdentifiers (ids);
				break;
				//Media
			case 40:
				settings = Media.SettingsWith ("name1", 10, "playerName1", "playerID1");
				settings.Milestones = "25,50,75";
				break;
			case 41:
				MediaSettings adSettings = Media.AdSettingsWith ("adName1", 2, "playerName1", "name1", "podName1", 4, "CPM1");
				break;
			case 42:
				Media.Open (settings, new MediaCallback());
				break;
			case 43:
				Media.Close ("name1");
				break;
			case 44:
				Media.Play ("name1", 0);
				break;
			case 45:
				Media.Complete ("name1", 3);
				break;
			case 46:
				Media.Stop ("name1", 3);
				break;
			case 47:
				Media.Click ("adName1", 3);
				break;	
			case 48:
				Media.Track ("name1",null);
				break;
			
			}
		}
	}
}


