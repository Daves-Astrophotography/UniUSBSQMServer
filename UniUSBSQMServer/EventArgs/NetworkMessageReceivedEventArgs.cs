
namespace UniUSBSQMServer
{
    public sealed class NetworkMessageReceivedEventArgs : EventArgs
    {
        public string MessgageInfo { get; set; } = String.Empty;

        public NetworkMessageReceivedEventArgs() : base() { }

    }
}
