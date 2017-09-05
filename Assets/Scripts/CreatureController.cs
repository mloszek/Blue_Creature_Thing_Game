using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureController : MonoBehaviour {

	private Animator animator;
	private Random rdm;
	private int level = 0;
	private int overallSatisfaction = 0;
	private int satisfaction = 0;
	private int weight = 0;

	void Awake(){

		animator = GetComponent<Animator> ();
		rdm = new Random ();
		//float firstStateChange = WhenNextStateChange ();
		//level = setLevel();
		//overallSatisfaction = setOverallSatisfaction();
		//satisfaction = setSatisfaction ();
		//weight = setWeight ();

	}

	public void setLevel(int newValue){
	
		level = newValue;	
	}

	public void setOverallSatisfaction(int newValue){

		overallSatisfaction = newValue;	
	}

	public void setSatisfaction(int newValue){

		satisfaction = newValue;	
	}

	public void setWeight(int newValue){

		weight = newValue;	
	}

	void Update () {

	

//		if (Input.GetKeyUp ("q")) {
//			animator.SetTrigger ("idle");
//			Debug.Log ("creature got back to normal!");
//		}
//		if (Input.GetKeyUp ("d")) {
//			animator.SetTrigger ("dead");
//			Debug.Log ("creature died!");
//		}
//		if (Input.GetKeyUp ("e")) {
//			animator.SetTrigger ("evolve");
//			Debug.Log ("creature has evolved!");
//		}
//		if (Input.GetKeyUp ("a")) {
//			animator.SetTrigger ("sleep");
//			Debug.Log ("creature is fast asleep!");
//		}
//		if (Input.GetKeyUp ("s")) {
//			animator.SetTrigger ("sad");
//			Debug.Log ("creature is sad!");
//		}


	}

	float WhenNextStateChange(){

		return Random.Range (5, 30);
	}
}
