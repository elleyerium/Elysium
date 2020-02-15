using Game.Graphics.UI.Buttons;
using Game.Graphics.UI.Screen.Window;
using Game.Online.API;
using Game.Online.Manager;
using Game.Online.Multiplayer.Lobby;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Graphics.UI.Screen
{
    public class LobbyScreen : Screen
    {
        [SerializeField] private WindowButtonHandler _windowButtonHandler;
        [SerializeField] private ConnectionProvider _connectionProvider;
        [SerializeField] private APIManager _apiManager;
        [SerializeField] private Lobby _lobby;
        [SerializeField] private Button _createNewRoom;

        public void Start()
        {
            _createNewRoom.onClick.AddListener(() => _lobby.CreateRoom(new Room
            {
                MinPlayers = 2,
                MaxPlayers = 14,
                Owner = _connectionProvider.GetLocalPlayer(),
                RoomName = "Elleyer's awesome room"
            }));
        }
    }
}