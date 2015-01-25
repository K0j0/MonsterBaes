using UnityEngine;
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

	public void Kiss(Baes who){
		print ("Kiss " + who);
		switch(who){
			case Baes.BUZZ:
			break;
			case Baes.DAN:
			break;
			case Baes.DAISY:
			break;
			case Baes.KULU:
				Klulu.gameObject.SetActive(false);
				Klulu_Button.SetActive(false);
				Klulu_Kiss.SetActive(true);
				
				HelperFunctions.DelayCallback(3f, ()=>{
					Klulu_Kiss.SetActive(false);
					GameFlags.flags[StoryEvent.DATED_KLULU] = true;
					MainScript.instance.onNavigate(GameAreas.BEACH);
					MainScript.instance.Klulu.gameObject.SetActive(false);
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
				Buzz.gameObject.SetActive (true);
				Buzz_Button.SetActive (true);
			break;
			case Baes.DAN:
				Dan.gameObject.SetActive (true);
				Dan_Button.SetActive (true);
			break;
			case Baes.DAISY:
				Daisy.gameObject.SetActive (true);
				Daisy_Button.SetActive (true);
			break;
			case Baes.KULU:
				GameFlags.flags[StoryEvent.DATING_KLULU] = true;
				Klulu.gameObject.SetActive (true);
				Klulu_Button.SetActive (true);
			break;
		}
	}
}
