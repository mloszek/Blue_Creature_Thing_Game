using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionScript : MonoBehaviour {

	public void giveMedicine(){
		GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().setSickness (false);
		Destroy (GameObject.FindWithTag ("skull"));
		GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().setAnim ("idle");
	}

	public void cleanPoop(){
		GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().setPoop (0);
		GameObject[] poo = GameObject.FindGameObjectsWithTag ("poo");
		if (poo != null) 
		{
			foreach (GameObject poop in poo) {
				Destroy (poop);
			}
		}
	}

	public void killSwitch ()
	{
		GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().kill ();
	}
}
