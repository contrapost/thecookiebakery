namespace TheCookieBakery
{
	class RaisinDecorator: CookieDecorator
	{
		public RaisinDecorator(ICookie cookie) : base(cookie)
		{
		}

		public override string GetDescription()
		{
			return base.GetDescription() + " with raisins";
		}
	}
}