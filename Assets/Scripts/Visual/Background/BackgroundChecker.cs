using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChecker : MonoBehaviour
{

	public Texture Emerald, Vertigonta, Aurora, BlueHorizon;
	public Material BackgroundMat;

	private void Awake()
	{
		if(!PlayerPrefs.HasKey("BackgroundName"))
			PlayerPrefs.SetString("BackgroundName","Vertigonta");	
		if(PlayerPrefs.GetString("BackgroundName") == "Aurora")
		BackgroundMat.SetTexture("_MainTex", Aurora);
		if(PlayerPrefs.GetString("BackgroundName") == "Emerald")
			BackgroundMat.SetTexture("_MainTex", Emerald);
		if(PlayerPrefs.GetString("BackgroundName") == "Vertigonta")
			BackgroundMat.SetTexture("_MainTex", Vertigonta);
		if(PlayerPrefs.GetString("BackgroundName") == "BlueHorizon")
			BackgroundMat.SetTexture("_MainTex", BlueHorizon);
	}
}
