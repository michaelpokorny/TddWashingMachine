namespace WashingMachine.TestDoubles
{
	class LoggingDisplay : IDisplay
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

		public string GetLog()
		{
			return _log;
		}
	}
}