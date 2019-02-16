using System.Collections;
using System.Collections.Generic;
using BeardedManStudios;
using UnityEngine;

public class SFXManager : MonoBehaviour
{

	public AudioSource SFXSource;
    public AudioClip buttonClick;
	public void PlaySound(AudioClip clip)
	{
        SFXSource.PlayOneShot(clip);
	}
	
	public void ClickSound()
    {
        SFXSource.PlayOneShot(buttonClick);
    }
}
