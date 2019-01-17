using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    [SerializeField] private IntroController introController;
    [SerializeField] private Button button1;
    [SerializeField] private Button button2;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float fadeInTime = 0.5f;
    [SerializeField] private float fadeOutTime = 1.0f;
    private float elapsedTime = 0;
    private AudioSource musicSource;

    private Coroutine fadeInCoroutine = null;
    private Coroutine fadeOutCoroutine = null;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
    }

    void Start()
    {
        CoroutinesHandler.Get().RunCoroutineWithCheck(ref fadeInCoroutine, DoFadeIn());
    }

    public void FadeOut()
    {
        button1.interactable = false;
        button2.interactable = false;

        CoroutinesHandler.Get().KillCoroutine(fadeInCoroutine);

        if (fadeOutCoroutine != null)
        {
            return;
        }
        CoroutinesHandler.Get().RunCoroutine(fadeOutCoroutine, DoFadeOut());
    }

    private IEnumerator DoFadeIn()
    {
        elapsedTime = 0;

        while (canvasGroup.alpha < 1.0f)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(0 + (elapsedTime / fadeInTime));
            yield return null;
        }
        yield return null;
    }

    private IEnumerator DoFadeOut()
    {
        elapsedTime = 0;

        musicSource = introController.GetComponent<AudioSource>();
        var isMusicSourceNull = musicSource == null ? true : false;

        while (canvasGroup.alpha > 0 && !isMusicSourceNull)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(1 - (elapsedTime / fadeOutTime));
            musicSource.volume = Mathf.Clamp01(1 - (elapsedTime / fadeOutTime));

            yield return null;
        }

        SceneManager.LoadScene("SelectionScene");
    }

    private void OnDisable()
    {
        Coroutine[] coroutinesToKill =
        {
            fadeInCoroutine,
            fadeOutCoroutine
        };

        CoroutinesHandler coroutinesHandler = CoroutinesHandler.Get();

        if (coroutinesHandler != null)
            coroutinesHandler.KillGivenCoroutines(coroutinesToKill);
    }
}