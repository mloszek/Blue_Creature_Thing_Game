using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMover : MonoBehaviour {

    [SerializeField]
    private List<GameObject> clouds;

    private Coroutine cloudMovingCoroutine;

    public float moveInterval = 0.1f;
    public Vector3 fastCloud = new Vector3(0.2f, 0, 0);
    public Vector3 slowCloud = new Vector3(0.1f, 0, 0);

    private void Start()
    {
        if (cloudMovingCoroutine != null)
        {
            StopCoroutine(cloudMovingCoroutine);
            cloudMovingCoroutine = null;
        }
        cloudMovingCoroutine = StartCoroutine(MoveClouds());
    }

    private IEnumerator MoveClouds()
    {
        yield return new WaitForSeconds(moveInterval);

        for (int i = 0; i < clouds.Count; i++)
        {
            if (i == 2 || i == 3)
                clouds[i].transform.position += fastCloud;
            else
                clouds[i].transform.position += slowCloud;
        }

        cloudMovingCoroutine = StartCoroutine(MoveClouds());
    }

    private void OnDisable()
    {
        if (cloudMovingCoroutine != null)
        {
            StopCoroutine(cloudMovingCoroutine);
            cloudMovingCoroutine = null;
        }
    }
}
