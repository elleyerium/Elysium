using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Text;

public class ConnectMasterServer : MonoBehaviour 
{
    const int PORT_NO = 5000;
    const string SERVER_IP = "127.0.0.1";


    public static void Request(string request)
    {
        TcpClient server = new TcpClient(SERVER_IP, PORT_NO);
        NetworkStream nwStream = server.GetStream();
        byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(request);
        nwStream.Write(bytesToSend, 0, bytesToSend.Length);
        Debug.Log(request);
        //byte[] bytesToRead = new byte[server.ReceiveBufferSize];
        //nwStream.Read(bytesToRead, 0, bytesToRead.Length);
        //string receive = ASCIIEncoding.ASCII.GetString(bytesToRead);
        //Debug.Log(receive);
        //server.Close();
    }
}
