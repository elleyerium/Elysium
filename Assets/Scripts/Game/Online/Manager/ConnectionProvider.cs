using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Game.Online.Notifications;

namespace Game.Online.Manager
{
    public class ConnectionProvider : MonoBehaviour
    {
        public const int Port = 27015;
        public bool IsConnected, Mentioned;
        public const string ServerIp = "127.0.0.1";
        public TcpClient Server = new TcpClient();

        public async Task Connect()
        {
            try
            {
                await Server.ConnectAsync(ServerIp, Port);
                Debug.Log(Server.Client.LocalEndPoint);
            }
            catch (Exception ex)
            {
                Debug.Log(ex);
                NotificationsCreator.NewNotification(TypeOfNofications.Warning.ToString(),
                    "Something wrong with your connection. Gonna try again in 30s.");
                Mentioned = true;
            }
            finally
            {
                if (Server.Connected)
                    IsConnected = true;
                if (!Server.Connected)
                    IsConnected = false;
                Debug.Log(IsConnected);
            }
        }

        public void Disconnect()
        {
            if (Server.Connected)
            {
                Server.Client.Disconnect(false);
                IsConnected = false;
                Debug.Log("Disconnected!");
            }
        }

        public void SendData(byte[] buffer)
        {
            if (!IsConnected)
                return;
            try
            {
                var nwStream = Server.GetStream();
                nwStream.Write(buffer, 0, buffer.Length);
            }
            catch (Exception ex)
            {
                Debug.Log(ex.ToString());
            }
        }
    }
}
