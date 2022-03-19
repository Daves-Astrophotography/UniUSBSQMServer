using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniUSBSQMServer
{
    public sealed class SerialManagerStateChangedEventArgs : EventArgs
    {

        public Enums.SerialConnectedStates ConnectedState { get; set; }
        public string SerialPortName { get; set; } = String.Empty;
        public int SerialPortInterval { get; set; } = 10;

        public SerialManagerStateChangedEventArgs() : base() { }
    }
}
