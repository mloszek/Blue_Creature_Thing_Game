using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameMenuScript : MonoBehaviour
{
	public AudioSource source;
	public GameObject mainMenuCanvas;
	public GameObject wholeCanvas;
	public GameObject toggleMenuButton;
	public GameObject buttons;
	public GameObject creature;
	public GameObject statPanel;
	public GameObject actionPanel;

	public void showMenu ()
	{
		source.Play ();
		buttons.SetActive (true);
		toggleMenuButton.SetActive (false);
	}

	public void hideMenu ()
	{
		source.Play ();
		buttons.SetActive (false);
		toggleMenuButton.SetActive (true);
	}

	public void getBackToMainMenu ()
	{
		source.Play ();
		GameObject.FindWithTag ("Creature").transform.position = new Vector3 (0, 0, 2f);
		if (GameObject.FindWithTag ("skull") != null) 
		{
			GameObject.FindWithTag ("skull").transform.position = new Vector3 (0, 2.22f, 2f);
		}
		GameObject[] poo = GameObject.FindGameObjectsWithTag ("poo");
		if (poo != null) 
		{
			foreach (GameObject poop in poo) {
				poop.transform.position = new Vector3 (0, -1.6f, 2f);
			}
		}
		buttons.SetActive (false);
		wholeCanvas.SetActive (false);
		mainMenuCanvas.SetActive (true);
	}

	public void getStats ()
	{
		source.Play ();
		buttons.SetActive (false);
		statPanel.SetActive (true);
//		string stats = GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().returnStats();
//		Debug.Log (stats);
	}

	public void getActions ()
	{
		source.Play ();
		buttons.SetActive (false);
		actionPanel.SetActive (true);
	}

	public void hidePanel ()
	{
		source.Play ();
		buttons.SetActive (true);
		statPanel.SetActive (false);
		actionPanel.SetActive (false);
	}

}
