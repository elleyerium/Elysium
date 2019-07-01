using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Audio.Effects
{
	public class SFXManager : MonoBehaviour
	{

		public AudioSource SFXSource;
		public AudioClip ClickUp, ClickBack;

		public void PlaySound(AudioClip clip) =>
			SFXSource.PlayOneShot(clip);

		public void ClickSound()
		{
			string ButtonTagName = EventSystem.current.currentSelectedGameObject.tag;
			Debug.Log(ButtonTagName);
			switch (ButtonTagName)
			{
				case "ClickUp":
					SFXSource.PlayOneShot(ClickUp);
					break;
				case "ClickBack":
					SFXSource.PlayOneShot(ClickBack);
					break;
			}
		}
	}
}

