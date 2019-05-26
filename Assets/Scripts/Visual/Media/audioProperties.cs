using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace Visual.Media
{
	public class audioProperties : MonoBehaviour
	{
		public deviceMusicListing DeviceMusicListing;
		[SerializeField] private serverMusicListing serverMusicListing;
		[SerializeField] private GameObject Name;
		[SerializeField] private GameObject length;
		public string TrackName { get; set; }
		public string TrackLength { get; set; }
		public AudioClip trackToPlay;
		private Button eventButton;

		void Start()
		{
			eventButton = gameObject.GetComponent<Button>();
			DeviceMusicListing.source.clip = trackToPlay;
			eventButton.onClick.AddListener(() => SelectClip(trackToPlay));
		}

		void SelectClip(AudioClip temp)
		{
			MusicManager.Trackname.text = TrackName;
			DeviceMusicListing.source.clip = temp;
			DeviceMusicListing.source.Play();
		}
		public void SetProperties (string trackName,List<AudioClip> list, int index)
		{
			trackToPlay = list[index];
			TrackName = trackName;
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

