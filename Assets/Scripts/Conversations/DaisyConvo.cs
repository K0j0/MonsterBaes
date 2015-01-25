using UnityEngine;
using System.Collections;

public class DaisyConvo : MonoBehaviour {
	public MainScript mainSCript;
	
	public void TalkToMe(){
		if(GameFlags.flags[StoryEvent.NEED_FLOWERS] == true){
			changeMood(Moods.SMILE);
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
			mainSCript.closeConvoButton.SetActive (true);
			mainSCript.blocker.SetActive(true);
			mainSCript.book.SetActive(false);
			
			mainSCript.closeConvoButton.SetActive(true);
		//	mainSCript.say(Baes.DAISY, "If you're willing to get your hands dirty...");
		}
		else{
			switch (mainSCript.lastState)
			{
			case GameState.START_FLORIST:
				mainSCript.lastState = GameState.SPEAK_TO_DAISY_1;
				changeMood(Moods.NEUTRAL);
				
				
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
				mainSCript.closeConvoButton.SetActive (false); // don't show close button here
				mainSCript.blocker.SetActive(true);
				mainSCript.book.SetActive(false);
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
			mainSCript.option1_text.text = "";
			mainSCript.option1.gameObject.SetActive(true);
			
			mainSCript.option2_text.text = "What has nature ever done for me?";
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
//		case GameState.SPEAK_TO_DAISY_7:
//			mainSCript.option1_text.text = "Oh...";
//			mainSCript.option1.gameObject.SetActive(true);
//			break;
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
	}
}
