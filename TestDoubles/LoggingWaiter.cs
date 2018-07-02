using System;

namespace WashingMachine.TestDoubles
{
	internal class LoggingWaiter : LoggingDouble, IWaiter
	{
		public LoggingWaiter(Action<string> log) : base(log)
		{
		}

		public void Wait(TimeSpan time)
		{
			Log($"[Wait({time.TotalSeconds})]");
		}

		public void WaitForWashingDrumToBeEmptyOfWater()
		{
			Log("[WaitFor(NoWaterInDrum=True)]");
		}

		public void WaitForWashingDrumToBeFilledWithWater()
		{
			Log("[WaitFor(WashingDrumFilledWithWater=True)]");
		}
	}
}