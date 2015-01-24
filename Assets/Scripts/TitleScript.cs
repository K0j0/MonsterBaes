using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class TitleScript : MonoBehaviour {
	public GameObject startPrompt;
	public GameObject enterNamePanel;
	public Text nameText;
	public Button submitNameButton;

	bool ready = false;
	bool showPanel = true;

	// Use this for initialization
	void Start () {
		HelperFunctions.DelayCallback (1f, () => {
			startPrompt.SetActive(true);
			ready = true;
		});
	
	}
	
	// Update is called once per frame
	void Update () {
		if (ready) {
			if(Input.GetMouseButton(0)){
				enterNamePanel.SetActive(true);

//				InputField input = enterNamePanel.GetComponentInChildren<InputField>();
//				EventSystem.current.SetSelectedGameObject(enterNamePanel);

				// slide in name panel
				if(showPanel){
					showPanel = false;
					Vector3 pos = enterNamePanel.transform.position;
					pos.y = 500;
					enterNamePanel.transform.position = pos;

					iTween.MoveTo(enterNamePanel, iTween.Hash(
						"y", 0
						, "islocal", true
						, "time", 1f
						, "delay", 0
					));
				}
			}

			// don't enable button without text in it
			if(nameText.text.Length > 0){
				submitNameButton.interactable = true;
			} else submitNameButton.interactable = false;
		}
	}

	public void onEnterName(){
		GameData.playerName = nameText.text;
		Debug.Log("Set name to: " + GameData.playerName);
	}
}
