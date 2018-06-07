using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WashingMachine.TestDoubles;

namespace WashingMachine
{
	[TestClass]
	public class WashingMachineTest
	{
		private const string ODI_FLASHED = "[ODI=True][ODI=False]";

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
			_machine.Start();

			Assert.AreEqual(ODI_FLASHED, GetLog());
		}

		[TestMethod]
		public void DoorClosed_Start_DontFlashOdi()
		{
			_machine.SetDoorClosed();
			
			_machine.Start();

			Assert.AreNotEqual(ODI_FLASHED, GetLog());
		}

		[TestMethod]
		public void DoorLockedDuringRun()
		{
			_machine.SetDoorClosed();

			_machine.Start();

			StringAssert.Matches(GetLog(), new Regex(@"\[DoorLocked=True\]"));
		}

		private string GetLog()
		{
			return _mechanicalController.GetLog();
		}
	}
}
