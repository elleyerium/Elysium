using Game.Graphics.UI.Screen.Window;
using Game.Online;
using Game.Online.Manager;
using LiteNetLib.Utils;
using UnityEngine;

namespace Game.Graphics.UI.Buttons
{
    public class WindowButtonHandler : MonoBehaviour
    {
        [SerializeField] private ConnectionProvider _connectionProvider;
        [SerializeField] private WebWindow _webWindow;
        [SerializeField] private MenuWindow _menuWindow;

        #region WebScreen

        public void SendChatMessage() => _connectionProvider.ChatHandler.SendMessage();

        public void ShowChatWindow() => _webWindow.ChangeWindow(WebWindowType.Chat);

        public void ShowUserInfoWindow()
        {
            _webWindow.ChangeWindow(WebWindowType.UserInfo);
            foreach (var id in _connectionProvider.ConnectedPeersId)
            {
                Debug.Log($"put {id}");
                var writer = new NetDataWriter();
                writer.Put(id);
                ConnectionProvider.SendMessage(MessageType.GetPlayerStats, writer);
            }
        }

        public void ShowEventsWindow() => _webWindow.ChangeWindow(WebWindowType.Events);

        public void ShowNewsWindow() => _webWindow.ChangeWindow(WebWindowType.News);

        #endregion

        #region MenuScreen

        public void ShowMainWindow() => _menuWindow.ChangeWindow(MenuWindowType.Main);

        public void ShowRankingWindow()
        {
            _menuWindow.ChangeWindow(MenuWindowType.Ranking);
        }

        public void ShowStylingWindow() => _menuWindow.ChangeWindow(MenuWindowType.Styling);

        public void ShowGameModeWindow() => _menuWindow.ChangeWindow(MenuWindowType.GameMode);

        public void ShowGameModeOfflineWindow() => _menuWindow.ChangeWindow(MenuWindowType.GameModeOffline);

        public void ShowGameModeOnlineWindow() => _menuWindow.ChangeWindow(MenuWindowType.GameModeOnline);

       #endregion
    }
}