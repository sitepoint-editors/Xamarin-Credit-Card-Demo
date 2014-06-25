using System;
using MonoTouch.UIKit;
using Card.IO;
using Xamarin.Forms;
using CreditCardReader.iOS;

[assembly: Dependency (typeof (MyCardReader))]

namespace CreditCardReader.iOS
{
	public class MyCardReader : ICardReader
	{
		#region ICardReader implementation

		public Action<string> CardFound { get; set; }

		public void ReadCard ()
		{
			var appcontroller = UIApplication.SharedApplication.KeyWindow.RootViewController;

			var paymentDelegate = new PaymentViewControllerDelegate();
			var paymentViewController = new PaymentViewController(paymentDelegate);

			paymentViewController.CollectCVV = false;
			paymentViewController.CollectExpiry = false;
			paymentViewController.MaskManualEntryDigits = true;
			paymentViewController.AppToken = "e63c673c88c44b179dcbaa9f7a1f76af";

			paymentDelegate.OnScanCompleted += (viewController, cardInfo) => {
				if (cardInfo != null)
				{
					if (CardFound != null)
					{
						CardFound(cardInfo.CardNumber);
					}
				}	

				appcontroller.DismissViewController (true, null);
			};

			appcontroller.PresentViewController(paymentViewController, true, null);
		}

		#endregion
	}
}
