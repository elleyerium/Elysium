using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public class ConnectMasterServer : MonoBehaviour 
{
    public const int PORT_NO = 5000;
    public static bool IsConnected;
    public const string SERVER_IP = "192.168.0.106";


    public static string Request(string tag, string data)
    {
        TcpClient server = new TcpClient(SERVER_IP,PORT_NO);
        if (server.Connected)
            IsConnected = true;
        if (!server.Connected)
            IsConnected = false;
        string responce = null;
        try
        {
            NetworkStream nwStream = server.GetStream();
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes($"{tag}|{data}");
            nwStream.Write(bytesToSend, 0, bytesToSend.Length);
            responce = ResponceReceiver.GetResponce(server);
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
        }
        return responce;
    }
}
