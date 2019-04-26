using UnityEngine;
using System;

namespace Auth
{
    public class Register : MonoBehaviour
    {
        public static void RegisterRequest(string username, string password, string email)
        {
            string DecryptKey = "a2V5Z2VuZXJhdG9y";
            string pass;
            try
            {
                pass = Encryptor.EncryptString(DecryptKey, password);
                ConnectMasterServer.Request($"{username} {pass} {email} ");
                Debug.Log($"{username} {pass} {email}");

            }
            catch (Exception ex)
            {
                Debug.Log(ex.ToString());
            }
        }
    }
}

