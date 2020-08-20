using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    //public GameObject textManager;
    public int stage;

    // Start is called before the first frame update
    void Start()
    {
        //textManager.SetActive(true);
        TypingManagerScript.stageNumber = stage;
    }

    // Update is called once per frame
    void Update()
    {
        if (TypingManagerScript.isLevelFinished.Equals("Fail")) 
        {
            // transition to fail scene
        } 
        else if (TypingManagerScript.isLevelFinished.Equals("Pass"))
        {
            // transition to pass scene
        }
    }
}
