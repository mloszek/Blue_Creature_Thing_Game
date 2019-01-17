using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMover : MonoBehaviour
{
    [SerializeField] private Vector3 fastCloud = new Vector3(0.02f, 0, 0);
    [SerializeField] private Vector3 slowCloud = new Vector3(0.01f, 0, 0);
    [SerializeField] private List<GameObject> clouds; 

    private Coroutine cloudMovingCoroutine = null;
    private bool isShuttingDown = false;

    private void Start()
    {
        CoroutinesHandler.Get().RunCoroutineWithCheck(ref cloudMovingCoroutine, MoveClouds());
    }

    private IEnumerator MoveClouds()
    {
        yield return null;

        if (!isShuttingDown)
        {
            for (int i = 0; i < clouds.Count; i++)
            {
                if (i == 2 || i == 3)
                    clouds[i].transform.position += fastCloud;
                else
                    clouds[i].transform.position += slowCloud;
            }

            CoroutinesHandler.Get().RunCoroutineWithCheck(ref cloudMovingCoroutine, MoveClouds());
        }
    }

    private void OnDisable()
    {
        isShuttingDown = true;
        CoroutinesHandler coroutinesHandler = CoroutinesHandler.Get();

        if (coroutinesHandler != null)
            coroutinesHandler.KillCoroutine(cloudMovingCoroutine);
    }
}
