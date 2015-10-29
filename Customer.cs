using System;
using System.Diagnostics;

namespace TheCookieBakery
{
	public class Customer
	{
		public string Name { get; }
		static readonly Stopwatch Delay = new Stopwatch();
		public double WaitingTime { get; }

		public Customer(string name, double waitingTime)
		{
			Name = name;
			WaitingTime = waitingTime;
            Delay.Start();
        }

		/// <summary>
		/// The method waits some time determined by user (milliseconds) and calls the SellCookieTo method
		/// from TheBakery object if the instance of TheBakery object still has cookies or has to produce 
		/// more cookies (checks by BakeryIsClosed method). 
		/// To ensure next attempt the method restarts the timer. 
		/// If there are no cookies and the bakery isn't producing more the methods writes to the console
		/// the amount of the cookies the customer has bought.
		/// </summary>
		/// <param name="bakery"></param>
		public void TryToBuy(TheBakery bakery)
		{
			var count = 0;
			while (true) {
				if (Delay.ElapsedMilliseconds <= WaitingTime) continue;
				if (bakery.BakeryIsClosed()) {
					Console.WriteLine("\t\t " + Name +
						" has bought " + count + " cookies.");
					return;
				}
				if (bakery.SellCookieTo(this)) count++;
				Delay.Restart();
			}
		}
	}
}