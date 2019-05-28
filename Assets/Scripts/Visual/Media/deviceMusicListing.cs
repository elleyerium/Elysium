using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.Android;
using UnityEngine.Networking;

namespace Visual.Media
{
	/// <summary>
	/// Public class for <c>initialize</c> device music listing.
	/// </summary>
	public class deviceMusicListing : MonoBehaviour
	{
		[SerializeField] private Text availableDevice, input, debug;
		[SerializeField] private GameObject trackPrefab;
		[SerializeField] private Transform parent;
		[SerializeField] private MusicManager _musicManager;
		public static string DataPath = @"B:\audio\";

		/// <summary>
		/// Call device listing manager by path.
		/// </summary>
		public void CallManager()
		{
			Permission.RequestUserPermission(Permission.ExternalStorageRead);
			Permission.RequestUserPermission(Permission.ExternalStorageWrite);

			DataPath = input.text.Length > 1 ? DataPath = input.text : DataPath;
				try
				{
					Debug.Log(Path.GetPathRoot(Application.dataPath));
					if (Directory.Exists(DataPath))
					{
						debug.text = DataPath;
						var FilesCount = Directory.GetFiles(DataPath).Count();
						availableDevice.text = "Available tracks : " + FilesCount;
						List<string> audioList = new List<string>(FilesCount);
						StartCoroutine(LoadSong($"{DataPath}", FilesCount, audioList));
					}

					if (!Directory.Exists(DataPath))
						debug.text = "Cant find directory!";
				}
				catch (Exception ex)
				{

					debug.text = ("Path not found! " + ex + "path " + DataPath);
				}
			//}
		//	else debug.text =("That is not android!");
		}

		public IEnumerator LoadSong(string path, int countOf,List<string> audioList)
		{
			int index = 0;

				if (!musicController.devicemode)
				{
					string[] allsongs = Directory.GetFiles(path);
					bool loaded = false;

						foreach (string song in allsongs)
						{
							if (Path.GetExtension(song) == ".mp3" || Path.GetExtension(song) == ".ogg" || Path.GetExtension(song) == ".wav" )
							{
								string clip = song;
								try
								{
									audioList.Add(clip);
									InitializeSong(song, index,audioList);
									debug.text = "Not null";
									Debug.Log(debug.text);
									if(debug.gameObject.activeInHierarchy && !loaded)
										debug.gameObject.SetActive(false);
									index++;
								}
								catch (Exception ex)
								{
									debug.text = ex.ToString();
								}
							}
							else
							{
								Debug.LogError("Is not a song " + Path.GetExtension(song));
								continue;
							}
							musicController.devicemode = true;
							yield return new WaitForFixedUpdate();
			          	}
					StopAllCoroutines();
			    }
		}

		public IEnumerator RequestSong(string path, bool userMusic, int temp)
		{
			if (userMusic)
			{
				Debug.Log("Click user++");
				Debug.Log($"file://{path}");
				if (_musicManager.GetComponent<AudioSource>().clip != null)
					Destroy(_musicManager.GetComponent<AudioSource>().clip);
				WWW www = new WWW($"file://{path}");
				yield return www;
				var clip = www.GetAudioClip(false, true);
				_musicManager.Play(clip);
				//www.Dispose();
			}

			if (!userMusic)
			{
				Debug.Log("Click user--");
				var clip = Resources.Load<AudioClip>(
					$"Songs/Menu/{Path.GetFileNameWithoutExtension(musicController.listedMusic[temp])}");
				_musicManager.Play(clip);
			}
		}

		void InitializeSong(string song, int index,List<string> audioList)
		{
			GameObject TrackID = Instantiate(trackPrefab, parent.transform);
			audioProperties properties = TrackID.GetComponent<audioProperties>();
			properties.DeviceMusicListing = this;
			properties.Path = song;
			properties.SetProperties(song, audioList, index);
		}
	}
}