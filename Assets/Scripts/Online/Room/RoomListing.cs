using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomListing : MonoBehaviour {
    [SerializeField]
    private Text _roomnametext;
    private Text Roomnametext
    {
    get {return _roomnametext;}

    }
    public string RoomName { get; private set;}
    public bool Updated { get; set; }
	void Start()
    {
        GameObject lobbyCanvasobj = MainCanvasManager.Instance.LobbyCanvas.gameObject;
        if (lobbyCanvasobj == null)
            return;
        LobbyCanvas lobbycanvas = lobbyCanvasobj.GetComponent<LobbyCanvas>();
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => lobbycanvas.OnClickJoinRoom(Roomnametext.text));
	}
    public void SetRoomNameText(string text)
    {
        RoomName = text;
        Roomnametext.text = RoomName;
    }
     
}
