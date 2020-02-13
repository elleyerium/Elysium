using System.Collections;
using UnityEngine;

namespace Game.Online.API.Requests
{
    public class APISettingsRequest : APIRequest
    {
        public APISettingsRequest() : base("game_settings/", RequestMethod.Get)
        {

        }
    }
}