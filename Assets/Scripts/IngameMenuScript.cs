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
	public GameObject statPanel;

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
		GameObject.FindWithTag ("Creature").transform.position = new Vector3 (0, 0, 2);
		buttons.SetActive (false);
		wholeCanvas.SetActive (false);
		mainMenuCanvas.SetActive (true);
	}

	public void getStats ()
	{
		
		buttons.SetActive (false);
		statPanel.SetActive (true);
//		string stats = GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().returnStats();
//		Debug.Log (stats);
	}

	public void hideStats ()
	{
		
		buttons.SetActive (true);
		statPanel.SetActive (false);
	}




}
