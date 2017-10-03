using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinDropper : MonoBehaviour {

	public AudioClip destroy;
	public float dropSpeed = 0f;

	public void setDropSpeed(float speed)
	{
		dropSpeed = speed;
	}

	void FixedUpdate ()
	{
		transform.Translate (Vector2.down * dropSpeed * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "dropCollider") {
			GameObject.FindWithTag ("MiniGameController").GetComponent<MiniGameController> ().lifeLost ();
			Destroy (gameObject);
		}
	}

	void OnMouseDown()
	{
		GameObject.FindWithTag ("MiniGameController").GetComponent<SoundManager> ().playSound2 (destroy, 1f);
		GameObject.FindWithTag ("scoreText").GetComponent<ScoreController> ().setScore (10 * 
			(GameObject.FindWithTag ("MiniGameController").GetComponent<MiniGameController> ().getLevel() + 1));
		Destroy (this.gameObject);
	}
}
