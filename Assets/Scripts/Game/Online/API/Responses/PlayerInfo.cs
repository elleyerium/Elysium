using Newtonsoft.Json;

namespace Game.Online.API.Responses
{
    public class PlayerInfo : APIResponse
    {
        [JsonProperty("username")]
        public string Username;

        [JsonProperty("rank")]
        public uint Rank;

        [JsonProperty("level")]
        public ushort Level;

        [JsonProperty("exp")]
        public ushort Exp;

        [JsonProperty("score")]
        public uint Score;

        [JsonProperty("space_points")]
        public ushort SpacePoints;
    }
}