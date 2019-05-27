using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using UnityEditor;
using UnityEngine.UI;

namespace Visual.Media
{
	public class deviceMusicListing : MonoBehaviour
	{
		[SerializeField] private Text availableDevice, input, debug;
		[SerializeField] private GameObject trackPrefab;
		[SerializeField] private Transform parent;
		private static string DataPath = null;

		public void CallManager()
		{
			DataPath = input.text;
			if (Application.platform == RuntimePlatform.Android)
			{
				try
				{
					PlayerSettings.Android.forceSDCardPermission = (true);
					Debug.Log(Path.GetPathRoot(Application.dataPath));
					if (Directory.Exists(DataPath))
					{
						debug.text = DataPath;
						var FilesCount = Directory.GetFiles(DataPath).Count();
						availableDevice.text = "Available tracks : " + FilesCount;
						List<AudioClip> audioList = new List<AudioClip>(FilesCount);
						StartCoroutine(LoadSong($"{DataPath}", FilesCount, audioList));
						DataPath = Directory.GetCurrentDirectory();
					}

					if (!Directory.Exists(DataPath))
						debug.text = "Cant find directory!";
				}
				catch (Exception ex)
				{

					debug.text = ("Path not found! " + ex + "path " + DataPath);
				}
			}
			else debug.text =("That is not android!");
		}

		public IEnumerator LoadSong(string path, int countOf,List<AudioClip> audioList)
		{
			int index = 0;

				if (!musicController.devicemode)
				{
					string[] allsongs = Directory.GetFiles(path);
					foreach (string song in allsongs)
					{
						if (song.Contains(".mp3"))
						{

							WWW req = new WWW("File://" + song);
							audioList.Add(req.GetAudioClipCompressed());

							while (!req.isDone)
							{
								yield return req;
							}

							req.Dispose();
						}
						else
						{
							Debug.LogError("Is not a song");
							continue;
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

					}
				}
		}
	}
}