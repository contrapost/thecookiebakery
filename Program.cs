using System;
using System.Diagnostics;
using System.Threading;

namespace TheCookieBakery
{
	class Program
	{
		static readonly TheBakery Bakery = new TheBakery(20);
		static readonly Stopwatch Delay = new Stopwatch();

		public static void Main(string[] args)
		{
			Delay.Start();
			var fredTheCustomer = new Customer("Fred");
			var tedTheCustomer = new Customer("Ted");
			var gregTheCustomer = new Customer("Greg");

			var threads = new Thread[4];
			threads[0] = new Thread(Bakery.MakeCookie);
			threads[1] = new Thread(delegate () { TryToBuy(fredTheCustomer); });
			threads[2] = new Thread(delegate () { TryToBuy(tedTheCustomer); });
			threads[3] = new Thread(delegate () { TryToBuy(gregTheCustomer); });

			for (var i = 0; i < 4; i++)
			{
				threads[i].Start();
			}

			for (var i = 0; i < 4; i++) {
				threads[i].Join();
			}

			Pause();

		}
		private static void Pause()
		{
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine("\nPress any key to close the bakery...");
			Console.ReadKey(true);
		}

		private static void TryToBuy(Customer customer)
		{
			while (true)
			{
				if (Delay.ElapsedMilliseconds <= 950) continue;
				if (Bakery.BakeryIsClosed()) return;
				Bakery.SellCookieTo(customer);
				Delay.Restart();
			}
		}
	}
}
