using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Createroom : Photon.MonoBehaviour
{
    public Text RoomName;
    public Text textMax;
    [SerializeField]
    private Slider maxPlayers;
    private byte maxplayers;
    public static bool HostPlayer = false;
    void Update()
    {
        if (PhotonNetwork.inRoom)
        {
            PhotonNetwork.LoadLevel("deathmatch");
                //Initiate.Fade("deathmatch", Color.black, 2.0f);
        }

        maxplayers = (byte)maxPlayers.value;
        textMax.text = ("Max players : " + maxplayers);
        
    }

    public void CreateRoom()
    {
        HostPlayer = true;
        RoomOptions roomOptions = new RoomOptions()
        {
            IsVisible = true,
            IsOpen = true,
            MaxPlayers = maxplayers,

        };
        PhotonNetwork.JoinOrCreateRoom(RoomName.text, roomOptions, TypedLobby.Default);
        Debug.Log(roomOptions.MaxPlayers);
        


    }
}
