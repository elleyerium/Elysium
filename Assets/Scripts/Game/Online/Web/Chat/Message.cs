using System;
using System.Collections;
using Game.Online.Users;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Online.Web.Chat
{
    public class Message : MonoBehaviour
    {
        public Text TimeStamp;
        public Text Username;
        public Text MessageText;

        public IEnumerator Init(string username, string message, PlayerType playerType)
        {
            var dt = DateTime.Now;

            TimeStamp.text = $"{dt:HH:mm}";
            Username.text = $"{username}:";

            switch (playerType)
            {
                case PlayerType.Administrator:
                    Username.color = Color.yellow;
                    break;
                case PlayerType.Moderator:
                    Username.color = Color.green;
                    break;
                case PlayerType.Player:
                    Username.color = Color.cyan;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(playerType), playerType, null);
            }

            MessageText.text = message;
            var messageRect = MessageText.rectTransform;
            var usernameRect = Username.rectTransform;

            yield return null;

            var res = usernameRect.sizeDelta.x + usernameRect.anchoredPosition.x + 20;
            messageRect.anchoredPosition = new Vector2(res, messageRect.sizeDelta.y);
            messageRect.sizeDelta = new Vector2(messageRect.sizeDelta.x - usernameRect.sizeDelta.x + 100, messageRect.sizeDelta.y);
        }
    }
}