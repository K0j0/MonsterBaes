using UnityEngine;
using System.Collections;

public class DanConvo : MonoBehaviour {
	public MainScript mainSCript;
	bool slide = true;

	public void TalkToMe(){
		switch (mainSCript.lastState)
		{
			case GameState.START:
			case GameState.SPEAK_TO_KAEDE_1:
				mainSCript.lastState = GameState.SPEAK_TO_DAN;

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
					mainSCript.say (Baes.YOU, "Hey you, Mr. Slime");
				
					setOptions(GameState.SPEAK_TO_DAN);
			break;
			case GameState.SPEAK_TO_DAN:
				mainSCript.say (Baes.DAN, "Wow, That not my name. Is that how you adress everyone?");
				if(slide){
					slide = false;
					HelperFunctions.DelayCallback (1.5f, () => {
						mainSCript.buttonGroup.SetActive (true);
					});
				}
				
			break;
			case GameState.SPEAK_TO_DAN_1A:
				mainSCript.say(Baes.DAN, "You're failing my class");
				mainSCript.closeConvoButton.SetActive(true);
			break;
			case GameState.SPEAK_TO_DAN_1B:
				mainSCript.say(Baes.DAN, "It's rude to address someone by their physical properties");
			break;
			case GameState.SPEAK_TO_DAN_1C:
				mainSCript.closeConversationPanel();
				mainSCript.lastState = GameState.SPEAK_TO_DAN;
			break;
			
			default:
				Debug.LogError("Whoa, didn't think you could talk to me during this state: " + mainSCript.lastState);
			break;
		}

	}

	public void setOptions(GameState forState){
		switch (forState) {
		case GameState.SPEAK_TO_DAN:
			mainSCript.option1_text.text = "Pretty much";
			mainSCript.option2_text.text = "What do you mean?";
			mainSCript.option3_text.text = "I'll come back later";
			mainSCript.option4.gameObject.SetActive(false);
			mainSCript.option4_text.text = "";
			break;
		}
	}
}
