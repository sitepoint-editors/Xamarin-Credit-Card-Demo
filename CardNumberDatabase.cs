using System;
using SQLite.Net;
using Xamarin.Forms;
using SQLite.Net.Interop;
using SQLite.Net.Attributes;

namespace CreditCardReader
{
	public class CreditCard
	{
		public CreditCard ()
		{
			Id = Guid.NewGuid ().ToString ();
		}

		[PrimaryKey]
		public string Id { get; set; }
		public string Number { get; set; }
	}

	public class CardNumberDatabase : SQLiteConnection
	{
		public CardNumberDatabase (string path) : base (DependencyService.Get<ISQLitePlatform>(), path, false, null)
		{
			CreateTable<CreditCard> ();
		}

		public int AddCardNumber (string number)
		{
			return Insert (new CreditCard { Number = number });
		}
	}
}

