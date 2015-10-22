namespace TheCookieBakery
{
	abstract class CookieDecorator: ICookie
	{
		private readonly ICookie _cookie;

		protected CookieDecorator(ICookie cookie)
		{
			_cookie = cookie;
		}
		public virtual string GetDescription()
		{
			return _cookie.GetDescription();
		}
	}
}