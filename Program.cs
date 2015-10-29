using System;
using System.Diagnostics;
using System.Threading;

namespace TheCookieBakery
{
	class Program
	{

		static readonly TheBakery Bakery = new TheBakery(21, 667);
		static readonly Stopwatch Delay = new Stopwatch();

		public static void Main(string[] args)
		{
			Console.Title = "The Cookie Bakery";
			// starts the timer
			Delay.Start();

			// initialization of local variables
			var fredTheCustomer = new Customer("Fred");
			var tedTheCustomer = new Customer("Ted");
			var gregTheCustomer = new Customer("Greg");

			var threads = new Thread[4];
			threads[0] = new Thread(Bakery.MakeCookie);
			threads[1] = new Thread(delegate () { TryToBuy(fredTheCustomer); });
			threads[2] = new Thread(delegate () { TryToBuy(tedTheCustomer); });
			threads[3] = new Thread(delegate () { TryToBuy(gregTheCustomer); });

			// starts the threads
			for (var i = 0; i < 4; i++)
			{
				threads[i].Start();
			}

			// waits for the threads are done
			for (var i = 0; i < 4; i++) {
				threads[i].Join();
			}

			// waits for the user to close the console
			Pause();

		}

		/// <summary>
		/// To wait for the user to close the program
		/// </summary>
		private static void Pause()
		{
//			Console.ForegroundColor = ConsoleColor.DarkRed; // Uncomment to change the color 
															//of the final prompt
			Console.WriteLine("\nPress any key to close the bakery...");
			Console.ReadKey(true);
		}

		/// <summary>
		/// Each "customer"-thread has this method as main. The method waits in 950 milliseconds
		/// and calls the SellCookieTo method from TheBakery object if the instance of TheBakery object
		/// still has cookies or has to produce more cookies (checks by BakeryIsClosed method). 
		/// To ensure next attempt the method restarts the timer. 
		/// If there are no cookies and the bakery isn't producing more the methods writes to the console
		/// the amount of the cookies the customer has bought.
		/// </summary>
		/// <param name="customer">Concrete customer who tries to buy a cookie</param>
		private static void TryToBuy(Customer customer)
		{
			var count = 0;
			while (true)
			{
				if (Delay.ElapsedMilliseconds <= 950) continue;
				if (Bakery.BakeryIsClosed())
				{
					Console.WriteLine("\t\t " + customer.Name + 
						" has bought " + count + " cookies.");
					return;
				}
				if(Bakery.SellCookieTo(customer)) count++;
				Delay.Restart();
			}
		}
	}
}
