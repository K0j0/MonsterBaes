using UnityEngine;
using System.Collections;

public class BuzzConvo : MonoBehaviour {
	public MainScript mainSCript;
	
	public void TalkToMe(){
        // first check for date
        if (GameFlags.flags[StoryEvent.DATING_BUZZ] == true)
        {
            mainSCript.closeConvoButton.SetActive(false);
            switch (mainSCript.lastState)
            {
                case GameState.DATE_BUZZ_1:
                    changeMood(Moods.SMILE);
                    mainSCript.conversationPanel.SetActive(true);
					mainSCript.say(Baes.BUZZ, "Thanks for keeping me oiled up and limber");
					setOptions(GameState.DATE_BUZZ_1);
					mainSCript.showOptions();
                break;

                case GameState.DATE_BUZZ_1A:
                    changeMood(Moods.HAPPY);
                    mainSCript.conversationPanel.SetActive(true);
                    mainSCript.say(Baes.BUZZ, "M'ere, sweet cheeks!");

                    HelperFunctions.DelayCallback(1f, () =>
                    {
                        mainSCript.baeDates.Kiss(Baes.BUZZ);
                        mainSCript.conversationPanel.SetActive(false);
                    });
                break;
            }
        }
        else
        {
		    if(GameFlags.flags[StoryEvent.NEED_OIL] == true){
			    if(GameFlags.flags[StoryEvent.GOT_OIL]){
                    changeMood(Moods.HAPPY);

                    switch (mainSCript.lastState)
                    {
                        case GameState.START_ZEN:
                            mainSCript.lastState = GameState.SPEAK_TO_BUZZ_6;
                            TakeFocus(false);
                            mainSCript.say(Baes.BUZZ, "Oh wonderful! You've brought me some oil. How about I get you lunch to repay you?");
                            setOptions(GameState.SPEAK_TO_BUZZ_6);
                            mainSCript.showOptions();
                        break;

                        case GameState.SPEAK_TO_BUZZ_6A:
                            mainSCript.closeConversationPanel();
				            mainSCript.StartDate(Baes.BUZZ);
                            changeMood(Moods.NEUTRAL);
                            mainSCript.lastState = GameState.DATE_BUZZ_1; // need to call this after closing panel
                        break;
                    }
			    }
			    else{
				    changeMood(Moods.SMILE);
				    TakeFocus(true);
				    mainSCript.say(Baes.BUZZ, "I'm so dry...");
			    }
		    }
		    else{
			    switch (mainSCript.lastState)
			    {
			    case GameState.START_ZEN:
				    mainSCript.lastState = GameState.SPEAK_TO_BUZZ_1;
				    changeMood(Moods.NEUTRAL);
				    TakeFocus(false);
				    mainSCript.say (Baes.BUZZ, "Namaste.");				
				    setOptions(GameState.SPEAK_TO_BUZZ_1);
				    mainSCript.showOptions();
				    break;
				
			    case GameState.SPEAK_TO_BUZZ_1A:				
				    changeMood(Moods.SMILE);
				    mainSCript.say(Baes.BUZZ, "Heh. Flattery will get you nowhere");
				    mainSCript.closeConvoButton.SetActive (true);
				    break;
				
			    case GameState.SPEAK_TO_BUZZ_1B:
				    mainSCript.lastState = GameState.SPEAK_TO_BUZZ_2;
				    mainSCript.say(Baes.BUZZ, "Cleaning up the beach...");
				    setOptions(GameState.SPEAK_TO_BUZZ_2);
				    mainSCript.showOptions();
				    break;
				
			    case GameState.SPEAK_TO_BUZZ_1C:
				    mainSCript.closeConversationPanel();
				    break;
				
			    case GameState.SPEAK_TO_BUZZ_2A:
				    mainSCript.closeConvoButton.SetActive(true);
				    mainSCript.say(Baes.BUZZ, "...");
				    break;
				
			    case GameState.SPEAK_TO_BUZZ_2B:
				    mainSCript.lastState = GameState.SPEAK_TO_BUZZ_3;
				    mainSCript.say(Baes.BUZZ, "Do you know...");
				    setOptions(GameState.SPEAK_TO_BUZZ_3);
				    mainSCript.showOptions();
				    break;
				
			    case GameState.SPEAK_TO_BUZZ_3A:
				    mainSCript.lastState = GameState.SPEAK_TO_BUZZ_4;
				    mainSCript.closeConvoButton.SetActive(true);
				    mainSCript.say(Baes.BUZZ, "Well allow me to illuminate you...");
				    setOptions(GameState.SPEAK_TO_BUZZ_4);
				    mainSCript.showOptions();
				    break;
				
			    case GameState.SPEAK_TO_BUZZ_3B:
				    mainSCript.closeConvoButton.SetActive(true);
				    mainSCript.say(Baes.BUZZ, "...");
				    changeMood(Moods.ANGRY);
				    break;
				
			    case GameState.SPEAK_TO_BUZZ_4A:
				    mainSCript.lastState = GameState.SPEAK_TO_BUZZ_5;
				    mainSCript.closeConvoButton.SetActive(true);
				    mainSCript.say(Baes.BUZZ, "Mhm, and all of that trash collection...");
				    setOptions(GameState.SPEAK_TO_BUZZ_5);
				    mainSCript.showOptions();
				    break;
				
			    case GameState.SPEAK_TO_BUZZ_4B:
				    mainSCript.closeConvoButton.SetActive(true);
				    mainSCript.say(Baes.BUZZ, "...");
				    changeMood(Moods.ANGRY);
				    break;
				
			    case GameState.SPEAK_TO_BUZZ_5A:
				    changeMood(Moods.SMILE);
				    GameFlags.flags[StoryEvent.NEED_OIL] = true;
				    mainSCript.closeConvoButton.SetActive(true);
				    mainSCript.say(Baes.BUZZ, "If you're willing to get your hands dirty...");
				    mainSCript.closeConvoButton.SetActive(true);
				    break;
				
			    case GameState.SPEAK_TO_BUZZ_5B:
				    mainSCript.closeConvoButton.SetActive(true);
				    mainSCript.say(Baes.BUZZ, "...");
				    changeMood(Moods.ANGRY);
				    break;
				
			    default:
				    Debug.LogError("Whoa, didn't think you could talk to Buzz during this state: " + mainSCript.lastState);
				    break;
			    }
		    }
        }
		
		
	}
	
