using System.Collections.Generic;

namespace TheCookieBakery
{
	class Program
	{
		public static void Main(string[] args)
		{
			// Initializing of a bakery object with the number of cookies to produce 
			// and production time in milliseconds
			var bakery = new TheBakery(21, 667);

			// Initializing of the time period for each attempt to get a cookie.
			// Now this value is common for all customers, but it can be set individualy
			// for each customer
			var waitingTime = 1000.0;

			// Initializing of customers with name and waiting time. 
			var fredTheCustomer = new Customer("Fred", waitingTime);
			var tedTheCustomer = new Customer("Ted", waitingTime);
			var gregTheCustomer = new Customer("Greg", waitingTime);

			// Uncomment next line and respective text in the line 31 to add Maggie as a customer.
			// var maggieTheCustomer = new Customer("Maggie", waitingTime); 

			// To add new cusomers initialize them with name and waitingTime and "put" them
			// into the list.

			var customers = new List<Customer>
			{
				fredTheCustomer, tedTheCustomer, gregTheCustomer /*, maggieTheCustomer */
			};

			// Initializing of a bakery controller object that proceed with multithreading
			// and visualization of the output.
			var bc = new BakeryController(bakery, customers);
			bc.Start();

		}
	}
}
