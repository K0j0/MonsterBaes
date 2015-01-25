using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainScript : MonoBehaviour {	

	public GameObject thisGameObject;
	public GameObject conversationPanel;
	public GameObject blocker;
	public GameObject blockerClassRoom;
	public GameObject blockerZen;
	public GameObject blockerBeach;
	public GameObject blockerFlorist;
	public GameObject closeConvoButton;
	public GameAreas gameAreas;
	public Text convoText;
	public Button Dan;
	public Button Dan_big;
	public Button Klulu;
	public Button Klulu_big;
	public Button Daisy;
	public Button Daisy_big;
	public Button Buzz;
	public Button Buzz_big;
	public GameState lastState = GameState.START;
	public float slide = 50;
	private static MonoBehaviour instance;
	public string currArea;
	public GameObject currNavButtons;
	public GameObject commonUI;
	public ConversationTree convoTree;
	public GameObject book;
	public GameObject bookBig;
	public GameObject[] trash;

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

		currNavButtons = gameAreas.classroomNav;
		convoTree.Init ();
		GameFlags.init ();
		
		conversationPanel.SetActive(false);
		buttonGroup.gameObject.SetActive(false);

		// where to start
		onNavigate (GameAreas.ZEN);
	}

	void Update(){
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit();
		}
	}

	public void closeConversationPanel(){
		switch (currArea) {
			case GameAreas.CLASSROOM:
				lastState = GameState.SPEAK_TO_DAN;
				// show characters
				Dan.gameObject.SetActive(true);
				// show nav
				currNavButtons.SetActive(true);
				// hide larger character
				resetDanBig();
				conversationPanel.SetActive(false);
				closeConvoButton.SetActive(true);
				blocker.SetActive(false);
				// hide buttons too
				buttonGroup.SetActive(false);
			break;
			case GameAreas.BEACH:
				lastState = GameState.START_BEACH;
				// show characters
				Klulu.gameObject.SetActive(true);
				// show nav
				currNavButtons.SetActive(true);
				// hide larger character
				resetKluluBig();
				conversationPanel.SetActive(false);
				closeConvoButton.SetActive(true);
				blocker.SetActive(false);
				// hide buttons too
				buttonGroup.SetActive(false);
			break;
			case GameAreas.ZEN:
				lastState = GameState.START_ZEN;
				// show characters
				Buzz.gameObject.SetActive(true);
				// show nav
				currNavButtons.SetActive(true);
				// hide larger character
				resetBuzzBig();
				conversationPanel.SetActive(false);
				closeConvoButton.SetActive(true);
				blocker.SetActive(false);
				// hide buttons too
				buttonGroup.SetActive(false);
			break;
			case GameAreas.FLORIST:
				lastState = GameState.START_FLORIST;
				// show characters
				Daisy.gameObject.SetActive(true);
				// show nav
				currNavButtons.SetActive(true);
				// hide larger character
				resetDaisyBig();
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

	public void fadeKluluBig(float newX){
		Vector3 newPos = Klulu_big.transform.position;
		newPos.x = newX;
		Klulu_big.transform.position = newPos;
	}

	void resetKluluBig(){
		Vector3 newPos = Klulu_big.transform.position;
		newPos.x = newPos.x - slide;
		Klulu_big.transform.position = newPos;
		Klulu_big.gameObject.SetActive(false);
	}

	void resetBuzzBig(){
		Vector3 newPos = Buzz_big.transform.position;
		newPos.x = newPos.x - slide;
		Buzz_big.transform.position = newPos;
		Buzz_big.gameObject.SetActive(false);
	}

	void resetDaisyBig(){
		Vector3 newPos = Daisy_big.transform.position;
		newPos.x = newPos.x - slide;
		Daisy_big.transform.position = newPos;
		Daisy_big.gameObject.SetActive(false);
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
				blocker = blockerClassRoom;
				lastState = GameState.START; // classroom with Dan
				currNavButtons = gameAreas.classroomNav;
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
				blocker = blockerZen;
				lastState = GameState.START_ZEN;
				currNavButtons = gameAreas.zenNav;
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
				blocker = blockerBeach;
				lastState = GameState.START_BEACH;
				currNavButtons = gameAreas.beachNav;
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
				blocker = blockerFlorist;
				commonUI.transform.SetAsLastSibling();
				lastState = GameState.START_FLORIST;
				currNavButtons = gameAreas.floristNav;
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

	int trashTotal = 0;
	public void pickupTrash(int piece){
		trash[piece].SetActive(false);
		++trashTotal;
		if (trashTotal >= trash.Length) {
			say (Baes.YOU, "This place is looking cleaner already!");
			conversationPanel.SetActive(true);
		}
	}
}
