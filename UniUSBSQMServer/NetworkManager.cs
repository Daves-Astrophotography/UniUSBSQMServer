using System.Text;
using System.Net;
using System.Net.Sockets;
using UniUSBSQMServer.Enums;

namespace UniUSBSQMServer
{
    internal sealed class NetworkManager
    {
        private static NetworkManager? instance;
        private static readonly object syncRoot = new();
        public static NetworkManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new NetworkManager();
                    }
                }

                return instance;
            }
        }
        private NetworkManager()
        {
            
            settingsManager = SettingsManager.Instance;

            //Load Settings
            _serverPort = SettingsManager.ServerPort;
            settingsManager.SettingsChanged += SettingsManager_SettingsChanged;

            allDone = new ManualResetEvent(false);
        }

        private static SettingsManager? settingsManager;

        private static ServerRunningStates _serverState = ServerRunningStates.Stopped;
        private static int _serverPort = 10000;
        //private static string _serverIP = "127.0.0.1";
        string _serverLastMessage = "";
        private static int _clientCount = 0;

        private Task? backgroundServer;

        private CancellationTokenSource? tokenSource;
        private CancellationToken token;

        readonly ManualResetEvent allDone = new(false);
        Socket? listener;


        //Events
        public event EventHandler<NetworkManagerStateChangeEventArgs>? ManagerStateChanged;
        public event EventHandler<NetworkMessageReceivedEventArgs>? ServerMessageReceived;


        //Incoming Event Listener
        private void SettingsManager_SettingsChanged(object? sender, EventArgs e)
        {
            _serverPort = SettingsManager.ServerPort;
        }

       
        //Event Triggers
        private void TriggerStateChangeEvent()
        {
            NetworkManagerStateChangeEventArgs eventData = new()
            {
                ServerState = _serverState,
                ServerPort = _serverPort.ToString(),
                ClientCount = _clientCount            

            };

            ManagerStateChanged?.Invoke(this, eventData);
        }

        private void TriggerServerMessageReceived() 
        {
            NetworkMessageReceivedEventArgs eventData = new()
            {
                MessgageInfo = _serverLastMessage
            };

            ServerMessageReceived?.Invoke(this, eventData);
        }

        //Properties
        public static int ServerPort
        {
            get
            {
                return _serverPort;
            }

        }

        public static ServerRunningStates ServerState
        {
            get { return _serverState; }
            //private set { }
        }


        //Methods
        public void ServerStart()
        {
            if (_serverState == Enums.ServerRunningStates.Stopped)
            {
                _serverPort = SettingsManager.ServerPort;;

                tokenSource = new();
                token = tokenSource.Token;

                backgroundServer = new Task(StartNetworkServer, token);

                backgroundServer.Start();

                TriggerStateChangeEvent();
            }
        }

        public void ServerStop()
        {
            if (_serverState == Enums.ServerRunningStates.Running)
            {
                if (tokenSource != null)
                {
                    tokenSource.Cancel();
                }
                TriggerStateChangeEvent();
            }
        }

        private void CancelServer()
        {
            if (listener != null)
            {
                //callback by cancellation token
                if (listener.Connected)
                {
                    listener.Shutdown(SocketShutdown.Both);
                }

                listener.Close();
            }
            _serverState = Enums.ServerRunningStates.Stopped; 
            _clientCount = 0;
            TriggerStateChangeEvent();
        }

        private void StartNetworkServer()
        {
            if (instance == null) return;

            IPEndPoint localEndPoint = new(IPAddress.Any, _serverPort);

            System.Diagnostics.Debug.WriteLine("Opening listener...");
            _serverState = Enums.ServerRunningStates.Running; 
            TriggerStateChangeEvent();

            listener = new Socket(localEndPoint.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                listener.Bind(localEndPoint);
                listener.Listen();
                instance.token.Register(CancelServer);

                instance.token.ThrowIfCancellationRequested();

                while (!instance.token.IsCancellationRequested) 
                {
                    allDone.Reset();
                    System.Diagnostics.Debug.WriteLine("Waiting for connection...");
                    listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);

                    allDone.WaitOne();
                }

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
            finally
            {
                listener.Close();
            }

            System.Diagnostics.Debug.WriteLine("Closing listener...");
            _serverState = Enums.ServerRunningStates.Stopped; 
        }

        private static void AcceptCallback(IAsyncResult ar)
        {
            if (instance == null) return;
            try
            {
                //Client coonected
                _clientCount++;
                instance.TriggerStateChangeEvent();

                // Get the socket that handles the client request.  
                if (ar.AsyncState == null) return;

                Socket listener = (Socket)ar.AsyncState;

                Socket handler = listener.EndAccept(ar);


                // Signal the main thread to continue.  
                instance.allDone.Set();

                // Create the state object.  
                StateObject state = new();
                state.WorkSocket = handler;

                while (_serverState == Enums.ServerRunningStates.Running)
                {
                    if (state.WorkSocket.Available > 0)
                    {
                        handler.Receive(state.buffer);
                        state.sb.Clear();   //clear the stringbuilder
                        state.sb.Append(Encoding.UTF8.GetString(state.buffer)); //move the buffer into the string builder for processing
                        state.buffer = new byte[StateObject.BufferSize];    //clear the buffer ready for the next incoming message
                    }
                    if (state.sb.Length > 0)
                    {

                        int byteCountSent = 0;
                        string? latestMessage;
                        //Temporary Test Message Handlers
                        if (state.sb.ToString().StartsWith("ix")) //Encoding.UTF8.GetString(state.buffer)
                        {
                            instance._serverLastMessage = $"{state.WorkSocket.RemoteEndPoint}: ix";
                            instance.TriggerServerMessageReceived();


                            SQMLatestMessageReading.GetReading("ix", out latestMessage);
                            latestMessage += "\n";      //Add a line feed as this is getting stripped out somewhere!

                            byteCountSent = handler.Send(Encoding.UTF8.GetBytes(latestMessage), latestMessage.Length, SocketFlags.None);
                        }
                        if (state.sb.ToString().StartsWith("rx")) //
                        {
                            instance._serverLastMessage = $"{state.WorkSocket.RemoteEndPoint}: rx";
                            instance.TriggerServerMessageReceived();

                            SQMLatestMessageReading.GetReading("rx", out latestMessage);
                            latestMessage += "\n";

                            byteCountSent = handler.Send(Encoding.UTF8.GetBytes(latestMessage), latestMessage.Length, SocketFlags.None);
                        }
                        if (state.sb.ToString().StartsWith("ux")) //
                        {

                            instance._serverLastMessage = $"{state.WorkSocket.RemoteEndPoint}: ux";
                            instance.TriggerServerMessageReceived();


                            SQMLatestMessageReading.GetReading("ux", out latestMessage);
                            latestMessage += "\n";

                            byteCountSent = handler.Send(Encoding.UTF8.GetBytes(latestMessage), latestMessage.Length, SocketFlags.None);
                        }

                        Thread.Sleep(250);
                    }
                }
                //handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                //  new AsyncCallback(ReadCallback), state);
            }
            catch (SocketException ex)
            {

                System.Diagnostics.Debug.WriteLine($"Socket Error: {ex.ErrorCode}, {ex.Message}");

                //Info: https://docs.microsoft.com/en-us/dotnet/api/system.net.sockets.socketerror?view=net-6.0
                //10053 = The connection was aborted by .NET or the underlying socket provider.
                //
                if (instance != null)
                {
                    _clientCount--;
                    if (_clientCount < 0)
                    {
                        _clientCount = 0;
                    }

                    instance.TriggerStateChangeEvent();
                }
            }
            catch (ObjectDisposedException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                //catch and dump this when form is closing
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                throw;
                //left this for future unhandled conditions to see what might need changed.
            }
        }
        public class StateObject
        {
            public Socket? WorkSocket;
            public const int BufferSize = 1024;
            public byte[] buffer = new byte[BufferSize];
            public StringBuilder sb = new();
        }
    }
}
