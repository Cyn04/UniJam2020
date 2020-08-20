using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoplayClass
{
    public string systemText;
    public string receivedText;
    public string sentText;
    
    public AutoplayClass(string[] textInfo)
    {
        systemText = textInfo[0];
        receivedText = textInfo[1];
        sentText = textInfo[2];
    }
}
