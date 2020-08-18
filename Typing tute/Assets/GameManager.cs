using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int msgCount;
    public int padding;
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
                SendMessageToChat(chatBox.text);
                chatBox.text = "";
            }
        }
        // activates chatbox if it's not focused
        else if (!chatBox.isFocused)
        {
            chatBox.ActivateInputField();
        }

    }

    public void SendMessageToChat(string text)
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
        newMsg.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = text;

        float textHeight = newMsg.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().preferredHeight;
        float origWrapperWidth = newMsg.GetComponent<RectTransform>().sizeDelta.x;

        // set wrapper's dimensions to text size
        newMsg.GetComponent<RectTransform>().sizeDelta = new Vector2(origWrapperWidth, textHeight + padding);

        // newMessage.textObject.text = newMessage.text;
        msgCount += 1;
    }
}

[System.Serializable]
public class Message
{
    public string text;
    public Text textObject;

}
