using System.Collections.Generic;

namespace TheCookieBakery
{
	class Program
	{
		public static void Main(string[] args)
		{
			// Initializing of a bakery object with the number of cookies to produce 
			// and production time per cookie in milliseconds.
			// NOTE: Production time should be smaller than the time that customer waits before attempt
			// to get a cookie (se next comment).
			var bakery = new TheBakery(21, 667);

			// Initializing of the time period that customer should wait before attempt to get a cookie.
			// Now this value is common for all customers, but it can be set individualy
			// when initializing a concrete customer. 
			const double waitingTime = 1000.0;

			// Initializing of customers with name and waiting time. 
			// To add new cusomers initialize them with name and waitingTime and "put" them
			// into the list in line 30.
			var fredTheCustomer = new Customer("Fred", waitingTime);
			var tedTheCustomer = new Customer("Ted", waitingTime);
			var gregTheCustomer = new Customer("Greg", waitingTime);

			// Uncomment next line and respective text in the line 32 to add Maggie as a customer.
			// var maggieTheCustomer = new Customer("Maggie", waitingTime); 

			var customers = new List<Customer>
			{
				fredTheCustomer, tedTheCustomer, gregTheCustomer /*, maggieTheCustomer */
			};

			// Initializing of a bakery controller object that proceeds with multithreading
			// and visualization of the output.
			var bc = new BakeryController(bakery, customers);
			bc.MakeItWork();
		}
	}
}
