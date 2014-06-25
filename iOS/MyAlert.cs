using CreditCardReader.iOS;
using Xamarin.Forms;
using MonoTouch.UIKit;

[assembly: Dependency (typeof (MyAlert))]

namespace CreditCardReader.iOS
{
	public class MyAlert : IAlert
	{
		#region IAlert implementation

		public void Show (string title, string message)
		{
			var alert = new UIAlertView (title, message, null, "OK", null);
			alert.Show ();
		}

		#endregion
	}
}
