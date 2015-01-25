using UnityEngine;
using System.Collections;

public class KluluConvo : MonoBehaviour {
	public MainScript mainSCript;

	public void TalkToMe(){
		switch (mainSCript.lastState)
		{
			case GameState.START_BEACH:
				mainSCript.lastState = GameState.SPEAK_TO_KLULU_1;
				changeBigMood(Moods.NEUTRAL);

//				if (!GameFlags.flags [StoryEvent.SPEAK_TO_DAN]) {
//					GameFlags.flags [StoryEvent.SPEAK_TO_DAN] = true;
					
					iTween.MoveTo(mainSCript.Klulu_big.gameObject, iTween.Hash(
						"x", mainSCript.Klulu_big.transform.position.x + mainSCript.slide
						, "islocal", false
						, "time", 1f
						, "delay", 0
						));
//					}
					// hide small character
					mainSCript.Klulu.gameObject.SetActive(false);
					// hide nav
					mainSCript.currNavButtons.SetActive(false);
					
					// show larger character
					mainSCript.Klulu_big.gameObject.SetActive(true);
					mainSCript.conversationPanel.SetActive(true);
					mainSCript.closeConvoButton.SetActive (false); // don't show close button here
					mainSCript.blocker.SetActive(true);
					mainSCript.say (Baes.YOU, "Hey you, Mr. Slime");
			break;
			
			default:
				Debug.LogError("Whoa, didn't think you could talk to Klulu during this state: " + mainSCript.lastState);
			break;
		}

	}

	void setOptions(GameState forState){
		switch (forState) {
			case GameState.START:
				mainSCript.option1_text.text = "";
				mainSCript.option1.gameObject.SetActive(true);

				mainSCript.option2_text.text = "?";
				mainSCript.option2.gameObject.SetActive(true);

				mainSCript.option3_text.text = "";
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
