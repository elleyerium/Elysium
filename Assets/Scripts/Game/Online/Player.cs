namespace Game.Online
{
    public class Player
    {
        public string Username { get; }
        public uint Id { get; } //TODO: List of players in ConnProvider;

        public Player(string username, uint id)
        {
            Username = username;
            Id = id;
        }
    }
}