using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using UnityEngine.UI;

public class TypingManagerScript : MonoBehaviour
{
	public List<string> toType;
	public TextMeshProUGUI displayOutput; //

	private int currTextPos = 0;
	private int textArrayPos = 0;

	[SerializeField] private int mistakeCount = 0; //hide later
	[SerializeField] private bool endOfText = false; //hide later

	void Start()
	{
		GetText();
	}

	private void GetText()
	{
		// find the next text in the toType array
		displayOutput.text = toType[textArrayPos];
		currTextPos = 0;
		endOfText = false;
	}

	private void Update()
	{
		CheckInput();
	}

	private void CheckInput()
	{

		// pressed enter at the end of text
		if (endOfText == true && Input.GetKeyDown("return"))
		{

			SoundManagerScript.PlaySound("sendText");

			// triggers the convo to proceed
			textArrayPos++;
			GetText();


			//end of convo
			if (textArrayPos == toType.Count)
			{
				//stage complete!!!!
			}


		}
		else if (Input.anyKeyDown)
		{

			string entered = Input.inputString;
			char charEntered = entered[0];

			//typed correct char
			if (endOfText == false && charEntered.Equals(toType[textArrayPos][currTextPos]))
			{
				SoundManagerScript.PlaySound("correctChar");

				currTextPos++;

				UpdateCorrectDisplay();

				//check if all the text has been typed
				if (currTextPos == toType[textArrayPos].Length)
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
		string typedText = toType[textArrayPos].Substring(0, currTextPos);
		string notTypedText = toType[textArrayPos].Substring(currTextPos, toType[textArrayPos].Length - currTextPos);

		displayOutput.text = $"<color=#C0C0FF>{typedText}</color>{notTypedText}";
	}

	private void UpdateIncorrectDisplay()
	{
		string typedText = toType[textArrayPos].Substring(0, currTextPos);
		char incorrectChar = toType[textArrayPos][currTextPos];
		string notTypedText = toType[textArrayPos].Substring(currTextPos + 1, toType[textArrayPos].Length - (currTextPos + 1));

		if (incorrectChar == ' ')
		{
			incorrectChar = '_';
		}

		displayOutput.text = $"<color=#C0C0FF>{typedText}</color><color=red>{incorrectChar}</color>{notTypedText}";
	}

}