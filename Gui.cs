using System;

namespace TheCookieBakery
{
	class Gui
	{
		public static void MakeGui(string consoleTitle, ConsoleColor color)
		{
			Console.Title = consoleTitle;
			Console.ForegroundColor = color;
		}

	}
}