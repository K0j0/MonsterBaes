using UnityEngine;
using System.Collections;

public class BaeDate : MonoBehaviour {
	public GameObject Klulu;
	public GameObject Daisy;
	public GameObject Dan;
	public GameObject Buzz;

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

		switch(who){
			case Baes.BUZZ:
				Buzz.SetActive (true);
			break;
			case Baes.DAN:
				Dan.SetActive (true);
			break;
			case Baes.DAISY:
				Daisy.SetActive (true);
			break;
			case Baes.KULU:
				Klulu.SetActive (true);
			break;
		}
	}
}
