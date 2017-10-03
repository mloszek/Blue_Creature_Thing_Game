using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameController : MonoBehaviour
{

	public SoundManager soundManager;
	public GameObject coin;
	public GameObject xMark;
	public GameObject dropCollider;
	public GameObject backButton;
	public GameObject ingameCanvas;
	public AudioSource source;
	public AudioClip arriveSound;
	public AudioClip gameOver;
	public float startWait;
	public float spawnWait;
	public float waveWait;

	private float level;
	private IEnumerator game;
	private int lifesLeft;

	System.Diagnostics.Stopwatch minigameTimer;

	public void beginGame ()
	{
		source.volume = GameObject.FindWithTag ("Player").GetComponent<tesText> ().getVolume ();
		soundManager.setVolume (GameObject.FindWithTag ("Player").GetComponent<tesText> ().getVolume());
		clearMarks ();
		level = 0f;
		lifesLeft = 3;
		dropCollider.SetActive (true);
		backButton.SetActive (false);
		minigameTimer = new System.Diagnostics.Stopwatch ();
		GameObject.FindWithTag ("scoreText").GetComponent<ScoreController> ().resetScore ();
		game = SpawnCoins ();
		StartCoroutine (game);
	}

	public void lifeLost ()
	{

		if (lifesLeft > 1) {
			Instantiate (xMark, new Vector2 (2f - (float)lifesLeft, 3f), Quaternion.identity);
			lifesLeft--;
		} else {
			Instantiate (xMark, new Vector2 (2f - (float)lifesLeft, 3f), Quaternion.identity);
			StopCoroutine (game);

			GameObject[] drop = GameObject.FindGameObjectsWithTag ("coin");
			foreach (GameObject item in drop) {
				Destroy (item);
			}

			backButton.SetActive (true);
			source.Play ();
		}

	}

	IEnumerator SpawnCoins ()
	{
		while (level < 40) {
			if (level == 0) {
				yield return new WaitForSeconds (startWait);
			} else {
				yield return new WaitForSeconds (waveWait);
			}

			minigameTimer.Start ();
			while (minigameTimer.Elapsed.Seconds <= 12) {
				Vector2 spawnPosition = new Vector2 (Random.Range (-4.8f, 4.8f), 3f);
				Quaternion spawnRotation = Quaternion.identity;
				coin.GetComponent<coinDropper> ().setDropSpeed (2f + level);
				soundManager.playSound2 (arriveSound, 1f + (0.08f * level));
				Instantiate (coin, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait - (0.1f * level));
			}
			minigameTimer.Reset ();
			level++;
		}
	}

	public void shutDownGame()
	{
		
		clearMarks ();
		ingameCanvas.SetActive (true);
		GameObject.FindWithTag ("Creature").transform.position = new Vector3 (0, 0, 0);
		if (GameObject.FindWithTag ("skull") != null) 
		{
			GameObject.FindWithTag ("skull").transform.position = new Vector3 (0, 2.22f, 0);
		}

		GameObject[] poo = GameObject.FindGameObjectsWithTag ("poo");
		if (poo != null) 
		{
			foreach (GameObject poop in poo) {
				poop.transform.position = new Vector3 (Random.Range(-2f, 2f), -1.6f, -3f);
			}
		}
		GameObject.FindWithTag ("Creature").GetComponent<CreatureController> ().isMinigameRunning = false;
		dropCollider.SetActive (false);
		gameObject.SetActive (false);
	}

	void clearMarks()
	{
		GameObject[] xMarks = GameObject.FindGameObjectsWithTag ("xMark");
		foreach (GameObject mark in xMarks) {
			Destroy (mark);
		}
	}

	public long getLevel(){
		return (long)level;
	}

}
