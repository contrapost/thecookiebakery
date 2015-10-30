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

			// This part of the code deals with multithreading.
			#region Multithreading
			// initialization of the araay of threads
			var threads = new Thread[_customers.Count + 1];

			// initialization of the bakery-thread
			threads[0] = new Thread(_bakery.MakeCookie);

			// initialization of customer-threads
            for (var i = 1; i < threads.Length; i++)
			{
				var index = i;
				threads[i] = new Thread(delegate () { _customers.ElementAt(index - 1).TryToBuy(_bakery); });
			}

			// start of the threads
			foreach (var t in threads)
			{
				t.Start();
			}

			// wait untill of threads are done
			foreach (var t in threads) {
				t.Join();
			}
			#endregion

			// Waits for the user to close the console.
			Pause(ConsoleColor.White);
		}

		/// <summary>
		/// Waits for the user to close the console. The color of the prompt can be changed.
		/// </summary>
		/// <param name="color">ConsoleColor of the final prompt</param>
		private static void Pause(ConsoleColor color)
		{
			Console.ForegroundColor = color; 
			Console.WriteLine("\nPress any key to close the bakery...");
			Console.ReadKey(true);
		}
	}
}