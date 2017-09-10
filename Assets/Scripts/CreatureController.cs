using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreatureController : MonoBehaviour
{
	public GameObject sickIndicator;
	public GameObject poop;

	private Animator animator;
	private Random rdm;
	private int comfort = 100;
	private float happiness = 100f;
	private int level = 0;
	private float stateInterval;
	private int poopCounter = 0;
	private float deathSickTimer = 100f;
	private float hunger = 0f;

	private bool isSick = false;
	private bool isDead = false;

	private float time;
	float currentTime = 0f;
	float timeWhenPaused = 0f;

	private tesText text;

	System.Diagnostics.Stopwatch timer;

	void Awake ()
	{
		timer = new System.Diagnostics.Stopwatch ();
		timer.Start ();

		Application.runInBackground = true;

		text = GameObject.FindWithTag ("Player").GetComponent<tesText> ();
		text.setText (System.TimeSpan.Zero);

		time = 0;
		animator = GetComponent<Animator> ();
		rdm = new Random ();
		stateInterval = 1000f;
	}

	public void startTimer ()
	{
		timer.Start ();
	}

	public int getLevel()
	{
		return level;
	}

	public float getHappiness()
	{
		return happiness;
	}

	public float getHunger()
	{
		return hunger;
	}

	public void setHunger (float newValue)
	{
		hunger = newValue;	
	}

	public void setComfort (int newValue)
	{
		comfort = newValue;	
	}

	public void setHappiness (float newValue)
	{
		happiness = newValue;	
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

	public void resetSickTimer ()
	{
		deathSickTimer = 100f;	
	}


	void Update ()
	{
		
		text.setText (timer.Elapsed);


		if (isDead) {
			return;
		} else if (level == 0) {
			if (timer.Elapsed.Seconds >= 10) {
				Debug.Log ("!");
				animator.SetTrigger ("evolve");
				level = level + 1;
				timer.Reset ();
				timer.Start ();
			}
		} else if (level == 1) {
//			if (timer.Elapsed.Seconds >= 10) {
//				Debug.Log ("!");
//				animator.SetTrigger ("evolve");
//				level = level + 1;
//				timer.Reset ();
//				timer.Start ();
//			}
			//a co jezeli bedzie smutny bo bedzie glodny ale bedzie tez chory?
			hunger += 0.003f;

			if (timer.Elapsed.Seconds >= 10) {
				makePoop ();
				timer.Reset ();
				timer.Start ();
			}

			if (isSick) {
				happiness -= 0.005f;
				deathSickTimer -= 0.008f;
				timer.Stop ();
			}
		}


		if (happiness <= 0 || deathSickTimer <= 0 || hunger >= 100) {
			kill ();
		}

//		if (!isDead && )
//			hunger += 0.003f;
	}

	float WhenNextStateChange ()
	{

		return Random.Range (30000f, 60000f);
	}

	public void kill ()
	{
		animator.SetTrigger ("dead");
		if (GameObject.FindWithTag ("skull") != null) {
			Destroy (GameObject.FindWithTag ("skull"));
		}
		isDead = true;
	}

	public void goToHeaven ()
	{
		animator.SetTrigger ("goToHeaven");
		if (GameObject.FindWithTag ("skull") != null) {
			Destroy (GameObject.FindWithTag ("skull"));
		}
		isDead = true;
	}

	public void makePoop ()
	{
		if (poopCounter < 3) {
			poopCounter += 1;
			Instantiate (poop, new Vector3 (Random.Range (-2f, 2f), -1.6f, -3f), Quaternion.identity);
		} else if (isSick == false) {
			makeSick ();
		}
	}

	public void makeSick ()
	{
		if (isSick == false) {
			isSick = true;
			animator.SetTrigger ("sad");
			Instantiate (sickIndicator);
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

	public string returnStats ()
	{
		string stats = /*"comfort: " + comfort + "\ncontentment: " + contentment +*/"poop: " + poopCounter + "\nsick: " + isSick;
		return stats;
	}
}