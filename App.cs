using System;
using Xamarin.Forms;

namespace CreditCardReader
{
	public class App
	{
		public static string DBPath { get; set; }

		public static Page GetMainPage ()
		{	
			var database = new CardNumberDatabase (DBPath);

			var label = new Label { Text = "Card No:" };
			var cardEntry = new Entry { Placeholder = "" };
			var scanButton = new Button { Text = "Scan", TextColor = Color.White, BackgroundColor = Color.FromHex ("77D065") };

			scanButton.Clicked += (sender, e) => {
				var platformCardReader = DependencyService.Get<ICardReader>();
				if (platformCardReader != null)
				{
					platformCardReader.CardFound = delegate (string cardNo) {
						cardEntry.Text = cardNo;

						// db save
						var success = database.AddCardNumber (cardNo) == 1;

						var alerter = DependencyService.Get<IAlert>();
						if (alerter != null)
						{
							alerter.Show ("Database", success ? "Card Number Saved!" : "Failed!");
						}
					};

					platformCardReader.ReadCard();
				}
			};

			return new ContentPage { 
				Content = new StackLayout {
					Spacing = 20, Padding = 50,
					VerticalOptions = LayoutOptions.Center,
					Children = { label, cardEntry, scanButton }
				}
			};
		}
	}
}

