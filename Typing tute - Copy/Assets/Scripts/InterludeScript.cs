using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningSceneScript : MonoBehaviour
{
    public int interlude;

    // Start is called before the first frame update
    void Awake()
    {
        AutoplayScript.interludeNumber = interlude;
    }

    // Update is called once per frame
    void Update()
    {
        if (AutoplayScript.finishedAutoplay)
        {
            UnityEngine.Debug.Log("to next stage");
            // load opponent intro
        }
    }
}
