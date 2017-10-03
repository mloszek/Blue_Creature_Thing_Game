using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreController : MonoBehaviour {

	public Text scoreText;

	private long score = 0;

	void Start () 
	{
		scoreText = GetComponent<Text> ();
		score = 0;
		scoreText.text = score.ToString();
	}

	public void setScore(long points)
	{
		score += points;
		scoreText.text = score.ToString();
	}

	public void resetScore()
	{
		score = 0;
		scoreText.text = score.ToString();
	}
}
