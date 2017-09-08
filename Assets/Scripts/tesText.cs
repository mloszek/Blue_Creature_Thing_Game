using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class tesText : MonoBehaviour {


	public Text text;

	void Start () {
		text = GetComponent<Text> ();
	}

	public void setText(TimeSpan time)
	{
		text.text = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
			time.Hours, time.Minutes, time.Seconds,
			time.Milliseconds / 10);
	}
}
