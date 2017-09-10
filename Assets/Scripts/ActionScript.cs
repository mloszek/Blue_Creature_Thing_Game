using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionScript : MonoBehaviour
{

	public void giveMedicine ()
	{
		if (GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().isSick == true) {
			GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().setSickness (false);
			Destroy (GameObject.FindWithTag ("skull"));
			GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().setAnim ("idle");
			GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().resetSickTimer ();
			GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().startTimer ();
		}
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
		if (GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().isHungry == true) {
			GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().setHunger (0);
			GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().startTimer ();
		} else if (GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().isHungry == false &&
			GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().getHunger () >= 20f){
			GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().setHunger (0);
		}  else if (GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().isHungry == false &&
			GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().getHunger () < 20f)
			GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().makeSick ();
		
	}

	public void entertain ()
	{
		if (GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().isBored == true) {
			GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().setBoredom (0);
			GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().startTimer ();
		}else
			GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().setBoredom (0);
	}

	public void killSwitch ()
	{
		GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().kill ();
	}
}
