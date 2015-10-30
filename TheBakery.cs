using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TheCookieBakery
{
	public class TheBakery
	{
		public int DailyProduction { get; }  
		public double ProductionTime { get; } 							  
		private readonly Queue<ICookie> _basket;  // _basket and _numbers queues can be replaced 
		private readonly Queue<int> _numbers;	 // by Dictionary, but in this case the order of numbers 
												//  of cookies that are bought by customers can vary. 
		private CookieType _cookieType;
		private readonly Stopwatch _timer;
		private readonly object _lockBacket;
		private int _count;

		/// <summary>
		/// Constructor with initialization of the fields
		/// </summary>
		/// <param name="dailyProduction">int, amount of cookies that bakery should produce</param>
		/// <param name="productionTime">double, time that bakery needs to produce one cookie</param>
		public TheBakery(int dailyProduction, double productionTime)
		{
			_basket = new Queue<ICookie>();
			_numbers = new Queue<int>();
			_cookieType = CookieType.Usual;
			DailyProduction = dailyProduction;
			ProductionTime = productionTime;
			_timer = new Stopwatch();
			_timer.Start();
			_lockBacket = new object();
//			_count = 1;	// Uncomment it if you want to start numbering of cookies from 1 (not from 0)
						// NB! It will reduce the production amount by 1.
		}

		/// <summary>
		/// Makes cookies with delay (ProductionTime) untill the daily production is acheived.
		/// Uses ChooseCookie method to vary the cookie types.
		/// </summary>
		public void MakeCookie()
		{
			while (_count < DailyProduction)
			{
				if (_timer.ElapsedMilliseconds <= ProductionTime) continue;
				var cookie = ChooseCookie();
				_basket.Enqueue(cookie);
				_numbers.Enqueue(_count);
				Console.WriteLine("Bakery made " + cookie.GetDescription() + " #" + _count);
				_count++;
				_timer.Restart();
			}
		}

		/// <summary>
		/// Returns ICookie object of different types depends on previous type.
		/// </summary>
		/// <returns>ICookie</returns>
		private ICookie ChooseCookie()
		{
			ICookie cookie = new UsualCookie();
			switch (_cookieType) {
				case CookieType.Raisin:
					_cookieType = CookieType.Chocolate;
					return new RaisinDecorator(cookie);
				case CookieType.Chocolate:
					_cookieType = CookieType.Almond;
					return new ChocolateDecorator(cookie);
				case CookieType.Almond:
					_cookieType = CookieType.Usual;
					return new AlmondDecorator(cookie);
				default:
					_cookieType = CookieType.Raisin;
					return cookie;
			}
		}

		/// <summary>
		/// Remove the cookie (number and name) from queues and writes the name of a customer 
		/// who "gets" it with information about the cookie. The method uses a lock object to ensure
		/// that only one thread can execute the critical part of the code (i.e. only one customer
		/// can get a concrete cookie).
		/// </summary>
		/// <param name="customer">Instance of Customer object</param>
		/// <returns>True if customer "got" a cookie or false if not.</returns>
		public bool SellCookieTo(Customer customer)
		{
				lock (_lockBacket) {
					if (BasketIsEmpty()) return false;
					Console.WriteLine("\t\t\t" + customer.Name + " received " +
									  _basket.Dequeue().GetDescription() + " #" 
									  + _numbers.Dequeue());
					if (BakeryIsClosed()) Console.WriteLine("\n\t Checkout:");
					return true;
				}
		}

		public bool BasketIsEmpty()
		{
			return _basket.Count() == 0;
		}

		public bool BakeryIsClosed()
		{
			return _basket.Count() == 0 && _count == DailyProduction;
		}
	}
}