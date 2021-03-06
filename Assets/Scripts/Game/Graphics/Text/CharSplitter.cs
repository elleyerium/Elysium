﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Graphics.Text
{
	public class CharSplitter : MonoBehaviour
	{
		private UnityEngine.UI.Text thisText;
		private RectTransform thisRect;
		public void SetSize ()
		{
			float upper = 0;
			thisRect = gameObject.GetComponent<RectTransform>();
			thisText = gameObject.GetComponent<UnityEngine.UI.Text>();
			string text = thisText.text;
			char[] array = new char[text.ToCharArray().Length];
			array = text.ToCharArray();
			//for (int i = 0; i < array.Length; i++)
			//{
			thisText.CalculateLayoutInputVertical();
			upper = thisText.preferredHeight;
			Debug.Log(upper);
			//}
			thisRect.sizeDelta = new Vector2(thisRect.sizeDelta.x, upper);
		}
	}
}

