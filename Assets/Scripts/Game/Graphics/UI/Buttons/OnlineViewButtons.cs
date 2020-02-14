using Game.Online.Multiplayer.Lobby;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Graphics.UI.Buttons
{
    public class OnlineViewButtons : MonoBehaviour
    {
        [SerializeField] private Lobby _lobby;
        [SerializeField] private Button _createRoomButton;
        [SerializeField] private Button _leaveRoomButton;
        [SerializeField] private Button _joinRoomButton;

        private void Start()
        {
            //_createRoomButton.onClick.AddListener(() => _lobby.);
        }
    }
}