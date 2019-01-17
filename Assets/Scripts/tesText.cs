using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TesText : MonoBehaviour {


	public Text text;
	public float volume = 0.65f;

	void Start () 
	{
		volume = GameObject.FindWithTag ("MainMenu").GetComponent<MainMenuButtonsScript> ().volume;
		text = GetComponent<Text> ();
	}

	public void setText(TimeSpan time)
	{
		text.text = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
			time.Hours, time.Minutes, time.Seconds,
			time.Milliseconds / 10);
	}

	public void setVolume(float newValue)
	{
		volume = newValue;
	}

	public float getVolume()
	{
		return volume;
	}

//	public void setText(float time)
//	{
//		text.text = time.ToString();
//	}
}
