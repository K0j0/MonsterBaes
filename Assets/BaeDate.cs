using UnityEngine;
using System.Collections;

public class BaeDate : MonoBehaviour {
	public GameObject Klulu;
	public GameObject Daisy;
	public GameObject Dan;
	public GameObject Buzz;

	public GameObject Klulu_Button;
	public GameObject Daisy_Button;
	public GameObject Dan_Button;
	public GameObject Buzz_Button;

	public GameObject Klulu_Kiss;
	public GameObject Daisy_Kiss;
	public GameObject Dan_Kiss;
	public GameObject Buzz_Kiss;

	public void Kiss(Baes who){
		switch(who){
			case Baes.BUZZ:
			break;
			case Baes.DAN:
			break;
			case Baes.DAISY:
			break;
			case Baes.KULU:
			break;
		}
	}

	public void StartDate(Baes who){
		Klulu.SetActive (false);
		Daisy.SetActive (false);
		Dan.SetActive (false);
		Buzz.SetActive (false);

		Klulu_Button.SetActive (false);
		Daisy_Button.SetActive (false);
		Dan_Button.SetActive (false);
		Buzz_Button.SetActive (false);

		switch(who){
			case Baes.BUZZ:
				Buzz.SetActive (true);
				Buzz_Button.SetActive (true);
			break;
			case Baes.DAN:
				Dan.SetActive (true);
				Dan_Button.SetActive (true);
			break;
			case Baes.DAISY:
				Daisy.SetActive (true);
				Daisy_Button.SetActive (true);
			break;
			case Baes.KULU:
				GameFlags.flags[StoryEvent.DATING_KLULU] = true;
				Klulu.SetActive (true);
				Klulu_Button.SetActive (true);
			break;
		}
	}
}
