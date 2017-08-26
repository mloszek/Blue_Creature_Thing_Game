using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{

	public Button button1;
	public Button button2;
	private CanvasGroup canvasGroup;
	private float elapsedTime = 0;
	private float fadeTime = 1.0f;

	private void Awake ()
	{
		canvasGroup = GetComponent<CanvasGroup> ();
		canvasGroup.alpha = 0;
	}

	void Start ()
	{
		StartCoroutine (DoFadeIn ());
	}

	public void FadeOut ()
	{
		button1.interactable = false;
		button2.interactable = false;
		StartCoroutine (DoFadeOut ());
	}

	IEnumerator DoFadeIn ()
	{
		elapsedTime = 0;

		while (canvasGroup.alpha < 1.0f) {
			elapsedTime += Time.deltaTime;
			canvasGroup.alpha = Mathf.Clamp01 (0 + (elapsedTime / fadeTime));
			yield return null;
		}
		yield return null;
	}

	IEnumerator DoFadeOut ()
	{
		elapsedTime = 0;

		while (canvasGroup.alpha > 0) {
			elapsedTime += Time.deltaTime;
			canvasGroup.alpha = Mathf.Clamp01 (1 - (elapsedTime / fadeTime));
			yield return null;
		}
		SceneManager.LoadScene ("selection");
	}
}
