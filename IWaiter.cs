using System;

namespace WashingMachine
{
	public interface IWaiter
	{
		void Wait(TimeSpan time);
		void WaitForWashingDrumToBeFilledWithWater();
		void WaitForWashingDrumToBeEmptyOfWater();
	}
}