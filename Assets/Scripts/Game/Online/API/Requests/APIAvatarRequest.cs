using System.Collections;
using UnityEngine;

namespace Game.Online.API.Requests
{
    public class APIAvatarRequest : APIRequest
    {
        public APIAvatarRequest(string username) : base($"avatar(username='{username}')", RequestMethod.Get)
        {

        }
    }
}