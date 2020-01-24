using System;
using System.IO;
using LiteNetLib.Utils;
using UnityEngine;

namespace Game.Online.Manager.Auth
{
    public class AuthProvider : MonoBehaviour
    {
        [SerializeField] private ConnectionProvider _connectionProvider;

        [SerializeField] private LoginPage _loginPage;
        //1st byte

        private void Start()
        {
            _connectionProvider.Init(this);
        }

        public void LoginAction(string username, string password)
        {
            try
            {
                var encrypted = Encryptor.EncryptString(Encryptor.DecryptKey, password);
                var writer = new NetDataWriter();
                writer.Put((byte)1);
                writer.Put(username);
                writer.Put(encrypted);
                _connectionProvider.Connect(writer);
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
                var writer = new NetDataWriter();
                writer.Put((byte)2);
                writer.Put(username);
                writer.Put(pass);
                writer.Put(email);
                _connectionProvider.Connect(writer);
            }
            catch (Exception ex)
            {
                Debug.Log(ex.ToString());
            }
        }

        public void LogOut(string token)
        {
            using (var ms = new MemoryStream())
            {
                using (var writer = new BinaryWriter(ms))
                {
                    writer.Write((byte)1);
                    writer.Write((byte)3);
                    writer.Write(token);
                }
            }
        }
    }
}