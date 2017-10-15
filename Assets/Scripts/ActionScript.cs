using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionScript : MonoBehaviour
{
	public GameObject text;
	public GameObject minigame;
	public GameObject minigameCanvas;

	private GameObject creature;

	void Start ()
	{
		creature = GameObject.FindWithTag ("Creature");
	}

	public void giveMedicine ()
	{
		if (creature.GetComponent<CreatureController> ().isAsleep == false
		    && creature.GetComponent<CreatureController> ().isDead == false
		    && creature.GetComponent<CreatureController> ().getLevel () > 0) {
			if (creature.GetComponent<CreatureController> ().isSick == true) {
				creature.GetComponent<CreatureController> ().medicineSource.Play ();
				creature.GetComponent<CreatureController> ().setSickness (false);
				Destroy (GameObject.FindWithTag ("skull"));
				creature.GetComponent<CreatureController> ().resetSickTimer ();
				creature.GetComponent<CreatureController> ().startTimer ();
			}
		}
	}

	public void cleanPoop ()
	{
		creature.GetComponent<CreatureController> ().setPoop (0);
		GameObject[] poo = GameObject.FindGameObjectsWithTag ("poo");
		if (poo.Length != 0) {
			foreach (GameObject poop in poo) {
				Destroy (poop);
			}
			creature.GetComponent<CreatureController> ().brushSource.Play ();
		}
	}

	public void feed ()
	{
		if (creature.GetComponent<CreatureController> ().isAsleep == false
		    && creature.GetComponent<CreatureController> ().isDead == false
		    && creature.GetComponent<CreatureController> ().getLevel () > 0) {
			if (creature.GetComponent<CreatureController> ().isHungry == true) {
				creature.GetComponent<CreatureController> ().setHunger (0);
				creature.GetComponent<CreatureController> ().startTimer ();
			} else if (creature.GetComponent<CreatureController> ().isHungry == false &&
			           creature.GetComponent<CreatureController> ().getHunger () >= 20f) {
				creature.GetComponent<CreatureController> ().setHunger (0);
			} else if (creature.GetComponent<CreatureController> ().isHungry == false &&
			           creature.GetComponent<CreatureController> ().getHunger () < 20f)
				creature.GetComponent<CreatureController> ().makeSick ();
		}
		
	}

	public void entertain ()
	{
		if (creature.GetComponent<CreatureController> ().isAsleep == false
		    && creature.GetComponent<CreatureController> ().isDead == false
		    && creature.GetComponent<CreatureController> ().getLevel () > 0) {
			creature.GetComponent<CreatureController> ().setBoredom (0);
			creature.transform.position = new Vector3 (0, 0, 2f);
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
			GameObject.FindWithTag ("IngameCanvas").SetActive (false);
			minigameCanvas.SetActive (true);
			GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().isMinigameRunning = true;
			minigame.SetActive (true);
			text.GetComponent<ScoreController> ().resetScore ();
			minigame.GetComponent<MiniGameController> ().beginGame ();
		}
	}


	public void killSwitch ()
	{
		creature.GetComponent<CreatureController> ().kill ();
	}

	public void putToSleep ()
	{
		creature.GetComponent<CreatureController> ().makeSleep ();
	}

	public void wakeUp ()
	{
		creature.GetComponent<CreatureController> ().wakeUp ();
	}
}