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

	// Use this for initialization
	void Start () 
	{

	}
	
	
	public void buzzRoom() 
	{
		audio.Stop ();
		audio.clip = buzzAmb;
		audio.Play ();
	}
	public void danRoom() 
	{
		audio.Stop ();
		audio.clip = danAmb;
		audio.Play ();
	}
	public void daisyRoom() 
	{
		audio.Stop ();
		audio.clip = daisyAmb;
		audio.Play ();
	}public void kluluRoom() 
	{
		audio.Stop ();
		audio.clip = kluluAmb;
		audio.Play ();
	}
	public void hallway() 
	{
        print("Play hallway");
		audio.Stop ();
        audio.clip = danAmb;
		audio.Play ();
	}
}
