using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenuButtonsScript : MonoBehaviour
{
	public GameObject optionBoard;
	public GameObject creature;
	public Fader fader;
	public GameObject ingameCanvas;

	public void begin ()
	{
		Debug.Log ("start");
		fader.FadeOut ();
		ingameCanvas.SetActive (true);
		Instantiate (creature);
	}

	public void options ()
	{
		optionBoard.SetActive(true);
		Debug.Log ("options");
	}

	public void quit ()
	{
		Application.Quit ();
		Debug.Log ("quit");
	}

	public void closeOptionWindow (){
		optionBoard.SetActive(false);
	}
}