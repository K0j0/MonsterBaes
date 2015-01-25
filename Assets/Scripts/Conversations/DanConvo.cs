using UnityEngine;
using System.Collections;

public class DanConvo : MonoBehaviour {
	public MainScript mainSCript;

	public void TalkToMe(){
		switch (mainSCript.lastState) {
			case GameState.START:
			case GameState.SPEAK_TO_KAEDE_1:
			case GameState.SPEAK_TO_DAN:
				if (!GameFlags.flags [StoryEvent.SPEAK_TO_DAN]) {
					GameFlags.flags [StoryEvent.SPEAK_TO_DAN] = true;
					
					iTween.MoveTo(mainSCript.Dan_big.gameObject, iTween.Hash(
						"x", mainSCript.Dan_big.transform.position.x + mainSCript.slide
						, "islocal", false
						, "time", 1f
						, "delay", 0
						));
					}
					// hide characters
					mainSCript.Kaede.gameObject.SetActive(false);
					mainSCript.Dan.gameObject.SetActive(false);
					// hide nav
					mainSCript.currNavButtons.SetActive(false);
					
					// show larger character
					mainSCript.Dan_big.gameObject.SetActive(true);
					mainSCript.conversationPanel.SetActive(true);
					mainSCript.closeConvoButton.SetActive (false); // don't show close button here
					mainSCript.blocker.SetActive(true);
					mainSCript.convoText.text = "DAN:\nWhat's up?";
					
					HelperFunctions.DelayCallback (1f, () => {
					mainSCript.buttonGroup.SetActive (true);
				});
				
				
				mainSCript.convoTree.setOptions(GameState.SPEAK_TO_DAN);
			break;
			default:
				Debug.LogError("Whoa, didn't think you could talk to me during this state: " + mainSCript.lastState);
			break;
		}

	}

	public void setOptions(GameState forState){
		switch (forState) {
		case GameState.SPEAK_TO_DAN:
			mainSCript.option1_text.text = "Hey, Dan...";
			mainSCript.option2_text.text = "Hey Dan. Did you see the debate last night?";
			mainSCript.option3_text.text = "Hey Dan. It sure is nice out right!";
			mainSCript.option4_text.text = "Hey Dan. What's with your hair?";
			break;
		}
	}
}
