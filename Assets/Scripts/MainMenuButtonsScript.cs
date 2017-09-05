using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuButtonsScript : MonoBehaviour
{
	public GameObject optionBoard;
	public GameObject creature;
	public Fader fader;
	public GameObject canvas;
	public GameObject ingameCanvas;
	public GameObject toggleButton;
	public IngameMenuScript ingameMenuScript;

	public void begin ()
	{
		canvas.SetActive (false);
		ingameCanvas.SetActive (true);
		if (GameObject.FindWithTag ("Creature") == null) 
		{
			Instantiate (creature);
		}
		GameObject.FindWithTag ("Creature").transform.position = new Vector3 (0, 0, 0);
		toggleButton.SetActive (true);
	}

	public void options ()
	{
		optionBoard.SetActive (true);
	}

	public void quit ()
	{
		Application.Quit ();
	}

	public void closeOptionWindow ()
	{
		optionBoard.SetActive (false);
	}
}