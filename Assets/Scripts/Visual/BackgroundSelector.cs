using System.Collections;
using System.Collections.Generic;
using  UnityEngine.UI;
using UnityEngine;

public class BackgroundSelector : MonoBehaviour
{

	[SerializeField] private Texture BackSprite;
	public Text SelectText, Backname;
	
	public void  Select() 
	{
		PlayerPrefs.SetString("BackgroundName", Backname.text);
		Backgroung.r.material.SetTexture("_MainTex", BackSprite );		
	}

	void Update()
	{
		
		if (PlayerPrefs.GetString("BackgroundName") == Backname.text)
		{
			SelectText.text = "selected";
			SelectText.color = Color.green;
		}

		if (PlayerPrefs.GetString("BackgroundName") != Backname.text)
		{
			SelectText.color = Color.white;
			SelectText.text = "select";
		}
	}
}
