using System;
using Game.Difficult;
using Game.Online.Multiplayer.Lobby;
using UnityEngine;

namespace Game
{
    public class GameHost
    {
        public void CreateHost(BotDifficult difficult)
        {
            //throw new NotImplementedException();
        }

        public void CreateHost(Room room) //TODO: Mark room as closed (send request to the server);
        {
            //var game
        }
    }

    public enum GameType
    {
        Offline,
        Online
    }
}