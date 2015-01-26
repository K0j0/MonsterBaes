using UnityEngine;
using System.Collections;

public class AudioScript : MonoBehaviour {

	public AudioClip kluluKiss;
	public AudioClip buzzKiss;
	public AudioClip daisyKiss;
	public AudioClip danKiss;
	public AudioClip daisyAmb;
	public AudioClip danAmb;
	public AudioClip kluluAmb;
	public AudioClip buzzAmb;
	public AudioClip hallAmb;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
//	void Update () 
//	{
//		if (Input.GetKeyDown (KeyCode.S)) 
//		{
//			if (GameFlags.soundBools [soundEvents.BUZZ_KISS]) {
//					audio.clip = buzzKiss;
//					audio.Play ();
//			} else if (GameFlags.soundBools [soundEvents.DAISY_KISS]) {
//					audio.clip = daisyKiss;
//					audio.Play ();
//			} else if (GameFlags.soundBools [soundEvents.DAN_KISS]) {
//					audio.clip = danKiss;
//					audio.Play ();
//			} else if (GameFlags.soundBools [soundEvents.KLULU_KISS]) {
//					audio.clip = kluluKiss;
//					audio.Play ();
//			} else if (GameFlags.soundBools [soundEvents.BUZZ_ROOM]) {
//					audio.clip = buzzKiss;
//					audio.Play ();
//			} else if (GameFlags.soundBools [soundEvents.DAISY_ROOM]) {
//					audio.clip = daisyKiss;
//					audio.Play ();
//			} else if (GameFlags.soundBools [soundEvents.DAN_ROOM]) {
//					audio.clip = danKiss;
//					audio.Play ();
//			} else if (GameFlags.soundBools [soundEvents.KLULU_ROOM]) {
//					audio.clip = kluluKiss;
//					audio.Play ();
//			} else if (GameFlags.soundBools [soundEvents.HALLWAY]) {
//					audio.clip = kluluKiss;
//					audio.Play ();
//			}
//		}
//	}
	public void buzzRoom() 
	{
		audio.clip = buzzAmb;
		audio.Play ();
	}
}
