using System;
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
        private List<UserPlaceholders> _placeholders = new List<UserPlaceholders>();


        public void UpdateHeader(uint usersCount)
        {
            Header.text = $"online - {usersCount.ToString()}";
        }

        public void AddUser(User user)
        {
            if(Users.Any(x => x.Id == user.Id))
                return;
            Users.Add(user);
            var userObject = Instantiate(_userPrefab, Parent, true);
            userObject.transform.localScale = new Vector3(1,1,1);
            var userPlaceholders = userObject.GetComponent<UserPlaceholders>();
            _placeholders.Add(userPlaceholders);
            userPlaceholders.Init(user, user.Username, user.Score.ToString(), user.Rank.ToString(), user.SpacePoints.ToString());
        }

        public void RemoveUser(User user)
        {
            Users.Remove(user);
            var pHolder = _placeholders.FirstOrDefault(x => x.User == user);
            Destroy(pHolder.gameObject);
            _placeholders.Remove(pHolder);
        }

        public void UpdateUserState(User user, UserStare userStare)
        {
            switch (userStare)
            {
                case UserStare.Offline:
                    Users.Remove(user);
                    break;
                case UserStare.Online:
                    AddUser(user);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(userStare), userStare, null);
            }
        }
    }

    public enum UserStare
    {
        Offline,
        Online
    }
}