using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI uiText = null;

    private float timer;
    private bool canCount = true;
    private bool doOnce = false;
    private GameManagerScript gameManagerScript;

    void Start()
    {
        GameObject GameManager = GameObject.Find("GameManager");
        gameManagerScript = GameManager.GetComponent<GameManagerScript>();
        timer = gameManagerScript.timeToPass;
        uiText.text = timer.ToString("F");
    }

    void Update()
    {
        if (timer >= 0.0f && canCount && TypingManagerScript.stageStatus.Equals("In Progress"))
        {
            timer = gameManagerScript.timeToPass - gameManagerScript.secPassed;
            uiText.text = timer.ToString("F");
        }

        else if (timer <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            uiText.text = "0.00";
            timer = 0.0f;

        }

    }

}
