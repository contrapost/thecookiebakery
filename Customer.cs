using System;
using System.Diagnostics;

namespace TheCookieBakery
{
	public class Customer
	{
		public string Name { get; }
		// Common timer for all instance of the class
		static readonly Stopwatch Timer = new Stopwatch();
		public double WaitingTime { get; }

		/// <summary>
		/// Constructor initializes name of a customer and time that customer should wait before
		/// the next attempt to get a cookie.
		/// </summary>
		/// <param name="name">Sting that contains the name of customer</param>
		/// <param name="waitingTime">Double that determine the waiting time</param>
		public Customer(string name, double waitingTime)
		{
			Name = name;
			WaitingTime = waitingTime;
            Timer.Start();
        }

		/// <summary>
		/// The method waits some time determined by user (milliseconds) and calls the SellCookieTo method
		/// from TheBakery object if the instance of TheBakery object still has cookies or has to produce 
		/// more cookies (checks by BakeryIsClosed method). 
		/// To ensure next attempt the method restarts the timer. 
		/// If there are no cookies and the bakery isn't producing more the methods writes to the console
		/// the amount of the cookies the customer has bought.
		/// </summary>
		/// <param name="bakery">Instance of TheBakery class</param>
		public void TryToBuy(TheBakery bakery)
		{
			var count = 0;
			while (true) {
				if (Timer.ElapsedMilliseconds <= WaitingTime) continue;
				if (bakery.BakeryIsClosed()) {
					Console.WriteLine("\t\t " + Name +
						" has bought " + count + " cookies.");
					return;
				}
				if (bakery.SellCookieTo(this)) count++;
				Timer.Restart();
			}
		}
	}
}