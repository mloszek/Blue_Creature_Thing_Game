using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroController : MonoBehaviour
{
    [SerializeField] private GameObject clouds;
    [SerializeField] private float spawnWait;
    [SerializeField] private float startWait;
    [SerializeField] private Vector2 spawnPosition;
    [SerializeField] private AudioSource source;

    private Coroutine spawnCloudsCoroutine;

    private static IntroController instance;

    public static IntroController Get()
    {
        return instance;
    }

    public void GetNumber()
    {
        instance.gameObject.SetActive(false);
    }

    void Start()
    {
        instance = this;
        Application.runInBackground = true;
        source.Play();

        if (spawnCloudsCoroutine != null)
        {
            StopCoroutine(spawnCloudsCoroutine);
            spawnCloudsCoroutine = null;
        }
        spawnCloudsCoroutine = StartCoroutine(SpawnClouds());
    }

    private IEnumerator SpawnClouds()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(clouds, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(spawnWait);
        }
    }

    private void OnDisable()
    {
        instance = null;

        if (spawnCloudsCoroutine != null)
        {
            StopCoroutine(spawnCloudsCoroutine);
            spawnCloudsCoroutine = null;
        }
    }
}
