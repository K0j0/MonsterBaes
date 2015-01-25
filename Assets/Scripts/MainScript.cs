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
	public GameState lastState = GameState.START;
	public float slide = 50;
	private static MonoBehaviour instance;
	private string currArea;
	public GameObject currNavButtons;
	public GameObject commonUI;
	public ConversationTree convoTree;
	public GameObject book;
	public GameObject bookBig;

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
		convoTree.Init ();

		GameFlags.init ();
		switch (lastState) {
		case GameState.START:
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

	void Update(){
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit();
		}
	}

//	public void talkToKaede(){
//		if (GameFlags.flags [StoryEvent.SPEAK_TO_KAEDE]) {
//			// hide characters
//			Kaede.gameObject.SetActive(false);
//			Dan.gameObject.SetActive(false);
//			// hide nav
//			currNavButtons.SetActive(false);
//			
//			// show larger character
//			Kaede_big.gameObject.SetActive(true);
//			conversationPanel.SetActive(true);
//			blocker.SetActive(true);
//			convoText.text = "KAEDE:\nSo what did he say?";
//		}
//		else {
//			switch (lastState) {
//			case GameState.START:
//				lastState = GameState.SPEAK_TO_KAEDE_1;
//				// hide characters
//				Kaede.gameObject.SetActive(false);
//				Dan.gameObject.SetActive(false);
//				// hide nav
//				currNavButtons.SetActive(false);
//				
//				iTween.MoveTo(Kaede_big.gameObject, iTween.Hash(
//					"x", Kaede_big.transform.position.x - slide
//					, "islocal", false
//					, "time", 1f
//					, "delay", 0
//					));
//				
//				// show larger character
//				Kaede_big.gameObject.SetActive(true);
//				conversationPanel.SetActive(true);
//				blocker.SetActive(true);
//				convoText.text = "KAEDE:\nHey! You have a crush on Dan right? I hear he's really into politics.";
//				break;
//			case GameState.SPEAK_TO_KAEDE_1:
//				GameFlags.flags[StoryEvent.SPEAK_TO_KAEDE] = true;
//				
//				// hide characters
//				Kaede.gameObject.SetActive(false);
//				Dan.gameObject.SetActive(false);
//				// hide nav
//				currNavButtons.SetActive(false);
//				
//				// show larger character
//				Kaede_big.gameObject.SetActive(true);
//				conversationPanel.SetActive(true);
//				blocker.SetActive(true);
//				convoText.text = "KAEDE:\nWhy don't you try talking to Dan?";
//				break;
//			
//			}
//		}
//
//	}

	public void closeConversationPanel(){
		switch (currArea) {
			case GameAreas.CLASSROOM:
				lastState = GameState.SPEAK_TO_DAN;
				// show characters
				Kaede.gameObject.SetActive(true);
				Dan.gameObject.SetActive(true);
				// show nav
				currNavButtons.SetActive(true);
				// hide larger character
				resetKaedeBig();
				resetDanBig();
				conversationPanel.SetActive(false);
				closeConvoButton.SetActive(true);
				blocker.SetActive(false);
				// hide buttons too
				buttonGroup.SetActive(false);
			break;
		}
	}

	public void say(Baes who, string what){
		convoText.text = "";
		switch (who) {
			case Baes.YOU:
				convoText.text = GameData.playerName + ":\n";
			break;
			case Baes.DAN:
				convoText.text = "Dan:\n";
			break;
			case Baes.BUZZ:
				convoText.text = "Buzz:\n";
			break;
			case Baes.DAISY:
				convoText.text = "Daisy:\n";
			break;
		}
		convoText.text += what;
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

	void resetDanBig(){
//		Vector3 newPos = Dan_big.transform.position;
//		newPos.x = newPos.x - slide;
//		Dan_big.transform.position = newPos;
		Dan_big.gameObject.SetActive(false);
	}

	public void showOptions(){
		print ("show options");
		HelperFunctions.DelayCallback (1.5f, () => {
			buttonGroup.SetActive (true);
		});
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
			case GameAreas.LEFT_MID_2:
				currArea = GameAreas.LEFT_MID_2;
				gameAreas.leftMid2.SetActive(true);
				gameAreas.leftMid2.transform.SetAsLastSibling();
				commonUI.transform.SetAsLastSibling();
			break;
			case GameAreas.RIGHT_MID_1:
				currArea = GameAreas.RIGHT_MID_1;
				gameAreas.rightMid1.SetActive(true);
				gameAreas.rightMid1.transform.SetAsLastSibling();
				commonUI.transform.SetAsLastSibling();
			break;
			case GameAreas.RIGHT_MID_2:
				currArea = GameAreas.RIGHT_MID_2;
				gameAreas.rightMid2.SetActive(true);
				gameAreas.rightMid2.transform.SetAsLastSibling();
				commonUI.transform.SetAsLastSibling();
			break;
			case GameAreas.ZEN:
				currArea = GameAreas.ZEN;
				gameAreas.zen.SetActive(true);
				gameAreas.zen.transform.SetAsLastSibling();
				commonUI.transform.SetAsLastSibling();
			break;
			case GameAreas.TOP_LEFT_2:
				currArea = GameAreas.TOP_LEFT_2;
				gameAreas.topLeft2.SetActive(true);
				gameAreas.topLeft2.transform.SetAsLastSibling();
				commonUI.transform.SetAsLastSibling();
			break;
			case GameAreas.CAFE_INSIDE:
				currArea = GameAreas.CAFE_INSIDE;
				gameAreas.cafeInside.SetActive(true);
				gameAreas.cafeInside.transform.SetAsLastSibling();
				commonUI.transform.SetAsLastSibling();
			break;
			case GameAreas.CAFE_OUTSIDE:
				currArea = GameAreas.CAFE_OUTSIDE;
				gameAreas.cafeOutside.SetActive(true);
				gameAreas.cafeOutside.transform.SetAsLastSibling();
				commonUI.transform.SetAsLastSibling();
			break;
			case GameAreas.BEACH:
				currArea = GameAreas.BEACH;
				gameAreas.beach.SetActive(true);
				gameAreas.beach.transform.SetAsLastSibling();
				commonUI.transform.SetAsLastSibling();
			break;
			case GameAreas.ENTRACE_OUTSIDE:
				currArea = GameAreas.ENTRACE_OUTSIDE;
				gameAreas.entraceOutside.SetActive(true);
				gameAreas.entraceOutside.transform.SetAsLastSibling();
				commonUI.transform.SetAsLastSibling();
			break;
			case GameAreas.FLORIST:
				currArea = GameAreas.FLORIST;
				gameAreas.florist.SetActive(true);
				gameAreas.florist.transform.SetAsLastSibling();
				commonUI.transform.SetAsLastSibling();
			break;
				case GameAreas.ENTRACE_1:
				currArea = GameAreas.ENTRACE_1;
				gameAreas.entrace1.SetActive(true);
				gameAreas.entrace1.transform.SetAsLastSibling();
				commonUI.transform.SetAsLastSibling();
			break;
			case GameAreas.ENTRANCE_2:
				currArea = GameAreas.ENTRANCE_2;
				gameAreas.entrace2.SetActive(true);
				gameAreas.entrace2.transform.SetAsLastSibling();
				commonUI.transform.SetAsLastSibling();
			break;
			case GameAreas.PALETTE:
				currArea = GameAreas.PALETTE;
				gameAreas.palette.SetActive(true);
				gameAreas.palette.transform.SetAsLastSibling();
				commonUI.transform.SetAsLastSibling();
			break;
			case GameAreas.BOTTOM_LEFT_1:
				currArea = GameAreas.BOTTOM_LEFT_1;
				gameAreas.bottomLeft1.SetActive(true);
				gameAreas.bottomLeft1.transform.SetAsLastSibling();
				commonUI.transform.SetAsLastSibling();
			break;
			case GameAreas.BOTTOM_LEFT_2:
				currArea = GameAreas.BOTTOM_LEFT_2;
				gameAreas.bottomLeft2.SetActive(true);
				gameAreas.bottomLeft2.transform.SetAsLastSibling();
				commonUI.transform.SetAsLastSibling();
			break;
			default:
				Debug.LogError("Unknown area: " + area + ". Maybe that's a type?");
			break;
		}
	}

	public void SelectItem(string itemName){
		switch(itemName){
			case "trashBags":
				if(GameFlags.flags[StoryEvent.NEED_TRASH_BAGS]) say (Baes.YOU, "I can use these to help Klulu clean up the beach");
				else say (Baes.YOU, "It's just some trash bags");
			break;
			case "flowers1":
				if(GameFlags.flags[StoryEvent.NEED_FLOWERS]){
					if(GameFlags.flags[StoryEvent.READ_BOOK]) say (Baes.YOU, "Those are flower1");
					else say (Baes.YOU, "I wonder if Daisy would like these?");
				}
				else say (Baes.YOU, "I wonder what kind of flowers those are?");
				conversationPanel.SetActive(true);
			break;
			case "flowers2":
				if(GameFlags.flags[StoryEvent.NEED_FLOWERS]){
					if(GameFlags.flags[StoryEvent.READ_BOOK]) say (Baes.YOU, "Those are flower1");
					else say (Baes.YOU, "I wonder if Daisy would like these?");
				}
				else say (Baes.YOU, "I wonder what kind of flowers those are?");
			break;

			case "flowers3":
				if(GameFlags.flags[StoryEvent.NEED_FLOWERS]){
					if(GameFlags.flags[StoryEvent.READ_BOOK]) say (Baes.YOU, "Those are flower1");
					else say (Baes.YOU, "I wonder if Daisy would like these?");
				}
				else say (Baes.YOU, "I wonder what kind of flowers those are?");
			break;
			case "oil":
				if(GameFlags.flags[StoryEvent.NEED_OIL]) say (Baes.YOU, "This is just what Buzz was looking for");
				else say (Baes.YOU, "It's just some peanut oil");
			break;
			case "glasses":
				if(GameFlags.flags[StoryEvent.NEED_GLASSES]) say (Baes.YOU, "Ah, Dan was looking for these. I'll return them to him");
				else say (Baes.YOU, "I wonder whose glasses these are?");
			break;
			case "book":
				GameFlags.flags[StoryEvent.READ_BOOK] = true;
				bookBig.SetActive(true);
				blocker.SetActive(true);
				book.SetActive(false);
				closeConversationPanel();
			break;
			default:
				Debug.LogError("What's that? " + itemName);
			break;
		}
	}

	public void CloseBook(){
		bookBig.SetActive(false);
		book.SetActive(true);
		blocker.SetActive(false);
	}
}
