using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageClearedScript : MonoBehaviour
{
    public int stage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("return"))
        {
            // go to level intro scene
            int sceneIndex = 4 * stage;
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
