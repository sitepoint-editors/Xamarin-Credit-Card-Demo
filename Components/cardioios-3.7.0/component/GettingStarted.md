
## Sign up for an App Token
Visit http://www.card.io and click `'Get an app token'`

Follow the registration process, confirm your registration by email, and you will have an App Token generated for you.


## Adding card.io to your iOS app

The most simple way to integrate card.io into your iOS app is to use the `PaymentViewController` just as you would any other UIViewController.  You will need to pass in an instance of `PaymentViewControllerDelegate` to the constructor so you can handle when a card is scanned, or the user has cancelled scanning.

```
// Create the delegate to handle events
var paymentDelegate = PaymentViewControllerDelegate();
paymentDelegate.OnScanCompleted += (viewController, cardInfo) => {

	if (cardInfo == null) {
		Console.WriteLine("Scanning Canceled!");
	} else {
		Console.WriteLine("Card Scanned: " + cardInfo.CardNumber);
	}	
	
	viewController.DismissViewController(true, null);
};

// Create and Show the View Controller
var paymentViewController = new PaymentViewController(paymentDelegate);

// Set the App Token - Use your own!
paymentViewController.AppToken = "YOUR-APP-TOKEN";

// Display the card.io interface
PresentViewController(paymentViewController, true);
```
