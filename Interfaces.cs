using System;

namespace CreditCardReader
{
	public interface IAlert
	{
		void Show (string title, string message);
	}
	
	public interface ICardReader
	{
		Action<string> CardFound { get; set; }

		void ReadCard();
	}
}
