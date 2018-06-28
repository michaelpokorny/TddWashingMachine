using System;

namespace WashingMachine.TestDoubles
{
	internal abstract class LoggingDouble
	{
		private Action<string> _log;

		public LoggingDouble(Action<string> log)
		{
			_log = log;
		}

		protected void Log(string message)
		{
			_log(message);
		}
	}
}