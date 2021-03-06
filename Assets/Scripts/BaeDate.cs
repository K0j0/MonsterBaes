﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BaeDate : MonoBehaviour {

	public Button Klulu;
	public Button Daisy;
	public Button Dan;
	public Button Buzz;

	public GameObject Klulu_Button;
	public GameObject Daisy_Button;
	public GameObject Dan_Button;
	public GameObject Buzz_Button;

	public GameObject Klulu_Kiss;
	public GameObject Daisy_Kiss;
	public GameObject Dan_Kiss;
	public GameObject Buzz_Kiss;

	public AudioClip kluluKissSound;
	public AudioClip danKissSound;
	public AudioClip daisyKissSound;
	public AudioClip buzzKissSound;

    AudioSource myAudio;

    private void Awake()
    {
        myAudio = GetComponent<AudioSource>();
    }


    public void Kiss(Baes who){
		print ("Kiss " + who);
		switch(who){
			case Baes.BUZZ:
                Buzz.gameObject.SetActive(false);
                Buzz_Button.SetActive(false);
                Buzz_Kiss.SetActive(true);
			    buzzKiss();
				
				HelperFunctions.DelayCallback(3f, ()=>{
                    Buzz_Kiss.SetActive(false);
					GameFlags.flags[StoryEvent.DATED_BUZZ] = true;
					MainScript.instance.onNavigate(GameAreas.ZEN);
					MainScript.instance.Buzz.gameObject.SetActive(false);
                    MainScript.instance.closeConvoButton.SetActive(true);
                    myAudio.Stop();
				});
			break;
			case Baes.DAN:
                Dan.gameObject.SetActive(false);
                Dan_Button.SetActive(false);
                Dan_Kiss.SetActive(true);
			    danKiss();
				
				HelperFunctions.DelayCallback(3f, ()=>{
                    Dan_Kiss.SetActive(false);
					GameFlags.flags[StoryEvent.DATED_DAN] = true;
					MainScript.instance.onNavigate(GameAreas.CLASSROOM);
					MainScript.instance.Dan.gameObject.SetActive(false);
                    MainScript.instance.closeConvoButton.SetActive(true);
                    myAudio.Stop();
				});
			break;
			case Baes.DAISY:
				Daisy.gameObject.SetActive(false);
				Daisy_Button.SetActive(false);
				Daisy_Kiss.SetActive(true);
			    daisyKiss();
				
				HelperFunctions.DelayCallback(3f, ()=>{
					Daisy_Kiss.SetActive(false);
					GameFlags.flags[StoryEvent.DATED_DAISY] = true;
					MainScript.instance.onNavigate(GameAreas.FLORIST);
					MainScript.instance.Daisy.gameObject.SetActive(false);
                    MainScript.instance.closeConvoButton.SetActive(true);
                    myAudio.Stop ();
				});
			break;
			case Baes.KLULU:
				Klulu.gameObject.SetActive(false);
				Klulu_Button.SetActive(false);
				Klulu_Kiss.SetActive(true);
			    kluluKiss();

				HelperFunctions.DelayCallback(3f, ()=>{
					Klulu_Kiss.SetActive(false);
					GameFlags.flags[StoryEvent.DATED_KLULU] = true;
					MainScript.instance.onNavigate(GameAreas.BEACH);
					MainScript.instance.Klulu.gameObject.SetActive(false);
                    MainScript.instance.closeConvoButton.SetActive(true);
                    myAudio.Stop ();
				});
			break;
		}
	}

	public void StartDate(Baes who){
		Klulu.gameObject.SetActive (false);
		Daisy.gameObject.SetActive (false);
		Dan.gameObject.SetActive (false);
		Buzz.gameObject.SetActive (false);

		Klulu_Button.SetActive (false);
		Daisy_Button.SetActive (false);
		Dan_Button.SetActive (false);
		Buzz_Button.SetActive (false);

		switch(who){
			case Baes.BUZZ:
				GameFlags.flags[StoryEvent.DATING_BUZZ] = true;
				Buzz.gameObject.SetActive (true);
				Buzz_Button.SetActive (true);
			break;
			case Baes.DAN:
				GameFlags.flags[StoryEvent.DATING_DAN] = true;
				Dan.gameObject.SetActive (true);
				Dan_Button.SetActive (true);
			break;
			case Baes.DAISY:
				GameFlags.flags[StoryEvent.DATING_DAISY] = true;
				Daisy.gameObject.SetActive (true);
				Daisy_Button.SetActive (true);
			break;
			case Baes.KLULU:
				GameFlags.flags[StoryEvent.DATING_KLULU] = true;
				Klulu.gameObject.SetActive (true);
				Klulu_Button.SetActive (true);
			break;
		}
	}
	public void kluluKiss(){
        myAudio.clip = kluluKissSound;
        myAudio.Play ();
	}
	public void danKiss(){
        myAudio.clip = danKissSound;
        myAudio.Play ();
	}
	public void daisyKiss(){
        myAudio.clip = daisyKissSound;
        myAudio.Play ();
	}
	public void buzzKiss(){
        myAudio.clip = buzzKissSound;
        myAudio.Play ();
	}
}
