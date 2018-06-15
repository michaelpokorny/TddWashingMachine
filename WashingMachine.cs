using System;
using WashingMachine.TestDoubles;

namespace WashingMachine
{
	internal class WashingMachine
	{
		private IMechanicalController _mechanicalController;
		private ISensorDataProvider _sensors;

		public WashingMachine(IMechanicalController controller, ISensorDataProvider sensors)
		{
			_mechanicalController = controller;
			_sensors = sensors;
		}

		internal void Start()
		{
			if (GetDoorOpen())
				FlashOpenDoorIndicator();
			else
				Run();
		}

		private bool GetDoorOpen()
		{
			return _sensors.GetDoorOpen();
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
			FillWashingDrumWithWater();
			_mechanicalController.UnlockDoor();
		}

		private void FillWashingDrumWithWater()
		{
			_mechanicalController.OpenWaterInjectionValve();
			_mechanicalController.WaitForWashingDrumToBeFilledWithWater();
		}
	}
}