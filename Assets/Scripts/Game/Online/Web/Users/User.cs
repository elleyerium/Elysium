using LiteNetLib.Utils;

namespace Game.Online.Web.Users
{
    public class User : INetSerializable
    {
        public string Username;
        public uint Rank;
        public ushort Level;
        public ushort Exp;
        public uint Score;
        public ushort SpacePoints;

        public void Serialize(NetDataWriter writer)
        {
            throw new System.NotImplementedException();
        }

        public void Deserialize(NetDataReader reader)
        {
            Username = reader.GetString();
            Rank = reader.GetUInt();
            Level = reader.GetUShort();
            Exp = reader.GetUShort();
            Score = reader.GetUInt();
            SpacePoints = reader.GetUShort();
        }
    }
}