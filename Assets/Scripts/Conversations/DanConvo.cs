using UnityEngine;
using System.Collections;

public class DanConvo : MonoBehaviour {
	public MainScript mainSCript;

	public void TalkToMe(){
		if(GameFlags.flags[StoryEvent.DATING_DAN] == true){
			mainSCript.closeConvoButton.SetActive(false);
			switch (mainSCript.lastState)
			{
				case GameState.DATE_DAN_1:					
					mainSCript.conversationPanel.SetActive(true);
                    mainSCript.say(Baes.DAN, "I can see you better now");
					setOptions(GameState.DATE_DAN_1);
					mainSCript.showOptions();
				break;

				case GameState.DATE_DAN_1A:
                    changeMood(Moods.SMILE);
					mainSCript.lastState = GameState.DATE_DAN_2;
                    mainSCript.say(Baes.DAN, "Are you made of Copper and Tellerium?");
					setOptions(GameState.DATE_DAN_2);
					mainSCript.showOptions();
				break;

				case GameState.DATE_DAN_2A:                    
					mainSCript.lastState = GameState.DATE_DAN_3;
					mainSCript.say(Baes.DAN, "Because you're CuTe");
					setOptions(GameState.DATE_DAN_3);
					mainSCript.showOptions();
				break;

				case GameState.DATE_DAN_2B:
					changeMood(Moods.ANGRY);
					mainSCript.say(Baes.DAN, "Nevermind. I should go.");

					HelperFunctions.DelayCallback(3f, ()=>{
						GameFlags.flags[StoryEvent.DATED_DAN] = true;
						MainScript.instance.onNavigate(GameAreas.CLASSROOM);
						MainScript.instance.Dan.gameObject.SetActive(false);
						mainSCript.conversationPanel.SetActive(false);
					});
				break;

				case GameState.DATE_DAN_3A:
                    changeMood(Moods.HAPPY);
					mainSCript.lastState = GameState.DATE_DAN_4;
					mainSCript.say(Baes.DAN, "I think there's chemistry between us...");
					setOptions(GameState.DATE_DAN_4);
					mainSCript.showOptions();
				break;

				case GameState.DATE_DAN_4A:
					changeMood(Moods.SMILE);
					mainSCript.say(Baes.DAN, "...");

					HelperFunctions.DelayCallback(1f, ()=>{
						mainSCript.baeDates.Kiss(Baes.DAN);
						mainSCript.conversationPanel.SetActive(false);
					});
				break;
			}
		}
		else{
			if(GameFlags.flags[StoryEvent.NEED_GLASSES]){
				if(GameFlags.flags[StoryEvent.GOT_GLASSES]){
					changeMood(Moods.HAPPY);
					
					switch (mainSCript.lastState)
					{
					case GameState.START_CLASSROOM:
						TakeFocus(false);
						mainSCript.lastState = GameState.SPEAK_TO_DAN_6;
						mainSCript.say (Baes.DAN, "Thank you so much! I must have left them in the cafeteria again.");
						setOptions(GameState.SPEAK_TO_DAN_6);
						mainSCript.showOptions();
						//						mainSCript.closeConvoButton.SetActive(true);
						break;
						
					case GameState.SPEAK_TO_DAN_6A:
						changeMood(Moods.SMILE);
						mainSCript.lastState = GameState.SPEAK_TO_DAN_7;
						mainSCript.say (Baes.DAN, "Say, I've got a free period. Wanna get chat in the cafeteria?");
						setOptions(GameState.SPEAK_TO_DAN_7);
						mainSCript.showOptions();
						break;
						
					case GameState.SPEAK_TO_DAN_7A:
						mainSCript.closeConversationPanel();
						mainSCript.StartDate(Baes.DAN);
						changeMood(Moods.NEUTRAL);
						mainSCript.lastState = GameState.DATE_DAN_1; // need to call this after closing panel
						break;
					}
				}
				else{
					changeMood(Moods.SMILE);
					TakeFocus(true);						
					mainSCript.say (Baes.DAN, "As soon as I find my glasses I'll be happy to tutor you.");
				}
			}
			else{
				switch (mainSCript.lastState)
				{
				case GameState.START_CLASSROOM:
					mainSCript.lastState = GameState.SPEAK_TO_DAN_0;
					changeMood(Moods.NEUTRAL);					
					TakeFocus(false);
					mainSCript.say (Baes.DAN, "Can I help you?");
                    setOptions(GameState.SPEAK_TO_DAN_0);
					mainSCript.showOptions();
				break;
				case GameState.SPEAK_TO_DAN_0A:
					mainSCript.lastState = GameState.SPEAK_TO_DAN_1;
					mainSCript.say (Baes.DAN, "Wow, That not my name. Is that how you adress everyone?");
					setOptions(GameState.SPEAK_TO_DAN_1);
					mainSCript.showOptions();
					break;
				case GameState.SPEAK_TO_DAN_1A:
					changeMood(Moods.ANGRY);
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
					changeMood(Moods.ANGRY);
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
					changeMood(Moods.ANGRY);
					mainSCript.say(Baes.DAN, "Excuse me?");
					setOptions(GameState.SPEAK_TO_DAN_4_2);
					mainSCript.showOptions();
					break;
					
				case GameState.SPEAK_TO_DAN_4A:
					mainSCript.lastState = GameState.SPEAK_TO_DAN_5;
					changeMood(Moods.SMILE);
					mainSCript.say(Baes.DAN, "Sure, office hours are in your handbook!");
					setOptions(GameState.SPEAK_TO_DAN_5);
					mainSCript.showOptions();
					break;
					
				case GameState.SPEAK_TO_DAN_4B:
					changeMood(Moods.ANGRY);
					mainSCript.say(Baes.DAN, "In your dreams!");
					mainSCript.closeConvoButton.SetActive(true);
					break;
					
				case GameState.SPEAK_TO_DAN_5A:
					GameFlags.flags[StoryEvent.NEED_GLASSES] = true;
					changeMood(Moods.SMILE);
					mainSCript.say(Baes.DAN, "I'd love to but I've misplaced my glasses. Honestly, I can hardly see the board myself without them. Once I find them I'll be happy to tutor you though.");
					mainSCript.closeConvoButton.SetActive(true);
					mainSCript.lastState = GameState.START_CLASSROOM;
					break;
					
				case GameState.SPEAK_TO_DAN_5B:
					mainSCript.closeConversationPanel();				
					break;
					
				default:
					Debug.LogError("Whoa, didn't think you could talk to Dan during this state: " + mainSCript.lastState);
					break;
				}
			}
		}
	}

