using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoplayClass
{
    public string text;
    public string sender;
    
    public AutoplayClass(string[] textInfo)
    {
        text = textInfo[0];
        sender = textInfo[1];
    }
}
