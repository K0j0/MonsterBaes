using UnityEngine;
using System.Collections.Generic;

public enum Baes{
	YOU,
	DAN,
	KULU,
	BUZZ,
	DAISY
}

public enum GameState{
	START,
	SPEAK_TO_KAEDE_1,
	SPEAK_TO_DAN,
	SPEAK_TO_DAN_1,
	SPEAK_TO_DAN_2,
	SPEAK_TO_DAN_1A,
	SPEAK_TO_DAN_1B,
	SPEAK_TO_DAN_1C
}

public enum StoryEvent{
	SPEAK_TO_KAEDE,
	SPEAK_TO_DAN
}

public class GameFlags{
	public static Dictionary<StoryEvent, bool> flags;

	public static void init(){
		flags = new Dictionary<StoryEvent, bool> ();
		flags [StoryEvent.SPEAK_TO_KAEDE] = false;
		flags [StoryEvent.SPEAK_TO_DAN] = false;
	}
}