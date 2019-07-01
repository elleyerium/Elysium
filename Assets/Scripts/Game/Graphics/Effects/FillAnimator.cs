using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Graphics.Effects
{
	public class FillAnimator : MonoBehaviour
	{
		public Image Filling;
		public float Time;
		private int MinAmount, MaxAmount;
		private bool back;

		void Start ()
		{
			back = false;
			MinAmount = 0;
			MaxAmount = 1;
			Filling.fillAmount = MinAmount;
			Filling.type = Image.Type.Filled;
			Filling.fillMethod = Image.FillMethod.Radial360;
		}

		void Update ()
		{
			if (!back)
			{
				Filling.fillClockwise = true;
				Filling.fillAmount += Time * UnityEngine.Time.deltaTime;
			}
			if (Filling.fillAmount == MaxAmount)
				back = true;

			if (Filling.fillAmount == MinAmount)
				back = false;

			if (back)
			{
				Filling.fillClockwise = false;
				Filling.fillAmount += -Time * UnityEngine.Time.deltaTime;
			}
		}
	}
}

