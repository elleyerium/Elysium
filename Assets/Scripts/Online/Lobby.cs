using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Lobby : Photon.MonoBehaviour {
    //public Toggle tvst, raid, survival;
    public Transform RoomParent;
    public GameObject RoomPrefabUI;
    void Awake()
    {
       PhotonNetwork.automaticallySyncScene = true;
    }
    void Update()
    {
        PhotonNetwork.GetRoomList();
        foreach (var item in PhotonNetwork.GetRoomList())
        {
           
        }
    }
    void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }
    void OnJoinedLobby()
    {
        Debug.Log("Joined lobby");
    }
    void OnCreatedRoom()
    {
        Debug.Log("room created");
    }
    
}
