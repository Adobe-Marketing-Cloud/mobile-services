using Foundation;
using UIKit;
using Com.Adobe.Mobile;

namespace tvOSSample
{
	[Register("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		public override UIWindow Window
		{
			get;
			set;
		}

		public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
		{
			// Adobe Mobile SDK - enable debug logging
			ADBMobile.SetDebugLogging(true);

			return true;
		}
	}
}

