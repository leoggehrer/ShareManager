using System;

namespace ShareManager.Logic
{
	public class ShareValue
	{
		public string Name { get; init; }
		public DateTime DateTime { get; init; }
		public double Value { get; init; }

		public string ToCsv()
		{
			return $"{Name};{DateTime};{Value}";
		}
	}
}
