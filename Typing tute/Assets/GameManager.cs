using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float MAX_TEXT_WIDTH = 220;
    private int TEXTBOX_PADDING = 25;

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
        if (chatBox.text != "")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SendMessageToChat();
                chatBox.text = "";
            }
        }
        // activates chatbox if it's not focused
        else if (!chatBox.isFocused)
        {
            chatBox.ActivateInputField();
        }

    }

    public void SendMessageToChat()
    {
        GameObject newMsg = new GameObject();

        if (msgCount % 2 == 0)
        {
            newMsg = Instantiate(playerWrapper, chatPanel.transform);
        }
        else
        {
            newMsg = Instantiate(replyWrapper, chatPanel.transform);
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
        }

        float origWrapperWidth = newMsg.GetComponent<RectTransform>().sizeDelta.x;

        // set background coloured container size to textbox size
        newMsg.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(textWidth + 10, textHeight + 5);

        // set wrapper's dimensions to text height
        newMsg.GetComponent<RectTransform>().sizeDelta = new Vector2(origWrapperWidth, textHeight + TEXTBOX_PADDING);
    }

}

[System.Serializable]
public class Message
{
    public string text;
    public Text textObject;

}
