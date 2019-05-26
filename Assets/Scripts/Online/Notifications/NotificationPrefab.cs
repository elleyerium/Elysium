using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationPrefab : MonoBehaviour
{
	public GameObject Type, NoficationText;
	public Sprite Warning_sprite, Info_sprite;
	public AudioClip DeleteFX;
	public void NoficationSettings(string NofType, string NofText)
	{
		switch (NofType)
		{
			case "Warning":
				Type.GetComponent<Image>().sprite = Warning_sprite;
				break;
			case "Info":
				Type.GetComponent<Image>().sprite = Info_sprite;
				break; 
		}
		NoficationText.GetComponent<Text>().text = NofText;
	}

	public void DeleteNotification()
	{
		Lerping Lerp = gameObject.AddComponent<Lerping>();
		NotificationsCreator.Source.PlayOneShot(DeleteFX);
		StartCoroutine(Lerp.LerpAction(transform,0,1,0.5f));
		if (NotificationsCreator.CountOfNotifications == 0)
		{
			
		}
	}
}
