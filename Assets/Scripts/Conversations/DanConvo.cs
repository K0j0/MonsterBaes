using UnityEngine;
using System.Collections;

public class DanConvo : MonoBehaviour {
	public MainScript mainSCript;

	public void TalkToMe(){
		switch (mainSCript.lastState)
		{
			case GameState.START:
			case GameState.SPEAK_TO_KAEDE_1:
			case GameState.SPEAK_TO_DAN:
	        	mainSCript.lastState = GameState.SPEAK_TO_DAN_1;
				changeBigMood(Moods.NEUTRAL);

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
			break;
			case GameState.SPEAK_TO_DAN_1:
				mainSCript.lastState = GameState.SPEAK_TO_DAN_1_0;
				mainSCript.say (Baes.DAN, "Wow, That not my name. Is that how you adress everyone?");
				setOptions(GameState.SPEAK_TO_DAN_1_0);
				mainSCript.showOptions();
			break;
			case GameState.SPEAK_TO_DAN_1A:
				changeBigMood(Moods.ANGRY);
				mainSCript.say(Baes.DAN, "You're failing my class");
				mainSCript.closeConvoButton.SetActive(true);
			break;
			case GameState.SPEAK_TO_DAN_1B:
				mainSCript.lastState = GameState.SPEAK_TO_DAN_2;
				mainSCript.say(Baes.DAN, "It's rude to address someone by their physical properties");
				setOptions(GameState.SPEAK_TO_DAN_2);
				mainSCript.showOptions();				
			break;
			case GameState.SPEAK_TO_DAN_1C:
				mainSCript.closeConversationPanel();
			break;

			case GameState.SPEAK_TO_DAN_2A:
				mainSCript.lastState = GameState.SPEAK_TO_DAN_3;
				mainSCript.say(Baes.DAN, "Dan Goo. What do you want?");
				setOptions(GameState.SPEAK_TO_DAN_3);
				mainSCript.showOptions();
			break;

			case GameState.SPEAK_TO_DAN_2B:				
				changeBigMood(Moods.ANGRY);
				mainSCript.say(Baes.DAN, "@#$%^# off!");
				mainSCript.closeConvoButton.SetActive(true);
			break;

			case GameState.SPEAK_TO_DAN_3A:
				mainSCript.lastState = GameState.SPEAK_TO_DAN_4_1;
				mainSCript.say(Baes.DAN, "Really?");
				setOptions(GameState.SPEAK_TO_DAN_4_1);
				mainSCript.showOptions();
			break;

			case GameState.SPEAK_TO_DAN_3B:
				mainSCript.lastState = GameState.SPEAK_TO_DAN_4_2;
				changeBigMood(Moods.ANGRY);
				mainSCript.say(Baes.DAN, "Excuse me?");
				setOptions(GameState.SPEAK_TO_DAN_4_2);
				mainSCript.showOptions();
			break;

			case GameState.SPEAK_TO_DAN_4A:
				mainSCript.lastState = GameState.SPEAK_TO_DAN_5;
				changeBigMood(Moods.SMILE);
				mainSCript.say(Baes.DAN, "Sure, office hours are in your handbook!");
				setOptions(GameState.SPEAK_TO_DAN_5);
				mainSCript.showOptions();
			break;

			case GameState.SPEAK_TO_DAN_4B:
				changeBigMood(Moods.ANGRY);
				mainSCript.say(Baes.DAN, "In your dreams!");
				mainSCript.closeConvoButton.SetActive(true);
			break;

			case GameState.SPEAK_TO_DAN_5A:
				mainSCript.say(Baes.DAN, "...Here's my number...");
			break;

			case GameState.SPEAK_TO_DAN_5B:
				mainSCript.closeConversationPanel();				
			break;
			
			default:
				Debug.LogError("Whoa, didn't think you could talk to Dan during this state: " + mainSCript.lastState);
			break;
		}

	}

