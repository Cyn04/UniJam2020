using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningSceneScript : MonoBehaviour
{
    public static bool finishedScene = false;
    public int stage;

    // Start is called before the first frame update
    void Awake()
    {
        AutoplayScript.stageNumber = stage;
    }

    // Update is called once per frame
    void Update()
    {
        if (finishedScene)
        { 
            // load opponent intro for stage 1
        }
    }
}
