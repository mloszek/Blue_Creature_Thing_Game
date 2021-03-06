﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuButtonsScript : MonoBehaviour
{
	public AudioSource source;
	public GameObject optionBoard;
	public GameObject creature;
	public Fader fader;
	public GameObject canvas;
	public GameObject ingameCanvas;
	public GameObject toggleButton;
	public IngameMenuScript ingameMenuScript;
	public float volume; 

	public void OnStartPress ()
	{
		volume = 0.65f;
		GameObject.FindWithTag ("Player").GetComponent<TesText> ().setVolume (volume);
		source.Play ();
		canvas.SetActive (false);
		ingameCanvas.SetActive (true);
		if (GameObject.FindWithTag ("Creature") == null) 
		{
			Instantiate (creature);
		}
		GameObject.FindWithTag ("Creature").transform.position = new Vector3 (0, 0, 0);
		if (GameObject.FindWithTag ("skull") != null) 
		{
			GameObject.FindWithTag ("skull").transform.position = new Vector3 (0, 2.22f, 0);
		}

		GameObject[] poo = GameObject.FindGameObjectsWithTag ("poo");
		if (poo != null) 
		{
			foreach (GameObject poop in poo) {
				poop.transform.position = new Vector3 (Random.Range(-2f, 2f), -1.6f, -3f);
			}
		}
		toggleButton.SetActive (true);
	}

	public void OnOptionsPressed ()
	{
		source.Play ();
		optionBoard.SetActive (true);
	}

	public void OnQuitPress ()
	{
		source.Play ();
		Application.Quit ();
	}

	public void OnCloseOptionPanel ()
	{
		source.Play ();
		optionBoard.SetActive (false);
	}

	public void ChangeVolume(float newValue)
	{
		source.volume = newValue;
		GameObject.FindWithTag ("Player").GetComponent<TesText> ().setVolume (newValue);
		if (GameObject.FindWithTag ("Creature") != null) {
			GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().setSourceVolume (newValue);
		}
		if (GameObject.FindWithTag ("MiniGameController") != null) {
			GameObject.FindWithTag ("MiniGameController").GetComponent<SoundManager> ().setSourceVolume (newValue);
		}
	}
}