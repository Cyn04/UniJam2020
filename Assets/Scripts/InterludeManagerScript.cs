using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class InterludeManagerScript : MonoBehaviour
{
    public int interlude;

    public TextMeshProUGUI displayMessage;

    // Start is called before the first frame update
    void Awake()
    {
        UnityEngine.Debug.Log("interlude start");
        AutoplayScript.interludeNumber = interlude;
    }

    void Start()
    {

    }

    void Update()
    {
        if (AutoplayScript.finishedAutoplay)
        {
            displayMessage.text = "Press ENTER to Continue...";
            
        }

        if (AutoplayScript.finishedAutoplay && Input.GetKeyDown("return"))
        {
            UnityEngine.Debug.Log("to next stage");
            // load opponent intro
            int sceneIndex = 4 * interlude + 1;
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
