using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GooglePlayGames;
<<<<<<< HEAD
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
=======
using UnityEngine;
>>>>>>> 46f6557c006040dbc335ccb9f08f0d9b60ad214f
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MusicManager : MonoBehaviour
{
	float timeSetter = 0;
<<<<<<< HEAD
	public Material backMaterial, GameMaterial;
	[SerializeField] private Image state;
	public Slider timearea;
	public string scenename;
=======
	public Material backMaterial;
	[SerializeField] private Image state;
	public Slider timearea;
>>>>>>> 46f6557c006040dbc335ccb9f08f0d9b60ad214f
	public static bool IsPlaying, IsPaused, isMoving;
	private int TrackNum, temp, backnum;
	public Text Trackname;
	public Sprite play, pause;
<<<<<<< HEAD
	public Texture[] backgrounds, starfield;
=======
	public Texture[] backgrounds;
>>>>>>> 46f6557c006040dbc335ccb9f08f0d9b60ad214f
	public GameObject _musicManager, textComponent;
	public AudioClip click, pauseclick;
	public AudioClip[] music;
	public AudioSource _publicSource, sfxsource;
	[SerializeField] Text availableList;

	void Start()
	{
		temp = Random.Range(0, music.Count());
		backnum = Random.Range(0, backgrounds.Count());
<<<<<<< HEAD
		backMaterial.SetTexture("_MainTex", backgrounds[backnum]);
=======
>>>>>>> 46f6557c006040dbc335ccb9f08f0d9b60ad214f
	    TrackNum = temp+1;
		availableList.text = ((TrackNum) + " of " +music.Length);
		Trackname.text = music[temp].name;
		IsPlaying = true;
		IsPaused = false;
		_publicSource.clip = music[temp];
		_publicSource.Play();		
		timearea.maxValue = music[temp].length;
<<<<<<< HEAD
		ChangeBackground();

=======
>>>>>>> 46f6557c006040dbc335ccb9f08f0d9b60ad214f
	}
	void Update ()
	{
		if (!_publicSource.isPlaying && !IsPaused)
		   Next();
		if (!isMoving)
<<<<<<< HEAD
		timearea.value = _publicSource.time;
=======
		   timearea.value = _publicSource.time;
		
>>>>>>> 46f6557c006040dbc335ccb9f08f0d9b60ad214f
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
		TrackNum--;
		temp--;
		backnum--;
		if (temp == -1)
		{
			temp = Convert.ToInt32(music.Length) -1 ;
			TrackNum = temp+1;
		}
		if (backnum == -1)
		{
			backnum = Convert.ToInt32(backgrounds.Length) -1;
		}

		availableList.text = ((TrackNum) + " of " +music.Length);
		Play();
	}
	public void Next()
	{
		sfxsource.PlayOneShot(click);
		TrackNum++;
		temp++;
		backnum++;
		if (temp == music.Length)
		{
		    temp = 0;
			TrackNum = temp + 1;
		}
		if (backnum == backgrounds.Length)
		{
			backnum = 0;
		}
<<<<<<< HEAD
		availableList.text = ((TrackNum) + " of " + music.Length);
		Play();		
	}

	 void Play()
=======
		availableList.text = ((TrackNum) + " of " +music.Length);
		Play();		
	}

	void Play()
>>>>>>> 46f6557c006040dbc335ccb9f08f0d9b60ad214f
	{
			state.sprite = pause;
		_publicSource.time = 0;
			_publicSource.clip = music[temp];
			timearea.maxValue = music[temp].length;
			_publicSource.Stop();
			Trackname.text = music[temp].name;
		_publicSource.clip = music[temp];
		_publicSource.Play();
		ChangeBackground();
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

	void ChangeBackground()
	{
<<<<<<< HEAD
		if(SceneManager.GetActiveScene().name == "main")
		Backgroung.r.material.SetTexture("_MainTex", backgrounds[backnum]);
		else 
			GameMaterial.SetTexture("_MainTex", starfield[backnum]);
=======
		Backgroung.r.material.SetTexture("_MainTex", backgrounds[backnum]);
>>>>>>> 46f6557c006040dbc335ccb9f08f0d9b60ad214f
	}
}
