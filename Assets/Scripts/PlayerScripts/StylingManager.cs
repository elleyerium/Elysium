using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StylingManager : MonoBehaviour
{

	public static bool Changewithmusic;
	public GameObject SkinsView, BackgroundView, WeaponsView;
	
	void Start () 
	{
	  if(Changewithmusic)
		  PlayerPrefs.SetString("NeedToChange", "true");
	}

	public void Skins()
	{
		BackgroundView.SetActive(false); WeaponsView.SetActive(false); SkinsView.SetActive(true);
	}

	public void Backgrounds()
	{
		WeaponsView.SetActive(false); SkinsView.SetActive(false); BackgroundView.SetActive(true);
	}

	public void Weapons()
	{
		SkinsView.SetActive(false); BackgroundView.SetActive(false); WeaponsView.SetActive(true);
	}
}
