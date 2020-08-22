using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterludeManagerScript : MonoBehaviour
{
    public int interlude;

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
        UnityEngine.Debug.Log("hi");
        if (AutoplayScript.finishedAutoplay)
        {
            UnityEngine.Debug.Log("to next stage");
            // load opponent intro
            int sceneIndex = 4 * interlude + 1;
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
