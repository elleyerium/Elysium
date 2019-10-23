using System;
using System.IO;
using UnityEngine;

namespace Game.Online.Manager.Auth
{
    public class AuthProvider : MonoBehaviour
    {
        //1st byte
        public void LoginAction(string username, string password)
        {
            try
            {
                var encrypted = Encryptor.EncryptString(Encryptor.DecryptKey, password);
                using (var ms = new MemoryStream())
                {
                    using (var writer = new BinaryWriter(ms))
                    {
                        writer.Write((byte)1);
                        writer.Write(username);
                        writer.Write(encrypted);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Log(ex.ToString());
            }
        }

        //2nd byte
        public void RegisterRequest(string username, string password, string email)
        {
            try
            {
                var pass = Encryptor.EncryptString(Encryptor.DecryptKey, password);

                using (var ms = new MemoryStream())
                {
                    using (var writer = new BinaryWriter(ms))
                    {
                        writer.Write((byte)5);
                        writer.Write(username);
                        writer.Write(email);
                        writer.Write(pass);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Log(ex.ToString());
            }
        }
    }
}