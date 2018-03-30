using System;
using WashingMachine.TestDoubles;

namespace WashingMachine
{
    internal class WashingMachine
    {
        private bool _doorClosed;
        private IDisplay _display;

        public WashingMachine(IDisplay display)
        {
            _display = display;
        }

        internal void SetDoorClosed()
        {
            _doorClosed = true;
        }

        internal void Start()
        {
            _display.SetOpenDoorIndicatorOn();

            if (!_doorClosed)
                _display.SetOpenDoorIndicatorOff();
        }
    }
}