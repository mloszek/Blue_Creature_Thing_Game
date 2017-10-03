using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public AudioSource audioSource1;
	public AudioSource audioSource2;

	public void setVolume(float newValue)
	{
		audioSource1.volume = newValue;
		audioSource2.volume = newValue;
	}

	public void playSound1(AudioClip clip, float pitch)
	{
		audioSource1.clip = clip;
		audioSource1.pitch = pitch;
		audioSource1.Play ();
	}

	public void playSound2(AudioClip clip, float pitch)
	{
		audioSource2.clip = clip;
		audioSource2.pitch = pitch;
		audioSource2.Play ();
	}

	public void setSourceVolume (float newValue)
	{
		audioSource1.volume = newValue;	
		audioSource2.volume = newValue;
	}
}
