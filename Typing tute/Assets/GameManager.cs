using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private float MAX_TEXT_WIDTH = 180;
    private int TEXTBOX_PADDING = 15;

    public int msgCount;
    public GameObject chatPanel, playerWrapper, replyWrapper;
    public InputField chatBox;

    // Start is called before the first frame update
    void Start()
    {
        msgCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // sends text to messenger UI depending on who is replying
    public void SendMessageToChat(string text, string player)
    {
        GameObject newMsg = new GameObject();

        if (player == "p1")
        {
            newMsg = Instantiate(playerWrapper, chatPanel.transform);
        }
        else if (player == "NPC")
        {
            newMsg = Instantiate(replyWrapper, chatPanel.transform);
        }
        else
        {
            UnityEngine.Debug.Log("non-valid player input");
        }

        // get child text object of the wrapper and set text
        newMsg.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = chatBox.text;

        resizeMsg(newMsg);

        // newMessage.textObject.text = newMessage.text;
        msgCount += 1;
    }

    private void resizeMsg(GameObject newMsg)
    {
        float textHeight = newMsg.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().preferredHeight;

        float textWidth = newMsg.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().preferredWidth;

        if (textWidth > MAX_TEXT_WIDTH)
        {
            textWidth = MAX_TEXT_WIDTH;
            leftJustify(newMsg);
        }

        float origWrapperWidth = newMsg.GetComponent<RectTransform>().sizeDelta.x;

        // set background coloured container size to textbox size
        newMsg.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(textWidth + 15, textHeight + 15);

        // set wrapper's dimensions to text height
        newMsg.GetComponent<RectTransform>().sizeDelta = new Vector2(origWrapperWidth, textHeight + TEXTBOX_PADDING);
    }

    private void leftJustify(GameObject newMsg)
    {
        newMsg.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().alignment = TextAlignmentOptions.TopLeft;
    }

}