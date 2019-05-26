using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.UI;

namespace Visual.Media
{
	public class deviceMusicListing : MonoBehaviour
	{
		[SerializeField] private Text availableDevice;
		[SerializeField] private GameObject trackPrefab;
		[SerializeField] private Transform parent;
		private static string DataPath = @"C:\Projects\Elysium\audioTest\";
		public AudioSource source;

		void Start()
		{
			source = gameObject.GetComponent<AudioSource>();
		}

		public void CallManager()
		{
			if (Directory.Exists(DataPath))
			{
				var FilesCount = Directory.GetFiles(DataPath).Count();
				availableDevice.text = "Available tracks : " + FilesCount;
				List<AudioClip> audioList = new List<AudioClip>(FilesCount);
                StartCoroutine(LoadSong($"{DataPath}", FilesCount, audioList));
			}
			else Debug.Log("Path not found! " + Directory.GetDirectories(DataPath));
		}

		public IEnumerator LoadSong(string path, int countOf,List<AudioClip> audioList)
		{
			int index = 0;
			if(!musicController.devicemode)
			{
				string[] allsongs = Directory.GetFiles(path);
           		foreach(string song in allsongs)
		           {
					WWW req = new WWW("File://" + song);
					audioList.Add(req.GetAudioClipCompressed());

						while (!req.isDone)
						{
							yield return req;
						}

			           if (audioList[index].loadState == AudioDataLoadState.Loaded)
			           {
				           GameObject TrackID = Instantiate(trackPrefab, parent.transform);
				           audioProperties properties = TrackID.GetComponent<audioProperties>();
				           properties.DeviceMusicListing = this;
				           properties.SetProperties(Path.GetFileNameWithoutExtension(song), audioList, index);
				           index++;
			           }
			        Debug.Log("full is " + song);
					Debug.Log("Loading");
					musicController.devicemode = true;
					req.Dispose();
				}
		    }
		}
	}
}