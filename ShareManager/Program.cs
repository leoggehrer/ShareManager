using System;

namespace ShareManager
{
	class Program
	{
		static void Main(/*string[] args*/)
		{
			Console.WriteLine("ShareManager");

			ConsoleWriter writer = new ();
			Logic.Share share = new("MSFT", 100);
			Logic.Brocker brocker = new("Max", 90.0, 110);
			Logic.ShareHistory history = new ("MSFT.csv");

			share.OnValueChanged += writer.WriteShareEvent;
			share.OnValueChanged += brocker.ChangedValueHandler;
			share.OnValueChanged += history.ChangedValueHandler;
			share.Start();
			_ = Console.ReadLine();
			share.OnValueChanged -= writer.WriteShareEvent;
			share.OnValueChanged -= brocker.ChangedValueHandler;
			share.OnValueChanged -= history.ChangedValueHandler;
			share.Stop();
		}
	}
}
