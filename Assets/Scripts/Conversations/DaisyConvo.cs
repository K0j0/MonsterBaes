using UnityEngine;
using System.Collections;

public class DaisyConvo : MonoBehaviour {
	public MainScript mainSCript;
	
	public void TalkToMe(){
		if(GameFlags.flags[StoryEvent.DATING_DAISY] == true){
			mainSCript.closeConvoButton.SetActive(false);
			switch (mainSCript.lastState)
			{
				case GameState.DATE_DAISY_1:					
					mainSCript.conversationPanel.SetActive(true);
					mainSCript.say(Baes.KLULU, "Thanks for finding the nightshade. It's one of my favorite dangerous flowers.");
					setOptions(GameState.DATE_DAISY_1);
					mainSCript.showOptions();
				break;

				case GameState.DATE_DAISY_1A:
					changeMood(Moods.SMILE);
					mainSCript.lastState = GameState.DATE_DAISY_2;
					mainSCript.say(Baes.KLULU, "I hope you washed your hand");
					setOptions(GameState.DATE_DAISY_2);
					mainSCript.showOptions();
				break;

				case GameState.DATE_DAISY_2A:
					changeMood(Moods.ANGRY);
					mainSCript.say(Baes.KLULU, "EW!?");

					HelperFunctions.DelayCallback(3f, ()=>{
						GameFlags.flags[StoryEvent.DATED_DAISY] = true;
						MainScript.instance.onNavigate(GameAreas.FLORIST);
						MainScript.instance.Daisy.gameObject.SetActive(false);
						mainSCript.conversationPanel.SetActive(false);
					});
				break;

				case GameState.DATE_DAISY_2B:
					changeMood(Moods.SMILE);
					mainSCript.say(Baes.KLULU, "You're just about as sweet as my little flowers");

					HelperFunctions.DelayCallback(1f, ()=>{
						mainSCript.baeDates.Kiss(Baes.DAISY);
						mainSCript.conversationPanel.SetActive(false);
					});
				break;
			}
		}
		else{
			if(GameFlags.flags[StoryEvent.NEED_FLOWERS] == true){
			if(GameFlags.flags[StoryEvent.GOT_FLOWER_NIGHTSHADE] == true ||
			   GameFlags.flags[StoryEvent.GOT_FLOWER_SEAFIG] == true ||
			   GameFlags.flags[StoryEvent.GOT_FLOWER_THISTLE] == true){

				switch (mainSCript.lastState)
				{
					case GameState.START_FLORIST:
						TakeFocus(false);
						changeMood(Moods.SMILE);
						mainSCript.say(Baes.DAISY, "Oh wow, are those for me?");
						mainSCript.lastState = GameState.SPEAK_TO_DAISY_7;
						setOptions(GameState.SPEAK_TO_DAISY_7);
						mainSCript.showOptions();
					break;
					case GameState.SPEAK_TO_DAISY_7A:
						mainSCript.lastState = GameState.SPEAK_TO_DAISY_8;
						mainSCript.say(Baes.DAISY, "Oh my nightshade! Local and very special. That's so thoughtful. Say, you wanna grab some coffee?");
						setOptions(GameState.SPEAK_TO_DAISY_8);
						mainSCript.showOptions();
					break;
					case GameState.SPEAK_TO_DAISY_7B:
						changeMood(Moods.NEUTRAL);
						mainSCript.say(Baes.DAISY, "This seafig smells like trash");
						mainSCript.closeConvoButton.SetActive(true);
					break;
					case GameState.SPEAK_TO_DAISY_7C:
						changeMood(Moods.NEUTRAL);
						mainSCript.say(Baes.DAISY, "Oh, a thistle...thanks");				
						mainSCript.closeConvoButton.SetActive(true);
					break;

					case GameState.SPEAK_TO_DAISY_8A:
						mainSCript.closeConversationPanel();
						mainSCript.StartDate(Baes.DAISY);
						changeMood(Moods.NEUTRAL);
						mainSCript.lastState = GameState.DATE_DAISY_1; // need to call this after closing panel
					break;
				}

			}
			else{
				changeMood(Moods.ANGRY);
				mainSCript.say(Baes.DAISY, "Sorry. Just... It really upsets me. *sad*");
				TakeFocus(true);
			}
		}
		else{
			switch (mainSCript.lastState)
			{
			case GameState.START_FLORIST:
				mainSCript.lastState = GameState.SPEAK_TO_DAISY_1;
				changeMood(Moods.NEUTRAL);
				
				
				TakeFocus (false);
				mainSCript.say (Baes.DAISY, "Hmm?");
				
				setOptions(GameState.SPEAK_TO_DAISY_1);
				mainSCript.showOptions();
				break;
				
			case GameState.SPEAK_TO_DAISY_1A:				
				changeMood(Moods.ANGRY);
				mainSCript.say(Baes.DAISY, "What's that supposed to mean?");
				mainSCript.closeConvoButton.SetActive (true);
				break;
				
			case GameState.SPEAK_TO_DAISY_1B:
				changeMood(Moods.SMILE);
				mainSCript.lastState = GameState.SPEAK_TO_DAISY_2;
				mainSCript.say(Baes.DAISY, "Oh, th-thank you.");
				setOptions(GameState.SPEAK_TO_DAISY_2);
				mainSCript.showOptions();
				break;
				
			case GameState.SPEAK_TO_DAISY_1C:
				mainSCript.closeConversationPanel();
				break;
				
			case GameState.SPEAK_TO_DAISY_2B:
				changeMood(Moods.NEUTRAL);
				mainSCript.closeConvoButton.SetActive(true);
				mainSCript.say(Baes.DAISY, "GET OUT.");
				break;
				
			case GameState.SPEAK_TO_DAISY_2A:
				mainSCript.lastState = GameState.SPEAK_TO_DAISY_3;
				mainSCript.say(Baes.DAISY, "Well, my favorite color is violet, like the flower. There's lots of purple flowers here in California.");
				setOptions(GameState.SPEAK_TO_DAISY_3);
				mainSCript.showOptions();
				break;
				
			case GameState.SPEAK_TO_DAISY_3A:
				mainSCript.lastState = GameState.SPEAK_TO_DAISY_4;
				changeMood(Moods.NEUTRAL);
				mainSCript.say(Baes.DAISY, "Its just kind of unfortunate that a lot of the native vegetation is is being choked out by invasive plants. I really like our plants. D.:");
				setOptions(GameState.SPEAK_TO_DAISY_4);
				mainSCript.showOptions();
				break;
				
			case GameState.SPEAK_TO_DAISY_3B:
				mainSCript.closeConvoButton.SetActive(true);
				mainSCript.say(Baes.DAISY, "...");
				changeMood(Moods.ANGRY);
				break;
				
			case GameState.SPEAK_TO_DAISY_4A:
				mainSCript.lastState = GameState.SPEAK_TO_DAISY_5;
		//		mainSCript.closeConvoButton.SetActive(true);
				mainSCript.say(Baes.DAISY, "Invasive plants are non-native plants brought here from other contries. Usually for landscaping reasons or accidentally transporting seeds.");
				setOptions(GameState.SPEAK_TO_DAISY_5);
				mainSCript.showOptions();
				break;
				
			case GameState.SPEAK_TO_DAISY_5A:
				mainSCript.lastState = GameState.SPEAK_TO_DAISY_6;
			//	GameFlags.flags[StoryEvent.NEED_FLOWERS] = true;
				mainSCript.say(Baes.DAISY, "The problem is that the natural predators of the plants don't come with so they grow out of control and steal all the resources and nutrients of the native ones, and its just terribly problomatic.");
			//	mainSCript.closeConvoButton.SetActive(true);
				setOptions(GameState.SPEAK_TO_DAISY_6);
				mainSCript.showOptions();
				break;

			case GameState.SPEAK_TO_DAISY_6A:
				mainSCript.say(Baes.DAISY, "Sorry. Just... It upsets me. *sad*");
				changeMood(Moods.ANGRY);
				mainSCript.closeConvoButton.SetActive(true);
				GameFlags.flags[StoryEvent.NEED_FLOWERS] = true;
				break;
				
			default:
				Debug.LogError("Whoa, didn't think you could talk to Daisy during this state: " + mainSCript.lastState);
				break;
			}
		}
		}
	}
	
