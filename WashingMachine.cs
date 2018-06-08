using System;
using WashingMachine.TestDoubles;

namespace WashingMachine
{
	internal class WashingMachine
	{
		private bool _doorClosed;
		private IMechanicalController _display;

		public WashingMachine(IMechanicalController display)
		{
			_display = display;
		}

		internal void SetDoorClosed()
		{
			_doorClosed = true;
		}

		internal void Start()
		{
			if (!_doorClosed)
			{
				_display.SetOpenDoorIndicatorOn();
				_display.SetOpenDoorIndicatorOff();
			}
			else
			{
				_display.LockDoor();
				_display.UnlockDoor();
			}


		}
	}
}