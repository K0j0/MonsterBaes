using UnityEngine;
using System.Collections.Generic;

public class GameFlags{
	public enum GameState{
		START,
		SPEAK_TO_KAEDE_1,
		SPEAK_TO_DAN
	}

	public enum StoryEvent{
		SPEAK_TO_KAEDE
	}

	public static Dictionary<StoryEvent, bool> flags;

	public static void init(){
		flags = new Dictionary<StoryEvent, bool> ();
		flags [StoryEvent.SPEAK_TO_KAEDE] = false;
	}

}