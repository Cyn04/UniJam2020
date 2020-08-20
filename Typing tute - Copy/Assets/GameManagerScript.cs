using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    //public GameObject textManager;
    public int stage;
    private int FINAL_STAGE = 5;

    // Start is called before the first frame update
    void Awake()
    {
        //textManager.SetActive(true);
        TypingManagerScript.stageNumber = stage;
    }

    // Update is called once per frame
    void Update()
    {
        if (TypingManagerScript.stageStatus.Equals("Fail")) 
        {
            // transition to fail scene
        } 
        else if (TypingManagerScript.stageStatus.Equals("Pass"))
        {
            // transition to pass scene
            UnityEngine.Debug.Log("passed stage" + stage);

            if (stage == FINAL_STAGE)
            {
                //to end game scene
            }
        }
    }
}
