using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMessage
{
    // class to store one text message that player has to send 

    public string receivedText;
    public string text;

    public bool swapLetter = false;
    public char swapFrom;
    public char swapTo;

    public bool skipLetter = false;
    public char charToSkip;

    public bool dupLetter = false;
    public char charToDup;

    public bool capitaliseLetter = false;
    public char charToCapitalise;

    public TextMessage(string[] textInfo)
    {
        receivedText = textInfo[0];
        text = textInfo[1];

        Boolean.TryParse(textInfo[2], out swapLetter);
        if (swapLetter)
        {
            swapFrom = textInfo[3][0];
            swapTo = textInfo[4][0];
        }

        Boolean.TryParse(textInfo[5], out skipLetter);
        if (skipLetter)
        {
            charToSkip = textInfo[6][0];
        }

        Boolean.TryParse(textInfo[7], out dupLetter);
        if (dupLetter)
        {
            charToDup = textInfo[8][0];
        }

        Boolean.TryParse(textInfo[9], out capitaliseLetter);
        if (capitaliseLetter)
        {
            charToCapitalise = textInfo[10][0];
        }
        
    }

}
