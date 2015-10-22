namespace TheCookieBakery
{
	class ChocolateDecorator: CookieDecorator
	{
		public ChocolateDecorator(ICookie cookie) : base(cookie)
		{
		}

		public override string GetDescription()
		{
			return base.GetDescription() + " with chocolate";
		}
	}
}