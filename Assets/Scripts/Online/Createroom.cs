using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Createroom : Photon.MonoBehaviour {
    public Text RoomName;

    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 4 };
        PhotonNetwork.CreateRoom(RoomName.text, roomOptions, TypedLobby.Default);
    }


}