	void setOptions(GameState forState){
		switch (forState) {
		case GameState.SPEAK_TO_BUZZ_1:
			mainSCript.option1_text.text = "What's cookin' good lookin'?";
			mainSCript.option1.gameObject.SetActive(true);
			
			mainSCript.option2_text.text = "What are you up to on the beach all by your lonesome?";
			mainSCript.option2.gameObject.SetActive(true);
			
			mainSCript.option3_text.text = "Nevermind";
			mainSCript.option3.gameObject.SetActive(true);
			
			mainSCript.option4_text.text = "";
			mainSCript.option4.gameObject.SetActive(false);
			break;
		case GameState.SPEAK_TO_BUZZ_2:
			mainSCript.option1_text.text = "Well...good luck with that!";
			mainSCript.option1.gameObject.SetActive(true);
			
			mainSCript.option2_text.text = "Then why are you still out here if no here?";
			mainSCript.option2.gameObject.SetActive(true);
			
			mainSCript.option3_text.text = "";
			mainSCript.option3.gameObject.SetActive(false);
			
			mainSCript.option4_text.text = "";
			mainSCript.option4.gameObject.SetActive(false);
			break;
		case GameState.SPEAK_TO_BUZZ_3:
			mainSCript.option1_text.text = "Not really no...";
			mainSCript.option1.gameObject.SetActive(true);
			
			mainSCript.option2_text.text = "Do I need to?";
			mainSCript.option2.gameObject.SetActive(true);
			
			mainSCript.option3_text.text = "";
			mainSCript.option3.gameObject.SetActive(false);
			
			mainSCript.option4_text.text = "";
			mainSCript.option4.gameObject.SetActive(false);
			break;
		case GameState.SPEAK_TO_BUZZ_4:
			mainSCript.option1_text.text = "Wait, seriously?";
			mainSCript.option1.gameObject.SetActive(true);
			
			mainSCript.option2_text.text = "Wow...interesting";
			mainSCript.option2.gameObject.SetActive(true);
			
			mainSCript.option3_text.text = "";
			mainSCript.option3.gameObject.SetActive(false);
			
			mainSCript.option4_text.text = "";
			mainSCript.option4.gameObject.SetActive(false);
			break;
		case GameState.SPEAK_TO_BUZZ_5:
			mainSCript.option1_text.text = "Oh no, that's terrible. Can I help at all?";
			mainSCript.option1.gameObject.SetActive(true);
			
			mainSCript.option2_text.text = "What has nature ever done for me?";
			mainSCript.option2.gameObject.SetActive(true);
			
			mainSCript.option3_text.text = "";
			mainSCript.option3.gameObject.SetActive(false);
			
			mainSCript.option4_text.text = "";
			mainSCript.option4.gameObject.SetActive(false);
			break;

        case GameState.SPEAK_TO_BUZZ_6:
            mainSCript.option1_text.text = "Uh, sure. Why not.";
            mainSCript.option1.gameObject.SetActive(true);

            mainSCript.option2_text.text = "";
            mainSCript.option2.gameObject.SetActive(false);

            mainSCript.option3_text.text = "";
            mainSCript.option3.gameObject.SetActive(false);

            mainSCript.option4_text.text = "";
            mainSCript.option4.gameObject.SetActive(false);
            break;

        case GameState.DATE_BUZZ_1:
            mainSCript.option1_text.text = "No problem!";
            mainSCript.option1.gameObject.SetActive(true);

            mainSCript.option2_text.text = "Erm, ok...";
            mainSCript.option2.gameObject.SetActive(true);

            mainSCript.option3_text.text = "";
            mainSCript.option3.gameObject.SetActive(false);

            mainSCript.option4_text.text = "";
            mainSCript.option4.gameObject.SetActive(false);
            break;
		}
	}
	
