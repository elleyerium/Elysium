using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class Skins : MonoBehaviour
{
	[SerializeField] private Text SkinName, SkinPrice;
	public int price;
	private bool IsAvailable;
	public GameObject Error_Log;

	public void Start()
	{
		if (PlayerPrefs.GetFloat("TotalScore") < price)
		{
			IsAvailable = (false);
			SkinPrice.text = "you need " + (price - PlayerPrefs.GetFloat("TotalScore")).ToString("2F") + " points more";
		}
		else
		{
			IsAvailable = (true);
			SkinPrice.text = "select skin";
		}
	}

	public void SetUpSkin()
	{

		if (IsAvailable)
		{
			PlayerPrefs.SetString("CurrentlySkin", SkinName.text);
			Debug.Log(PlayerPrefs.GetString("CurrentlySkin"));
		}
		else
		{
			GameObject Clone = Instantiate(Error_Log);
			Clone.transform.parent = GameObject.FindGameObjectWithTag("SkinsParent").transform;
			Clone.transform.localScale = new Vector3(1, 1, 1);
			var z = Clone.transform.position.z;
			z = -55;
			Destroy(Clone,8);
		}

	}

	void Update()
	{
		if (PlayerPrefs.GetString("CurrentlySkin") == SkinName.text)
		{
			SkinPrice.text = "selected";
			SkinPrice.color = Color.green;
		}
		if (PlayerPrefs.GetString("CurrentlySkin") != SkinName.text)
		{
			SkinPrice.color = Color.white;
			SkinPrice.text = "select";
		}
		if ((PlayerPrefs.GetFloat("TotalScore") < price))
	    SkinPrice.text = "you need " + (price - PlayerPrefs.GetFloat("TotalScore")) + " points more";
	}
}
