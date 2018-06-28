using System;

namespace WashingMachine.TestDoubles
{
	class LoggingMechanicalController : IMechanicalController
	{
		private Action<string> _log;

		public LoggingMechanicalController(Action<string> log)
		{
			_log = log;
		}

		public void SetOpenDoorIndicatorOff()
		{
			_log("[OpenDoorIndicator=False]");
		}

		public void SetOpenDoorIndicatorOn()
		{
			_log("[OpenDoorIndicator=True]");
		}

		public void LockDoor()
		{
			_log( "[DoorLocked=True]");
		}
		public void UnlockDoor()
		{
			_log("[DoorLocked=False]");
		}

		public void Wait(TimeSpan time)
		{
			_log($"[Wait({time.TotalSeconds})]");
		}

		public void WaitForWashingDrumToBeFilledWithWater()
		{
			_log("[WaitFor(WashingDrumFilledWithWater=True)]");
		}

		public void OpenWaterInjectionValve()
		{
			_log("[WaterInjectionValveOpened=True]");
		}

		public void CloseWaterInjectionValve()
		{
			_log("[WaterInjectionValveOpened=False]");
		}

		public void StartSpinningSlowly()
		{
			_log("[SpinSlowly=True]");
		} 
	}
}