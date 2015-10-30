/////////////////////////////////////////////////////////////////////////////////////////////////////
// 
// NOTE: ICookie interface, abstract class CookieDecorator and class UsualCookie that inherit from
//		 ICookie, classes AlmondDecorator, ChocolateDecorator and RaisinDecorator are parts of the
//		 decorator design pattern thar is used by TheBakery class to produce different cookies.
//		 To add a new cookie type make a new decorator class, change CookieTypes enum and ChooseCookie
//		 method in TheBakery class.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

namespace TheCookieBakery
{
	interface ICookie
	{
		string GetDescription();
	}
}