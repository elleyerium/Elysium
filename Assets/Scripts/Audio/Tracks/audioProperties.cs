using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Audio.Tracks
{
	public class audioProperties : MonoBehaviour
	{
		public deviceMusicListing DeviceMusicListing;
		[SerializeField] private Text _name, _length;
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
		public void SetProperties (string trackName,List<string> list, int index, TimeSpan length)
		{
			thisIndex = index + 1 + musicController.alreadyIndex;
			var name = System.IO.Path.GetFileNameWithoutExtension(Path);
			_name.text = name.Length <= 30 ? name : name.Substring(0, 29) + "...";
			_length.text = $"{(int)length.TotalMinutes}:{length.Seconds:00}";
		}
	}
}
