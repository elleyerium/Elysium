using System.Collections.Generic;
using Game.Online.Manager;
using LiteNetLib.Utils;
using UnityEngine;

namespace Game.Online.Multiplayer.Lobby
{
    public class Room : INetSerializable
    {
        public Player Owner;
        public string RoomName;
        public int MinPlayers;
        public int MaxPlayers;
        public List<Player> RoomPlayers = new List<Player>();

        public void Leave(Player player)
        {
            RoomPlayers.Remove(player);
        }

        public void Serialize(NetDataWriter writer)
        {
            throw new System.NotImplementedException();
        }

        public void Deserialize(NetDataReader reader)
        {
            //Owner =
        }
    }
}