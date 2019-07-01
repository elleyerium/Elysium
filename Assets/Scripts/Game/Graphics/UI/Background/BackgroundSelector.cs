using System.Collections;
using System.Collections.Generic;
using  UnityEngine.UI;
using UnityEngine;

namespace Game.Graphics.UI.Background
{
	public class BackgroundSelector : MonoBehaviour
	{

		[SerializeField] private Texture BackSprite;
		public UnityEngine.UI.Text SelectText, Backname;

		public void  Select() =>
	    PlayerPrefs.SetString("BackgroundName", Backname.text);

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
}

