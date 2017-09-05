using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameMenuScript : MonoBehaviour
{

	public GameObject mainMenuCanvas;
	public GameObject wholeCanvas;
	public GameObject toggleMenuButton;
	public GameObject buttons;
	public GameObject creature;

	public void showMenu ()
	{

		buttons.SetActive (true);
		toggleMenuButton.SetActive (false);
	}

	public void hideMenu ()
	{

		buttons.SetActive (false);
		toggleMenuButton.SetActive (true);
	}

	public void getBackToMainMenu ()
	{

		creature.SetActive (false);
		buttons.SetActive (false);
		wholeCanvas.SetActive (false);
		mainMenuCanvas.SetActive (true);
	}

}
