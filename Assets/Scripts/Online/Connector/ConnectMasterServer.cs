using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public class ConnectMasterServer : MonoBehaviour
{
    public const int PORT_NO = 27015;
    public static bool IsConnected, Mentoried;
    public const string SERVER_IP = "127.0.0.1";
    public static TcpClient Server = new TcpClient();

    public static Task Connect()
    {
        try
        {
            Server.Connect(SERVER_IP, PORT_NO);
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
        if  (Server.Connected)
            Server.Client.Disconnect(false);
        Server.Dispose();
    }
    public static string Request(string tag, string data)
    { 
        string responce = null;
        try
        {   if(!IsConnected)
            Connect();
            else
            {
                NetworkStream nwStream = Server.GetStream();
                byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes($"{tag}|{data}");
                nwStream.Write(bytesToSend, 0, bytesToSend.Length);
                responce = ResponceReceiver.GetResponce(Server);
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
        }
        return responce;
    }
}
