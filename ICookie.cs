/////////////////////////////////////////////////////////////////////////////////////////////////////
// 
// NOTE: ICookie interface, abstract class CookieDecorator and class UsualCookie that inherit from
//		 ICookie, classes AlmondDecorator, ChocolateDecorator and RaisinDecorator are parts of the
//		 decorator design pattern thar is used by TheBakery class to produce different cookies.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

namespace TheCookieBakery
{
	interface ICookie
	{
		string GetDescription();
	}
}