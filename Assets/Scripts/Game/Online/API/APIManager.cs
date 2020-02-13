using System.Net;
using System;
using System.IO;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using Game.Online.API.Requests;
using Game.Online.API.Responses;
using Newtonsoft.Json;
using UnityEngine;
using Avatar = Game.Online.API.Responses.Avatar;

namespace Game.Online.API
{
    public class APIManager : MonoBehaviour, IAPIProvider
    {
        public const string Endpoint = "http://localhost:8153/api.rsc";

        public string AuthorizationHeader { get; } = "x-cdata-authtoken";

        public string SecretToken { get; set; } = "8h0G5v5j1X1t1k9X9z0d";


        private void Start()
        {
            //CreateWebRequest(APIRequestType.Avatar);
            CreateWebRequest(APIRequestType.PlayerInfo);
        }

        public void CreateWebRequest(APIRequestType apiRequestType, params string[] data)
        {
            try
            {
                APIRequest request;
                switch (apiRequestType)
                {
                    case APIRequestType.Avatar:
                        request = new APIAvatarRequest("elleyer");
                        request.APIRequestType = APIRequestType.Avatar;
                        break;
                    case APIRequestType.Config:
                        request = new APIConfigRequest(1337);
                        request.APIRequestType = APIRequestType.Config;
                        break;
                    case APIRequestType.Settings:
                        request = new APISettingsRequest();
                        request.APIRequestType = APIRequestType.Settings;
                        break;
                    case APIRequestType.PlayerInfo:
                        request = new APIPlayerInfoRequest("elleyer");
                        request.APIRequestType = APIRequestType.PlayerInfo;
                        break;
                    case APIRequestType.Leaderboards:
                        request = new APILeaderboardsRequest();
                        request.APIRequestType = APIRequestType.Leaderboards;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(apiRequestType), apiRequestType, null);
                }
                request.SetRequestHeader(AuthorizationHeader, SecretToken);
                StartCoroutine(SendRequest(request));
            }
            catch
            {
                // ignored
            }
        }

        private static IEnumerator SendRequest(APIRequest request)
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
                Debug.Log(request.url);
            }
            else
            {
                APIResponse type;
                switch (request.APIRequestType)
                {
                    case APIRequestType.Avatar:
                        type = request.Deserialize<Avatar>(request.downloadHandler.text);
                        break;
                    case APIRequestType.Config:
                        type = request.Deserialize<Avatar>(request.downloadHandler.text);
                        break;
                    case APIRequestType.Settings:
                        type = request.Deserialize<Avatar>(request.downloadHandler.text);
                        break;
                    case APIRequestType.PlayerInfo:
                        type = request.Deserialize<PlayerInfo>(request.downloadHandler.text);
                        type = (PlayerInfo)type;
                        break;
                    case APIRequestType.Leaderboards:
                        type = request.Deserialize<Leaderboards>(request.downloadHandler.text);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                Debug.Log(type.GetType().ToString());
                request.Dispose();
            }
        }
    }

    public enum APIRequestType
    {
        Avatar,
        Config,
        Settings,
        PlayerInfo,
        Leaderboards
    }
}