using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMover : MonoBehaviour
{

    [SerializeField] private List<GameObject> clouds;

    private Coroutine cloudMovingCoroutine;
    private bool isShuttingDown = false;

    public float moveInterval = 0.1f;
    public Vector3 fastCloud = new Vector3(0.2f, 0, 0);
    public Vector3 slowCloud = new Vector3(0.1f, 0, 0);

    private void Start()
    {
        CoroutinesHandler.Get().RunCoroutineWithCheck(cloudMovingCoroutine, MoveClouds());
    }

    private IEnumerator MoveClouds()
    {
        yield return new WaitForSeconds(moveInterval);

        if (!isShuttingDown)
        {
            for (int i = 0; i < clouds.Count; i++)
            {
                if (i == 2 || i == 3)
                    clouds[i].transform.position += fastCloud;
                else
                    clouds[i].transform.position += slowCloud;
            }

            CoroutinesHandler.Get().RunCoroutineWithCheck(cloudMovingCoroutine, MoveClouds());
        }            
    }

    private void OnDisable()
    {
        isShuttingDown = true;
        CoroutinesHandler.Get().KillCoroutine(cloudMovingCoroutine);
    }
}
