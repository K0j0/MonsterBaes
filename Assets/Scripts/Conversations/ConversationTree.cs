using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConversationTree : MonoBehaviour {
	public MainScript mainScript;
	public DanConvo dan;

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
	}

	// TODO, this should route to each conversation script based off of current state (who you're speaking to)
	public void optionChosen(int choice){
		Debug.Log ("Chose Option " + choice);
		switch (mainScript.lastState) {
		case GameState.START:
		case GameState.SPEAK_TO_KAEDE_1:
			
			break;
		}
	}
	public void setOptions(GameState forState){
		switch (forState) {
			case GameState.SPEAK_TO_DAN:
				dan.setOptions(forState);
			break;
			default:
				Debug.LogError("Dunno, who to set the options for in this state: " + forState);
			break;
		}
	}
	
	public void TalkToDan(){
		dan.TalkToMe ();
	}
}
