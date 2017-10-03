using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinksController : MonoBehaviour
{
	public Text text;
	public Button button;
	private Vector3 zeroPosition;
	private Vector3 positionWhenCredits;
	private bool isShown = false;

	void Start ()
	{
		text.text = "";
	}

	void Update ()
	{

		zeroPosition = new Vector3 (Screen.width / 2, 340, 0);
		positionWhenCredits = new Vector3 (Screen.width / 2, -10, 0);

		if (isShown) {
			button.interactable = false;
			button.transform.position = Vector3.MoveTowards (button.transform.position, positionWhenCredits, Time.deltaTime * 500);
			text.text = "miloszloszek@gmail.com"; /* \ngithub.com/mloszek";*/
		} else {
			if (button.transform.position != zeroPosition) {
				button.interactable = true;
				button.transform.position = zeroPosition;
				text.text = "";
			}
		}
	}

	public void showC ()
	{
		isShown = !isShown;
	}
}
