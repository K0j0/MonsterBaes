using UnityEngine;
using System.Collections;

public class KluluConvo : MonoBehaviour {
	public MainScript mainSCript;

	public void TalkToMe(){
		if(GameFlags.flags[StoryEvent.NEED_TRASH_BAGS] == true){
			changeMood(Moods.SMILE);
			iTween.MoveTo(mainSCript.Klulu_big.gameObject, iTween.Hash(
				"x", mainSCript.Klulu_big.transform.position.x + mainSCript.slide
				, "islocal", false
				, "time", 1f
				, "delay", 0
				));
			
			// hide small character
			mainSCript.Klulu.gameObject.SetActive(false);
			// hide nav
			mainSCript.currNavButtons.SetActive(false);
			
			// show larger character
			mainSCript.Klulu_big.gameObject.SetActive(true);
			mainSCript.conversationPanel.SetActive(true);
			mainSCript.closeConvoButton.SetActive (true);
			mainSCript.blocker.SetActive(true);

			mainSCript.closeConvoButton.SetActive(true);
			mainSCript.say(Baes.KULU, "If you're willing to get your hands dirty...");
		}
		else{
			switch (mainSCript.lastState)
			{
				case GameState.START_BEACH:
					mainSCript.lastState = GameState.SPEAK_TO_KLULU_1;
					changeMood(Moods.NEUTRAL);

						
					iTween.MoveTo(mainSCript.Klulu_big.gameObject, iTween.Hash(
						"x", mainSCript.Klulu_big.transform.position.x + mainSCript.slide
						, "islocal", false
						, "time", 1f
						, "delay", 0
						));

					// hide small character
					mainSCript.Klulu.gameObject.SetActive(false);
					// hide nav
					mainSCript.currNavButtons.SetActive(false);
					
					// show larger character
					mainSCript.Klulu_big.gameObject.SetActive(true);
					mainSCript.conversationPanel.SetActive(true);
					mainSCript.closeConvoButton.SetActive (false); // don't show close button here
					mainSCript.blocker.SetActive(true);
					mainSCript.say (Baes.KULU, "Hey.");

					setOptions(GameState.SPEAK_TO_KLULU_1);
					mainSCript.showOptions();
				break;

				case GameState.SPEAK_TO_KLULU_1A:				
					changeMood(Moods.SMILE);
					mainSCript.say(Baes.KULU, "Heh. Flattery will get you nowhere");
					mainSCript.closeConvoButton.SetActive (true);
				break;

				case GameState.SPEAK_TO_KLULU_1B:
					mainSCript.lastState = GameState.SPEAK_TO_KLULU_2;
					mainSCript.say(Baes.KULU, "Cleaning up the beach...");
					setOptions(GameState.SPEAK_TO_KLULU_2);
					mainSCript.showOptions();
				break;

				case GameState.SPEAK_TO_KLULU_1C:
					mainSCript.closeConversationPanel();
				break;

				case GameState.SPEAK_TO_KLULU_2A:
					mainSCript.closeConvoButton.SetActive(true);
					mainSCript.say(Baes.KULU, "...");
				break;

				case GameState.SPEAK_TO_KLULU_2B:
					mainSCript.lastState = GameState.SPEAK_TO_KLULU_3;
					mainSCript.say(Baes.KULU, "Do you know...");
					setOptions(GameState.SPEAK_TO_KLULU_3);
					mainSCript.showOptions();
				break;

				case GameState.SPEAK_TO_KLULU_3A:
					mainSCript.lastState = GameState.SPEAK_TO_KLULU_4;
					mainSCript.closeConvoButton.SetActive(true);
					mainSCript.say(Baes.KULU, "Well allow me to illuminate you...");
					setOptions(GameState.SPEAK_TO_KLULU_4);
					mainSCript.showOptions();
				break;

				case GameState.SPEAK_TO_KLULU_3B:
					mainSCript.closeConvoButton.SetActive(true);
					mainSCript.say(Baes.KULU, "...");
					changeMood(Moods.ANGRY);
				break;

				case GameState.SPEAK_TO_KLULU_4A:
					mainSCript.lastState = GameState.SPEAK_TO_KLULU_5;
					mainSCript.closeConvoButton.SetActive(true);
					mainSCript.say(Baes.KULU, "Mhm, and all of that trash collection...");
					setOptions(GameState.SPEAK_TO_KLULU_5);
					mainSCript.showOptions();
				break;

				case GameState.SPEAK_TO_KLULU_4B:
					mainSCript.closeConvoButton.SetActive(true);
					mainSCript.say(Baes.KULU, "...");
					changeMood(Moods.ANGRY);
				break;

				case GameState.SPEAK_TO_KLULU_5A:
					changeMood(Moods.SMILE);
					GameFlags.flags[StoryEvent.NEED_TRASH_BAGS] = true;
					mainSCript.closeConvoButton.SetActive(true);
					mainSCript.say(Baes.KULU, "If you're willing to get your hands dirty...");
					mainSCript.closeConvoButton.SetActive(true);
				break;

				case GameState.SPEAK_TO_KLULU_5B:
					mainSCript.closeConvoButton.SetActive(true);
					mainSCript.say(Baes.KULU, "...");
					changeMood(Moods.ANGRY);
				break;
				
				default:
					Debug.LogError("Whoa, didn't think you could talk to Klulu during this state: " + mainSCript.lastState);
				break;
			}
		}


	}

