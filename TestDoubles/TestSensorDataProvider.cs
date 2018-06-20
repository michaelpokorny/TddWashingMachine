namespace WashingMachine.TestDoubles
{
	internal class TestSensorDataProvider : ISensorDataProvider
	{
		private bool _doorOpen;

		public bool GetDoorOpen()
		{
			return _doorOpen;
		}

		internal void SetDoorClosed()
		{
			_doorOpen = false;
		}

		internal void SetDoorOpen()
		{
			_doorOpen = true;
		}

	}
}