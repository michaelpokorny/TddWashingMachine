using System;
using WashingMachine.TestDoubles;

namespace WashingMachine
{
	internal class WashingMachine
	{
		private IMechanicalController _mechanicalController;

		public WashingMachine(IMechanicalController controller)
		{
			_mechanicalController = controller;
		}

		// internal void SetDoorClosed()
		// {
		// 	_doorClosed = true;
		// }

		// internal void SetDoorOpen()
		// {
		// 	_doorClosed = false;
		// }

		internal void Start()
		{
			if (GetDoorOpen())
				FlashOpenDoorIndicator();
			else
				Run();
		}

		private bool GetDoorOpen()
		{
			return _mechanicalController.GetDoorOpen();
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
			_mechanicalController.GetWater();
			_mechanicalController.UnlockDoor();
		}
	}
}