using System;
using Game.Difficult;
using Game.Online.Multiplayer.Lobby;
using UnityEngine;

namespace Game
{
    public class GameProvider : MonoBehaviour
    {
        public void SetGameProvider(GameType gameType, Room room)
        {
            IGameHost gameHost;
            /*switch (gameType)
            {
                case GameType.Offline:
                    gameHost = new GameHost();
                    gameHost.CreateHost(new BotDifficult(DifficultRate.Easy));
                    break;
                case GameType.Online:
                    gameHost = new GameHost();
                    gameHost.CreateHost(room);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(gameType), gameType, null);
            }*/
        }
    }
}