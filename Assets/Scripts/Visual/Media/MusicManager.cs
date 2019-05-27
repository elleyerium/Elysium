using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MusicManager : MonoBehaviour
{
	float timeSetter = 0;
	//public Material backMaterial, GameMaterial;
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
	public AudioClip[] music;
	public AudioSource _publicSource, sfxsource;
	[SerializeField] private Text availableList;

	void Start()
	{
		musicController.listedMusic = new List<AudioClip>();

		foreach (AudioClip song in music)
		{
			musicController.listedMusic.Add(song);
			musicController.alreadyIndex++;
			Debug.Log("Listed!");
		}
		temp = Random.Range(0, musicController.listedMusic.Count-1);
		backnum = Random.Range(0, backgrounds.Count());
		musicController.position = temp;
		availableList.text = TrackNum + " of " + music.Length;
		Trackname.text = $"{musicController.listedMusic[temp].name} ";
		IsPlaying = true;
		IsPaused = false;
		_publicSource.clip = musicController.listedMusic[temp];
		_publicSource.Play();
		StartCoroutine(TextDisplay());
		timearea.maxValue = musicController.listedMusic[temp].length;
	}
	void Update ()
	{
		if (!_publicSource.isPlaying && !IsPaused)
		   Next();
		if (!isMoving)
		timearea.value = _publicSource.time;
	}

	IEnumerator TextDisplay()
	{
		Debug.Log(Trackname.preferredWidth);
		if (Trackname.preferredWidth > Trackname.gameObject.GetComponent<RectTransform>().rect.width)
		{
			Trackname.alignment = TextAnchor.MiddleLeft;
			while (Trackname.text != null)
			{
				Trackname.text += Trackname.text[0];
				Trackname.text = Trackname.text.Remove(0, 1);
				Debug.Log("Removed!");
				yield return new WaitForSeconds(0.2f);
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

		temp--;
		backnum--;
		musicController.position--;
		availableList.text = musicController.position + " of " + musicController.listedMusic.Count;
/*		if (Trackname.text.Length <=0)
		{
			Play(musicController.position, musicController.trackName);
			Debug.Log("Track name is null!");
		}*/
		if(musicController.position >= 0)
		{
			Play(musicController.position, musicController.listedMusic[musicController.position].name);
			Debug.Log("if");
		}
		else
		{
			Debug.Log("else");
			musicController.position = musicController.listedMusic.Count-1;
			Play(musicController.position, musicController.listedMusic[musicController.position].name);
		}
	}
	public void Next()
	{
		sfxsource.PlayOneShot(click);
		musicController.position++;

		temp++;
		backnum++;

		if(musicController.position >= musicController.listedMusic.Count)
		{
			musicController.position = 0;
			Play(musicController.position, musicController.listedMusic[musicController.position].name);
			Debug.Log("track name is not a null!");
		}
		else Play(musicController.position, musicController.listedMusic[musicController.position].name);

	}
	 public void Play(int pos, string nameOfTrack)
	{
		StopAllCoroutines();
		Trackname.text = nameOfTrack;
			state.sprite = pause;
		_publicSource.time = 0;
			_publicSource.clip = musicController.listedMusic[pos];
			timearea.maxValue = musicController.listedMusic[pos].length;
			_publicSource.Stop();
		StartCoroutine(TextDisplay());
		_publicSource.Play();
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

