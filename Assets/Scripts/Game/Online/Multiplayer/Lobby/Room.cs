using System.Collections.Generic;
using Game.Online.Manager;
using Packages.LiteNetLib.Utils;
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
            writer.Put(RoomName);
            writer.Put(Owner.Id);
            writer.Put(MinPlayers);
            writer.Put(MaxPlayers);
        }

        public void Deserialize(NetDataReader reader)
        {
            //Owner = writer.Put(RoomName);
            RoomName = reader.GetString();
            MinPlayers = reader.GetInt();
            MaxPlayers = reader.GetInt();
        }
    }
}