using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TheCookieBakery
{
	public class BakeryController
	{
		private readonly TheBakery _bakery;
		private readonly List<Customer> _customers; 
		public BakeryController(TheBakery bakery, List<Customer> customers)
		{
			_bakery = bakery;
			_customers = customers;
		}

		public void Start()
		{
			// Can be used to change the title of the console and the text color.
			Gui.MakeGui("The Cookie Bakery", ConsoleColor.White);

			var threads = new Thread[_customers.Count + 1];

			threads[0] = new Thread(_bakery.MakeCookie);

            for (var i = 1; i < threads.Length; i++)
			{
				var index = i;
				threads[i] = new Thread(delegate () { _customers.ElementAt(index - 1).TryToBuy(_bakery); });
			}

			foreach (var t in threads)
			{
				t.Start();
			}

			foreach (var t in threads) {
				t.Join();
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
	}
}