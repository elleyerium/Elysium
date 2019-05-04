using System;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ResponceReceiver
    {       
        public static string GetResponce(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] bytesToRead = new byte[client.ReceiveBufferSize];
            stream.Read(bytesToRead, 0, bytesToRead.Length);
            string receive = Encoding.ASCII.GetString(bytesToRead);
            return receive;
        }       
    }
