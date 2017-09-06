using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreatureController : MonoBehaviour
{

	private Animator animator;
	private Random rdm;
	private int level = 0;
	private int overallSatisfaction = 0;
	private int satisfaction = 0;
	private int weight = 0;
	private float stateInterval;

	private float time;
	float currentTime = 0f;
	float timeWhenPaused = 0f;

	private tesText text;

	void Awake ()
	{
		text = GameObject.FindWithTag ("Player").GetComponent<tesText> ();
		text.setText (0);

		time = 0;
		animator = GetComponent<Animator> ();
		rdm = new Random ();
		stateInterval = 1000f;

		//level = setLevel();
		//overallSatisfaction = setOverallSatisfaction();
		//satisfaction = setSatisfaction ();
		//weight = setWeight ();
	}

	public void setLevel (int newValue)
	{
		level = newValue;	
	}

	public void setOverallSatisfaction (int newValue)
	{
		overallSatisfaction = newValue;	
	}

	public void setSatisfaction (int newValue)
	{
		satisfaction = newValue;	
	}

	public void setWeight (int newValue)
	{
		weight = newValue;	
	}

	void Update ()
	{
		time++;
		text.setText (time++);

		if (weight == 0) {
			if (time > 1000f) {
				Debug.Log ("!");
				doEvolve ();
				weight = weight + 1;
				setWeight (weight);
				time = 0;
			}
		}
		else if (stateInterval < time && weight > 0) {
			stateLottery ();
			stateInterval = 1000f;
			time = 0;
		}


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

	float WhenNextStateChange ()
	{

		return Random.Range (30000f, 60000f);
	}

	void makePoop ()
	{
		Debug.Log ("creature made poo!");
	}

	void makeBored ()
	{
		Debug.Log ("creature is bored!");
	}

	void makeSleep ()
	{
		Debug.Log ("creature fell asleep!");
	}

	void makeHungry ()
	{
		Debug.Log ("creature isHungry!");
	}

	void makeSick ()
	{
		Debug.Log ("creature is sick!");
	}

	void doEvolve ()
	{
		animator.SetTrigger ("evolve");
	}

	void stateLottery ()
	{
		switch (Random.Range (1, 5)) {

		case 1: 
			makePoop ();
			break;
		case 2: 
			makeBored ();
			break;
		case 3: 
			makeSleep ();
			break;
		case 4: 
			makeHungry ();
			break;
		case 5: 
			makeSick ();
			break;
		}
	}

	void OnApplicationPause (bool pauseStatus)
	{
		

		if (pauseStatus) {
			currentTime = Time.realtimeSinceStartup;
		} else {
			timeWhenPaused = Time.realtimeSinceStartup - currentTime;
			Debug.Log (timeWhenPaused);
			time += timeWhenPaused * 80;
		}
	}

	public string returnStats()
	{
		string stats = "weight: " + weight + "\nlevel: " + level;
		return stats;
	}
}