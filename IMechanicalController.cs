namespace WashingMachine
{
	public interface IMechanicalController
	{
		void SetOpenDoorIndicatorOn();
		void SetOpenDoorIndicatorOff();
		void LockDoor();
		void UnlockDoor();
	}
}