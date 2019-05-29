using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Visual.Media
{
	public class audioProperties : MonoBehaviour
	{
		public deviceMusicListing DeviceMusicListing;
		[SerializeField] private GameObject Name;
		public string Path { get; set; }
		public int Index { get; set; }
		private Button eventButton;
		private AudioSource musicSource;
		private int thisIndex;

		void Start()
		{
			eventButton = gameObject.GetComponent<Button>();
			eventButton.onClick.AddListener(() => SelectClip(Path));
		}

		void SelectClip(string thisPath)
		{
			musicController.position = thisIndex;
			StartCoroutine(DeviceMusicListing.RequestSong(thisPath, true, thisIndex));
			Debug.Log("Clicked!");
		}
		public void SetProperties (string trackName,List<string> list, int index)
		{
			thisIndex = index+1 + musicController.alreadyIndex;
			Name.GetComponent<Text>().text = System.IO.Path.GetFileNameWithoutExtension(Path);
		}
	}
}
