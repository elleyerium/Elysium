using System;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

namespace Game.Online.Statistics.Leaderboard
{
    public struct ScoresListing
    {
        public int id { get; set; }
        public string Username { get; set; }
        public int Score { get; set; }

        public ScoresListing(int ID, string username, int score)
        {
            id = ID;
            Username = username;
            Score = score;
        }
    }
}
