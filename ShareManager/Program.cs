using System;

namespace ShareManager
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("ShareManager");

			Logic.Share share = new("MSFT", 100);
			Logic.Brocker brocker = new("Max", 90.0, 110);
			Logic.ShareHistory history = new Logic.ShareHistory("MSFT.csv");
			ConsoleWriter writer = new ConsoleWriter();

			share.OnValueChanged += writer.WriteShareEvent;
			share.OnValueChanged += brocker.ChangedValueHandler;
			share.OnValueChanged += history.ChangedValueHandler;
			share.Start();
			Console.ReadLine();
			share.OnValueChanged -= writer.WriteShareEvent;
			share.OnValueChanged -= brocker.ChangedValueHandler;
			share.OnValueChanged -= history.ChangedValueHandler;
			share.Stop();
		}
	}
}
