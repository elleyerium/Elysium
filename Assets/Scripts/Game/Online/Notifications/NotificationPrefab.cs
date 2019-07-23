using System.Collections;
using System.Collections.Generic;
using Game.Graphics.Effects;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Online.Notifications
{
	public class NotificationPrefab : MonoBehaviour
	{
		public GameObject Type, NoficationText;
		[SerializeField] private Sprite Warning_sprite, Info_sprite;
		public AudioClip DeleteFX;

		public void NotificationSettings(string nofType, string nofText)
		{
			switch (nofType)
			{
				case "Warning":
					Type.GetComponent<Image>().sprite = Warning_sprite;
					break;
				case "Info":
					Type.GetComponent<Image>().sprite = Info_sprite;
					break;
			}
			NoficationText.GetComponent<Text>().text = nofText;
		}

		public void DeleteNotification()
		{
			Lerping Lerp = gameObject.AddComponent<Lerping>();
			NotificationsCreator.Source.PlayOneShot(DeleteFX);
			StartCoroutine(Lerp.LerpAction(transform,0,1,0.5f));
		}
	}
}
