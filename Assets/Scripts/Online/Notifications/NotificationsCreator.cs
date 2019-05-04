using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class NotificationsCreator : MonoBehaviour
{
	public static int CountOfNotifications;
	public Text CountText;
	public static Text StaticCountText;
	public Button ShowNofications, HideNotifications,DeleteNotifications;
	public GameObject Prefab, UI;
	public static GameObject PrefabInstance;
	public Transform parent;
	public static Transform transformInstance;

	void Start()
	{
		CountOfNotifications = parent.childCount;
		transformInstance = parent;
		PrefabInstance = Prefab;
		StaticCountText = CountText;
		StartCoroutine("Updater");
		Actions();
	}

	IEnumerator Updater()
	{
		while (true)
		{
		    CountOfNotifications = parent.childCount;
		    CountText.text = CountOfNotifications.ToString();
		    Debug.Log(CountOfNotifications);
		    yield return new WaitForSeconds(2);
	    }
    }

	void Actions()
	{
		ShowNofications.onClick.AddListener(() => UI.SetActive(true));
		HideNotifications.onClick.AddListener(() => UI.SetActive(false));
		DeleteNotifications.onClick.AddListener(() => Destroy(GameObject.FindWithTag("Notification")));
	}
	public static void NewNofication(string Type, string Text)
	{
		Debug.Log($"{Type} {Text}");
		GameObject nofication = Instantiate(PrefabInstance);
		nofication.transform.SetParent(transformInstance);
		nofication.GetComponent<NotificationPrefab>().NoficationSettings(Type, Text);
		CountOfNotifications++;
		StaticCountText.text = transformInstance.childCount.ToString();
	}
}
