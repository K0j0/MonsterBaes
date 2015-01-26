using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConversationTree : MonoBehaviour {
	public MainScript mainScript;
	public DanConvo dan;
	public KluluConvo klulu;
	public BuzzConvo buzz;
	public DaisyConvo daisy;

	public Button option1;
	public Text option1_text;
	public Button option2;
	public Text option2_text;
	public Button option3;
	public Text option3_text;
	public Button option4;
	public Text option4_text;

	public void Init(){
		print ("CTree init");
		dan.mainSCript = mainScript;
		klulu.mainSCript = mainScript;
		buzz.mainSCript = mainScript;
		daisy.mainSCript = mainScript;
	}

	// TODO, this should route to each conversation script based off of current state (who you're speaking to)
	public void optionChosen(int choice){
		Debug.Log ("Chose Option " + choice);
		switch (mainScript.lastState) {
			case GameState.START:
			case GameState.SPEAK_TO_DAN:
			case GameState.SPEAK_TO_DAN_1_0:
        	switch(choice)
				{
					case 1:
						mainScript.lastState = GameState.SPEAK_TO_DAN_1A;
					break;
					case 2:
						mainScript.lastState = GameState.SPEAK_TO_DAN_1B;
					break;
					case 3:
						mainScript.lastState = GameState.SPEAK_TO_DAN_1C;
					break;
				}
				mainScript.buttonGroup.SetActive(false);
				TalkToDan();
			break;
			case GameState.SPEAK_TO_DAN_2:
				switch(choice)
				{
					case 1:
						mainScript.lastState = GameState.SPEAK_TO_DAN_2A;
					break;
					case 2:
						mainScript.lastState = GameState.SPEAK_TO_DAN_2B;
					break;
				}
				mainScript.buttonGroup.SetActive(false);
				TalkToDan();
			break;

			case GameState.SPEAK_TO_DAN_3:
				switch(choice)
				{
					case 1:
						mainScript.lastState = GameState.SPEAK_TO_DAN_3A;
					break;
					case 2:
						mainScript.lastState = GameState.SPEAK_TO_DAN_3B;
					break;
				}
				mainScript.buttonGroup.SetActive(false);
				TalkToDan();
			break;

			case GameState.SPEAK_TO_DAN_4_1:
				switch(choice)
				{
					case 1:
						mainScript.lastState = GameState.SPEAK_TO_DAN_4A;
					break;
					case 2:
						mainScript.lastState = GameState.SPEAK_TO_DAN_4B;
					break;
				}
				mainScript.buttonGroup.SetActive(false);
				TalkToDan();
			break;

			case GameState.SPEAK_TO_DAN_4_2:
				switch(choice)
				{
					case 1:
						mainScript.lastState = GameState.SPEAK_TO_DAN_4B;
					break;
					case 2:
						mainScript.lastState = GameState.SPEAK_TO_DAN_4A;
					break;
				}
				mainScript.buttonGroup.SetActive(false);
				TalkToDan();
			break;

			case GameState.SPEAK_TO_DAN_5:
				switch(choice)
				{
					case 1:
						mainScript.lastState = GameState.SPEAK_TO_DAN_5B;
					break;
					case 2:
						mainScript.lastState = GameState.SPEAK_TO_DAN_5B;
					break;
					case 3:
						mainScript.lastState = GameState.SPEAK_TO_DAN_5A;
					break;
				}
				mainScript.buttonGroup.SetActive(false);
				TalkToDan();
			break;

		case GameState.SPEAK_TO_DAN_6:
		//	switch(choice)
		//	{
		//	case 1:
		//		mainScript.lastState = GameState.SPEAK_TO_DAN_6C;
		//		break;
		//	case 2:
		//		mainScript.lastState = GameState.SPEAK_TO_DAN_6B;
		//		break;
		//	case 3:
		//		mainScript.lastState = GameState.SPEAK_TO_DAN_6A;
		//		break;
		//	}
		//	mainScript.buttonGroup.SetActive(false);
			TalkToDan();
			break;

		case GameState.SPEAK_TO_DAN_7:
			switch(choice)
			{
			case 1:
				mainScript.lastState = GameState.SPEAK_TO_DAN_7A;
				break;										
			case 2:										   
				mainScript.lastState = GameState.SPEAK_TO_DAN_7B;
				break;										
			case 3:										   
				mainScript.lastState = GameState.SPEAK_TO_DAN_7C;
				break;
			}
			mainScript.buttonGroup.SetActive(false);
			TalkToDan();
			break;

		case GameState.SPEAK_TO_DAN_8:
			switch(choice)
			{
			case 1:
				mainScript.lastState = GameState.SPEAK_TO_DAN_8C;
				break;
			case 2:
				mainScript.lastState = GameState.SPEAK_TO_DAN_8B;
				break;
			case 3:
				mainScript.lastState = GameState.SPEAK_TO_DAN_8A;
				break;
			}
			mainScript.buttonGroup.SetActive(false);
			TalkToDan();
			break;


			// Klulu
			case GameState.SPEAK_TO_KLULU_1:
				switch(choice)
				{
					case 1:
						mainScript.lastState = GameState.SPEAK_TO_KLULU_1A;
					break;
					case 2:
						mainScript.lastState = GameState.SPEAK_TO_KLULU_1B;
					break;
					case 3:
						mainScript.lastState = GameState.SPEAK_TO_KLULU_1C;
					break;
				}
				mainScript.buttonGroup.SetActive(false);
				TalkToKlulu();
			break;

			case GameState.SPEAK_TO_KLULU_2:
				switch(choice)
				{
					case 1:
						mainScript.lastState = GameState.SPEAK_TO_KLULU_2A;
					break;
					case 2:
						mainScript.lastState = GameState.SPEAK_TO_KLULU_2B;
					break;
				}
				mainScript.buttonGroup.SetActive(false);
				TalkToKlulu();
			break;

			case GameState.SPEAK_TO_KLULU_3:
				switch(choice)
				{
					case 1:
						mainScript.lastState = GameState.SPEAK_TO_KLULU_3A;
					break;
					case 2:
						mainScript.lastState = GameState.SPEAK_TO_KLULU_3B;
					break;
				}
				mainScript.buttonGroup.SetActive(false);
				TalkToKlulu();
			break;

			case GameState.SPEAK_TO_KLULU_4:
				switch(choice)
				{
					case 1:
						mainScript.lastState = GameState.SPEAK_TO_KLULU_4A;
					break;
					case 2:
						mainScript.lastState = GameState.SPEAK_TO_KLULU_4B;
					break;
				}
				mainScript.buttonGroup.SetActive(false);
				TalkToKlulu();
			break;

			case GameState.SPEAK_TO_KLULU_5:
				switch(choice)
				{
					case 1:
						mainScript.lastState = GameState.SPEAK_TO_KLULU_5A;
					break;
					case 2:
						mainScript.lastState = GameState.SPEAK_TO_KLULU_5B;
					break;
				}
				mainScript.buttonGroup.SetActive(false);
				TalkToKlulu();
			break;

			case GameState.SPEAK_TO_KLULU_6:
				switch(choice)
				{
					case 1:
						mainScript.lastState = GameState.SPEAK_TO_KLULU_6A;
					break;
				}
				mainScript.buttonGroup.SetActive(false);
				TalkToKlulu();
			break;

			case GameState.DATE_KLULU_1:
				switch(choice)
				{
					case 1:
						mainScript.lastState = GameState.DATE_KLULU_1A;
					break;
				}
				mainScript.buttonGroup.SetActive(false);
				TalkToKlulu();
			break;

			case GameState.DATE_KLULU_2:
				switch(choice)
				{
					case 1:
						mainScript.lastState = GameState.DATE_KLULU_2A;
					break;
					case 2:
						mainScript.lastState = GameState.DATE_KLULU_2B;
					break;
				}
				mainScript.buttonGroup.SetActive(false);
				TalkToKlulu();
			break;

			// Daisy
			case GameState.SPEAK_TO_DAISY_1:
				switch(choice)
				{
					case 1:
						mainScript.lastState = GameState.SPEAK_TO_DAISY_1A;
					break;
					case 2:
						mainScript.lastState = GameState.SPEAK_TO_DAISY_1B;
					break;
					case 3:
						mainScript.lastState = GameState.SPEAK_TO_DAISY_1C;
					break;
				}
				mainScript.buttonGroup.SetActive(false);
				TalkToDaisy();
			break;

			case GameState.SPEAK_TO_DAISY_2:
				switch(choice)
				{
					case 1:
						mainScript.lastState = GameState.SPEAK_TO_DAISY_2A;
					break;
					case 2:
						mainScript.lastState = GameState.SPEAK_TO_DAISY_2B;
					break;
				}
				mainScript.buttonGroup.SetActive(false);
			TalkToDaisy();
			break;

			case GameState.SPEAK_TO_DAISY_3:
				switch(choice)
				{
					case 1:
						mainScript.lastState = GameState.SPEAK_TO_DAISY_3A;
					break;
					case 2:
						mainScript.lastState = GameState.SPEAK_TO_DAISY_3B;
					break;
				}
				mainScript.buttonGroup.SetActive(false);
				TalkToDaisy();
			break;

			case GameState.SPEAK_TO_DAISY_4:
				switch(choice)
				{
					case 1:
						mainScript.lastState = GameState.SPEAK_TO_DAISY_4A;
					break;
					case 2:
						mainScript.lastState = GameState.SPEAK_TO_DAISY_4B;
					break;
				}
				mainScript.buttonGroup.SetActive(false);
				TalkToDaisy();
			break;

			case GameState.SPEAK_TO_DAISY_5:
				switch(choice)
				{
					case 1:
						mainScript.lastState = GameState.SPEAK_TO_DAISY_5A;
					break;
					case 2:
						mainScript.lastState = GameState.SPEAK_TO_DAISY_5B;
					break;
				}
				mainScript.buttonGroup.SetActive(false);
				TalkToDaisy();
			break;

			case GameState.SPEAK_TO_DAISY_6:
				switch(choice)
				{
					case 1:
						mainScript.lastState = GameState.SPEAK_TO_DAISY_6A;
					break;
				}
				mainScript.buttonGroup.SetActive(false);
				TalkToDaisy();
			break;

			case GameState.SPEAK_TO_DAISY_7:
				switch(choice)
				{
					case 1:
						mainScript.lastState = GameState.SPEAK_TO_DAISY_7A;
					break;
					case 2:
						mainScript.lastState = GameState.SPEAK_TO_DAISY_7B;
					break;
					case 3:
						mainScript.lastState = GameState.SPEAK_TO_DAISY_7C;
					break;
				}
				mainScript.buttonGroup.SetActive(false);
				TalkToDaisy();
			break;

			case GameState.SPEAK_TO_DAISY_8:
				switch(choice)
				{
					case 1:
						mainScript.lastState = GameState.SPEAK_TO_DAISY_8A;
					break;
				}
				mainScript.buttonGroup.SetActive(false);
				TalkToDaisy();
			break;

			case GameState.DATE_DAISY_1:
				switch(choice)
				{
					case 1:
						mainScript.lastState = GameState.DATE_DAISY_1A;
					break;
				}
				mainScript.buttonGroup.SetActive(false);
				TalkToDaisy();
			break;

			case GameState.DATE_DAISY_2:
				switch(choice)
				{
					case 1:
						mainScript.lastState = GameState.DATE_DAISY_2A;
					break;
					case 2:
						mainScript.lastState = GameState.DATE_DAISY_2B;
					break;
				}
				mainScript.buttonGroup.SetActive(false);
				TalkToDaisy();
			break;


			// Buzz
			case GameState.SPEAK_TO_BUZZ_1:
				switch(choice)
				{
					case 1:
						mainScript.lastState = GameState.SPEAK_TO_BUZZ_1A;
					break;
					case 2:
						mainScript.lastState = GameState.SPEAK_TO_BUZZ_1B;
					break;
					case 3:
						mainScript.lastState = GameState.SPEAK_TO_BUZZ_1C;
					break;
				}
				mainScript.buttonGroup.SetActive(false);
				TalkToBuzz();
			break;

			case GameState.SPEAK_TO_BUZZ_2:
				switch(choice)
				{
					case 1:
						mainScript.lastState = GameState.SPEAK_TO_BUZZ_2A;
					break;
					case 2:
						mainScript.lastState = GameState.SPEAK_TO_BUZZ_2B;
					break;
				}
				mainScript.buttonGroup.SetActive(false);
				TalkToBuzz();
			break;

			case GameState.SPEAK_TO_BUZZ_3:
				switch(choice)
				{
					case 1:
						mainScript.lastState = GameState.SPEAK_TO_BUZZ_3A;
					break;
					case 2:
						mainScript.lastState = GameState.SPEAK_TO_BUZZ_3B;
					break;
				}
				mainScript.buttonGroup.SetActive(false);
				TalkToBuzz();
			break;

			case GameState.SPEAK_TO_BUZZ_4:
				switch(choice)
				{
					case 1:
						mainScript.lastState = GameState.SPEAK_TO_BUZZ_4A;
					break;
					case 2:
						mainScript.lastState = GameState.SPEAK_TO_BUZZ_4B;
					break;
				}
				mainScript.buttonGroup.SetActive(false);
				TalkToBuzz();
			break;

			case GameState.SPEAK_TO_BUZZ_5:
				switch(choice)
				{
					case 1:
						mainScript.lastState = GameState.SPEAK_TO_BUZZ_5A;
					break;
					case 2:
						mainScript.lastState = GameState.SPEAK_TO_BUZZ_5B;
					break;
				}
				mainScript.buttonGroup.SetActive(false);
				TalkToBuzz();
			break;

			default:
				Debug.LogError("Whoops, wasn't expecting you to say something in this state: " + mainScript.lastState);
			break;
		}
	}

	public void TalkToDan(){
		print ("Talk to Dan");
		dan.TalkToMe ();
	}

	public void TalkToKlulu(){
		print ("Talk to Klulu");
		klulu.TalkToMe();
	}

	public void TalkToBuzz(){
		print ("Talk to Buzz");
		buzz.TalkToMe();
	}

	public void TalkToDaisy(){
		print ("Talk to Daisy");
		daisy.TalkToMe();
	}
}
