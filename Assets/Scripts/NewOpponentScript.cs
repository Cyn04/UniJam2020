using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewOpponentScript : MonoBehaviour
{
    public int stage;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Debug.Log("Start NewOpponent " + stage);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("return"))
        {
            // go to level intro scene
            int sceneIndex = 4 * stage - 2;
            UnityEngine.Debug.Log("Going into scene " + sceneIndex);
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
