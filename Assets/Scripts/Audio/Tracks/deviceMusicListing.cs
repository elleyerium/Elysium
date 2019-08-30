using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.Android;
using UnityEngine.Networking;
using NLayer;

namespace Audio.Tracks
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
		public static string DataPath = @"/sdcard/music";
		private AudioSource _audioSource;

		/// <summary>
		/// Call device listing manager by path.
		/// </summary>

		private void Start()
		{
			_audioSource = _musicManager.GetComponent<AudioSource>();
			Permission.RequestUserPermission(Permission.ExternalStorageRead);
			Permission.RequestUserPermission(Permission.ExternalStorageWrite);
		}
		public void CallManager()
		{
			DataPath = input.text.Length > 1 ? DataPath = input.text : DataPath;
				try
				{
					if (Directory.Exists(DataPath))
					{
						debug.text = DataPath;
						var filesCount = Directory.GetFiles(DataPath).Count();
						availableDevice.text = "Available tracks : " + filesCount;
						//List<string> audioList = new List<string>(FilesCount);
						StartCoroutine(LoadSong($"{DataPath}", filesCount, musicController.listedMusic));
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
							//	try
							//	{
									audioList.Add(song);
									Debug.Log(song);
									var mpeg = new MpegFile(song);
									InitializeSong(song, index, audioList, mpeg.Duration);
									debug.text = "Not null";
									if(debug.gameObject.activeInHierarchy && !loaded)
										debug.gameObject.SetActive(false);
									index++;
							//	}
							//	catch (Exception ex)
							//	{
								//	debug.text = ex.ToString();
								//	Debug.Log(ex);
							//	}
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
					if (_audioSource.clip != null && musicController.position >= 4)
						Destroy(_audioSource.clip);

					musicController.position = temp;

					var mp3Clip = new MpegFile(path);
					var clip = AudioClip.Create(path, (int) mp3Clip.Length/sizeof(float)/mp3Clip.Channels, mp3Clip.Channels, mp3Clip.SampleRate, true,
						data => {
							var actualReadCount = mp3Clip.ReadSamples(data, 0, data.Length);
						}, position => {
							mp3Clip = new MpegFile(path);
						});
					yield return clip;
					clip.name = Path.GetFileNameWithoutExtension(path);
					_audioSource.clip = clip;
					_musicManager.Play(clip);
					StopAllCoroutines();

				}

				if (!userMusic)
				{
					Debug.Log("Click user--"); //Got click by user
					var clip = UnityEngine.Resources.Load<AudioClip>(
						$"Audio/Songs/Menu/{Path.GetFileNameWithoutExtension(musicController.listedMusic[temp])}");
					_musicManager.Play(clip);
					StopAllCoroutines();
				}
		}

		private void InitializeSong(string song, int index,List<string> audioList, TimeSpan length)
		{
			var trackId = Instantiate(trackPrefab, parent.transform);
			var properties = trackId.GetComponent<audioProperties>();
			properties.DeviceMusicListing = this;
			properties.Path = song;
			properties.Index = index;
			properties.SetProperties(song, audioList, index, length);
		}
	}
}