using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Splash : MonoBehaviour
{
	public AudioSource startup;
	

	IEnumerator Start()
	{
		Debug.Log("Showing splash screen");
		SplashScreen.Begin();
		while (!SplashScreen.isFinished)
		{
			startup.Play();
			SplashScreen.Draw();
			yield return null;
		}
		Debug.Log("Finished showing splash screen");
	}
}
