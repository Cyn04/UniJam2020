﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }
    }
}
