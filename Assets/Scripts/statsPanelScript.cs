using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statsPanelScript : MonoBehaviour
{

	public Text levelText;

	void OnEnable ()
	{
		if (GameObject.FindGameObjectWithTag ("Creature") != null)
			levelText.text = GameObject.FindGameObjectWithTag ("Creature").GetComponent<CreatureController> ().getLevel ().ToString ();
		else
			levelText.text = "0";
	}
}
