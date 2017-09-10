using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionScript : MonoBehaviour
{

	public void giveMedicine ()
	{
		GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().setSickness (false);
		Destroy (GameObject.FindWithTag ("skull"));
		GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().setAnim ("idle");
		GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().resetSickTimer ();
		GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().startTimer ();

	}

	public void cleanPoop ()
	{
		GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().setPoop (0);
		GameObject[] poo = GameObject.FindGameObjectsWithTag ("poo");
		if (poo != null) {
			foreach (GameObject poop in poo) {
				Destroy (poop);
			}
		}
	}

	public void feed ()
	{
		if (GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().getHunger () > 50f)
			GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().setHunger (0);
		else if (GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().getHunger () < 20f
		         && GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().getHunger () > 1f) {
			GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().setHunger (0);
			GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().makePoop ();
		} else
			GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().makeSick ();
	}

	public void killSwitch ()
	{
		GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().kill ();
	}
}
