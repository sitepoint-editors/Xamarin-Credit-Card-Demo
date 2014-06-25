
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinIOS;
using CreditCardReader.iOS;
using Xamarin.Forms;

[assembly: Dependency (typeof (MySqlite))]

namespace CreditCardReader.iOS
{
	public class MySqlite : ISQLitePlatform
	{
		#region ISQLitePlatform implementation

		public ISQLiteApi SQLiteApi	{ get {	return new SQLiteApiIOS(); } }

		public IStopwatchFactory StopwatchFactory { get { return new StopwatchFactoryIOS(); } }

		public IReflectionService ReflectionService { get { return new ReflectionServiceIOS(); } }

		public IVolatileService VolatileService { get {	return new VolatileServiceIOS(); } }

		#endregion
	}
}
