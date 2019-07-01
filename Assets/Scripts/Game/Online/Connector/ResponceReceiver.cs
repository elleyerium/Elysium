using System;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Online.Connector
{
    public class ResponceReceiver
    {
        public string StartTask()
        {
            return GetResponce();
        }
        public string GetResponce()
        {
            NetworkStream stream = ConnectMasterServer.Server.GetStream();
            byte[] bytesToRead = new byte[ConnectMasterServer.Server.ReceiveBufferSize];
            stream.Read(bytesToRead, 0, bytesToRead.Length);
            string receive = Encoding.ASCII.GetString(bytesToRead);
            return receive;
        }
    }
}
