using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Audio.Tracks
{
	public class musicController : MonoBehaviour
    {
	   [SerializeField] private deviceMusicListing DeviceMusicListing;
	   [SerializeField] private serverMusicListing ServerMusicListing;
	   [SerializeField] private MusicManager MusicManager;
	   [SerializeField] private Button[] actions;
	   public static List<string> listedMusic;
	   public static int alreadyIndex = -1;
	   public static int position;
	   public static bool devicemode;
	   public static string trackName = "Empty test";
	   [SerializeField] private RectTransform rect;
	   public float height = 820;
	   public float basic;
	   public float currently;
	   private bool lerped, moving;

	void Start ()
   	{
   		//DeviceMusicListing = gameObject.AddComponent<deviceMusicListing>();
   		currently = basic;
   		actions[0].onClick.AddListener(() => ServerLoad());
   		actions[1].onClick.AddListener(() => DeviceLoad());
   		actions[2].onClick.AddListener(() => List());
   		//rect = gameObject.GetComponent<RectTransform>();
   	}

	void ServerLoad()
	{

	}
	void DeviceLoad()
	{
		DeviceMusicListing.CallManager();
	}
	public void List()
	{
		if (!moving)
			StartCoroutine(Lerp(lerped));
		else
			Debug.Log("can't lerp");
	}
	IEnumerator Lerp(bool status)
	{
		currently = basic;
		status = lerped;
		if (!lerped && !moving)
			while (!status)
			{
					if (rect.rect.height < height)
					{
						var temp = Mathf.Lerp(currently, height, 3 * Time.fixedDeltaTime);
						currently += temp - currently;
						rect.sizeDelta = new Vector2(526, temp);
						moving = true;
					}
					yield return new WaitForFixedUpdate();
				if (rect.rect.height >= height - 10)
				{
					lerped = true;
					moving = false;
					yield break;
				}
			}
		if (lerped && !moving)
			while (status)
			{

	                var temp = Mathf.Lerp(height, currently, 3 * Time.fixedDeltaTime);
	 				currently = currently - temp;
					rect.sizeDelta = new Vector2(526, temp);
					moving = true;
					yield return new WaitForFixedUpdate();


				if (rect.rect.height <= basic)
				{
					lerped = false;
					moving = false;
					yield break;
				}
		    }
	    else if(moving) Debug.Log("Again, wait a bit!");
	    }
    }
}

