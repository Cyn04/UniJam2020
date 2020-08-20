using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AutoplayScript : MonoBehaviour
{
    public static bool finishedAutoplay = false;

    private List<AutoplayClass> toAutoplay = new List<AutoplayClass>();
    private int listIndex = 0;

    public static int stageNumber;
    private char SPECIAL_CHAR = '|';

    public GameObject LinkToScript;

    void Start()
    {
        readCsvFile(stageNumber);
        playText();
    }

    void readCsvFile(int stage)
    {
        string filename = "interlude" + stage;

        TextAsset readIn = Resources.Load<TextAsset>(filename);
        string[] csvValues = readIn.text.Split(new char[] { '\n' });

        // replace commas
        for (int i = 1; i < csvValues.Length - 1; i++)
        {
            string[] oneRow = csvValues[i].Split(new char[] { ',' });
            oneRow[0] = oneRow[0].Replace(SPECIAL_CHAR, ',');
            oneRow[1] = oneRow[1].Replace(SPECIAL_CHAR, ',');

            AutoplayClass oneText = new AutoplayClass(oneRow);
            toAutoplay.Add(oneText);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!finishedAutoplay)
        {
            playText();
        } 
        
    }

    private void playText()
    {
        if (!toAutoplay[listIndex].systemText.Equals("-"))
        {
            // send system message
            StartCoroutine(Wait());
        }

        if (!toAutoplay[listIndex].receivedText.Equals("-"))
        {
            // Find messsagefactory object and get its script
            LinkToScript = GameObject.Find("MessageFactory");
            MessageFactory messageFactoryReceive = LinkToScript.GetComponent<MessageFactory>();
            messageFactoryReceive.SendMessageToChat(toAutoplay[listIndex].receivedText, "NPC");

            StartCoroutine(Wait());
        }

        if (!toAutoplay[listIndex].sentText.Equals("-"))
        {
            // Find messsagefactory object and get its script
            LinkToScript = GameObject.Find("MessageFactory");
            MessageFactory messageFactorySend = LinkToScript.GetComponent<MessageFactory>();
            messageFactorySend.SendMessageToChat(toAutoplay[listIndex].sentText, "p1");

            StartCoroutine(Wait());
        }

        listIndex++;

        if (listIndex == toAutoplay.Count)
        {
            finishedAutoplay = true;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
    }
}
