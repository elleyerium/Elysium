using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net.Sockets;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

public class ConnectMasterServer : MonoBehaviour {

    private string UserID;
    static Socket socket;

    void Start()
    {
        Task listeningTask = new Task(ReceiveDataTask);
        listeningTask.Start();
        
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        
        IPEndPoint remotePoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 39999 );
        
        UserID = PlayerPrefs.GetString("username");
        try
        {
            byte[] buffer = Encoding.Unicode.GetBytes(UserID);
            socket.SendTo(buffer, remotePoint);
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
        finally
        {
            Debug.Log("Done");
        }
    }

    private static void ReceiveDataTask()
    {
        IPEndPoint Server = new IPEndPoint(IPAddress.Any, 27016);
        socket.Bind(Server);
        try
        {
            while (true)
            {
                StringBuilder GetDataFrom = new StringBuilder();
                int count = 0;
                byte[] bytesdata = new byte[1024];
                EndPoint ServerAdress = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 39999);
                do
                {
                    count = socket.ReceiveFrom(bytesdata, ref ServerAdress);
                    GetDataFrom.Append(Encoding.Unicode.GetString(bytesdata, 0, count));
                } while (socket.Available > 0);

                Debug.Log(GetDataFrom.ToString());               

            }
        }

        catch (Exception ex)
        {
            Debug.Log(ex);
        }
        finally
        {
            Debug.Log("Done");
        }
    }
}
