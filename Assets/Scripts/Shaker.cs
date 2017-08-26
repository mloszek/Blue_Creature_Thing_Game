using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour {
	/*
	public float smooth = 2.0F;
	public float tiltAngle = 30.0F;
	public float waitTime;
	public float startTime = 0;
	private Quaternion pointZero = Quaternion.Euler (0, 0, 0);

	void Update () {

		startTime += Time.deltaTime;

		if (startTime > waitTime) {
			startTime = 0;
			shake ();
		}
	
	}

	void shake () {

		Quaternion targetLeft = Quaternion.Euler (0, 0, tiltAngle);
		Quaternion targetRight = Quaternion.Euler (0, 0, -tiltAngle);
		transform.rotation = Quaternion.Slerp (transform.rotation, targetLeft, Time.deltaTime * smooth);
		transform.rotation = Quaternion.Slerp (transform.rotation, targetRight, Time.deltaTime * smooth);
		transform.rotation = Quaternion.Slerp (transform.rotation, pointZero, Time.deltaTime * smooth);
	}
	*/
}
