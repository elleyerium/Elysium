using System;
using Game.Online.Manager;
using Game.Online.Users;
using LiteNetLib.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Online.Web.Chat
{
    public class ChatHandler : MonoBehaviour
    {
        public Transform LayoutGroup;
        [SerializeField] private GameObject _messagePrefab;
        [SerializeField] private InputField _textInput;

        public void ReceiveMessage(string username, string messageText, PlayerType playerType)
        {
            _textInput.text = string.Empty;
            var message = Instantiate(_messagePrefab, LayoutGroup).GetComponent<Message>();
            StartCoroutine(message.Init(username, messageText, playerType));
        }

        public void SendMessage()
        {
            var writer = new NetDataWriter();
            writer.Put(_textInput.text);
            ConnectionProvider.SendMessage(MessageType.SendChatMessage, writer);
        }
    }
}