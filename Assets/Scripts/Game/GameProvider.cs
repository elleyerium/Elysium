using System;
using Game.Difficult;
using Game.Online.Multiplayer.Lobby;
using UnityEngine;

namespace Game
{
    public class GameProvider : MonoBehaviour
    {
        public GameObject GameContainerPrefab;

        public void SetOnlineHost(Room room, Online.Player player)
        {
            var gamehost = new GameHost(room, player, GameContainerPrefab);
        }

        public void SetOfflineHost(BotDifficult difficult)
        {
            var gamehost = new GameHost(difficult, GameContainerPrefab);
        }
    }
}