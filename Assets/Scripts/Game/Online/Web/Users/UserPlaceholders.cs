using LiteNetLib.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Online.Web.Users
{
    public class UserPlaceholders : MonoBehaviour
    {

        public Text Username;
        public Text Score;
        public Text Rank;
        public Text SpacePoints;

        public void Init(string username, string score, string rank, string spacePoints)
        {
            Username.text = username;
            Score.text = $"Score: {score}";
            Rank.text = $"Rank: #{rank}";
            SpacePoints.text = $"SP: {spacePoints}";
        }
    }
}