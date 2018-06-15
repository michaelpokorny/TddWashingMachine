using System;

namespace WashingMachine
{
	public interface ISensorDataProvider
	{
		bool GetDoorOpen();
	}
}