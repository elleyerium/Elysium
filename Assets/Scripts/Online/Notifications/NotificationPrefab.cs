using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationPrefab : MonoBehaviour
{
	public GameObject Type, NoficationText;
	public Sprite Warning_sprite, Info_sprite;
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
		Destroy(gameObject);
		//NotificationsCreator.StaticCountText.text = NotificationsCreator.transformInstance.childCount - 1;
	}
}
