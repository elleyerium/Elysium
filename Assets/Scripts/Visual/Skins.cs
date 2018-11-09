using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class Skins : MonoBehaviour
{
	[SerializeField] private Image _materialship;
	[SerializeField] private Image _default;
	[SerializeField] private Image _bloodydarkness;
	[SerializeField] private Text SkinName;

	public void SetUpSkin()
	{
		PlayerPrefs.SetString("CurrentlySkin", SkinName.text);
		Debug.Log(PlayerPrefs.GetString("CurrentlySkin"));
	}
}
