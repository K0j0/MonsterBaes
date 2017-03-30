using UnityEngine;
using System.Collections;

public class AudioScript : MonoBehaviour {

	//public AudioClip kluluKiss;
	//public AudioClip buzzKiss;
	//public AudioClip daisyKiss;
	//public AudioClip danKiss;
	public AudioClip daisyAmb;
	public AudioClip danAmb;
	public AudioClip kluluAmb;
	public AudioClip buzzAmb;
	public AudioClip hallAmb;

    AudioSource gameAudio;

	// Use this for initialization
	void Start () 
	{
        gameAudio = GetComponent<AudioSource>();
	}
	
	
	public void buzzRoom() 
	{
		gameAudio.Stop ();
		gameAudio.clip = buzzAmb;
		gameAudio.Play ();
	}
	public void danRoom() 
	{
		gameAudio.Stop ();
		gameAudio.clip = danAmb;
		gameAudio.Play ();
	}
	public void daisyRoom() 
	{
		gameAudio.Stop ();
		gameAudio.clip = daisyAmb;
		gameAudio.Play ();
	}public void kluluRoom() 
	{
		gameAudio.Stop ();
		gameAudio.clip = kluluAmb;
		gameAudio.Play ();
	}
	public void hallway() 
	{
        print("Play hallway");
		gameAudio.Stop ();
        gameAudio.clip = danAmb;
		gameAudio.Play ();
	}
}
