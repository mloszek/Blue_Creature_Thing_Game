using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{

    [SerializeField] private Texture onDay;
    [SerializeField] private Texture onEvening;
    [SerializeField] private Texture onNight;
    [SerializeField] private MeshRenderer meshRenderer;

    private int currentTime;
    private Coroutine checkTimeCoroutine = null;
    private const int refreshTimeCheckingInterval = 60;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        CoroutinesHandler.Get().RunCoroutineWithCheck(ref checkTimeCoroutine, CheckHour());
    }

    private IEnumerator CheckHour()
    {

        currentTime = System.DateTime.Now.Hour;

        if (currentTime >= 8 && currentTime < 16)
        {
            meshRenderer.material.SetTexture("_MainTex", onDay);
        }
        else if (currentTime >= 16 && currentTime < 22)
        {
            meshRenderer.material.SetTexture("_MainTex", onEvening);
        }
        else
        {
            meshRenderer.material.SetTexture("_MainTex", onNight);
        }

        yield return new WaitForSecondsRealtime(refreshTimeCheckingInterval);

        CoroutinesHandler.Get().RunCoroutineWithCheck(ref checkTimeCoroutine, CheckHour());
    }
}
