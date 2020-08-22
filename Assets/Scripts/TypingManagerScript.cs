using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics;


public class TypingManagerScript : MonoBehaviour
{
    public static string stageStatus;  // can be: "In Progress", "Fail", "Pass"
    //public GameObject timer;

    private List<TextMessage> toType = new List<TextMessage>(); 
    public TextMeshProUGUI displayOutput;
    public TextMeshProUGUI ruleMessage;

    public static int stageNumber;
    private int textArrayPos = 0;
    private int currTextPos = 0;

    private int mistakeCount = 0; 
    private bool endOfText = false; 

    private char SPECIAL_CHAR = '|';
    private bool skippedChar = false;
    private bool dupedLetter = false;
    private bool receiveNextText = true;

    public GameObject LinkToScript;

    void Start()
    {
        ReadCsvFile(stageNumber);
        stageStatus = "In Progress";

        // Find messsagefactory object and get its script
        LinkToScript = GameObject.Find("MessageFactory");
        MessageFactory messageFactoryStart = LinkToScript.GetComponent<MessageFactory>();
        messageFactoryStart.SendMessageToChat(toType[textArrayPos].receivedText, "NPC");

        DisplayRule();
        GetText();
    }

    private void GetText()
    {
        // find the next text in the toType array
        displayOutput.text = toType[textArrayPos].text;
        currTextPos = 0;
        endOfText = false;
    }

    private void ReadCsvFile(int stage)
    {
        string filename = "stage"+stage;
        UnityEngine.Debug.Log("reading stage" + stage);

        TextAsset readIn = Resources.Load<TextAsset>(filename);
        string[] csvValues = readIn.text.Split(new char[] { '\n' });

        // replace commas
        for (int i = 1; i < csvValues.Length - 1; i++)
        {
            string[] oneRow = csvValues[i].Split(new char[] { ',' });
            oneRow[0] = oneRow[0].Replace(SPECIAL_CHAR, ',');
            oneRow[1] = oneRow[1].Replace(SPECIAL_CHAR, ',');

            TextMessage oneText = new TextMessage(oneRow);
            toType.Add(oneText);
        }
    }

    private void Update()
    {
        if (stageStatus == "In Progress" && receiveNextText)
        {
            
            CheckInput();
            
        }
    }

