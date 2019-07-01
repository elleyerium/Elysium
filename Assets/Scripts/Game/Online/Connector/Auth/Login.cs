using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Online.Connector.Auth
{
	public class Login : MonoBehaviour
	{

		public Text text;
		public GameObject GameObject1;
		public static bool Logged;
		public static string Result;
		public static string LoginAction(string username, string password)
		{
			try
			{
				var Encrypted = Encryptor.EncryptString(Encryptor.DecryptKey, password);
				ConnectMasterServer connector = new ConnectMasterServer();
				Result = connector.Request(TypeOfTags.LoginRequest.ToString(), $"{username} {Encrypted}");
				//Result = ConnectMasterServer.Request(TypeOfTags.LoginRequest.ToString(), $"{username} {Encrypted}");
			}
			catch (Exception ex)
			{
				Debug.Log(ex.ToString());
			}
			return Result;
		}
	}
}

