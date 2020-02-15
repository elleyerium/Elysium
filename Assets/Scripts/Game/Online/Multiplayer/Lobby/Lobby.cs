using System.Collections.Generic;
using Game.Graphics.UI.Screen.Window;
using Game.Online.API;
using Game.Online.Manager;
using Packages.LiteNetLib.Utils;
using UnityEngine;
using Screen = Game.Graphics.UI.Screen.Screen;

namespace Game.Online.Multiplayer.Lobby
{
    public class Lobby : MonoBehaviour
    {
        public List<Room> Rooms = new List<Room>();
        public Room CurrentRoom;
        //public Window OwnerWindow, PlayerWindow;
        public GameProvider Provider;

        public void CreateRoom(Room room) //Create room request
        {
            var writer = new NetDataWriter();
            writer.Put(room); //Serialize room
            ConnectionProvider.SendMessage(MessageType.CreateRoom, writer);
            Rooms.Add(room);
        }

        public void CloseRoom(Room room)
        {
            Rooms.Remove(room);
            Debug.Log($"Room {room.RoomName} has been closed!");
        }

        public void LeaveRoom(Player player)
        {
            CurrentRoom.Leave(player);
        }

        public void JoinRoom(Room room)
        {
            if (room == CurrentRoom)
            {
                Debug.Log("Already joined");
                return;
            }

            CurrentRoom = room;
            Debug.Log("Joined!");
        }


        public void StartGame()
        {
            //Provider.SetGameProvider(GameType.Online);
        }
    }
}