using System.Collections;
using UnityEngine;

namespace Game.Online.API.Requests
{
    public class APIConfigRequest : APIRequest
    {
        public APIConfigRequest(uint userId) : base($"/game_config{userId.ToString()}", RequestMethod.Get) //TODO: Config struct with properties
        {

        }
    }
}