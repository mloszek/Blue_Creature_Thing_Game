using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenuButtonsScript : MonoBehaviour
{
	public GameObject optionBoard;

	public void begin ()
	{
		Debug.Log ("start");
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