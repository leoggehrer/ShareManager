using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
