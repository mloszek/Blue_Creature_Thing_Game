using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreatureController : MonoBehaviour
{
	public GameObject sickIndicator;
	public GameObject poop;
	public AudioSource poopSource;
	public AudioSource sickSource;
	public AudioSource medicineSource;
	public AudioSource brushSource;
	public AudioSource evolveSource;
	public AudioSource heavenSource;
	public AudioSource goToSleepSource;
	public AudioSource wakeUpSource;
	public AudioSource deadSource;

	private Animator animator;
	private float happiness = 100f;
	private int level = 0;
	private int poopCounter = 0;
	private float deathSickTimer = 100f;
	private float hunger = 0f;
	private float poopPressure = 0f;
	private float boredom = 0f;
	private float sleepTime = 0f;

	public bool isSick = false;
	public bool isDead = false;
	public bool isHungry = false;
	public bool isBored = false;
	public bool isAsleep = false;

	private tesText text;

	System.Diagnostics.Stopwatch timer;

	void Awake ()
	{
		timer = new System.Diagnostics.Stopwatch ();
		timer.Start ();

		text = GameObject.FindWithTag ("Player").GetComponent<tesText> ();
		text.setText (System.TimeSpan.Zero);

		animator = GetComponent<Animator> ();
	}

	public void startTimer ()
	{
		timer.Start ();
	}

	public int getLevel ()
	{
		return level;
	}

	public float getHappiness ()
	{
		return happiness;
	}

	public float getHunger ()
	{
		return hunger;
	}

	public void setHunger (float newValue)
	{
		hunger = newValue;	
		if(isHungry){
			animator.SetTrigger ("idle");
			isHungry = false;
		}
		medicineSource.Play ();
	}

	public float getBoredom ()
	{
		return boredom;
	}

	public void setBoredom (float newValue)
	{
		
		boredom = newValue;	
		if (isBored) {
			animator.SetTrigger ("idle");
			isBored = false;
		}

	}

	public void setHappiness (float newValue)
	{
		happiness = newValue;	
	}

	public void setSickness (bool newValue)
	{
		if (isSick) {
			animator.SetTrigger ("idle");
			isSick = newValue;	
		}
	}

	public void setPoop (int newValue)
	{
		poopCounter = newValue;	
	}

	public void setSourceVolume (float newValue)
	{
		poopSource.volume = newValue;	
		sickSource.volume = newValue;
		medicineSource.volume = newValue;
		brushSource.volume = newValue;
		evolveSource.volume = newValue;
		heavenSource.volume = newValue;
		goToSleepSource.volume = newValue;
		wakeUpSource.volume = newValue;
		deadSource.volume = newValue;
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
//		text.setText (poopPressure);

		if (isDead) {
			return;
		} else if (!isAsleep) {
			if (level == 0) {
				if (timer.Elapsed.Minutes >= 1) {
					animator.SetTrigger ("evolve");
					evolveSource.Play ();
					level = level + 1;
					timer.Reset ();
					timer.Start ();
				}
			} else if (level > 0) {
			
				if (level == 1 && timer.Elapsed.Minutes >= 15) {
					animator.SetTrigger ("evolve");
					evolveSource.Play ();
					level = level + 1;
					timer.Reset ();
					timer.Start ();
				} else if (level == 1 && timer.Elapsed.Minutes >= 15) {
					if (happiness >= 50) {
						animator.SetTrigger ("evolveGood");
						evolveSource.Play ();
						level = level + 1;
						timer.Reset ();
						timer.Start ();
					} else {
						animator.SetTrigger ("evolveBad");
						evolveSource.Play ();
						level = level + 1;
						timer.Reset ();
						timer.Start ();
					}
				} else if (level == 1 && timer.Elapsed.Minutes >= 15) {
					if (happiness >= 50) {
						animator.SetTrigger ("evolveGood");
						evolveSource.Play ();
						level = level + 1;
						timer.Reset ();
						timer.Start ();
					} else {
						animator.SetTrigger ("evolveBad");
						evolveSource.Play ();
						level = level + 1;
						timer.Reset ();
						timer.Start ();
					}
				} else if (level == 1 && timer.Elapsed.Minutes >= 15) {
					animator.SetTrigger ("goToHeaven");
					heavenSource.Play ();
					isDead = true;
					timer.Reset ();
				}
				
				hunger += 0.003f;
				poopPressure += 0.02f;


				if (isBored) {
					happiness -= 0.005f;
				} else
					boredom += 0.002f;

				if (isSick) {
					happiness -= 0.005f;
					deathSickTimer -= 0.05f;
				}

				if (isHungry) {
					happiness -= 0.05f;
				}

				if (hunger > 70f && isHungry == false) {
					sickSource.Play ();
					isHungry = true;
					animator.SetTrigger ("sad");
					timer.Stop ();
				}

				if (boredom > 80f && isBored == false) {
					makeBored ();
				}

				if (poopPressure >= 100f) {
					makePoop ();
					poopPressure = Random.Range (0, 20f);
				}
					
			}
		}

		if (isAsleep) {
			if (sleepTime < 100f) {
				sleepTime += 0.001f;
				if (happiness < 100f)
					happiness += 0.001f;
			} else
				wakeUp ();
		}
			
		if (happiness <= 0 || deathSickTimer <= 0 || hunger >= 100) {
			kill ();
		}
	}

	public void kill ()
	{
		animator.SetTrigger ("dead");
		deadSource.Play ();
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
			poopSource.Play ();
			poopCounter += 1;
			if (GameObject.FindWithTag ("MainMenu").activeSelf == true) {
				Instantiate (poop, new Vector3 (Random.Range (-2f, 2f), -1.6f, 2f), Quaternion.identity);
			} else {
				Instantiate (poop, new Vector3 (Random.Range (-2f, 2f), -1.6f, -3f), Quaternion.identity);
			}
		} else if (isSick == false) {
			makeSick ();
		}
	}

	public void makeSick ()
	{
		if (isSick == false) {
			sickSource.Play ();
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
		sickSource.Play ();
		timer.Stop ();
	}

	public void makeSleep ()
	{
		if (!isBored && !isAsleep && !isSick && !isHungry && !isDead && level > 0) {
			isAsleep = true;
			timer.Stop ();
			animator.SetTrigger ("sleep");
			goToSleepSource.Play ();
			GameObject.FindWithTag ("DirectionalLight").GetComponent<Light> ().intensity = 0.5f;
		}
	}

	public void wakeUp ()
	{
		if (isAsleep) {
			isAsleep = false;
			sleepTime = 0f;
			timer.Start ();
			animator.SetTrigger ("idle");
			wakeUpSource.Play ();
			GameObject.FindWithTag ("DirectionalLight").GetComponent<Light> ().intensity = 1f;
		}
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