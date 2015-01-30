using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class TitleScript : MonoBehaviour {
	public GameObject startPrompt;
	public GameObject enterNamePanel;
	public Text nameText;
	public Button submitNameButton;
    public Button beginButton;

	bool ready = false;
	bool showPanel = true;
    public Text creditsText;
    public GameObject credits;

	// Use this for initialization
	void Start () {
		HelperFunctions.DelayCallback (1f, () => {
			startPrompt.SetActive(true);
			ready = true;
		});
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit();
		}

		// don't enable submit button without text in input
		if(nameText.text.Length > 0){
			submitNameButton.interactable = true;
		} else submitNameButton.interactable = false;
	}

    public void onBegin()
    {
        print("onBegin");
		if (ready) {
		    enterNamePanel.SetActive(true);
//				InputField input = enterNamePanel.GetComponentInChildren<InputField>();
//				EventSystem.current.SetSelectedGameObject(enterNamePanel);

			// slide in name panel
			if(showPanel){
				showPanel = false;

                // hide credtis toggle
                creditsText.gameObject.SetActive(false);

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

    }

	public void onEnterName(){
		GameData.playerName = nameText.text;
		Debug.Log("Set name to: " + GameData.playerName);
		if(nameText.text.Length > 0){
			Application.LoadLevel("MainScene");
		}
	}

    public void onToggleCredits()
    {
        credits.SetActive(!credits.activeInHierarchy);        
        if (credits.activeInHierarchy)
        {
            creditsText.text = "BACK";
            beginButton.gameObject.SetActive(false);
        }
        else
        {
            creditsText.text = "CREDITS";
            beginButton.gameObject.SetActive(true);
        }
    }
}
