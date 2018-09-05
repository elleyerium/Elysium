using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyCanvas:MonoBehaviour {
    [SerializeField]
    private RoomLayoutGroup _roomLayoutGroup;
    public RoomLayoutGroup RoomLayoutGroup
    {
        get { return _roomLayoutGroup; }
    }

    public void OnClickJoinRoom(string roomName)
    {

    }
}
