using System;
using System.IO;

namespace ShareManager.Logic
{
	public class ShareHistory
	{
		public string FilePath { get; init; }
		public ShareHistory(string filePath)
		{
			FilePath = filePath;
		}
		public void ChangedValueHandler(Object sender, EventArgs args)
		{
			if (sender is Share share)
			{
				if (File.Exists(FilePath) == false)
				{
					File.WriteAllText(FilePath, CreateShareValue(share).ToCsv());
				}
				else
				{
					using StreamWriter sw = File.AppendText(FilePath);

					sw.WriteLine(CreateShareValue(share).ToCsv());
				}
			}
		}


		private static ShareValue CreateShareValue(Share share)
		{
			return new ShareValue
			{
				Name = share.Name,
				DateTime = DateTime.Now,
				Value = share.CurrentValue,
			};
		}

	}
}