using System;

namespace WashingMachine.TestDoubles
{
	class LoggingMechanicalController : IMechanicalController
	{
		private string _log = string.Empty;

		public void SetOpenDoorIndicatorOff()
		{
			_log += "[OpenDoorIndicator=False]";
		}

		public void SetOpenDoorIndicatorOn()
		{
			_log += "[OpenDoorIndicator=True]";
		}

		public void LockDoor()
		{
			_log += "[DoorLocked=True]";
		}
		public void UnlockDoor()
		{
			_log += "[DoorLocked=False]";
		}

		public string GetLog()
		{
			return _log;
		}

		public void Wait(TimeSpan time)
		{
			_log += $"[Wait({time.TotalSeconds})]";
		}
	}
}