using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace Game.Online.API.Requests
{
    public class APIRequest : UnityWebRequest, IAPIRequest
    {
        public string AdditionalPath { get; set; }
        public APIRequestType APIRequestType;

        protected APIRequest(string additionalPath, RequestMethod requestMethod) : base(string.Join("/",
            APIManager.Endpoint, additionalPath), requestMethod.ToString().ToUpper())
        {
            AdditionalPath = additionalPath;
            downloadHandler = new DownloadHandlerBuffer();
        }

        public T Deserialize<T>(string value)
        {
            Debug.Log(value);
            return JsonConvert.DeserializeObject<T>(value);
        }
    }

    public enum RequestMethod
    {
        Get,
        Post
    }
}