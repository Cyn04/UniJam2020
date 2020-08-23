using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
	public static AudioClip correctCharSound, incorrectCharSound, sendTextSound, receiveTextSound, failSound, restartSound;
	static AudioSource audioSrc;

	void Start()
	{
		correctCharSound = Resources.Load<AudioClip>("sfx_correcttype");
		incorrectCharSound = Resources.Load<AudioClip>("sfx_incorrecttype");

		sendTextSound = Resources.Load<AudioClip>("sfx_sendmessage");
		receiveTextSound = Resources.Load<AudioClip>("sfx_receivemessage");

		failSound = Resources.Load<AudioClip>("sfx_gameover");
		restartSound = Resources.Load<AudioClip>("sfx_restartstage");

		audioSrc = GetComponent<AudioSource>();
	}

	public static void PlaySound(string sound) 
	{
		switch (sound) {
		case "correctChar":
			audioSrc.PlayOneShot(correctCharSound);
			break;
		case "incorrectChar":
			audioSrc.PlayOneShot(incorrectCharSound);
			break;
		case "sendText":
			audioSrc.PlayOneShot(sendTextSound);
			break;
		case "receiveText":
			audioSrc.PlayOneShot(receiveTextSound);
			break;
		case "fail":
			audioSrc.PlayOneShot(failSound);
			break;
		case "restart":
			audioSrc.PlayOneShot(restartSound);
			break;
		}
	}

}
