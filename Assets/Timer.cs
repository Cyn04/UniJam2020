using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI uiText = null;
    public float mainTimer;

    private float timer;
    private bool canCount = true;
    private bool doOnce = false;

    void Start()
    {
        timer = mainTimer;
        uiText.text = timer.ToString("F");
    }

    void Update()
    {
        if (timer >= 0.0f && canCount && TypingManagerScript.stageStatus.Equals("In Progress"))
        {
            timer -= Time.deltaTime;
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
