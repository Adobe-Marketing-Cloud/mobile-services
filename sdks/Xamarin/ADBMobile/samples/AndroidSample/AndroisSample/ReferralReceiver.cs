using System;
using Android.App;
using Android.Content;
using Com.Adobe.Mobile;

namespace AndroidSample
{

	[BroadcastReceiver]
	[IntentFilter(new[] { "com.android.vending.INSTALL_REFERRER" })]
	public class ReferralReceiver  : BroadcastReceiver
	{

		public override void OnReceive(Context context, Intent intent)
		{
			Analytics.ProcessReferrer(context, intent);
		}
	}
}

