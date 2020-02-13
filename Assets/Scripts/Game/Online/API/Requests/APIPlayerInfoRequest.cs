using System.Collections;
using UnityEngine;

namespace Game.Online.API.Requests
{
    public class APIPlayerInfoRequest : APIRequest
    {
        public APIPlayerInfoRequest(string username) : base($"players(username='{username}')", RequestMethod.Get)
        {

        }
    }
}