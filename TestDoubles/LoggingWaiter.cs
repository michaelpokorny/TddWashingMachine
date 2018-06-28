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

		public void WaitForTrue(Func<bool> getValue)
		{
			Log($"[WaitForTrue({getValue.Method.Name})]");

		}

		public void WaitForWashingDrumToBeFilledWithWater()
		{
			Log("[WaitFor(WashingDrumFilledWithWater=True)]");
		}
	}
}