namespace WashingMachine.TestDoubles
{
	class LoggingMechanicalController : IMechanicalController
	{
		private string _log = string.Empty;

		public void SetOpenDoorIndicatorOff()
		{
			_log += "[ODI=False]";
		}

		public void SetOpenDoorIndicatorOn()
		{
			_log += "[ODI=True]";
		}

		public void LockDoor()
		{
			_log += "[DoorLocked=True]";
		}

		public string GetLog()
		{
			return _log;
		}
	}
}