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
		[SerializeField] private serverMusicListing serverMusicListing;
		[SerializeField] private MusicManager _musicManager;
		[SerializeField] private GameObject Name;
		public string Path { get; set; }
		private Button eventButton;
		private AudioSource musicSource;
		private int thisIndex;

		void Start()
		{
			_musicManager = FindObjectOfType<MusicManager>();
			eventButton = gameObject.GetComponent<Button>();
			eventButton.onClick.AddListener(() => SelectClip(Path));
			Debug.Log(thisIndex);
		}

		void SelectClip(string thisPath)
		{
			StartCoroutine(DeviceMusicListing.RequestSong(thisPath, true, thisIndex));
			Debug.Log("Clicked!");
		}
		public void SetProperties (string trackName,List<string> list, int index)
		{
			thisIndex =  musicController.alreadyIndex;
			Debug.Log(thisIndex);
			musicController.listedMusic.Add(list[index]);
			musicController.alreadyIndex++;
			Debug.Log(trackName);
			Name.GetComponent<Text>().text = System.IO.Path.GetFileNameWithoutExtension(Path);
		}
	}
}

