using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Auth.Encryptor;

public class Login : MonoBehaviour
{

	public Text text;
	public GameObject GameObject1;
	public static string Result;
	public static string LoginAction(string username, string password)
	{
		try
		{
			var Encrypted = EncryptString(DecryptKey, password);
			Result = ConnectMasterServer.Request(TypeOfTags.LoginRequest.ToString(), $"{username} {Encrypted}");
		}
		catch (Exception ex)
		{
			Debug.Log(ex.ToString());
		}
		return Result;
	}
}
