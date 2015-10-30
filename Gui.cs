using System;

namespace TheCookieBakery
{
	class Gui
	{
		/// <summary>
		/// Set the title of the console and the color of the text.
		/// </summary>
		/// <param name="consoleTitle"></param>
		/// <param name="color"></param>
		public static void MakeGui(string consoleTitle, ConsoleColor color)
		{
			Console.Title = consoleTitle;
			Console.ForegroundColor = color;
		}

	}
}