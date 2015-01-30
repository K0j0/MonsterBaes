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
				    mainSCript.say(Baes.BUZZ, "Please let me know when you've found some organic oil. Peace.");
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
				    mainSCript.say(Baes.BUZZ, "...");
				    mainSCript.closeConvoButton.SetActive (true);
				    break;
				
			    case GameState.SPEAK_TO_BUZZ_1B:
				    mainSCript.lastState = GameState.SPEAK_TO_BUZZ_2;
				    mainSCript.say(Baes.BUZZ, "I'm practicing Bit-Ram yoga. My circuits heat up to about 200 degrees as I pose.");
				    setOptions(GameState.SPEAK_TO_BUZZ_2);
				    mainSCript.showOptions();
				    break;
				
			    case GameState.SPEAK_TO_BUZZ_1C:
				    mainSCript.closeConversationPanel();
				    break;
				
			    case GameState.SPEAK_TO_BUZZ_2A:
                    changeMood(Moods.SMILE);
				    mainSCript.closeConvoButton.SetActive(true);
				    mainSCript.say(Baes.BUZZ, "I bet you say that to all the robots.");
				    break;
				
			    case GameState.SPEAK_TO_BUZZ_2B:
				    mainSCript.lastState = GameState.SPEAK_TO_BUZZ_3;
				    mainSCript.say(Baes.BUZZ, "Oh it is. I'm actually a bit worried about my gears though. I forgot to consume any organic oil this morning.");
				    setOptions(GameState.SPEAK_TO_BUZZ_3);
				    mainSCript.showOptions();
				    break;
				
			    case GameState.SPEAK_TO_BUZZ_3A:
				    mainSCript.lastState = GameState.SPEAK_TO_BUZZ_4;
				    mainSCript.say(Baes.BUZZ, "Operating at a high temperature for too long can corrupt my memory. Nothing a soft reboot won't fix.");
				    setOptions(GameState.SPEAK_TO_BUZZ_4);
				    mainSCript.showOptions();
				    break;
				
			    case GameState.SPEAK_TO_BUZZ_3B:
                    changeMood(Moods.ANGRY);
				    mainSCript.closeConvoButton.SetActive(true);
				    mainSCript.say(Baes.BUZZ, "I'm detecting some negativity...");
				    changeMood(Moods.ANGRY);
				    break;
				
			    case GameState.SPEAK_TO_BUZZ_4A:
				    mainSCript.lastState = GameState.SPEAK_TO_BUZZ_5;
				    mainSCript.say(Baes.BUZZ, "Say, could you do me a solid and bring me some organiz oil? I can already feel my pistons starting to chafe.");
				    setOptions(GameState.SPEAK_TO_BUZZ_5);
				    mainSCript.showOptions();
				    break;
				
			    case GameState.SPEAK_TO_BUZZ_4B:
				    mainSCript.closeConvoButton.SetActive(true);
				    mainSCript.say(Baes.BUZZ, "We all shut down one day, friend.");
				    break;
				
			    case GameState.SPEAK_TO_BUZZ_5A:
				    changeMood(Moods.SMILE);
				    GameFlags.flags[StoryEvent.NEED_OIL] = true;
				    mainSCript.closeConvoButton.SetActive(true);
				    mainSCript.say(Baes.BUZZ, "Thanks! Please let me know when you've found some. I'd really appreciate it.");				    
				    break;
				
			    case GameState.SPEAK_TO_BUZZ_5B:
				    mainSCript.closeConvoButton.SetActive(true);
				    mainSCript.say(Baes.BUZZ, "Lighten up, bro!");
				    changeMood(Moods.SMILE);
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
			mainSCript.option1_text.text = "Come again?";
			mainSCript.option1.gameObject.SetActive(true);
			
			mainSCript.option2_text.text = "What are you doing?";
			mainSCript.option2.gameObject.SetActive(true);
			
			mainSCript.option3_text.text = "Nevermind";
			mainSCript.option3.gameObject.SetActive(true);
			
			mainSCript.option4_text.text = "";
			mainSCript.option4.gameObject.SetActive(false);
			break;
		case GameState.SPEAK_TO_BUZZ_2:
			mainSCript.option1_text.text = "Wow, you're hot";
			mainSCript.option1.gameObject.SetActive(true);
			
			mainSCript.option2_text.text = "Sounds intense";
			mainSCript.option2.gameObject.SetActive(true);
			
			mainSCript.option3_text.text = "";
			mainSCript.option3.gameObject.SetActive(false);
			
			mainSCript.option4_text.text = "";
			mainSCript.option4.gameObject.SetActive(false);
			break;
		case GameState.SPEAK_TO_BUZZ_3:
			mainSCript.option1_text.text = "Robots forget things?";
			mainSCript.option1.gameObject.SetActive(true);
			
			mainSCript.option2_text.text = "Sucks for you";
			mainSCript.option2.gameObject.SetActive(true);
			
			mainSCript.option3_text.text = "";
			mainSCript.option3.gameObject.SetActive(false);
			
			mainSCript.option4_text.text = "";
			mainSCript.option4.gameObject.SetActive(false);
			break;
		case GameState.SPEAK_TO_BUZZ_4:
			mainSCript.option1_text.text = "Good to know";
			mainSCript.option1.gameObject.SetActive(true);

            mainSCript.option2_text.text = "Sure you won't shut down?";
			mainSCript.option2.gameObject.SetActive(true);
			
			mainSCript.option3_text.text = "";
			mainSCript.option3.gameObject.SetActive(false);
			
			mainSCript.option4_text.text = "";
			mainSCript.option4.gameObject.SetActive(false);
			break;
		case GameState.SPEAK_TO_BUZZ_5:
			mainSCript.option1_text.text = "Sure thing";
			mainSCript.option1.gameObject.SetActive(true);
			
			mainSCript.option2_text.text = "TMI, dude";
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
