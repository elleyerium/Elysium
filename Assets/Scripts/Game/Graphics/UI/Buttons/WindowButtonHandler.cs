using Game.Graphics.UI.Screen.Window;
using Game.Online;
using Game.Online.Manager;
using Game.Online.Web.Chat;
using Game.Online.Web.Users;
using LiteNetLib.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Graphics.UI.Buttons
{
    public class WindowButtonHandler : MonoBehaviour
    {
        [SerializeField] private ConnectionProvider _connectionProvider;
        [SerializeField] private WindowManager _windowManager;

        #region WebScreen

        public void SendChatMessage() => _connectionProvider.ChatHandler.SendMessage();

        public void ShowChatWindow() => _windowManager.ChangeWindow(WindowType.Chat);

        public void ShowUserInfoWindow()
        {
            _windowManager.ChangeWindow(WindowType.UserInfo);
            foreach (var id in _connectionProvider.ConnectedPeersId)
            {
                Debug.Log($"put {id}");
                var writer = new NetDataWriter();
                writer.Put(id);
                ConnectionProvider.SendMessage(MessageType.GetPlayerStats, writer);
            }
        }

        public void ShowEventsWindow() => _windowManager.ChangeWindow(WindowType.Events);

        public void ShowNewsWindow() => _windowManager.ChangeWindow(WindowType.News);

        #endregion
    }
}