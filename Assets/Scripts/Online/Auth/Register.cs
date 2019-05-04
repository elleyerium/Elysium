using UnityEngine;
using System;
using static Auth.Encryptor;

namespace Auth
{
    public class Register : MonoBehaviour
    {
        public static void RegisterRequest(string username, string password, string email)
        {    
            string pass;
            try
            {
                pass = EncryptString(DecryptKey, password);
                var request = ConnectMasterServer.Request(TypeOfTags.RegistrationRequest.ToString(), $"{username} {pass} {email}");
                Debug.Log(request);
            }
            catch (Exception ex)
            {
                Debug.Log(ex.ToString());
            }
        }
    }
}

