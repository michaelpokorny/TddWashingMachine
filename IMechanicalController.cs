using System;

namespace WashingMachine
{
	public interface IMechanicalController
	{
		void SetOpenDoorIndicatorOn();
		void SetOpenDoorIndicatorOff();
		void LockDoor();
		void UnlockDoor();
		void OpenWaterInjectionValve();
		void CloseWaterInjectionValve();
		void StartSpinningSlowly();
		void StopSpinningSlowly();
		void StartWaterPump();
	}
}