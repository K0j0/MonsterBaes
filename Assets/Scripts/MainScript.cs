using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainScript : MonoBehaviour {	

	public GameObject thisGameObject;
	public Items items;
	public BaeDate baeDates;
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
	public static MainScript instance;
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
		onNavigate (GameAreas.BEACH);
	}

	void Update(){
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit();
		}
	}

	public void closeConversationPanel(){
		conversationPanel.SetActive(false);
		closeConvoButton.SetActive(true);
		blocker.SetActive(false);
		buttonGroup.SetActive(false);
		
		switch (currArea) {
			case GameAreas.CLASSROOM:
				lastState = GameState.SPEAK_TO_DAN;
				// show characters
				Dan.gameObject.SetActive(true);
				// show nav
				currNavButtons.SetActive(true);
				// hide larger character
				resetDanBig();
			break;
			case GameAreas.BEACH:
				lastState = GameState.START_BEACH;
				// show characters
				Klulu.gameObject.SetActive(true);
				// show nav
				currNavButtons.SetActive(true);
				// hide larger character
				resetKluluBig();
			break;
			case GameAreas.ZEN:
				lastState = GameState.START_ZEN;
				// show characters
				Buzz.gameObject.SetActive(true);
				// show nav
				currNavButtons.SetActive(true);
				// hide larger character
				resetBuzzBig();
			break;
			case GameAreas.FLORIST:
				lastState = GameState.START_FLORIST;
				// show characters
				Daisy.gameObject.SetActive(true);
				// show nav
				currNavButtons.SetActive(true);
				// hide larger character
				resetDaisyBig();
				// show book again
				book.SetActive(true);
			break;
			case GameAreas.ENTRACE_OUTSIDE:
				gameAreas.entraceOutsideNav.SetActive(true);
			break;
			case GameAreas.CAFE_OUTSIDE:
				gameAreas.cafeOutsideNav.SetActive(true);
			break;
			case GameAreas.PALETTE:
				gameAreas.paletteNav.SetActive(true);
			break;
			case GameAreas.CAFE_INSIDE:
				gameAreas.cafeInsideNav.SetActive(true);
			break;
			case GameAreas.LEFT_MID_2:
				gameAreas.leftMid2Nav.SetActive(true);
			break;
		}
	}

	public void say(Baes who, string what){
		convoText.text = "";
		switch (who) {
			case Baes.YOU:
				convoText.text = GameData.playerName + ":\n";
			break;
			case Baes.KULU:
				convoText.text = "Klulu:\n";
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
//		newPos.x = newPos.x - slide;
		newPos.x = 548;
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
			case GameAreas.DATE:
				currArea = GameAreas.DATE;
				gameAreas.date.SetActive(true);
				gameAreas.date.transform.SetAsLastSibling();
				commonUI.transform.SetAsLastSibling();
			break;
			default:
				Debug.LogError("Unknown area: " + area + ". Maybe that's a type?");
			break;
		}
	}

	public void SelectItem(string itemName){
		print ("Selected " + itemName);
		switch(itemName){
			case "trashbags":
				if(GameFlags.flags[StoryEvent.NEED_TRASH_BAGS]){ say (Baes.YOU, "I can use these to help Klulu clean up the beach");
					GameFlags.flags[StoryEvent.GOT_TRASH_BAGS] = true;
					items.trashBags.SetActive(false);
				}
				else say (Baes.YOU, "It's just some trash bags");
				conversationPanel.SetActive(true);
				gameAreas.leftMid2Nav.SetActive(false);
			break;

			case "thistle":
				if(GameFlags.flags[StoryEvent.NEED_FLOWERS] && !GameFlags.flags[StoryEvent.GOT_FLOWER_THISTLE]){
					if(GameFlags.flags[StoryEvent.READ_BOOK]) say (Baes.YOU, "This is a thistle.");
					else say (Baes.YOU, "I wonder if Daisy would like these?");
					GameFlags.flags[StoryEvent.GOT_FLOWER_THISTLE] = true;
					items.thistle.SetActive(false);
				}
				else say (Baes.YOU, "I wonder what kind of flowers those are?");
				conversationPanel.SetActive(true);
				gameAreas.cafeOutsideNav.SetActive(false);
			break;
			case "seafig":
				if(GameFlags.flags[StoryEvent.NEED_FLOWERS] && !GameFlags.flags[StoryEvent.GOT_FLOWER_SEAFIG]){
					if(GameFlags.flags[StoryEvent.READ_BOOK]) say (Baes.YOU, "Those are seafig");
					else say (Baes.YOU, "I wonder if Daisy would like these?");
					GameFlags.flags[StoryEvent.GOT_FLOWER_SEAFIG] = true;
					items.seafig.SetActive(false);
				}
				else say (Baes.YOU, "I wonder what kind of flowers those are?");
				conversationPanel.SetActive(true);
				gameAreas.beachNav.SetActive(false);
			break;

			case "nightshade":
				if(GameFlags.flags[StoryEvent.NEED_FLOWERS] && !GameFlags.flags[StoryEvent.GOT_FLOWER_NIGHTSHADE] ){
					if(GameFlags.flags[StoryEvent.READ_BOOK]) say (Baes.YOU, "Those are nightshade");
					else say (Baes.YOU, "I wonder if Daisy would like these?");
					GameFlags.flags[StoryEvent.GOT_FLOWER_NIGHTSHADE] = true;
					items.nightshade.SetActive(false);
				}
				else say (Baes.YOU, "I wonder what kind of flowers those are?");
				conversationPanel.SetActive(true);
				gameAreas.entraceOutsideNav.SetActive(false);
			break;
			case "oil":
				if(GameFlags.flags[StoryEvent.NEED_OIL]){ say (Baes.YOU, "This is just what Buzz was looking for");
					items.oilCan.SetActive(false);
					GameFlags.flags[StoryEvent.GOT_OIL] = true;
				}
				else say (Baes.YOU, "It's just some organic oil");
				conversationPanel.SetActive(true);
				gameAreas.paletteNav.SetActive(false);
			break;
			case "glasses":
				if(GameFlags.flags[StoryEvent.NEED_GLASSES] && !GameFlags.flags[StoryEvent.GOT_GLASSES]){
					say (Baes.YOU, "Ah, Dan was looking for these. I'll return them to him");
					items.glasses.SetActive(false);
					GameFlags.flags[StoryEvent.GOT_GLASSES] = true;
				}
				else say (Baes.YOU, "I wonder whose glasses these are?");
				conversationPanel.SetActive(true);
				gameAreas.cafeInsideNav.SetActive(false);
			break;
			case "book":
				GameFlags.flags[StoryEvent.READ_BOOK] = true;
				bookBig.SetActive(true);
				blocker.SetActive(true);
				book.SetActive(false);
				closeConversationPanel();
				gameAreas.floristNav.SetActive(false);
			break;
			default:
				Debug.LogError("What's that? " + itemName);
			break;
		}
	}

	public void CloseBook(){
		currNavButtons.SetActive(true);
		bookBig.SetActive(false);
		book.SetActive(true);
		blocker.SetActive(false);
	}

	int trashTotal = 0;
	public void pickupTrash(int piece){
		if(GameFlags.flags[StoryEvent.GOT_TRASH_BAGS]){ 
			items.alLTrash[piece].SetActive(false);
			++trashTotal;
			if (trashTotal >= items.alLTrash.Length) {
				say (Baes.YOU, "This place is looking cleaner already!");
				GameFlags.flags [StoryEvent.PICKED_UP_ALL_TRASH] = true;
				conversationPanel.SetActive(true);
			}
			else say (Baes.YOU, "One less piece of trash.");
		}
		else{
			say (Baes.YOU, "This place is dirty.");
			conversationPanel.SetActive(true);
		}
	}

	public void StartDate(Baes withWho){
		onNavigate (GameAreas.DATE);
		baeDates.StartDate (withWho);
	}
}
