using Packages.LiteNetLib.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Online.Web.Users
{
    public class UserPlaceholders : MonoBehaviour
    {

        public User User;
        public Text Username;
        public Text Score;
        public Text Rank;
        public Text SpacePoints;

        public void Init(User user, string username, string score, string rank, string spacePoints)
        {
            User = user;
            Username.text = username;
            Score.text = $"Score: {score}";
            Rank.text = $"Rank: #{rank}";
            SpacePoints.text = $"SP: {spacePoints}";
        }
    }
}