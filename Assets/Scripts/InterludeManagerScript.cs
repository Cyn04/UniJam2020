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
        UnityEngine.Debug.Log("star interlude " + interlude);
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
            
            // load opponent intro
            int sceneIndex = 4 * interlude + 1;

            if (interlude == 6)
            {
                sceneIndex = 22;
            }
            UnityEngine.Debug.Log("Going into scene " + sceneIndex);
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
