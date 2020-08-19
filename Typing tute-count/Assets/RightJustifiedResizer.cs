using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// gets textbox width to be as small as possible so the text can be 
// left justified without looking weird
public class RightJustifiedResizer : MonoBehaviour
{
    public float MAX_TEXT_WIDTH = 220;
    private float textWidth;
    private static float textHeight;
    // Start is called before the first frame update
    void Start()
    {
        textWidth = this.GetComponent<TMPro.TextMeshProUGUI>().preferredWidth;
        textHeight = this.GetComponent<TMPro.TextMeshProUGUI>().preferredHeight;

        if (textWidth > MAX_TEXT_WIDTH)
        {
            this.GetComponent<RectTransform>().sizeDelta = new Vector2(MAX_TEXT_WIDTH, textHeight);
        } else
        {
            this.GetComponent<RectTransform>().sizeDelta = new Vector2(textWidth, textHeight);
        }
        UnityEngine.Debug.Log(textHeight);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
