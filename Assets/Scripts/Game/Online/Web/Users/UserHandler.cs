using System.Linq;
using Boo.Lang;
using Game.Online.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Online.Web.Users
{
    public class UserHandler : MonoBehaviour
    {
        [SerializeField] private GameObject _userPrefab;
        public Transform Parent;
        public List<User> Users = new List<User>();
        public Text Header;


        public void UpdateHeader(uint usersCount)
        {
            Header.text = $"online - {usersCount.ToString()}";
        }

        public void AddUser(User user)
        {
            if(Users.Any(x => x.Username == user.Username))
                return;
            Users.Add(user);
            var userObject = Instantiate(_userPrefab, Parent, true);
            var userPlaceholders = userObject.GetComponent<UserPlaceholders>();
            userPlaceholders.Init(user.Username, user.Score.ToString(), user.Rank.ToString(), user.SpacePoints.ToString());
        }

        public void UpdateUserState(User user)
        {

        }
    }
}