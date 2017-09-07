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
	}

	public void killSwitch ()
	{
		GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().kill ();
	}
}
