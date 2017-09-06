using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tesText : MonoBehaviour {


	public Text text;

	void Start () {
		text = GetComponent<Text> ();
	}

	public void setText(float number)
	{
		text.text = number.ToString ();
	}
}
