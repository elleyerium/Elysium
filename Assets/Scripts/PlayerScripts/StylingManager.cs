using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StylingManager : MonoBehaviour
{

	public static bool Changewithmusic;
	public GameObject SkinsView, BackgroundView, WeaponsView;
	[SerializeField] private GameObject linepos;
	private Vector3 CurrentPos, NewPos;
	private bool IsMoving, NeedChange;
	public Text State;


	void Start()
	{
		if (PlayerPrefs.GetString("NeedToChange") == "false")
		{
			NeedChange = false;
			State.text = "-";
		}
		else
		{
			NeedChange = true;
			State.text = "+";
		}
	}

	public void ClickChecker()
	{
		if (NeedChange)
		{
			PlayerPrefs.SetString("NeedToChange", "false");
			State.text = "-";
			Debug.Log("Changed to -");
			NeedChange = false;
		}		
		 if(!NeedChange)
		{
			PlayerPrefs.SetString("NeedToChange", "true");
			State.text = "+";
			Debug.Log("Changed to +");
			NeedChange = true;
		}		
		Debug.Log(PlayerPrefs.GetString("NeedToChange"));
	}

	public void Skins()
	{
		IsMoving = true;
		linepos.transform.localPosition = new Vector3 (-418.3013f, 198.0004f);
		BackgroundView.SetActive(false); WeaponsView.SetActive(false); SkinsView.SetActive(true);
	}

	public void Backgrounds()
	{
		IsMoving = true;
		linepos.transform.localPosition =  new Vector3(-11.6f, 198.0004f);
		WeaponsView.SetActive(false); SkinsView.SetActive(false); BackgroundView.SetActive(true);
	}

	public void Weapons()
	{
		IsMoving = true;
		linepos.transform.localPosition = new Vector3(398.9f, 198.0004f);
		SkinsView.SetActive(false); BackgroundView.SetActive(false); WeaponsView.SetActive(true);
	}
}
