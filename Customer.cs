namespace TheCookieBakery
{
	public class Customer
	{
		private readonly string _name;

		public Customer(string name)
		{
			_name = name;
		}

		public string GetName()
		{
			return _name;
		}
	}
}