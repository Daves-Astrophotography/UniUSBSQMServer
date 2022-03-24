
namespace UniUSBSQMServer
{
    public sealed class SerialManagerDataReceivedEventArgs : EventArgs
    {

        public string Data { get; set; } = String.Empty;

        public SerialManagerDataReceivedEventArgs() : base() { }
    }
}