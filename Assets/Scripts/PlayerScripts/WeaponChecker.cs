using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WeaponChecker : MonoBehaviour
{
	public Text WeaponTag, button;
	
	void Update()
	{
		if (PlayerPrefs.GetString("WeaponTag") == WeaponTag.text)
		{
			button.text = "selected";
			button.color = Color.green;
		}

		if (PlayerPrefs.GetString("WeaponTag") != WeaponTag.text)
		{
			button.color = Color.white;
			button.text = "select";
		}
	}

	public void Select()
	{
		PlayerPrefs.SetString("WeaponTag", WeaponTag.text);
	}

}
