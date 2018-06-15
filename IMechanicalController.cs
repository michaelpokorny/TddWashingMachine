using System;

namespace WashingMachine
{
	public interface IMechanicalController
	{
		void SetOpenDoorIndicatorOn();
		void SetOpenDoorIndicatorOff();
		void LockDoor();
		void OpenWaterInjectionValve();
		void UnlockDoor();

		void Wait(TimeSpan time);
		void WaitForWashingDrumToBeFilledWithWater();
	}
}