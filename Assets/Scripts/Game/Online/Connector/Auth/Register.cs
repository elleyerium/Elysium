using UnityEngine;
using System;

namespace Game.Online.Connector.Auth
{
    public class Register : MonoBehaviour
    {
        public static void RegisterRequest(string username, string password, string email)
        {
            string pass;
            try
            {
                pass = Encryptor.EncryptString(Encryptor.DecryptKey, password);
                ConnectMasterServer connector = new ConnectMasterServer();
                var request = connector.Request(TypeOfTags.RegistrationRequest.ToString(), $"{username} {pass} {email}");
                Debug.Log(request);
            }
            catch (Exception ex)
            {
                Debug.Log(ex.ToString());
            }
        }
    }
}

