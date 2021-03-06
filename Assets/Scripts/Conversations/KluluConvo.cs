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
					mainSCript.say(Baes.KLULU, "Thanks for helping me out, dear.");
					setOptions(GameState.DATE_KLULU_1);
					mainSCript.showOptions();
				break;

				case GameState.DATE_KLULU_1A:
					mainSCript.lastState = GameState.DATE_KLULU_2;
					mainSCript.say(Baes.KLULU, "On behalf of the marine life and other lovely critters, we appreciate it.");
					setOptions(GameState.DATE_KLULU_2);
					mainSCript.showOptions();
				break;

				case GameState.DATE_KLULU_2A:
					changeMood(Moods.ANGRY);
					mainSCript.say(Baes.KLULU, "What!?");

					HelperFunctions.DelayCallback(3f, ()=>{
						GameFlags.flags[StoryEvent.DATED_KLULU] = true;
						MainScript.instance.onNavigate(GameAreas.BEACH);
						MainScript.instance.Klulu.gameObject.SetActive(false);
						mainSCript.conversationPanel.SetActive(false);
					});
				break;

				case GameState.DATE_KLULU_2B:
					changeMood(Moods.SMILE);
					mainSCript.say(Baes.KLULU, "Oh you flirt");

					HelperFunctions.DelayCallback(1f, ()=>{
						mainSCript.baeDates.Kiss(Baes.KLULU);
						mainSCript.conversationPanel.SetActive(false);
					});
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
							mainSCript.say(Baes.KLULU, "Well thanks for helping. Why don't I take you out for coffee or something?");
							setOptions(GameState.SPEAK_TO_KLULU_6);
							mainSCript.showOptions();
						break;
						case GameState.SPEAK_TO_KLULU_6A:							
							mainSCript.closeConversationPanel();
							mainSCript.StartDate(Baes.KLULU);
							changeMood(Moods.NEUTRAL);
							mainSCript.lastState = GameState.DATE_KLULU_1; // need to call this after closing panel
						break;
					}
					
				}
				else if(GameFlags.flags[StoryEvent.GOT_TRASH_BAGS]){
					changeMood(Moods.SMILE);
					TakeFocus (true);
					mainSCript.say(Baes.KLULU, "That's great! Now we can clean up the beach.");
					
				}
				else{
					changeMood(Moods.SMILE);
					TakeFocus (true);
					mainSCript.say(Baes.KLULU, "If your willing to get your hands dirty in the name of sea life, grab a pick and a trash bag and lets clean this beach.");
				}
			}
			else{
				switch (mainSCript.lastState)
				{
				case GameState.START_BEACH:
					mainSCript.lastState = GameState.SPEAK_TO_KLULU_1;
					changeMood(Moods.NEUTRAL);
					
					TakeFocus (false);
					mainSCript.say(Baes.KLULU, "Hey.");
					setOptions(GameState.SPEAK_TO_KLULU_1);
					mainSCript.showOptions();
					break;
					
				case GameState.SPEAK_TO_KLULU_1A:				
					changeMood(Moods.SMILE);
					mainSCript.say(Baes.KLULU, "Heh. Flattery will get you nowhere");
					mainSCript.closeConvoButton.SetActive (true);
					break;
					
				case GameState.SPEAK_TO_KLULU_1B:
					mainSCript.lastState = GameState.SPEAK_TO_KLULU_2;
					mainSCript.say(Baes.KLULU, "Cleaning up the beach. To be honest, I'm pretty pissed. No one showed up. Even the guy who was bringing the trash bags and pickers.");
					setOptions(GameState.SPEAK_TO_KLULU_2);
					mainSCript.showOptions();
					break;
					
				case GameState.SPEAK_TO_KLULU_1C:
					mainSCript.closeConversationPanel();
					break;
					
				case GameState.SPEAK_TO_KLULU_2A:
					mainSCript.closeConvoButton.SetActive(true);
					mainSCript.say(Baes.KLULU, "...");
					break;
					
				case GameState.SPEAK_TO_KLULU_2B:
					mainSCript.lastState = GameState.SPEAK_TO_KLULU_3;
					mainSCript.say(Baes.KLULU, "Do you know what trash, specifically plastic does to animals?");
					setOptions(GameState.SPEAK_TO_KLULU_3);
					mainSCript.showOptions();
					break;
					
				case GameState.SPEAK_TO_KLULU_3A:
					mainSCript.lastState = GameState.SPEAK_TO_KLULU_4;
					mainSCript.say(Baes.KLULU, "Well allow me to illuminate you on the subject. First of all a large present of litter ends up in our oceans from people just throwing trash on the ground and letting it run into our storm drains");
					setOptions(GameState.SPEAK_TO_KLULU_4);
					mainSCript.showOptions();
					break;
					
				case GameState.SPEAK_TO_KLULU_3B:
					mainSCript.closeConvoButton.SetActive(true);
					mainSCript.say(Baes.KLULU, "...");
					changeMood(Moods.ANGRY);
					break;
					
				case GameState.SPEAK_TO_KLULU_4A:
					mainSCript.lastState = GameState.SPEAK_TO_KLULU_5;
					mainSCript.say(Baes.KLULU, "Mhm, and all that trash collects into giant gyres in each ocean. These bits of garbage can either be ingested by wildlife or they can be caught in it and be physically deformed.");
					setOptions(GameState.SPEAK_TO_KLULU_5);
					mainSCript.showOptions();
					break;
					
				case GameState.SPEAK_TO_KLULU_4B:
					mainSCript.closeConvoButton.SetActive(true);
					mainSCript.say(Baes.KLULU, "...");
					changeMood(Moods.ANGRY);
					break;
					
				case GameState.SPEAK_TO_KLULU_5A:
					mainSCript.lastState = GameState.SPEAK_TO_KLULU_6;
					changeMood(Moods.SMILE);
					GameFlags.flags[StoryEvent.NEED_TRASH_BAGS] = true;
					mainSCript.closeConvoButton.SetActive(true);
					mainSCript.say(Baes.KLULU, "If your willing to get your hands dirty in the name of sea life, grab a pick and a trash bag and lets clean this beach.");
					mainSCript.closeConvoButton.SetActive(true);
					break;
					
				case GameState.SPEAK_TO_KLULU_5B:
					mainSCript.closeConvoButton.SetActive(true);
					mainSCript.say(Baes.KLULU, "...");
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
				mainSCript.option1_text.text = "No problem";
				mainSCript.option1.gameObject.SetActive(true);

				mainSCript.option2_text.text = "";
				mainSCript.option2.gameObject.SetActive(false);

				mainSCript.option3_text.text = "";
				mainSCript.option3.gameObject.SetActive(false);

				mainSCript.option4_text.text = "";
				mainSCript.option4.gameObject.SetActive(false);
			break;

			case GameState.DATE_KLULU_2:
				mainSCript.option1_text.text = "All the more for me to eat";
				mainSCript.option1.gameObject.SetActive(true);

				mainSCript.option2_text.text = "I love sea critters almost as much as I love you";
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
		mainSCript.baeDates.Klulu.image.sprite = newSprite;
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