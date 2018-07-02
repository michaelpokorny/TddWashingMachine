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
				RunProgram();
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

		private void RunProgram()
		{
			_mechanicalController.LockDoor();
			FillWashingDrumWithWater();
			SpinSlowly();
			StartWaterPump();
			SpinFast();
			StopWaterPumpWhenDrumEmptyOfWater();
			_mechanicalController.UnlockDoor();
		}

		private void SpinFast()
		{
			_mechanicalController.StartSpinningFast();
			_waiter.Wait(TimeSpan.FromSeconds(60));
			_mechanicalController.StopSpinningFast();
		}
		
		private void FillWashingDrumWithWater()
		{
			_mechanicalController.OpenWaterInjectionValve();
			_waiter.WaitForWashingDrumToBeFilledWithWater();
			_mechanicalController.CloseWaterInjectionValve();
		}

		private void SpinSlowly()
		{
			_mechanicalController.StartSpinningSlowly();
			_waiter.Wait(TimeSpan.FromSeconds(600));
			_mechanicalController.StopSpinningSlowly();
		}

		private void StartWaterPump()
		{
			_mechanicalController.StartWaterPump();
		}

		private void StopWaterPumpWhenDrumEmptyOfWater()
		{
			_waiter.WaitForWashingDrumToBeEmptyOfWater();
			_mechanicalController.StopWaterPump();
		}

	}
}