using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniUSBSQMServer
{
    public sealed class NetworkMessageReceivedEventArgs : EventArgs
    {
        public string MessgageInfo { get; set; } = String.Empty;

        public NetworkMessageReceivedEventArgs() : base() { }

    }
}
