using System;
using Game.Graphics.UI.Screen;
using Game.Online.Manager.Auth;
using UnityEngine;
using LiteNetLib;
using LiteNetLib.Utils;
using Screen = Game.Graphics.UI.Screen.Screen;

namespace Game.Online.Manager
{
    public class ConnectionProvider : MonoBehaviour
    {
        private const string ServerIp = "127.0.0.1";
        private const int Port = 27015;
        public NetManager Client;
        private readonly EventBasedNetListener _listener = new EventBasedNetListener();
        private AuthScreen _authScreen;
        private bool _isConnected;

        public void Init(AuthProvider authProvider)
        {
            _authScreen = (AuthScreen)ScreenManager.Instance.GetScreen(ScreenType.AuthScreen);
            _authScreen.AuthProvider = authProvider;
        }

        private void Start()
        {
            _listener.NetworkReceiveEvent += (fromPeer, dataReader, deliveryMethod) =>
            {
                try
                {
                    switch ((MessageType)dataReader.GetByte())
                    {
                        case MessageType.AuthorizationResponse:
                            Debug.Log($"{dataReader.GetString()}");
                            break;
                        case MessageType.UserConnected:
                            Debug.Log($"connected name: {dataReader.GetString()}, id: {dataReader.GetUInt()}");
                            break;
                        case MessageType.UserDisconnected:
                            Debug.Log($"disconnected id: {dataReader.GetUInt()}");
                            break;
                        case MessageType.GetConcurrentUsersResponse:
                            Debug.Log("List of available players :");
                            var count = dataReader.GetUInt();
                            for (var i = 0; i < count; i++)
                            {
                                Debug.Log($"{dataReader.GetString()} / {dataReader.GetUInt()}");
                            }
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    dataReader.Recycle();
                }
                catch (Exception)
                {
                    // ignored
                }
            };

            _listener.PeerDisconnectedEvent += (peer, info) =>
            {
                Debug.Log($"{peer.EndPoint} just disconnected : {info.Reason}");
                Client.Stop();
            };

            _listener.PeerConnectedEvent += peer =>
            {
                _isConnected = true;
                Debug.Log("peer connected");
                ScreenManager.Instance.ChangeScreen(ScreenManager.Instance.GetScreen(ScreenType.MainScreen));
            };
        }

        public void Connect(NetDataWriter writer)
        {
            if (_isConnected)
                Disconnect(Client.FirstPeer);

            Client = new NetManager(_listener);
            Client.Start();
            Client.Connect(ServerIp /* host ip or name */, Port /* port */, writer /* text key or NetDataWriter */);
        }

        public void Disconnect(NetPeer peer)
        {
            peer.Disconnect();
        }

        #region SendMessage

        public void SendMessage(MessageType messageType, NetDataWriter writer)
        {
            var data = writer.CopyData();
            writer.Reset();
            writer.Put((byte)messageType);
            writer.Put(data);
            Client.FirstPeer.Send(writer, DeliveryMethod.ReliableOrdered);
        }

        #endregion

        private void Update()
        {
            if (Client == null || !Client.IsRunning)
                return;
            Client.PollEvents();
            if (UnityEngine.Input.GetMouseButtonDown(1))
            {
                SendMessage(MessageType.GetConcurrentUsers, new NetDataWriter());
            }
        }
    }
}
