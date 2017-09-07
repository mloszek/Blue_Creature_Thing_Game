using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreatureController : MonoBehaviour
{
	public GameObject sickIndicator;

	private Animator animator;
	private Random rdm;
	private int overallSatisfaction = 100;
	private float contentment = 100;
	private int weight = 0;
	private float stateInterval;
	private int poopCounter = 0;
	private bool isSick = false;

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

	public void setOverallSatisfaction (int newValue)
	{
		overallSatisfaction = newValue;	
	}

	public void setContentment (float newValue)
	{
		contentment = newValue;	
	}

	public void setWeight (int newValue)
	{
		weight = newValue;	
	}

	public void setSickness (bool newValue)
	{
		isSick = newValue;	
	}

	public void setPoop (int newValue)
	{
		poopCounter = newValue;	
	}

	public void setAnim (string newValue)
	{
		animator.SetTrigger (newValue);	
	}

	void Update ()
	{
		time++;
		text.setText (contentment);

		if (weight == 0) {
			if (time > 1000f) {
				Debug.Log ("!");
				doEvolve ();
				weight = weight + 1;
				setWeight (weight);
				time = 0;
			}
		}
		else if (weight > 0) {
			if (stateInterval < time){
			
			stateLottery ();
			stateInterval = 1000f;
			time = 0;
			}

			if (isSick) {
				contentment -= 0.003f;
			}
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
		if (poopCounter < 3) {
			poopCounter += 1;
			Debug.Log ("creature made poo!");
		} else if (isSick == false) {
			makeSick ();
		}
	}

	void makeSick ()
	{
		if (isSick == false) {
			isSick = true;
			animator.SetTrigger ("sad");
			Instantiate (sickIndicator);
			Debug.Log ("creature is sick!");
		}
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


	void doEvolve ()
	{
		animator.SetTrigger ("evolve");
	}

	void stateLottery ()
	{
		switch (Random.Range (1, 1)) {

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
		string stats = /*"overallSatisfaction: " + overallSatisfaction + "\ncontentment: " + contentment + "\nweight: " + weight + */"poop: " + poopCounter + "\nsick: " + isSick;
		return stats;
	}
}