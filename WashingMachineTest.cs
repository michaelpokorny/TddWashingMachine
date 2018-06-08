using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WashingMachine.TestDoubles;

namespace WashingMachine
{
	[TestClass]
	public class WashingMachineTest
	{
		private const string ODI_FLASHED = "[ODI=True][ODI=False]";
		private readonly Regex _odiFlashPattern = new Regex(@"\[ODI=True\].*\[ODI=False\]");
		// in the future this needs to 
		// have a [SLEEP=1s] between flashes in order to make sure the lights are visibly flashed

		LoggingMechanicalController _mechanicalController;
		WashingMachine _machine;

		[TestInitialize]
		public void Initialize()
		{
			_mechanicalController = new LoggingMechanicalController();
			_machine = new WashingMachine(_mechanicalController);
		}

		[TestMethod]
		public void DoorOpen_Start_FlashOdi()
		{
			Run();

			StringAssert.Matches(GetLog(), _odiFlashPattern);
		}

		[TestMethod]
		public void DoorClosed_Start_DontFlashOdi()
		{
			CloseDoor();

			Run();

			Assert.AreNotEqual(ODI_FLASHED, GetLog());
		}

		[TestMethod]
		public void DoorLockedDuringRun()
		{
			CloseDoor();

			Run();

			StringAssert.StartsWith(GetLog(), "[DoorLocked=True]");
			StringAssert.EndsWith(GetLog(), "[DoorLocked=False]");
		}

		[TestMethod]
		public void asdf()
		{

		}

		private string GetLog()
		{
			return _mechanicalController.GetLog();
		}

		private void Run()
		{
			_machine.Start();
		}
		
		private void CloseDoor()
		{
			_machine.SetDoorClosed();
		}

	}
	
}