	void setOptions(GameState forState){
		switch (forState) {
            case GameState.SPEAK_TO_DAN_0:
                mainSCript.option1_text.text = "Hey, Mr. Slime";
                mainSCript.option1.gameObject.SetActive(true);

                mainSCript.option2_text.text = "";
                mainSCript.option2.gameObject.SetActive(false);

                mainSCript.option3_text.text = "";
                mainSCript.option3.gameObject.SetActive(false);

                mainSCript.option4_text.text = "";
                mainSCript.option4.gameObject.SetActive(false);
            break;
			case GameState.SPEAK_TO_DAN_1:
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
				mainSCript.option3_text.text = "Can you tutor me now?";
				mainSCript.option3.gameObject.SetActive(true);
				mainSCript.option4_text.text = "";
				mainSCript.option4.gameObject.SetActive(false);
			break;
			case GameState.SPEAK_TO_DAN_6:
				mainSCript.option1_text.text = "Happy to help";
				mainSCript.option1.gameObject.SetActive(true);
				mainSCript.option2_text.text = "";
				mainSCript.option2.gameObject.SetActive(false);
				mainSCript.option3_text.text = "";
				mainSCript.option3.gameObject.SetActive(false);
				mainSCript.option4_text.text = "";
				mainSCript.option4.gameObject.SetActive(false);
			break;
			case GameState.SPEAK_TO_DAN_7:
				mainSCript.option1_text.text = "Let's do it";
				mainSCript.option1.gameObject.SetActive(true);
				mainSCript.option2_text.text = "";
				mainSCript.option2.gameObject.SetActive(false);
				mainSCript.option3_text.text = "";
				mainSCript.option3.gameObject.SetActive(false);
				mainSCript.option4_text.text = "";
				mainSCript.option4.gameObject.SetActive(false);
			break;

			case GameState.DATE_DAN_1:
				mainSCript.option1_text.text = "Haha, I'm glad.";
				mainSCript.option1.gameObject.SetActive(true);
				mainSCript.option2_text.text = "";
				mainSCript.option2.gameObject.SetActive(false);
				mainSCript.option3_text.text = "";
				mainSCript.option3.gameObject.SetActive(false);
				mainSCript.option4_text.text = "";
				mainSCript.option4.gameObject.SetActive(false);
			break;

			case GameState.DATE_DAN_2:
				mainSCript.option1_text.text = "Uh, what?";
				mainSCript.option1.gameObject.SetActive(true);
				mainSCript.option2_text.text = "You're not funny. Stop.";
				mainSCript.option2.gameObject.SetActive(true);
				mainSCript.option3_text.text = "";
				mainSCript.option3.gameObject.SetActive(false);
				mainSCript.option4_text.text = "";
				mainSCript.option4.gameObject.SetActive(false);
			break;

            case GameState.DATE_DAN_3:
                mainSCript.option1_text.text = "You're not bad yourself";
                mainSCript.option1.gameObject.SetActive(true);
                mainSCript.option2_text.text = "";
                mainSCript.option2.gameObject.SetActive(false);
                mainSCript.option3_text.text = "";
                mainSCript.option3.gameObject.SetActive(false);
                mainSCript.option4_text.text = "";
                mainSCript.option4.gameObject.SetActive(false);
            break;

            case GameState.DATE_DAN_4:
                mainSCript.option1_text.text = "Oh gosh, stop.";
                mainSCript.option1.gameObject.SetActive(true);
                mainSCript.option2_text.text = "";
                mainSCript.option2.gameObject.SetActive(false);
                mainSCript.option3_text.text = "";
                mainSCript.option3.gameObject.SetActive(false);
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
		mainSCript.Dan_big.image.sprite = newSprite;
        mainSCript.baeDates.Dan.image.sprite = newSprite;
	}

	void TakeFocus(bool showCloseButton){
        print("Dan - TakeFocus. xPos: " + mainSCript.Dan_big.transform.position.x);
		if (mainSCript.Dan_big.transform.position.x == 239) {
			iTween.MoveTo(mainSCript.Dan_big.gameObject, iTween.Hash(
				"x", mainSCript.Dan_big.transform.position.x + mainSCript.slide
				, "islocal", false
				, "time", 1f
				, "delay", 0
				));
			}
			
			// hide characters
			mainSCript.Dan.gameObject.SetActive(false);
			// hide nav
			mainSCript.currNavButtons.SetActive(false);
			
			// show larger character
			mainSCript.Dan_big.gameObject.SetActive(true);
			mainSCript.conversationPanel.SetActive(true);
			mainSCript.closeConvoButton.SetActive (showCloseButton);
			mainSCript.blocker.SetActive(true);

	}
	
}
