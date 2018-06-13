using System;
using WashingMachine.TestDoubles;

namespace WashingMachine
{
	internal class WashingMachine
	{
		private bool _doorClosed;
		private IMechanicalController _mechanicalController;

		public WashingMachine(IMechanicalController controller)
		{
			_mechanicalController = controller;
		}

		internal void SetDoorClosed()
		{
			_doorClosed = true;
		}

		internal void Start()
		{
			if (!_doorClosed)
				FlashOpenDoorIndicator();
			else
				Run();
		}

		private void FlashOpenDoorIndicator()
		{
			_mechanicalController.SetOpenDoorIndicatorOn();
			_mechanicalController.Wait(TimeSpan.FromSeconds(1));
			_mechanicalController.SetOpenDoorIndicatorOff();
		}

		private void Run()
		{
			_mechanicalController.LockDoor();
			_mechanicalController.UnlockDoor();
		}
	}
}