	void setOptions(GameState forState){
		switch (forState) {
			case GameState.SPEAK_TO_KLULU_1:
				mainSCript.option1_text.text = "What's cookin' good lookin'?";
				mainSCript.option1.gameObject.SetActive(true);

				mainSCript.option2_text.text = "What are you up to on the beach all by your lonesome?";
				mainSCript.option2.gameObject.SetActive(true);

				mainSCript.option3_text.text = "Nevermind";
				mainSCript.option3.gameObject.SetActive(true);

				mainSCript.option4_text.text = "";
				mainSCript.option4.gameObject.SetActive(false);
			break;
			case GameState.SPEAK_TO_KLULU_2:
				mainSCript.option1_text.text = "Well...good luck with that!";
				mainSCript.option1.gameObject.SetActive(true);

				mainSCript.option2_text.text = "Then why are you still out here if no here?";
				mainSCript.option2.gameObject.SetActive(true);

				mainSCript.option3_text.text = "";
				mainSCript.option3.gameObject.SetActive(false);

				mainSCript.option4_text.text = "";
				mainSCript.option4.gameObject.SetActive(false);
			break;
			case GameState.SPEAK_TO_KLULU_3:
				mainSCript.option1_text.text = "Not really no...";
				mainSCript.option1.gameObject.SetActive(true);

				mainSCript.option2_text.text = "Do I need to?";
				mainSCript.option2.gameObject.SetActive(true);

				mainSCript.option3_text.text = "";
				mainSCript.option3.gameObject.SetActive(false);

				mainSCript.option4_text.text = "";
				mainSCript.option4.gameObject.SetActive(false);
			break;
			case GameState.SPEAK_TO_KLULU_4:
				mainSCript.option1_text.text = "Wait, seriously?";
				mainSCript.option1.gameObject.SetActive(true);

				mainSCript.option2_text.text = "Wow...interesting";
				mainSCript.option2.gameObject.SetActive(true);

				mainSCript.option3_text.text = "";
				mainSCript.option3.gameObject.SetActive(false);

				mainSCript.option4_text.text = "";
				mainSCript.option4.gameObject.SetActive(false);
			break;
			case GameState.SPEAK_TO_KLULU_5:
				mainSCript.option1_text.text = "Oh no, that's terrible. Can I help at all?";
				mainSCript.option1.gameObject.SetActive(true);

				mainSCript.option2_text.text = "What has nature ever done for me?";
				mainSCript.option2.gameObject.SetActive(true);

				mainSCript.option3_text.text = "";
				mainSCript.option3.gameObject.SetActive(false);

				mainSCript.option4_text.text = "";
				mainSCript.option4.gameObject.SetActive(false);
			break;
		}
	}

 	void changeMood(Moods mood){
		print ("Change Klulu mood to " + mood);
		Sprite newSprite = null;
			switch (mood) {
			case Moods.SMILE:
				newSprite = Resources.Load<Sprite> ("Images/Klulu/klulu_smile");
			break;
			case Moods.ANGRY:
				newSprite = Resources.Load<Sprite> ("Images/Klulu/klulu_angry");
			break;
			case Moods.HAPPY:
				newSprite = Resources.Load<Sprite> ("Images/Klulu/klulu_happy");
			break;		
			case Moods.NEUTRAL:
			default:
				newSprite = Resources.Load<Sprite> ("Images/Klulu/klulu_neutral");
			break;
		}
		mainSCript.Klulu_big.image.sprite = newSprite;
	}
}