	void setOptions(GameState forState){
		switch (forState) {
			case GameState.SPEAK_TO_DAISY_1:
				mainSCript.option1_text.text = "Looks like I found the beef.";
				mainSCript.option1.gameObject.SetActive(true);
				
				mainSCript.option2_text.text = "My, what lovely green eyes you have.";
				mainSCript.option2.gameObject.SetActive(true);
				
				mainSCript.option3_text.text = "Nevermind...";
				mainSCript.option3.gameObject.SetActive(true);
				
				mainSCript.option4_text.text = "";
				mainSCript.option4.gameObject.SetActive(false);
				break;
			case GameState.SPEAK_TO_DAISY_2:
				mainSCript.option1_text.text = "Rather fitting for a florist. Green looks good on you.";
				mainSCript.option1.gameObject.SetActive(true);
				
				mainSCript.option2_text.text = "Lovely hunk of florist right here.";
				mainSCript.option2.gameObject.SetActive(true);
				
				mainSCript.option3_text.text = "";
				mainSCript.option3.gameObject.SetActive(false);
				
				mainSCript.option4_text.text = "";
				mainSCript.option4.gameObject.SetActive(false);
				break;
			case GameState.SPEAK_TO_DAISY_3:
				mainSCript.option1_text.text = "Yeah, we got a lot of cool plants, don't we?";
				mainSCript.option1.gameObject.SetActive(true);
				
				mainSCript.option2_text.text = "And happy cows.";
				mainSCript.option2.gameObject.SetActive(true);
				
				mainSCript.option3_text.text = "";
				mainSCript.option3.gameObject.SetActive(false);
				
				mainSCript.option4_text.text = "";
				mainSCript.option4.gameObject.SetActive(false);
				break;
			case GameState.SPEAK_TO_DAISY_4:
				mainSCript.option1_text.text = "Invasive.. plants?";
				mainSCript.option1.gameObject.SetActive(true);
				
				mainSCript.option2_text.text = "";
				mainSCript.option2.gameObject.SetActive(false);
				
				mainSCript.option3_text.text = "";
				mainSCript.option3.gameObject.SetActive(false);
				
				mainSCript.option4_text.text = "";
				mainSCript.option4.gameObject.SetActive(false);
				break;
			case GameState.SPEAK_TO_DAISY_5:
				mainSCript.option1_text.text = "I see";
				mainSCript.option1.gameObject.SetActive(true);
				
				mainSCript.option2_text.text = "";
				mainSCript.option2.gameObject.SetActive(false);
				
				mainSCript.option3_text.text = "";
				mainSCript.option3.gameObject.SetActive(false);
				
				mainSCript.option4_text.text = "";
				mainSCript.option4.gameObject.SetActive(false);
				break;
			case GameState.SPEAK_TO_DAISY_6:
				mainSCript.option1_text.text = "Oh...";
				mainSCript.option1.gameObject.SetActive(true);
				
				mainSCript.option2_text.text = "What has nature ever done for me?";
				mainSCript.option2.gameObject.SetActive(false);
				
				mainSCript.option3_text.text = "";
				mainSCript.option3.gameObject.SetActive(false);
				
				mainSCript.option4_text.text = "";
				mainSCript.option4.gameObject.SetActive(false);
				break;
			case GameState.SPEAK_TO_DAISY_7:
				if(GameFlags.flags[StoryEvent.GOT_FLOWER_NIGHTSHADE]){
					mainSCript.option1_text.text = GameFlags.flags[StoryEvent.READ_BOOK] ? "*Give Nigthshade*" : "*Give flower from entrance*";
					mainSCript.option1.gameObject.SetActive(true);
				}
				else{
					mainSCript.option1_text.text = "";
					mainSCript.option1.gameObject.SetActive(false);
				}
				if(GameFlags.flags[StoryEvent.GOT_FLOWER_SEAFIG]){
					mainSCript.option2_text.text = GameFlags.flags[StoryEvent.READ_BOOK] ? "*Give Seafig*" : "*Give flower from beach*";
					mainSCript.option2.gameObject.SetActive(true);
				}
				else{
					mainSCript.option2_text.text = "";
					mainSCript.option2.gameObject.SetActive(false);
				}
				if(GameFlags.flags[StoryEvent.GOT_FLOWER_THISTLE]){
					mainSCript.option3_text.text = GameFlags.flags[StoryEvent.READ_BOOK] ? "*Give Thistle*" : "*Give  flower from cafe*";
					mainSCript.option3.gameObject.SetActive(true);
				}
				else{
					mainSCript.option3_text.text = "";
					mainSCript.option3.gameObject.SetActive(false);
				}
				mainSCript.option4_text.text = "";
				mainSCript.option4.gameObject.SetActive(false);

			break;
			case GameState.SPEAK_TO_DAISY_8:
				mainSCript.option1_text.text = "I'd love that";
				mainSCript.option1.gameObject.SetActive(true);
				
				mainSCript.option2_text.text = "";
				mainSCript.option2.gameObject.SetActive(false);
				
				mainSCript.option3_text.text = "";
				mainSCript.option3.gameObject.SetActive(false);
				
				mainSCript.option4_text.text = "";
				mainSCript.option4.gameObject.SetActive(false);
				break;
			case GameState.DATE_DAISY_1:
				mainSCript.option1_text.text = "No sweat";
				mainSCript.option1.gameObject.SetActive(true);
				
				mainSCript.option2_text.text = "";
				mainSCript.option2.gameObject.SetActive(false);
				
				mainSCript.option3_text.text = "";
				mainSCript.option3.gameObject.SetActive(false);
				
				mainSCript.option4_text.text = "";
				mainSCript.option4.gameObject.SetActive(false);
			break;
			case GameState.DATE_DAISY_2:
				mainSCript.option1_text.text = "*Wipes hand on her*";
				mainSCript.option1.gameObject.SetActive(true);
				
				mainSCript.option2_text.text = "No problem. I'm glad you liked it.";
				mainSCript.option2.gameObject.SetActive(true);
				
				mainSCript.option3_text.text = "";
				mainSCript.option3.gameObject.SetActive(false);
				
				mainSCript.option4_text.text = "";
				mainSCript.option4.gameObject.SetActive(false);
			break;
		}
	}
	
