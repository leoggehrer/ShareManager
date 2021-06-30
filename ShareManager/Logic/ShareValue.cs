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

		public static ShareValue Create(string csv)
		{
			var result = default(ShareValue);
			var data = csv?.Split(";");

			if (data != null && data.Length == 3)
			{
				result = new ShareValue
				{
					Name = data[0],
					DateTime = DateTime.Parse(data[1]),
					Value = double.Parse(data[2]),
				};
			}
			return result;
		}
	}
}
