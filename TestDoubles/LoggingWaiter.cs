using System;

namespace WashingMachine.TestDoubles
{
	internal class LoggingWaiter : IWaiter
	{
		private Action<string> _log;

		public LoggingWaiter(Action<string> log)
		{
			_log = log;
		}

		public void Wait(TimeSpan time)
		{
			_log($"[Wait({time.TotalSeconds})]");
		}

		public void WaitForWashingDrumToBeFilledWithWater()
		{
			_log("[WaitFor(WashingDrumFilledWithWater=True)]");
		}
	}
}