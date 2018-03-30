using Microsoft.VisualStudio.TestTools.UnitTesting;
using WashingMachine.TestDoubles;

namespace WashingMachine
{
    [TestClass]
    public class WashingMachineTest
    {
        private const string ODI_FLASHED = "[ODI=True][ODI=False]";

        LoggingDisplay _display;
        WashingMachine _machine;

        [TestInitialize]
        public void Initialize()
        {
            _display = new LoggingDisplay();
            _machine = new WashingMachine(_display);
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

        private string GetLog()
        {
            return _display.GetLog();
        }
    }
}
