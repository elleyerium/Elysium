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
		[SerializeField] private GameObject length;
		public string TrackName { get; set; }
		public string TrackLength { get; set; }
		public AudioClip trackToPlay;
		private Button eventButton;
		private AudioSource musicSource;
		private int thisIndex;

		void Start()
		{
			_musicManager = FindObjectOfType<MusicManager>();
			eventButton = gameObject.GetComponent<Button>();
			eventButton.onClick.AddListener(() => SelectClip(trackToPlay, thisIndex));
			Debug.Log(thisIndex);
		}

		void SelectClip(AudioClip temp, int Arraypos)
		{
			musicController.position = Arraypos+1;
			musicSource = _musicManager.GetComponent<AudioSource>();
			musicSource.clip = temp;
			Debug.Log(thisIndex);
			_musicManager.Play(musicController.position, TrackName);
		}
		public void SetProperties (string trackName,List<AudioClip> list, int index)
		{
			trackToPlay = list[index];
			thisIndex =  musicController.alreadyIndex;
			Debug.Log(thisIndex);
			musicController.listedMusic.Add(list[index]);
			trackToPlay.name = trackName;
			musicController.alreadyIndex++;
			TrackName = trackName + " ";
			Debug.Log(trackName);
			TimeSpan t = TimeSpan.FromSeconds(list[index].length);
			TrackLength = string.Format("{0:D2}m:{1:D2}s",
				t.Minutes,
				t.Seconds);
			Name.GetComponent<Text>().text = TrackName;
			length.GetComponent<Text>().text = TrackLength;
			Debug.Log(list[index].loadType);
		}
	}
}

