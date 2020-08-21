using System.Collections;
using System.Collections.Generic;
//using System.Media;
using System.Threading;
using UnityEngine;

public class AutoplayScript : MonoBehaviour
{
    public static bool finishedAutoplay = false;
    //private bool continueSending = true;

    private List<AutoplayClass> toAutoplay = new List<AutoplayClass>();
    private int listIndex = 0;
    //private string player = "";

    private float waitTime = 0.0f;

    public static int interludeNumber;
    private char SPECIAL_CHAR = '|';

    public GameObject LinkToScript;
    private MessageFactory messageFactorySend;

    void Start()
    {
        // Find messsagefactory object and get its script
        LinkToScript = GameObject.Find("MessageFactory");
        messageFactorySend = LinkToScript.GetComponent<MessageFactory>();

        readCsvFile(interludeNumber);
        playText();
    }

    void readCsvFile(int interlude)
    {
        string filename = "interlude" + interlude;

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
        
    }

    private void playText()
    {

        if (toAutoplay[listIndex].sender.Equals("system"))
        {
            waitTime = 1.0f;
        }
        else
        {
            waitTime = 2.0f;
        }

        StartCoroutine(SendMessage());

        listIndex++;


        if (listIndex == toAutoplay.Count)
        {
            finishedAutoplay = true;
            UnityEngine.Debug.Log("finished autoplay" + finishedAutoplay);
        }

    }

    IEnumerator SendMessage()
    {
         messageFactorySend.SendMessageToChat(toAutoplay[listIndex].text, toAutoplay[listIndex].sender);

        yield return new WaitForSeconds(waitTime);

        if (!finishedAutoplay)
        {
            playText();
        }
    }
}
