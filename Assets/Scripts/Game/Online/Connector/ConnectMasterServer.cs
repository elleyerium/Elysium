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

namespace Game.Online.Connector
{
    public class ConnectMasterServer : MonoBehaviour
    {
        public const int PORT_NO = 27015;
        public static bool IsConnected, Mentoried, idReceived;
        public const string SERVER_IP = "192.168.0.106";
        public static TcpClient Server = new TcpClient();
        private static ResponceReceiver _receiver;

        public static Task Connect()
        {
            try
            {
                Server.Connect(SERVER_IP, PORT_NO);
                Debug.Log(Server.Client.LocalEndPoint);
            }
            catch (Exception ex)
            {
                Debug.Log(ex);
                NotificationsCreator.NewNofication(TypeOfNofications.Warning.ToString(),
                    "Something wrong with your connection. Gonna try again in 30s.");
                Mentoried = true;
            }
            finally
            {
                if (Server.Connected)
                    IsConnected = true;
                if (!Server.Connected)
                    IsConnected = false;
                Debug.Log(IsConnected);
            }
            return null;
        }

        public static void Disconnect()
        {
            if (Server.Connected)
            {
                Server.Client.Disconnect(false);
                IsConnected = false;
                Debug.Log("Disconnected!");
            }
            //Server.Dispose();
        }
        public string Request(string tag, string data)
        {
            string Responce = String.Empty;
            if (!IsConnected)
            {
                Debug.Log("Is not connected");
            }
            try
            {
                NetworkStream nwStream = Server.GetStream();
                byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes($"{tag}|{data}");
                nwStream.Write(bytesToSend, 0, bytesToSend.Length);
                _receiver = new ResponceReceiver();
                Responce = _receiver.StartTask();
            }
            catch (Exception ex)
            {
                Debug.Log(ex.ToString());
            }
            return Responce;
        }
    }
}
