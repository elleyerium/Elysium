using System.Collections;
using UnityEngine;

namespace Game.Online.API.Requests
{
    public class APILeaderboardsRequest : APIRequest
    {
        public APILeaderboardsRequest() : base("/leaderboards", RequestMethod.Get)
        {

        }
    }
}