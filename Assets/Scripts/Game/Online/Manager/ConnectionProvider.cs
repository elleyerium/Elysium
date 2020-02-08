using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Game.Graphics.UI.Buttons;
using Game.Graphics.UI.Screen;
using Game.Online.Manager.Auth;
using Game.Online.Users;
using UnityEngine;
using LiteNetLib;
using LiteNetLib.Utils;
using Game.Online.Web;
using Game.Online.Web.Chat;
using Game.Online.Web.Users;
using Screen = Game.Graphics.UI.Screen.Screen;

namespace Game.Online.Manager
{
    public class ConnectionProvider : MonoBehaviour
    {
        public WindowButtonHandler WindowButtonHandler;
        public ChatHandler ChatHandler;
        public UserHandler UserHandler;
        private const string ServerIp = "127.0.0.1";
        private const int Port = 27015;
        private static NetManager _client;
        private readonly EventBasedNetListener _listener = new EventBasedNetListener();
        private AuthScreen _authScreen;
        private bool _isConnected;
        public List<uint> ConnectedPeersId = new List<uint>();
        public uint LocalId;

        public void Init(AuthProvider authProvider)
        {
            _authScreen = (AuthScreen)ScreenManager.Instance.GetScreen(ScreenType.AuthScreen);
            _authScreen.AuthProvider = authProvider;
        }

        private void Start()
        {
            _listener.NetworkReceiveEvent += (fromPeer, dataReader, deliveryMethod) =>
            {
                using (var writer = new NetDataWriter())
                {
                    try
                    {
                        switch ((MessageType)dataReader.GetByte())
                        {
                            case MessageType.AuthorizationResponse: //We got auth response
                                dataReader.GetString();
                                LocalId = dataReader.GetUInt();
                                Debug.Log(LocalId);
                                //SendMessage(MessageType.GetPlayerStats, new NetDataWriter());
                                //SendMessage(MessageType.GetAvatar, new NetDataWriter());
                                break;
                            case MessageType.UserConnected: //new user just connected
                                dataReader.GetString();
                                var connId = dataReader.GetUInt();
                                if(connId == LocalId)
                                    return;
                                writer.Put(connId);
                                SendMessage(MessageType.GetPlayerStats, writer);
                                //UserHandler.UpdateUserState(UserHandler.Users.FirstOrDefault(x => x.Id == connectedId), UserStare.Online);
                                break;
                            case MessageType.UserDisconnected: //user just disconnected
                                UserHandler.RemoveUser(
                                    UserHandler.Users.FirstOrDefault(x => x.Id == dataReader.GetUInt()));
                                UserHandler.UpdateHeader((uint)UserHandler.Users.Count);
                                break;
                            case MessageType.LeaderboardsResponse: //we got leaderboards response
                                break;
                            case MessageType.GetConcurrentUsersResponse: //we got concurrent users response
                                var count = dataReader.GetUInt();
                                UserHandler.UpdateHeader(count);
                                Debug.Log(count);
                                for (var i = 0; i < count; i++)
                                {
                                    var message = dataReader.GetUInt();
                                    //writer.Put(message);
                                    ConnectedPeersId.Add(message);
                                    //SendMessage(MessageType.GetPlayerStats, writer);
                                }
                                break;
                            case MessageType.UpdateProfileSettingsResponse: //We got UpdateProfileSettingsResponse response
                                break;
                            case MessageType.PlayerStatsResponse: //We got player stats response
                                var user = dataReader.Get<User>();
                                UserHandler.AddUser(user);
                                break;
                            case MessageType.GetAvatarResponse: //We got avatar response
                                break;
                            case MessageType.IncomingChatMessage: //We got incoming chat message
                                ChatHandler.ReceiveMessage(dataReader.GetString(), dataReader.GetString(),
                                    (PlayerType)Enum.Parse(typeof(PlayerType), dataReader.GetString()));
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
                    writer.Reset();
                    writer.Dispose();
                }
            };

            _listener.PeerDisconnectedEvent += (peer, info) =>
            {
                Debug.Log($"{peer.EndPoint} just disconnected : {info.Reason}");
                _client.Stop();
            };

            _listener.PeerConnectedEvent += peer =>
            {
                _isConnected = true;
                SendMessage(MessageType.GetConcurrentUsers, new NetDataWriter());
                Debug.Log("peer connected");
                //ScreenManager.Instance.ChangeScreen();
                ScreenManager.Instance.ChangeScreen(ScreenManager.Instance.GetScreen(ScreenType.MainScreen));
                WindowButtonHandler.ShowMainWindow();
            };
        }

        public void Connect(NetDataWriter writer)
        {
            if (_isConnected)
                Disconnect(_client.FirstPeer);

            _client = new NetManager(_listener);
            _client.Start();
            _client.Connect(ServerIp /* host ip or name */, Port /* port */, writer /* text key or NetDataWriter */);
        }

        public static void Disconnect(NetPeer peer)
        {
            peer.Disconnect();
        }

        #region SendMessage

        public static void SendMessage(MessageType messageType, NetDataWriter writer)
        {
            Debug.Log($"sent {messageType.ToString()}");
            var data = writer.CopyData();
            writer.Reset();
            writer.Put((byte)messageType);
            writer.Put(data);
            _client.FirstPeer.Send(writer, DeliveryMethod.ReliableOrdered);
        }

        #endregion

        private void Update()
        {
            if (_client == null || !_client.IsRunning)
                return;
            _client.PollEvents();
        }
    }
}
