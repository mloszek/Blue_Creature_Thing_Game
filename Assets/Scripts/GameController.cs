using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public GameObject clouds;
	public float spawnWait;
	public float startWait;
	public float spawnPointX;
	public float spawnPointY;
	public AudioSource source;

	void Start ()
	{
		source.Play ();
		StartCoroutine (SpawnClouds ());
	}

	IEnumerator SpawnClouds ()
	{
		yield return new WaitForSeconds (startWait);
		while (true) {
			Vector2 spawnPosition = new Vector2 (spawnPointX, spawnPointY);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (clouds, spawnPosition, spawnRotation);
			yield return new WaitForSeconds (spawnWait);
		}
	}
}
