using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConversationTree : MonoBehaviour {
	public MainScript mainScript;

	public Button option1;
	public Text option1_text;
	public Button option2;
	public Text option2_text;
	public Button option3;
	public Text option3_text;
	public Button option4;
	public Text option4_text;

	public void optionChosen(int choice){
		Debug.Log ("Chose Option " + choice);
		switch (mainScript.lastState) {
		case GameFlags.GameState.START:
		case GameFlags.GameState.SPEAK_TO_KAEDE_1:
			
			break;
		}
	}
	
	public void setOptions(GameFlags.GameState forState){
		switch (forState) {
		case GameFlags.GameState.SPEAK_TO_DAN:
			option1_text.text = "Hey, Dan...";
			option2_text.text = "Hey Dan. Did you see the debate last night?";
			option3_text.text = "Hey Dan. It sure is nice out right!";
			option4_text.text = "Hey Dan. What's with your hair?";
			break;
		}
	}
	

}