	void setOptions(GameState forState){
		switch (forState) {
			case GameState.SPEAK_TO_DAN_1_0:
				mainSCript.option1_text.text = "Pretty much";
				mainSCript.option1.gameObject.SetActive(true);

				mainSCript.option2_text.text = "What do you mean?";
				mainSCript.option2.gameObject.SetActive(true);

				mainSCript.option3_text.text = "I'll come back later";
				mainSCript.option3.gameObject.SetActive(true);

				mainSCript.option4_text.text = "";
				mainSCript.option4.gameObject.SetActive(false);
			break;
			case GameState.SPEAK_TO_DAN_2:
				mainSCript.option1_text.text = "Sorry, what's your name?";
				mainSCript.option1.gameObject.SetActive(true);
				mainSCript.option2_text.text = "Sorry, goo guy";
				mainSCript.option2.gameObject.SetActive(true);
				mainSCript.option3_text.text = "";
				mainSCript.option3.gameObject.SetActive(false);
				mainSCript.option4_text.text = "";
				mainSCript.option4.gameObject.SetActive(false);
			break;
			case GameState.SPEAK_TO_DAN_3:
				mainSCript.option1_text.text = "I don't know...";
				mainSCript.option1.gameObject.SetActive(true);
				mainSCript.option2_text.text = "I wanna be yo bae";
				mainSCript.option2.gameObject.SetActive(true);
				mainSCript.option3_text.text = "";
				mainSCript.option3.gameObject.SetActive(false);
				mainSCript.option4_text.text = "";
				mainSCript.option4.gameObject.SetActive(false);
			break;
			case GameState.SPEAK_TO_DAN_4_1:
				mainSCript.option1_text.text = "Do you tutor?";
				mainSCript.option1.gameObject.SetActive(true);
				mainSCript.option2_text.text = "Hey Mr. Goo, wanna be my boo?";
				mainSCript.option2.gameObject.SetActive(true);
				mainSCript.option3_text.text = "";
				mainSCript.option3.gameObject.SetActive(false);
				mainSCript.option4_text.text = "";
				mainSCript.option4.gameObject.SetActive(false);
			break;
			case GameState.SPEAK_TO_DAN_4_2:
				mainSCript.option1_text.text = "Hey Mr. Goo, wanna be my boo?";
				mainSCript.option1.gameObject.SetActive(true);
				mainSCript.option2_text.text = "I want you to tutor me";
				mainSCript.option2.gameObject.SetActive(true);
				mainSCript.option3_text.text = "";
				mainSCript.option3.gameObject.SetActive(false);
				mainSCript.option4_text.text = "";
				mainSCript.option4.gameObject.SetActive(false);
			break;
			case GameState.SPEAK_TO_DAN_5:
				mainSCript.option1_text.text = "Thank you!";
				mainSCript.option1.gameObject.SetActive(true);
				mainSCript.option2_text.text = "See you then";
				mainSCript.option2.gameObject.SetActive(true);
				mainSCript.option3_text.text = "What about if I wanna meet outside office hours?";
				mainSCript.option3.gameObject.SetActive(true);
				mainSCript.option4_text.text = "";
				mainSCript.option4.gameObject.SetActive(false);
			break;
		}
	}

	public void changeMood(Moods mood){
		Sprite newSprite = null;
		switch (mood) {
			case Moods.SMILE:
				newSprite = Resources.Load<Sprite> ("Images/DanGoo/goodan_smile");
			break;
			case Moods.ANGRY:
				newSprite = Resources.Load<Sprite> ("Images/DanGoo/goodan_angry");
			break;
			case Moods.HAPPY:
				newSprite = Resources.Load<Sprite> ("Images/DanGoo/goodan_happy");
			break;		
			case Moods.NEUTRAL:
			default:
				newSprite = Resources.Load<Sprite> ("Images/DanGoo/goodan_neutral");
			break;
		}
		mainSCript.Dan.image.sprite = newSprite;
	}

	public void changeBigMood(Moods mood){
		Sprite newSprite = null;
			switch (mood) {
			case Moods.SMILE:
				newSprite = Resources.Load<Sprite> ("Images/DanGoo/goodan_smile");
			break;
			case Moods.ANGRY:
				newSprite = Resources.Load<Sprite> ("Images/DanGoo/goodan_angry");
			break;
			case Moods.HAPPY:
				newSprite = Resources.Load<Sprite> ("Images/DanGoo/goodan_happy");
			break;		
		case Moods.NEUTRAL:
			default:
				newSprite = Resources.Load<Sprite> ("Images/DanGoo/goodan_neutral");
			break;
		}
		mainSCript.Dan_big.image.sprite = newSprite;
	}
	
}
