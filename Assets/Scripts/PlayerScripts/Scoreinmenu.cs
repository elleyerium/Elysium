using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.UI;

public class Scoreinmenu : MonoBehaviour
{
	public static Dictionary<string , Dictionary<string , int>> UserScores;
	public void Start()
	{
		UserScores = new Dictionary<string, Dictionary<string, int>>();
		UserScores["Elleyer"]["Score"] = 32323;
		UserScores["Elleyer"]["DateTime"] = Convert.ToInt32(System.DateTime.Now);
		
	}
}

