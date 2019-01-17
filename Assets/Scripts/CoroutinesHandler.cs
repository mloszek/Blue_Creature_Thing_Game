using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutinesHandler : MonoBehaviour
{
    private static CoroutinesHandler instance;
    private static object _lock = new object();
    private static bool isShutingDown = false;

    public static CoroutinesHandler Get()
    {
        if (isShutingDown)
            return null;

        lock (_lock)
        {
            if (instance == null)
            {
                instance = (CoroutinesHandler) FindObjectOfType(typeof(CoroutinesHandler));

                if (instance == null)
                {
                    GameObject newGameObject = new GameObject(typeof(CoroutinesHandler).ToString());
                    instance = newGameObject.AddComponent<CoroutinesHandler>();
                    DontDestroyOnLoad(newGameObject);
                }                
            }

            return instance;
        }
    }

    public void RunCoroutine(Coroutine coroutine, IEnumerator enumerator)
    {
        coroutine = StartCoroutine(enumerator);
    }

    public void RunCoroutineWithCheck(Coroutine coroutine, IEnumerator enumerator)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
        coroutine = StartCoroutine(enumerator);
    }

    public void KillCoroutine(Coroutine coroutine)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }

    public void KillGivenCoroutines(Coroutine[] coroutines)
    {
        foreach (Coroutine coroutine in coroutines)
            KillCoroutine(coroutine);
    }

    private void OnApplicationQuit()
    {
        isShutingDown = true;
    }

    private void OnDisable()
    {
        isShutingDown = true;
    }
}