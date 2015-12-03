using System;
using TimesSquare.iOS;

#if __UNIFIED__
using Foundation;
using UIKit;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;

using ObjCRuntime = global::MonoTouch.ObjCRuntime;
#endif


namespace TimesSquareiOSSample
{
	public class TSQTAViewController : UIViewController
	{
		NSCalendar _calendar;
		public NSCalendar Calendar {
			get {
				return _calendar;
			}
			set {
				_calendar = value;
				NavigationItem.Title = Calendar.Identifier;
				TabBarItem.Title = Calendar.Identifier;
			} 
		}

		public override void LoadView ()
		{
			base.LoadView ();

			var onePixel = 1.0f / UIScreen.MainScreen.Scale;

			var calendarView = new TSQCalendarView () {
				Calendar = Calendar,
				RowCellClass = new ObjCRuntime.Class ("TSQTACalendarRowCell"),
				FirstDate = NSDate.Now,
				LastDate = NSDate.FromTimeIntervalSinceNow (60 * 60 * 24 * 365 * 5),
				BackgroundColor = UIColor.FromRGBA (0.84f, 0.85f, 0.86f, 1.0f),
				PagingEnabled = true,
				ContentInset = new UIEdgeInsets (0.0f, onePixel, 0.0f, onePixel)
			};

			calendarView.DidSelectDate += (sender, e) => {
				InvokeOnMainThread ( ()=> {
					var netDate = (DateTime) e.Date;
					new UIAlertView ("You selected", netDate.ToLongDateString(), null, "Ok", null).Show ();
				});
			};

			View = calendarView;
		}
	}
}

