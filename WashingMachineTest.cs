using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WashingMachine.TestDoubles;

namespace WashingMachine
{
	[TestClass]
	public class WashingMachineTest
	{
		private const string OPEN_DOOR_INDICATOR_FLASHED = "[OpenDoorIndicator=True][Wait(1)][OpenDoorIndicator=False]";
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
			OpenDoor();
			Run();

			StringAssert.Contains(GetLog(), OPEN_DOOR_INDICATOR_FLASHED);
		}

		[TestMethod]
		public void DoorClosed_Start_DontFlashOdi()
		{
			Run();

			Assert.AreNotEqual(OPEN_DOOR_INDICATOR_FLASHED, GetLog());
		}

		[TestMethod]
		public void DoorLockedDuringRun()
		{
			Run();

			StringAssert.StartsWith(GetLog(), "[DoorLocked=True]");
			StringAssert.EndsWith(GetLog(), "[DoorLocked=False]");
		}

		[TestMethod]
		public void DefaultProgramHasCorrectOrder() {
			Run();
			StringAssert.Contains(GetLog(), "[GetWater=True][WaitFor(WaterFilled=True)]");
		//  - Wasser einlassen
		// 	- Durchmischen(Drehen der Trommel mit niedriger Geschwindigkeit) [WaterIndicator=Full]
		// 	- Wasser abpumpen
		// 	- Schleudern(Drehen der Trommel mit hoher Geschwindigkeit)
		// - Die Maschine darf in keinen Zustand gelangen, der eine weitere zweckmäßige Verwendung verhindert bzw. schwierig macht
		}

		private string GetLog()
		{
			return _mechanicalController.GetLog();
		}

		private void Run()
		{
			_machine.Start();
		}

		private void OpenDoor()
		{
			_mechanicalController.SetDoorOpen();
		}
	}
}
