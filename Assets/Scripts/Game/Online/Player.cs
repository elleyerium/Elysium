using System;

namespace Game.Online
{
    [Serializable]
    public class Player
    {
        public string Username { get; }
        public uint Id { get; } //TODO: List of players in ConnProvider;
        public bool IsLocal { get; }
        public Player(string username, uint id, bool isLocal)
        {
            Username = username;
            Id = id;
            IsLocal = isLocal;
        }
    }
}