using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniUSBSQMServer
{
    internal class NetworkManagerStateChangeEventArgs : EventArgs
    {
        public Enums.ServerRunningStates ServerState { get; set; }
        public string ServerPort { get; set; } = "10001";
        public string ServerIP { get; set; } = String.Empty;
        public int ClientCount { get; set; } = 0;

        public NetworkManagerStateChangeEventArgs() : base() { }

    }
}
