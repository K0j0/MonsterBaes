using UnityEngine;
using System.Collections;

public class KluluConvo : MonoBehaviour {
	public MainScript mainSCript;

	public void TalkToMe(){
		// first check for date
		if(GameFlags.flags[StoryEvent.DATING_KLULU] == true){
			mainSCript.closeConvoButton.SetActive(false);
			switch (mainSCript.lastState)
			{
				case GameState.DATE_KLULU_1:
					mainSCript.conversationPanel.SetActive(true);
					mainSCript.say(Baes.KULU, "So here we are");
					setOptions(GameState.DATE_KLULU_1);
					mainSCript.showOptions();
				break;
			}
		}
		else{
			if(GameFlags.flags[StoryEvent.NEED_TRASH_BAGS] == true){
				if(GameFlags.flags[StoryEvent.PICKED_UP_ALL_TRASH]){
					changeMood(Moods.HAPPY);
					
					switch (mainSCript.lastState)
					{
						case GameState.START_BEACH:
						case GameState.SPEAK_TO_KLULU_6:
							mainSCript.lastState = GameState.SPEAK_TO_KLULU_6;
							TakeFocus (false); // Lead to date
							mainSCript.say(Baes.KULU, "Well thanks for helping. Why don't I take you out for coffee or something?");
							setOptions(GameState.SPEAK_TO_KLULU_6);
							mainSCript.showOptions();
						break;
						case GameState.SPEAK_TO_KLULU_6A:							
							mainSCript.closeConversationPanel();
							mainSCript.StartDate(Baes.KULU);
							mainSCript.lastState = GameState.DATE_KLULU_1; // need to call this after closing panel
						break;
					}
					
				}
				else if(GameFlags.flags[StoryEvent.GOT_TRASH_BAGS]){
					changeMood(Moods.SMILE);
					TakeFocus (true);
					mainSCript.say(Baes.KULU, "That's great! Now we can clean up the beach.");
					
				}
				else{
					changeMood(Moods.SMILE);
					TakeFocus (true);
					mainSCript.say(Baes.KULU, "If your willing to get your hands dirty in the name of sea life, grab a pick and a trash bag and lets clean this beach.");
				}
			}
			else{
				switch (mainSCript.lastState)
				{
				case GameState.START_BEACH:
					mainSCript.lastState = GameState.SPEAK_TO_KLULU_1;
					changeMood(Moods.NEUTRAL);
					
					TakeFocus (false);
					mainSCript.say(Baes.KULU, "Hey.");
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
					mainSCript.say(Baes.KULU, "Cleaning up the beach. To be honest, I'm pretty pissed. No one showed up. Even the guy who was bringing the trash bags and pickers.");
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
					mainSCript.say(Baes.KULU, "Do you know what trash, specifically plastic does to animals?");
					setOptions(GameState.SPEAK_TO_KLULU_3);
					mainSCript.showOptions();
					break;
					
				case GameState.SPEAK_TO_KLULU_3A:
					mainSCript.lastState = GameState.SPEAK_TO_KLULU_4;
					mainSCript.say(Baes.KULU, "Well allow me to illuminate you on the subject. First of all a large present of litter ends up in our oceans from people just throwing trash on the ground and letting it run into our storm drains");
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
					mainSCript.say(Baes.KULU, "Mhm, and all that trash collects into giant gyres in each ocean. These bits of garbage can either be ingested by wildlife or they can be caught in it and be physically deformed.");
					setOptions(GameState.SPEAK_TO_KLULU_5);
					mainSCript.showOptions();
					break;
					
				case GameState.SPEAK_TO_KLULU_4B:
					mainSCript.closeConvoButton.SetActive(true);
					mainSCript.say(Baes.KULU, "...");
					changeMood(Moods.ANGRY);
					break;
					
				case GameState.SPEAK_TO_KLULU_5A:
					mainSCript.lastState = GameState.SPEAK_TO_KLULU_6;
					changeMood(Moods.SMILE);
					GameFlags.flags[StoryEvent.NEED_TRASH_BAGS] = true;
					mainSCript.closeConvoButton.SetActive(true);
					mainSCript.say(Baes.KULU, "If your willing to get your hands dirty in the name of sea life, grab a pick and a trash bag and lets clean this beach.");
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
			case GameState.SPEAK_TO_KLULU_6:
				mainSCript.option1_text.text = "I'd like that.";
				mainSCript.option1.gameObject.SetActive(true);

				mainSCript.option2_text.text = "";
				mainSCript.option2.gameObject.SetActive(false);

				mainSCript.option3_text.text = "";
				mainSCript.option3.gameObject.SetActive(false);

				mainSCript.option4_text.text = "";
				mainSCript.option4.gameObject.SetActive(false);
			break;

			case GameState.DATE_KLULU_1:
				mainSCript.option1_text.text = "You look nice.";
				mainSCript.option1.gameObject.SetActive(true);

				mainSCript.option2_text.text = "I'm kinda regretting it...";
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

	void TakeFocus(bool showCloseButton){

		if(mainSCript.Klulu_big.transform.position.x == 548){
			iTween.MoveTo(mainSCript.Klulu_big.gameObject, iTween.Hash(
				"x", mainSCript.Klulu_big.transform.position.x + mainSCript.slide
				, "islocal", false
				, "time", 1f
				, "delay", 0
			));
		}

		
		// hide small character
		mainSCript.Klulu.gameObject.SetActive(false);
		// hide nav
		mainSCript.currNavButtons.SetActive(false);
		
		// show larger character
		mainSCript.Klulu_big.gameObject.SetActive(true);
		mainSCript.conversationPanel.SetActive(true);
		mainSCript.closeConvoButton.SetActive (true);
		mainSCript.blocker.SetActive(true);
		
		mainSCript.closeConvoButton.SetActive(showCloseButton);
	}
}	