using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareManager.Logic
{
	class Share
	{
		public delegate void NotificationDelegate(Object sender, EventArgs args);

		private readonly int delay = 500;
		private volatile bool running = false;
		private static readonly Random random = new(DateTime.Now.Millisecond);
		private NotificationDelegate valueChangedHandler;
		public event NotificationDelegate OnValueChanged
		{
			add
			{
				valueChangedHandler += value;
			}
			remove
			{
				valueChangedHandler -= value;
			}
		}

		public string Name { get; init; }
		public double StartValue { get; init; }
		public double CurrentValue { get; private set; }
		public bool IsRunning => running;

		public Share(string name, double startValue)
		{
			Name = name;
			StartValue = CurrentValue = startValue < 0 ? 0 : startValue;
		}
		public void Start()
		{
			if (running == false)
			{
				System.Threading.Thread t = new(Run);

				t.IsBackground = true;
				t.Start();
			}
		}
		public void Stop() => running = false;

		private void Run()
		{
			running = true;
			while (running)
			{
				int sign = (int)(random.NextDouble() * 1000 % 2);
				double change = random.NextDouble() * 5;
				double changeValue = CurrentValue * change / 100;

				if (sign == 0)
				{
					CurrentValue += changeValue;
				}
				else
				{
					CurrentValue -= changeValue;
				}
				CurrentValue = Math.Max(0, CurrentValue);
				valueChangedHandler?.Invoke(this, EventArgs.Empty);
				System.Threading.Thread.Sleep(delay);
			}
		}
	}
}
