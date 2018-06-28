using System;

namespace WashingMachine.TestDoubles
{
	class LoggingMechanicalController : LoggingDouble, IMechanicalController
	{
		public LoggingMechanicalController(Action<string> log) : base(log)
		{
		}

		public void SetOpenDoorIndicatorOff()
		{
			Log("[OpenDoorIndicator=False]");
		}

		public void SetOpenDoorIndicatorOn()
		{
			Log("[OpenDoorIndicator=True]");
		}

		public void LockDoor()
		{
			Log("[DoorLocked=True]");
		}
		public void UnlockDoor()
		{
			Log("[DoorLocked=False]");
		}

		public void OpenWaterInjectionValve()
		{
			Log("[WaterInjectionValveOpened=True]");
		}

		public void CloseWaterInjectionValve()
		{
			Log("[WaterInjectionValveOpened=False]");
		}

		public void StartSpinningSlowly()
		{
			Log("[SpinSlowly=True]");
		}
	}
}