    private void CheckInput()
    {
        // pressed enter at the end of text
        if (endOfText == true && Input.GetKeyDown("return"))
        {

            //SoundManagerScript.PlaySound("sendText");

            LinkToScript = GameObject.Find("MessageFactory");
            MessageFactory messageFactorySend = LinkToScript.GetComponent<MessageFactory>();
            messageFactorySend.SendMessageToChat(toType[textArrayPos].text, "p1"); 

            textArrayPos++;

            //end of convo
            if (textArrayPos == toType.Count)
            {
                UnityEngine.Debug.Log("stage comp");
                displayOutput.text = "<color=#1D1D1D>Press ENTER to Continue...</color>";
                ruleMessage.text = "";
                stageStatus = "Pass";
            } 
            else
            {
                // triggers the convo to proceed
                StartCoroutine(ReceiveMessage());
            }

        }


        else if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.LeftShift) && !Input.GetKeyDown(KeyCode.RightShift) && !Input.GetKeyDown(KeyCode.CapsLock))
        {
            char desiredChar = toType[textArrayPos].text[currTextPos];

            // skipLetter mechanism
            if (toType[textArrayPos].skipLetter && desiredChar.Equals(toType[textArrayPos].charToSkip))
            {
                if (currTextPos + 1 == toType[textArrayPos].text.Length)
                {
                    endOfText = true;
                    return;
                }
                desiredChar = toType[textArrayPos].text[currTextPos + 1];
                skippedChar = true;
            }

            // swapLetter mechanism
            if (toType[textArrayPos].swapLetter && desiredChar.Equals(toType[textArrayPos].swapFrom))
            {
                desiredChar = toType[textArrayPos].swapTo;
            }

            // capitaliseLetter mechanism
            else if (toType[textArrayPos].capitaliseLetter && desiredChar.Equals(toType[textArrayPos].charToCapitalise))
            {
                desiredChar = char.ToUpper(desiredChar);
            }



            // compare if correct char is entered
            string entered = Input.inputString;
            char charEntered = entered[0];

            //typed correct char
            if (endOfText == false && charEntered.Equals(desiredChar))
            {
                SoundManagerScript.PlaySound("correctChar");


                // dupLetter mechanism
                if (toType[textArrayPos].dupLetter && desiredChar.Equals(toType[textArrayPos].charToDup) && dupedLetter == false)
                {
                    dupedLetter = true;
                    return;
                }
                else if (toType[textArrayPos].dupLetter && desiredChar.Equals(toType[textArrayPos].charToDup) && dupedLetter)
                {
                    dupedLetter = false;
                }

                // update currTextPos according to the rules
                if (skippedChar)
                {
                    currTextPos += 2;
                    skippedChar = false;
                }
                else
                {
                    currTextPos++;
                }

                UpdateCorrectDisplay();

                //check if all the text has been typed
                if (currTextPos == toType[textArrayPos].text.Length)
                {
                    endOfText = true;
                }

                //made error
            }
            else
            {
                //All error effects: text shake, buzzer sound
                UpdateIncorrectDisplay();
                SoundManagerScript.PlaySound("incorrectChar");
                mistakeCount++;
            }

        }

    }

    private void UpdateCorrectDisplay()
    {
        string typedText = toType[textArrayPos].text.Substring(0, currTextPos);
        string notTypedText = toType[textArrayPos].text.Substring(currTextPos, toType[textArrayPos].text.Length - currTextPos);

        displayOutput.text = $"<color=#0F0F0F>{typedText}</color>{notTypedText}";
    }

    private void UpdateIncorrectDisplay()
    {
        string typedText = toType[textArrayPos].text.Substring(0, currTextPos);
        char incorrectChar = toType[textArrayPos].text[currTextPos];
        string notTypedText = toType[textArrayPos].text.Substring(currTextPos + 1, toType[textArrayPos].text.Length - (currTextPos + 1));

        if (incorrectChar == ' ')
        {
            incorrectChar = '_';
        }

        displayOutput.text = $"<color=#0F0F0F>{typedText}</color><color=#ba2f1a>{incorrectChar}</color>{notTypedText}";
    }

    private void DisplayRule()
    {
        string rule = "Special Rules:\n\n";

        if (toType[textArrayPos].skipLetter)
        {
            rule += $"<color=#3c912c>Skip</color> <color=#D77097>{toType[textArrayPos].charToSkip}</color>\n";
        }

        if (toType[textArrayPos].swapLetter)
        {
            rule += $"<color=#3c912c>Replace</color> <color=#D77097>{toType[textArrayPos].swapFrom}</color> with <color=#D77097>{toType[textArrayPos].swapTo}</color>\n";
        }

        if (toType[textArrayPos].dupLetter)
        {
            rule += $"Type <color=#D77097>{toType[textArrayPos].charToDup}</color> <color=#3c912c>twice</color>\n";
        }

        if (toType[textArrayPos].capitaliseLetter)
        {
            rule += $"<color=#3c912c>Capitalise</color> <color=#D77097>{toType[textArrayPos].charToCapitalise}</color>\n";
        }

        ruleMessage.text = rule;
    }

    IEnumerator ReceiveMessage()
    {
        receiveNextText = false;
        displayOutput.text = "";
        ruleMessage.text = "Special Rules:";

        yield return new WaitForSeconds(2.0f);

        LinkToScript = GameObject.Find("MessageFactory");
        MessageFactory messageFactoryReceive = LinkToScript.GetComponent<MessageFactory>();
        messageFactoryReceive.SendMessageToChat(toType[textArrayPos].receivedText, "NPC");

        receiveNextText = true;
        GetText();
        DisplayRule();
    }
}
