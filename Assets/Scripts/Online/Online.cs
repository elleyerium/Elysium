//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Online : MonoBehaviour {
//    public GameObject Connecting, Connected, Disconnected;
//    public string versionName = "0.5";

//    private void Awake()
//    {
//        PhotonNetwork.ConnectUsingSettings(versionName);
//      //  Connected.SetActive(true);
//    }
//    private void OnConnectedToMaster()
//    {
//        PhotonNetwork.JoinLobby(TypedLobby.Default);
//    }
//    private void OnJoinedLobby()
//    {
//        Debug.Log("Joined!");
//        Connecting.SetActive(false);
//        Connected.SetActive(true);
//        Disconnected.SetActive(false);
//    }
//    private void OnDisconnectedFromPhoton()
//    {
//        if (Connecting.active)
//        {
//            Connecting.SetActive(false);
//        }
//        if (Connected.active)
//        {
//            Connected.SetActive(false);
//        }
//        Disconnected.SetActive(true);
//        PhotonNetwork.Reconnect();
       
//    }
//}
