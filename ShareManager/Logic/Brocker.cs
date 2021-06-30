using System;

namespace ShareManager.Logic
{
	public class Brocker
	{
		#region Fields
		private bool hasBuy = false;
		private double buyValue;
		#endregion Fields

		#region Properties
		public string Name { get; init; }
		public double PurchaseValue { get; init; }
		public double SaleValue { get; init; }
		public double GainOrLoss { get; private set; } = 0;
		public double CurrentGainOrLoss { get; private set; }
		#endregion Properties

		#region Event handler
		public void ChangedValueHandler(Object sender, EventArgs args)
		{
			if (sender is Share share)
			{
				if (hasBuy == false && share.CurrentValue <= PurchaseValue)
				{
					hasBuy = true;
					buyValue = share.CurrentValue;
				}
				else if (hasBuy && share.CurrentValue >= SaleValue)
				{
					hasBuy = false;
					GainOrLoss += share.CurrentValue - buyValue;
				}
				CurrentGainOrLoss = GainOrLoss;
				if (hasBuy)
				{
					CurrentGainOrLoss += share.CurrentValue - buyValue;
				}
				WriteGainOrLoss(Name, CurrentGainOrLoss);
			}
		}
		#endregion Event handler

		#region Methods
		public Brocker(string name, double purchaseValue, double saleValue)
		{
			Name = name;
			PurchaseValue = purchaseValue > 0 ? purchaseValue : 0;
			SaleValue = saleValue > 0 ? saleValue : 0;
		}
		private static void WriteGainOrLoss(string name, double gainOrLoss)
		{
			ConsoleColor saveColor = Console.ForegroundColor;

			if (gainOrLoss < 0)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"Name: {name} Verlust: {gainOrLoss:f}");
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine($"Name: {name} Gewinn:  {gainOrLoss:f}");
			}
			Console.ForegroundColor = saveColor;
		}
		#endregion Methods
	}
}
