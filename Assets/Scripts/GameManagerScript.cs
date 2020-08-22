using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public float timeToPass;
    private float secPassed;
    //public GameObject textManager;
    public int stage;

    // Start is called before the first frame update
    void Awake()
    {
        //textManager.SetActive(true);
        UnityEngine.Debug.Log("Start Stage " + stage);
        TypingManagerScript.stageNumber = stage;
    }

    // Update is called once per frame
    void Update()
    {

        if (TypingManagerScript.stageStatus.Equals("In Progress")) { 
            secPassed += Time.deltaTime;
        }
        
        if (TypingManagerScript.stageStatus.Equals("Awaiting Player Start") && Input.GetKeyDown("return"))
        {
            TypingManagerScript.stageStatus = "Player Start";
        }
        else if ((secPassed > timeToPass || Input.GetKeyDown(KeyCode.Backslash)) && TypingManagerScript.stageStatus.Equals("In Progress"))
        {
            UnityEngine.Debug.Log("restart stage " + stage);
            Application.LoadLevel(Application.loadedLevel);
        }
        else if (TypingManagerScript.stageStatus.Equals("Pass") && Input.GetKeyDown("return"))
        {
            // transition to pass scene
            UnityEngine.Debug.Log("passed stage" + stage);

            int sceneIndex = 4 * stage - 1;
            UnityEngine.Debug.Log("Going into scene " + sceneIndex);
            SceneManager.LoadScene(sceneIndex);

        }
    }
}