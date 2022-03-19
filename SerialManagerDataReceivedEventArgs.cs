using System;

namespace UniUSBSQMServer
{
    public sealed class SerialManagerDataReceivedEventArgs : EventArgs
    {

        public string data { get; set; }

        public SerialManagerDataReceivedEventArgs() : base() { }
    }
}