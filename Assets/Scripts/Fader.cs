using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
	[SerializeField] private Button button1;
	[SerializeField] private Button button2;
	private CanvasGroup canvasGroup;
	private float elapsedTime = 0;
	private float fadeInTime = 0.5f;
	private float fadeOutTime = 1.0f;
	private string sceneName; 

	private void Awake ()
	{
		sceneName = SceneManager.GetActiveScene().name;
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
			canvasGroup.alpha = Mathf.Clamp01 (0 + (elapsedTime / fadeInTime));
			yield return null;
		}
		yield return null;
	}

	IEnumerator DoFadeOut ()
	{
		elapsedTime = 0;

		while (canvasGroup.alpha > 0) {
			elapsedTime += Time.deltaTime;
			canvasGroup.alpha = Mathf.Clamp01 (1 - (elapsedTime / fadeOutTime));
			GameObject.FindWithTag ("GameController").GetComponent<AudioSource> ().volume = Mathf.Clamp01 (1 - (elapsedTime / fadeOutTime));
			yield return null;
		}

		if (sceneName == "chmurki") {
			SceneManager.LoadScene ("selection");
		}
	}
}