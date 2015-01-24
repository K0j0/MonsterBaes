using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainScript : MonoBehaviour {	

	public GameObject thisGameObject;
	public GameObject conversationPanel;
	public GameObject blocker;
	public GameObject closeConvoButton;
	public GameAreas gameAreas;
	public Text convoText;
	public Button Dan;
	public Button Dan_big;
	public Button Kaede;
	public Button Kaede_big;
	public GameFlags.GameState lastState = GameFlags.GameState.START;
	public float slide = 50;
	private static MonoBehaviour instance;
	private string currArea;
	public GameObject currNavButtons;
	public GameObject commonUI;

	public GameObject buttonGroup;
	public Button option1;
	public Text option1_text;
	public Button option2;
	public Text option2_text;
	public Button option3;
	public Text option3_text;
	public Button option4;
	public Text option4_text;

	// Use this for initialization
	void Start () {
		Debug.Log("Bae.");
		instance = this;
		currArea = GameAreas.CLASSROOM;
		currNavButtons = gameAreas.classroomNav;

		GameFlags.init ();
		switch (lastState) {
		case GameFlags.GameState.START:
				conversationPanel.SetActive(false);
				blocker.SetActive(false);
				Dan.gameObject.SetActive(true);
				Dan_big.gameObject.SetActive(false);
				Kaede.gameObject.SetActive(true);
				Kaede_big.gameObject.SetActive(false);
				buttonGroup.gameObject.SetActive(false);
			break;
		}
	}

	public void talkToKaede(){
		if (GameFlags.flags [GameFlags.StoryEvent.SPEAK_TO_KAEDE]) {
			// hide characters
			Kaede.gameObject.SetActive(false);
			Dan.gameObject.SetActive(false);
			// hide nav
			currNavButtons.SetActive(false);
			
			// show larger character
			Kaede_big.gameObject.SetActive(true);
			conversationPanel.SetActive(true);
			blocker.SetActive(true);
			convoText.text = "KAEDE:\nSo what did he say?";
		}
		else {
			switch (lastState) {
			case GameFlags.GameState.START:
				lastState = GameFlags.GameState.SPEAK_TO_KAEDE_1;
				// hide characters
				Kaede.gameObject.SetActive(false);
				Dan.gameObject.SetActive(false);
				// hide nav
				currNavButtons.SetActive(false);
				
				iTween.MoveTo(Kaede_big.gameObject, iTween.Hash(
					"x", Kaede_big.transform.position.x - slide
					, "islocal", false
					, "time", 1f
					, "delay", 0
					));
				
				// show larger character
				Kaede_big.gameObject.SetActive(true);
				conversationPanel.SetActive(true);
				blocker.SetActive(true);
				convoText.text = "KAEDE:\nHey! You have a crush on Dan right? I hear he's really into politics.";
				break;
			case GameFlags.GameState.SPEAK_TO_KAEDE_1:
				GameFlags.flags[GameFlags.StoryEvent.SPEAK_TO_KAEDE] = true;
				
				// hide characters
				Kaede.gameObject.SetActive(false);
				Dan.gameObject.SetActive(false);
				// hide nav
				currNavButtons.SetActive(false);
				
				// show larger character
				Kaede_big.gameObject.SetActive(true);
				conversationPanel.SetActive(true);
				blocker.SetActive(true);
				convoText.text = "KAEDE:\nWhy don't you try talking to Dan?";
				break;
			
			}
		}

	}

	public void talkToDan(){
		if (!GameFlags.flags [GameFlags.StoryEvent.SPEAK_TO_DAN]) {
			GameFlags.flags [GameFlags.StoryEvent.SPEAK_TO_DAN] = true;

			iTween.MoveTo(Dan_big.gameObject, iTween.Hash(
				"x", Dan_big.transform.position.x + slide
				, "islocal", false
				, "time", 1f
				, "delay", 0
				));
		}
		// hide characters
		Kaede.gameObject.SetActive(false);
		Dan.gameObject.SetActive(false);
		// hide nav
		currNavButtons.SetActive(false);
		
		// show larger character
		Dan_big.gameObject.SetActive(true);
		conversationPanel.SetActive(true);
		closeConvoButton.SetActive (false); // don't show close button here
		blocker.SetActive(true);
		convoText.text = "DAN:\nWhat's up?";

		HelperFunctions.DelayCallback (1f, () => {
			buttonGroup.SetActive (true);
		});


		setOptions(GameFlags.GameState.SPEAK_TO_DAN);
	}

	public void closeConversationPanel(){
		switch (lastState) {
			case GameFlags.GameState.START:
			case GameFlags.GameState.SPEAK_TO_KAEDE_1:
					lastState = GameFlags.GameState.SPEAK_TO_KAEDE_1;
					// show characters
					Kaede.gameObject.SetActive(true);
					Dan.gameObject.SetActive(true);
					// show nav
					currNavButtons.SetActive(true);
					// hide larger character
					resetKaedeBig();
					conversationPanel.SetActive(false);
					blocker.SetActive(false);
			break;
		}
	}

	public void fadeKaedeBig(float newX){
		Vector3 newPos = Kaede_big.transform.position;
		newPos.x = newX;
		Kaede_big.transform.position = newPos;
	}

	void resetKaedeBig(){
		Vector3 newPos = Kaede_big.transform.position;
		newPos.x = newPos.x + slide;
		Kaede_big.transform.position = newPos;
		Kaede_big.gameObject.SetActive(false);
	}

	public void optionChosen(int choice){
		Debug.Log ("Chose Option " + choice);
		switch (lastState) {
			case GameFlags.GameState.START:
			case GameFlags.GameState.SPEAK_TO_KAEDE_1:
				
			break;
		}
	}

	void setOptions(GameFlags.GameState forState){
		switch (forState) {
			case GameFlags.GameState.SPEAK_TO_DAN:
				option1_text.text = "Hey, Dan...";
				option2_text.text = "Hey Dan. Did you see the debate last night?";
				option3_text.text = "Hey Dan. It sure is nice out right!";
				option4_text.text = "Hey Dan. What's with your hair?";
			break;
		}
	}

	public void onNavigate(string area){
		print ("Navigate to " + area);
		switch (area) {
			case GameAreas.CLASSROOM:
				currArea = GameAreas.CLASSROOM;
				gameAreas.classroom.SetActive(true);
				gameAreas.classroom.transform.SetAsLastSibling();
				commonUI.transform.SetAsLastSibling();
			break;
			case GameAreas.CLASSROOM_BLUE:
				currArea = GameAreas.CLASSROOM_BLUE;
				gameAreas.classroomBlue.SetActive(true);
				gameAreas.classroomBlue.transform.SetAsLastSibling();
				commonUI.transform.SetAsLastSibling();
			break;
			case GameAreas.CLASSROOM_RED:
				currArea = GameAreas.CLASSROOM_RED;
				gameAreas.classroomRed.SetActive(true);
				gameAreas.classroomRed.transform.SetAsLastSibling();
				commonUI.transform.SetAsLastSibling();
			break;
			default:
				Debug.LogError("Unknown area: " + area + ". Maybe that's a type?");
			break;
		}
	}
}
