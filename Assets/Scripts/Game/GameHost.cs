using System;
using Game.Difficult;
using Game.Online.Multiplayer.Lobby;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game
{
    public class GameHost
    {
        private Room _room;
        private Online.Player _player;
        private BotDifficult _botDifficult;
        public GameType GameType;
        public GameContainer GameContainer;
        public GameObject ContainerPrefab;
        public Transform Parent;

        public GameHost(BotDifficult difficult, GameObject container) //Offline mode
        {
            ContainerPrefab = container;
            _botDifficult = difficult;
            _player = new Online.Player("Local player", 1, true);
            Initialize(GameType.Offline);
        }

        public GameHost(Room room, Online.Player player, GameObject container) //TODO: Mark room as closed (send request to the server); //Online mode
        {
            ContainerPrefab = container;
            _room = room;
            _player = player;
            Initialize(GameType.Online);
        }

        private void Initialize(GameType gameType)
        {
            var go = Object.Instantiate(ContainerPrefab);
            GameContainer = go.GetComponent<GameContainer>();
            switch (gameType)
            {
                case GameType.Offline:
                    GameContainer.ProvideOfflineContainer();
                    break;
                case GameType.Online:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(gameType), gameType, null);
            }
        }
    }

    public enum GameType
    {
        Offline,
        Online
    }
}