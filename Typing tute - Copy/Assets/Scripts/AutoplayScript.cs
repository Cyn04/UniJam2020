using System.Collections;
using System.Collections.Generic;
//using System.Media;
using System.Threading;
using UnityEngine;

public class AutoplayScript : MonoBehaviour
{
    public static bool finishedAutoplay = false;
    private bool continueSending = true;

    private List<AutoplayClass> toAutoplay = new List<AutoplayClass>();
    private int listIndex = 0;

    private float waitTime = 0.0f;
    private string player = "";
    private string toSend = "";

    public static int stageNumber;
    private char SPECIAL_CHAR = '|';

    public GameObject LinkToScript;
    private MessageFactory messageFactorySend;

    void Start()
    {
        // Find messsagefactory object and get its script
        LinkToScript = GameObject.Find("MessageFactory");
        messageFactorySend = LinkToScript.GetComponent<MessageFactory>();

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
        if ((!finishedAutoplay) && continueSending)
        {
            playText();
        }

    }

    private void playText()
    {
        

        if (!toAutoplay[listIndex].systemText.Equals("-"))
        {
            // send system message
            waitTime = 2.0f;
            //StartCoroutine(Wait());
        }

        while (continueSending == false)
        {
            // do absolutely nothing
        }

        if (!toAutoplay[listIndex].receivedText.Equals("-"))
        {
            
            UnityEngine.Debug.Log("NPC");
            waitTime = 3.0f;
            player = "NPC";
            toSend = toAutoplay[listIndex].receivedText;

            StartCoroutine(Wait());
        }

        while (continueSending == false)
        {
            // do absolutely nothing
        }

        if (!toAutoplay[listIndex].receivedText.Equals("-"))
        {

            UnityEngine.Debug.Log("p1");

            waitTime = 3.0f;
            player = "p1";
            toSend = toAutoplay[listIndex].sentText;

            //StartCoroutine(Wait());
        }

        
        listIndex++;

        if (listIndex == toAutoplay.Count)
        {
            finishedAutoplay = true;
        }

    }

   

    IEnumerator Wait()
    {
        continueSending = false;

        UnityEngine.Debug.Log(toSend + player);
        
        yield return new WaitForSeconds(waitTime);

        messageFactorySend.SendMessageToChat(toSend, player);

        UnityEngine.Debug.Log(toSend + player);

        continueSending = true;
    }
}