	void changeMood(Moods mood){
		print ("Change Buzz mood to " + mood);
		Sprite newSprite = null;
		switch (mood) {
		case Moods.SMILE:
			newSprite = Resources.Load<Sprite> ("Images/Buzz/buzz_smile");
			break;
		case Moods.ANGRY:
			newSprite = Resources.Load<Sprite> ("Images/Buzz/buzz_angry");
			break;
		case Moods.HAPPY:
			newSprite = Resources.Load<Sprite> ("Images/Buzz/buzz_happy");
			break;		
		case Moods.NEUTRAL:
		default:
			newSprite = Resources.Load<Sprite> ("Images/Buzz/buzz_neutral");
			break;
		}
		mainSCript.Buzz_big.image.sprite = newSprite;
        mainSCript.baeDates.Buzz.image.sprite = newSprite;
	}

	void TakeFocus(bool showCloseButton){
		iTween.MoveTo(mainSCript.Buzz_big.gameObject, iTween.Hash(
			"x", mainSCript.Buzz_big.transform.position.x + mainSCript.slide
			, "islocal", false
			, "time", 1f
			, "delay", 0
			));
		
		// hide small character
		mainSCript.Buzz.gameObject.SetActive(false);
		// hide nav
		mainSCript.currNavButtons.SetActive(false);
		
		// show larger character
		mainSCript.Buzz_big.gameObject.SetActive(true);
		mainSCript.conversationPanel.SetActive(true);
		mainSCript.closeConvoButton.SetActive (true);
		mainSCript.blocker.SetActive(true);			
		mainSCript.closeConvoButton.SetActive (showCloseButton);
	}
}
