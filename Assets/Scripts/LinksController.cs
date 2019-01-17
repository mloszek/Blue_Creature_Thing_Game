using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinksController : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private Button button;

    private Vector3 zeroPosition;
    private Vector3 positionWhenCredits;
    private bool isShown = false;

    private Coroutine moveOutOfScreenCoroutine;
    private Vector3 moveVector = new Vector3(0, 10f, 0);

    private const string creditText = "by lohu";

    void Start()
    {
        text.text = string.Empty;
        zeroPosition = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        positionWhenCredits = new Vector3(Screen.width / 2, -10, 0);
    }

    public void ManageCredits()
    {
        if (!isShown)
            ShowCredits();
        else
            HideCredits();
    }

    private void ShowCredits()
    {
        button.interactable = false;
        CoroutinesHandler.Get().RunCoroutineWithCheck(moveOutOfScreenCoroutine, MoveOutOfScreen());
        text.text = creditText;
        isShown = true;
    }

    private IEnumerator MoveOutOfScreen()
    {
        yield return new WaitForSeconds(0);

        button.transform.position -= moveVector;

        if (button.transform.position.y > positionWhenCredits.y)
        {
            CoroutinesHandler.Get().RunCoroutineWithCheck(moveOutOfScreenCoroutine, MoveOutOfScreen());
        }
    }

    private void HideCredits()
    {
        button.interactable = true;
        CoroutinesHandler.Get().KillCoroutine(moveOutOfScreenCoroutine);
        button.transform.position = zeroPosition;
        text.text = "";
        isShown = false;
    }

    private void OnDisable()
    {
        CoroutinesHandler.Get().KillCoroutine(moveOutOfScreenCoroutine);
    }
}
