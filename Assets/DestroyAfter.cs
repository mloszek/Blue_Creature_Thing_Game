using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    [SerializeField]
    private float timeTillDestroy = 10f;

    void Start()
    {
        Destroy(this.gameObject, timeTillDestroy);
    }
}
