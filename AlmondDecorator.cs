namespace TheCookieBakery
{
	class AlmondDecorator: CookieDecorator
	{
		public AlmondDecorator(ICookie cookie) : base(cookie)
		{
		}

		public override string GetDescription()
		{
			return base.GetDescription() + " with almonds";
		}
	}
}