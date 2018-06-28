using System;
using WashingMachine.TestDoubles;

namespace WashingMachine
{
	internal class WashingMachine
	{
		private IMechanicalController _mechanicalController;
		private ISensorDataProvider _sensors;
		private IWaiter _waiter;

		public WashingMachine(IMechanicalController controller, ISensorDataProvider sensors, IWaiter waiter)
		{
			_mechanicalController = controller;
			_sensors = sensors;
			_waiter = waiter;
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
			_waiter.Wait(TimeSpan.FromSeconds(1));
			_mechanicalController.SetOpenDoorIndicatorOff();
		}

		private void Run()
		{
			_mechanicalController.LockDoor();
			FillWashingDrumWithWater();
			_mechanicalController.StartSpinningSlowly();
			_mechanicalController.UnlockDoor();
		}

		private void FillWashingDrumWithWater()
		{
			_mechanicalController.OpenWaterInjectionValve();
			_mechanicalController.WaitForWashingDrumToBeFilledWithWater();
			_mechanicalController.CloseWaterInjectionValve();
		}
	}
}