using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statsPanelScript : MonoBehaviour
{

	public Text levelText;
	public Text happinessText;
	public Text hungerText;
	public Text entertainmentText;

	void OnEnable ()
	{
		if (GameObject.FindGameObjectWithTag ("Creature") != null) {
			levelText.text = GameObject.FindGameObjectWithTag ("Creature").GetComponent<CreatureController> ().getLevel ().ToString ();
			happinessText.text = GameObject.FindGameObjectWithTag ("Creature").GetComponent<CreatureController> ().getHappiness ().ToString("0");
			hungerText.text = GameObject.FindGameObjectWithTag ("Creature").GetComponent<CreatureController> ().getHunger ().ToString ("0");
			entertainmentText.text = (100f - GameObject.FindGameObjectWithTag ("Creature").GetComponent<CreatureController> ().getBoredom ()).ToString ("0");
		}
		else
			levelText.text = "0";
	}
}
