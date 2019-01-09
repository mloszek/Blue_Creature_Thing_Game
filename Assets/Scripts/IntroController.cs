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

    void Start()
    {
        Application.runInBackground = true;
        source.Play();

        if (spawnCloudsCoroutine != null)
        {
            StopCoroutine(spawnCloudsCoroutine);
            spawnCloudsCoroutine = null;
        }
        spawnCloudsCoroutine = StartCoroutine(SpawnClouds());
    }

    IEnumerator SpawnClouds()
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
        if (spawnCloudsCoroutine != null)
        {
            StopCoroutine(spawnCloudsCoroutine);
            spawnCloudsCoroutine = null;
        }
    }
}
