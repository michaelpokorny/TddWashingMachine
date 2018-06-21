using System;

namespace WashingMachine
{
	public interface IWaiter
	{
		void Wait(TimeSpan time);
		void WaitForWashingDrumToBeFilledWithWater();
		void WaitForTrue(Func<bool> getValue);
	}
}