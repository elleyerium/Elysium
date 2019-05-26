﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NotificationsCreator : MonoBehaviour
{
	public static AudioSource Source;
	public static int CountOfNotifications;
	public Text CountText;
	public static Text StaticCountText;
	public Button ShowNofications, HideNotifications,DeleteNotifications;
	public GameObject Prefab, ui_all, ui_panel, EmptyAlert;
	public static GameObject PrefabInstance;
	public Transform parent;
	public static Transform transformInstance;
	private uiClickActions fader;
	private float DeletionDelay;
	private Lerping lerp;

	void Start()
	{
		lerp = gameObject.AddComponent<Lerping>();
	    fader = gameObject.AddComponent<uiClickActions>();
		fader.Panel = ui_all;
		CountOfNotifications = parent.childCount;
		transformInstance = parent;
		PrefabInstance = Prefab;
		StaticCountText = CountText;
		Source = gameObject.GetComponent<AudioSource>();
		StartCoroutine(Updater());
		Actions();
	}

	private IEnumerator Updater()
	{
		while (true)
		{
		    CountOfNotifications = parent.childCount;
		    CountText.text = CountOfNotifications.ToString();
			if (CountOfNotifications == 0)
				EmptyAlert.SetActive(true);
			else	
				EmptyAlert.SetActive(false);

			yield return new WaitForSeconds(0.1f);
	    }
    }
	void Actions()
	{
		ShowNofications.onClick.AddListener(() => fader.OnClickProfile());
		ShowNofications.onClick.AddListener(mainAction);
		DeleteNotifications.onClick.AddListener(() => DestroyNotifications());
	}
	void mainAction()
	{
		if (ui_panel.activeSelf)
		{
			ui_panel.SetActive(false);
			Debug.Log("Done, action is falseSetter");
			return;
		}
		if (!ui_panel.activeSelf)
		{
			ui_panel.SetActive(true);
			Debug.Log("Done, action is trueSetter");
		}
	}
	void DestroyNotifications()
	{
		Coroutine cor = null;
			for (int i = 0; i < transformInstance.transform.childCount; i++)
			{
				Debug.Log(true);
				Transform temp = transformInstance.transform.GetChild(i).gameObject.GetComponent<RectTransform>();
			    StartCoroutine(lerp.LerpAction(temp, 0, 1, 0.5f));
			}
	}
	public static void NewNofication(string Type, string Text)
	{
		Debug.Log($"{Type} {Text}");
		GameObject nofication = Instantiate(PrefabInstance);
		nofication.transform.SetParent(transformInstance);
		nofication.GetComponent<NotificationPrefab>().NoficationSettings(Type, Text);
		CountOfNotifications++;
		StaticCountText.text = transformInstance.childCount.ToString();
		Source.Play();
	}
}
