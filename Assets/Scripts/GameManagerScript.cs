using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public float timeToPassStage;
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
        secPassed += Time.deltaTime;
        UnityEngine.Debug.Log("sec passed: " + secPassed);
        if (secPassed > timeToPassStage || Input.GetKeyDown(KeyCode.Backslash))
        {
            UnityEngine.Debug.Log("failed stage " + stage);
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