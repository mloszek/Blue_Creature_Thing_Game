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

	public void begin ()
	{
		canvas.SetActive (false);
		ingameCanvas.SetActive (true);
			Instantiate (creature);
//		creature.SetActive (true);
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