	void changeMood(Moods mood){
		print ("Change Daisy mood to " + mood);
		Sprite newSprite = null;
		switch (mood) {
		case Moods.SMILE:
			newSprite = Resources.Load<Sprite> ("Images/Daisy/daisy_smile");
			break;
		case Moods.ANGRY:
			newSprite = Resources.Load<Sprite> ("Images/Daisy/daisy_angry");
			break;
		case Moods.HAPPY:
			newSprite = Resources.Load<Sprite> ("Images/Daisy/daisy_happy");
			break;		
		case Moods.NEUTRAL:
		default:
			newSprite = Resources.Load<Sprite> ("Images/Daisy/daisy_neutral");
			break;
		}
		mainSCript.Daisy_big.image.sprite = newSprite;
		mainSCript.baeDates.Daisy.image.sprite = newSprite;
	}

	void TakeFocus(bool showCLoseButton){
		iTween.MoveTo(mainSCript.Daisy_big.gameObject, iTween.Hash(
			"x", mainSCript.Daisy_big.transform.position.x + mainSCript.slide
			, "islocal", false
			, "time", 1f
			, "delay", 0
			));
		
		// hide small character
		mainSCript.Daisy.gameObject.SetActive(false);
		// hide nav
		mainSCript.currNavButtons.SetActive(false);
		
		// show larger character
		mainSCript.Daisy_big.gameObject.SetActive(true);
		mainSCript.conversationPanel.SetActive(true);
		mainSCript.closeConvoButton.SetActive (showCLoseButton);
		mainSCript.blocker.SetActive(true);
		mainSCript.book.SetActive(false);
	}
}
	