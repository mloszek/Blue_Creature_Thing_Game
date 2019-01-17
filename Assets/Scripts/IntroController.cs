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

    private Coroutine spawnCloudsCoroutine = null;
    private bool isShuttingDown = false;

    void Start()
    {
        Application.runInBackground = true;
        source.Play();

        CoroutinesHandler.Get().RunCoroutineWithCheck(ref spawnCloudsCoroutine, SpawnClouds());
    }

    private IEnumerator SpawnClouds()
    {
        yield return new WaitForSeconds(startWait);
        while (!isShuttingDown) 
        {
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(clouds, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(spawnWait);
        }
    }

    private void OnDisable()
    {
        isShuttingDown = true;
        CoroutinesHandler coroutinesHandler = CoroutinesHandler.Get();

        if (coroutinesHandler != null)
            coroutinesHandler.KillCoroutine(spawnCloudsCoroutine);
    }
}