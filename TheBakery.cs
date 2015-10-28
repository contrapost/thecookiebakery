using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TheCookieBakery
{
	class TheBakery
	{

		private readonly Queue<ICookie> _basket;
		private readonly Queue<int> _numbers;
		private CookieType _cookieType;
		private readonly int _dailyProduction;
		private readonly Stopwatch _productionTime;
		private readonly object _cookieOnHold;
		private int _count;

		public TheBakery(int dailyProduction)
		{
			_basket = new Queue<ICookie>();
			_numbers = new Queue<int>();
			_cookieType = CookieType.Usual;
			_dailyProduction = dailyProduction;
			_productionTime = new Stopwatch();
			_productionTime.Start();
			_cookieOnHold = new object();
//			_count = 1;	// Uncomment it if you want to start numbering of cookies from 1 (not from 0)
						// NB! It will reduce the production by 1.
		}

		public void MakeCookie()
		{
			while (_count < _dailyProduction)
			{
				if (_productionTime.ElapsedMilliseconds <= 677) continue;
				var cookie = ChooseCookie();
				_basket.Enqueue(cookie);
				_numbers.Enqueue(_count);
				Console.WriteLine("Bakery made " + cookie.GetDescription() + " #" + _count);
				_count++;
				_productionTime.Restart();
			}
		}

	

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

		public bool SellCookieTo(Customer customer)
		{
				lock (_cookieOnHold) {
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
			return _basket.Count() == 0 && _count == _dailyProduction;
		}
	}
}