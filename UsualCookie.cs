namespace TheCookieBakery
{
	public class UsualCookie: ICookie
	{
		private readonly string _name;

		public UsualCookie()
		{
			_name = "cookie";
		}
		public string GetDescription()
		{
			return _name;
		}
	}
}