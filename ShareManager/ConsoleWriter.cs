using System;

namespace ShareManager
{
	public class ConsoleWriter
	{
		public void WriteShareEvent(Object sender, EventArgs args)
		{
			if (sender is Logic.Share share)
			{
				Console.WriteLine($"Name: {share.Name} Value: {share.CurrentValue:f}");
			}
		}
	}
}
