using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Audio.Tracks
{
  public class MusicManager : MonoBehaviour
  {
   	    [SerializeField] private Image state;
   	    public Slider timearea;
   	    public string scenename;
   	    public static bool IsPlaying, IsPaused, isMoving;
   	    private int TrackNum, temp, backnum;
   	    public Text Trackname;
   	    public Sprite play, pause;
   	    public Texture[] backgrounds, starfield;
   	    public GameObject _musicManager;
   	    public AudioClip click, pauseclick;
   	    public string[] installedTracks;
   	    public AudioSource _publicSource, sfxsource;
   	    [SerializeField] private deviceMusicListing DeviceMusicListing;

	void Start()
	{
		AudioClip[] clips = UnityEngine.Resources.LoadAll<AudioClip>("Audio/Songs/Menu/");
		installedTracks = new string[clips.Length];

		for (int i = 0; i < clips.Length; i++)
		{
			installedTracks[i] = clips[i].name;
			//Debug.Log(installedTracks[i]);
		}

		//Debug.Log(clips.Length);
		var list = installedTracks.ToList();
		musicController.listedMusic = new List<string>();

		foreach (var song in installedTracks)
		{
			//if (Path.GetExtension(song) == ".mp3")
			//{
				musicController.listedMusic.Add(song);
				musicController.alreadyIndex++;
				Debug.Log(song);
			//}
			//else list.Remove(song);
		}

		installedTracks = new string[list.Count];
		temp = Random.Range(0, musicController.listedMusic.Count);
		musicController.position = temp;
		IsPlaying = true;
		IsPaused = false;
		AudioClip clip = (AudioClip)UnityEngine.Resources.Load($"Audio/Songs/Menu/{Path.GetFileNameWithoutExtension(list[temp])}");
		Play(clip);
		Trackname.text = _publicSource.clip.name;
		StartCoroutine(TextDisplay());
		timearea.maxValue = _publicSource.clip.length;
		StartCoroutine(StatusCoroutine());
	}

	IEnumerator StatusCoroutine()
	{
		timearea.value = _publicSource.time;
		while (true)
		{
			if (!isMoving)
				timearea.value = _publicSource.time;
			if (!_publicSource.isPlaying && !IsPaused)
			{
				for (int i = 0; i < 1; i++)
				{
					Next();
				}
			}
			yield return new WaitForSeconds(1);
		}
	}

	IEnumerator TextDisplay()
	{
		Debug.Log("Case preferred Width : " + Trackname.preferredWidth);
		if (Trackname.preferredWidth > Trackname.gameObject.GetComponent<RectTransform>().rect.width)
		{
			Trackname.text += " ";
			Trackname.alignment = TextAnchor.MiddleLeft;
			while (Trackname.text != null)
			{
				Trackname.text += Trackname.text[0];
				Trackname.text = Trackname.text.Remove(0, 1);
				yield return new WaitForSeconds(0.13f);
			}
		}

		if (Trackname.text == null || Trackname.preferredWidth <
		    Trackname.gameObject.GetComponent<RectTransform>().rect.width)
		{
			Debug.Log("Smaller or eq");
			Trackname.alignment = TextAnchor.MiddleLeft;
			StopAllCoroutines();
		}
		else Debug.Log("null TextDisplay");
	}

	public void SliderPointerDown()
	{
		isMoving = true;
		Debug.Log("Down");
	}

	public void SliderPointerUp()
	{
		isMoving = false;
		_publicSource.time = timearea.value;
		Debug.Log("Up");
	}

	public void Previous()
	{
		sfxsource.PlayOneShot(click);
		musicController.position--;
		Debug.Log(musicController.position+1 + " listed is " + musicController.listedMusic.Count);

		if (musicController.position <0)
		{
			musicController.position = musicController.listedMusic.Count;
			Previous();
		}

		if (musicController.position > installedTracks.Length)
			StartCoroutine(DeviceMusicListing.RequestSong(deviceMusicListing.DataPath + Path.GetFileName(musicController.listedMusic[musicController.position]), true,
				musicController.position));

		if (musicController.position <= installedTracks.Length)
			StartCoroutine(DeviceMusicListing.RequestSong(Path.GetFileNameWithoutExtension(musicController.listedMusic[musicController.position]), false,
				musicController.position));
	}
	public void Next()
	{
		sfxsource.PlayOneShot(click);
		musicController.position++;
		Debug.Log(musicController.position+1 + " of listed " + musicController.listedMusic.Count);

		if (musicController.position == musicController.listedMusic.Count)
			musicController.position = 0;

		if (musicController.position >= installedTracks.Length)
			StartCoroutine(DeviceMusicListing.RequestSong(deviceMusicListing.DataPath + Path.GetFileName(musicController.listedMusic[musicController.position]), true,
				musicController.position));

		if (musicController.position < installedTracks.Length)
			StartCoroutine(DeviceMusicListing.RequestSong(Path.GetFileNameWithoutExtension(musicController.listedMusic[musicController.position]), false,
				musicController.position));
	}
	 public void Play(AudioClip clip)
	{
		_publicSource.Stop();
		state.sprite = pause;
		_publicSource.clip = clip;
		timearea.maxValue = clip.length;
		_publicSource.Play();
		_publicSource.time = 0;
		Trackname.text = clip.name;
		StopAllCoroutines();
		StartCoroutine(TextDisplay());
		StartCoroutine(StatusCoroutine());
	}

	public void State()
	{
		if (!IsPaused)
		{
			state.sprite = play;
			IsPaused = true;
			sfxsource.PlayOneShot(pauseclick);
			_publicSource.Pause();
		}
		else
		{
			state.sprite = pause;
			IsPaused = false;
			_publicSource.UnPause();
		}
    }
  }
}


