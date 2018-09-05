using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLayoutGroup : MonoBehaviour {
    [SerializeField]
    private GameObject _roomlistingPrefab;
    private GameObject Roomlistingprefab
    {
        get { return _roomlistingPrefab; }
    }
    private List<RoomListing> _roomListingButtons = new List<RoomListing>();
    private List<RoomListing> RoomListingButtons
    {
        get { return _roomListingButtons; }
    }

    private void OnReceivedRoomListUpdate()
    {
        RoomInfo[] rooms = PhotonNetwork.GetRoomList();
        foreach (RoomInfo room in rooms)
        {
            RoomReceived(room);
        }
    }
        private void RoomReceived(RoomInfo room)
    {
        int index = RoomListingButtons.FindIndex(x => x.RoomName == room.Name);
        if(index == -1)
        {
            if(room.IsVisible && room.PlayerCount < room.MaxPlayers)
            {
                GameObject roomListingObj = Instantiate(Roomlistingprefab);
                roomListingObj.transform.SetParent(transform, false);

                RoomListing roomlisting = roomListingObj.GetComponent<RoomListing>();
                RoomListingButtons.Add(roomlisting);

                index = (RoomListingButtons.Count - 1);
                 
            }
        }
        if(index != -1)
        {
            RoomListing roomListing = RoomListingButtons[index];
            roomListing.SetRoomNameText(room.Name);
            roomListing.Updated = true;
        }
    }
    private void RemoveOldRooms()
    {
        List<RoomListing> removeRooms = new List<RoomListing>();
        foreach (RoomListing roomListing in RoomListingButtons)
        {
            if (!roomListing.Updated)
                removeRooms.Add(roomListing);
            else
                roomListing.Updated = false;
        }
        foreach  (RoomListing roomListing in  removeRooms)
        {
            GameObject roomListingObj = roomListing.gameObject;
            RoomListingButtons.Remove(roomListing);
            Destroy(roomListingObj);
        }
    }


}
