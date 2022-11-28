

namespace UniUSBSQMServer
{
    public sealed class SimulatorDataReceivedEventArgs : EventArgs
    {
        public string Data { get; set; } = String.Empty;

        public SimulatorDataReceivedEventArgs() : base() { }

    }
}

