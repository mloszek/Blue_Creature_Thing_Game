using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreatureController : MonoBehaviour
{
	public GameObject sickIndicator;
	public GameObject poop;

	private Animator animator;
	private float happiness = 100f;
	private int level = 0;
	private int poopCounter = 0;
	private float deathSickTimer = 100f;
	private float hunger = 0f;
	private float poopPressure = 0f;
	private float boredom = 0f;

	public bool isSick = false;
	public bool isDead = false;
	public bool isHungry = false;
	public bool isBored = false;
	public bool isAsleep = false;


//	private float time;
//	float currentTime = 0f;
//	float timeWhenPaused = 0f;

	private tesText text;

	System.Diagnostics.Stopwatch timer;

	void Awake ()
	{
		timer = new System.Diagnostics.Stopwatch ();
		timer.Start ();

		Application.runInBackground = true;

		text = GameObject.FindWithTag ("Player").GetComponent<tesText> ();
		text.setText (System.TimeSpan.Zero);

		animator = GetComponent<Animator> ();
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
		isHungry = false;
		animator.SetTrigger ("idle");
	}

	public float getBoredom()
	{
		return boredom;
	}

	public void setBoredom (float newValue)
	{
		
		boredom = newValue;	
		if(isBored)
			animator.SetTrigger ("idle");
		isBored = false;

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
			if (timer.Elapsed.Minutes >= 3) {
				animator.SetTrigger ("evolve");
				level = level + 1;
				timer.Reset ();
				timer.Start ();
			}
		} else if (level > 0) {
			
			if (level == 1 && timer.Elapsed.Minutes >= 15) {
				animator.SetTrigger ("evolve");
				level = level + 1;
				timer.Reset ();
				timer.Start ();
			} else if (level == 1 && timer.Elapsed.Minutes >= 15) {
				if (happiness >= 50) {
					animator.SetTrigger ("evolveGood");
					level = level + 1;
					timer.Reset ();
					timer.Start ();
				} else {
					animator.SetTrigger ("evolveBad");
					level = level + 1;
					timer.Reset ();
					timer.Start ();
				}
			} else if (level == 1 && timer.Elapsed.Minutes >= 15) {
				if (happiness >= 50) {
					animator.SetTrigger ("evolveGood");
					level = level + 1;
					timer.Reset ();
					timer.Start ();
				} else {
					animator.SetTrigger ("evolveBad");
					level = level + 1;
					timer.Reset ();
					timer.Start ();
				}
			} else if (level == 1 && timer.Elapsed.Minutes >= 15) {
				animator.SetTrigger ("goToHeaven");
				isDead = true;
				timer.Reset ();
			}

			if (isAsleep == false) {
				
				hunger += 0.003f;
				poopPressure += 0.008f;


				if (isBored) {
					happiness -= 0.005f;
				} else
					boredom += 0.001f;

				if (isSick) {
					happiness -= 0.005f;
					deathSickTimer -= 0.008f;
				}

				if (isHungry) {
					happiness -= 0.005f;
				}

				if (hunger > 70f && isHungry == false) {
					isHungry = true;
					animator.SetTrigger ("sad");
					timer.Stop ();
				}

				if (boredom > 60f && isBored == false) {
					makeBored ();
				}

				if (poopPressure >= 100f) {
					makePoop ();
					poopPressure = Random.Range (0, 20f);
				}
					
			}


		}


		if (happiness <= 0 || deathSickTimer <= 0 || hunger >= 100) {
			kill ();
		}
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
			timer.Stop ();
		}
	}

	void makeBored ()
	{
		isBored = true;
		animator.SetTrigger ("sad");
		timer.Stop ();
	}

	void makeSleep ()
	{
		Debug.Log ("creature fell asleep!");
	}

//	void OnApplicationPause (bool pauseStatus)
//	{
//		
//		if (pauseStatus) {
//			currentTime = Time.realtimeSinceStartup;
//		} else {
//			timeWhenPaused = Time.realtimeSinceStartup - currentTime;
//			Debug.Log (timeWhenPaused);
//			time += timeWhenPaused * 80;
//		}
//	}
//
//	public string returnStats ()
//	{
//		string stats = /*"comfort: " + comfort + "\ncontentment: " + contentment +*/"poop: " + poopCounter + "\nsick: " + isSick;
//		return stats;
//	}
}