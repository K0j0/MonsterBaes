using UnityEngine;
using System.Collections.Generic;

public enum Baes{
	YOU,
	DAN,
	KULU,
	BUZZ,
	DAISY
}

public enum Moods{
	NEUTRAL,
	SMILE,
	ANGRY,
	HAPPY
}

public enum GameState{
	// for Dan
	START,
	SPEAK_TO_DAN,
	SPEAK_TO_DAN_1,
	SPEAK_TO_DAN_1_0,
	SPEAK_TO_DAN_2,
	SPEAK_TO_DAN_1A,
	SPEAK_TO_DAN_1B,
	SPEAK_TO_DAN_1C,
	SPEAK_TO_DAN_2A,
	SPEAK_TO_DAN_2B,
	SPEAK_TO_DAN_3,
	SPEAK_TO_DAN_3A,
	SPEAK_TO_DAN_3B,
	SPEAK_TO_DAN_4_1,
	SPEAK_TO_DAN_4_2,
	SPEAK_TO_DAN_4A,
	SPEAK_TO_DAN_4B,
	SPEAK_TO_DAN_5,
	SPEAK_TO_DAN_5A,
	SPEAK_TO_DAN_5B,

	// for Klulu
	START_BEACH,
	SPEAK_TO_KLULU_1,
	SPEAK_TO_KLULU_1A,
	SPEAK_TO_KLULU_1B,
	SPEAK_TO_KLULU_1C,
	SPEAK_TO_KLULU_2,
	SPEAK_TO_KLULU_2A,
	SPEAK_TO_KLULU_2B,
	SPEAK_TO_KLULU_3,
	SPEAK_TO_KLULU_3A,
	SPEAK_TO_KLULU_3B,
	SPEAK_TO_KLULU_4,
	SPEAK_TO_KLULU_4A,
	SPEAK_TO_KLULU_4B,
	SPEAK_TO_KLULU_5,
	SPEAK_TO_KLULU_5A,
	SPEAK_TO_KLULU_5B
}

public enum StoryEvent{
	NEED_TRASH_BAGS,
	GOT_TRASH_BAGS,
	READ_BOOK,
	NEED_FLOWERS,
	GOT_FLOWER_1,
	GOT_FLOWER_2,
	GOT_FLOWER_3,
	NEED_OIL,
	GOT_OIL,
	NEED_GLASSES,
	GOT_GLASSES,
}

public class GameFlags{
	public static Dictionary<StoryEvent, bool> flags;

	public static void init(){
		flags = new Dictionary<StoryEvent, bool> ();
//		flags [StoryEvent.SPEAK_TO_KAEDE] = false;
//		flags [StoryEvent.SPEAK_TO_DAN] = false;
		flags [StoryEvent.NEED_TRASH_BAGS] = false;
		flags [StoryEvent.GOT_TRASH_BAGS] = false;
		flags [StoryEvent.READ_BOOK] = false;
		flags [StoryEvent.NEED_FLOWERS] = false;
		flags [StoryEvent.GOT_FLOWER_1] = false;
		flags [StoryEvent.GOT_FLOWER_2] = false;
		flags [StoryEvent.GOT_FLOWER_3] = false;
		flags [StoryEvent.NEED_OIL] = false;
		flags [StoryEvent.GOT_OIL] = false;
		flags [StoryEvent.NEED_GLASSES] = false;
		flags [StoryEvent.GOT_GLASSES] = false;
	}
}