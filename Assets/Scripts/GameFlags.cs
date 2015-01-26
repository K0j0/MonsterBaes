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
	SPEAK_TO_DAN_6,
	SPEAK_TO_DAN_6A,
	SPEAK_TO_DAN_6B,
	SPEAK_TO_DAN_6C,
	SPEAK_TO_DAN_7,
	SPEAK_TO_DAN_7A,
	DATE_DAN_1,
	DATE_DAN_1A,
	DATE_DAN_1B,
	DATE_DAN_2,
	DATE_DAN_2A,
	DATE_DAN_2B,
	DATE_DAN_3,
	DATE_DAN_3A,
	DATE_DAN_4,
	DATE_DAN_4A,
	DATE_DAN_5,

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
	SPEAK_TO_KLULU_5B,
	SPEAK_TO_KLULU_6,
	SPEAK_TO_KLULU_6A,
	DATE_KLULU_1,
	DATE_KLULU_1A,
	DATE_KLULU_2,
	DATE_KLULU_2A,
	DATE_KLULU_2B,

	// for Buzz
	START_ZEN,
	SPEAK_TO_BUZZ_1,
	SPEAK_TO_BUZZ_1A,
	SPEAK_TO_BUZZ_1B,
	SPEAK_TO_BUZZ_1C,
	SPEAK_TO_BUZZ_2,
	SPEAK_TO_BUZZ_2A,
	SPEAK_TO_BUZZ_2B,
	SPEAK_TO_BUZZ_3,
	SPEAK_TO_BUZZ_3A,
	SPEAK_TO_BUZZ_3B,
	SPEAK_TO_BUZZ_4,
	SPEAK_TO_BUZZ_4A,
	SPEAK_TO_BUZZ_4B,
	SPEAK_TO_BUZZ_5,
	SPEAK_TO_BUZZ_5A,
	SPEAK_TO_BUZZ_5B,

	// for Daisy
	START_FLORIST,
	SPEAK_TO_DAISY_1,
	SPEAK_TO_DAISY_1A,
	SPEAK_TO_DAISY_1B,
	SPEAK_TO_DAISY_1C,
	SPEAK_TO_DAISY_2,
	SPEAK_TO_DAISY_2A,
	SPEAK_TO_DAISY_2B,
	SPEAK_TO_DAISY_3,
	SPEAK_TO_DAISY_3A,
	SPEAK_TO_DAISY_3B,
	SPEAK_TO_DAISY_4,
	SPEAK_TO_DAISY_4A,
	SPEAK_TO_DAISY_4B,
	SPEAK_TO_DAISY_5,
	SPEAK_TO_DAISY_5A,
	SPEAK_TO_DAISY_5B,
	SPEAK_TO_DAISY_6,
	SPEAK_TO_DAISY_6A,
	SPEAK_TO_DAISY_7,
	SPEAK_TO_DAISY_7A,
	SPEAK_TO_DAISY_7B,
	SPEAK_TO_DAISY_7C,
	SPEAK_TO_DAISY_8,
	SPEAK_TO_DAISY_8A,
	DATE_DAISY_1,
	DATE_DAISY_1A,
	DATE_DAISY_2,
	DATE_DAISY_2A,
	DATE_DAISY_2B
}

public enum StoryEvent{
	NEED_TRASH_BAGS,
	GOT_TRASH_BAGS,
	PICKED_UP_ALL_TRASH,
	DATING_KLULU,
	DATED_KLULU,

	READ_BOOK,
	NEED_FLOWERS,
	GOT_FLOWER_THISTLE,
	GOT_FLOWER_SEAFIG,
	GOT_FLOWER_NIGHTSHADE,
	DATING_DAISY,
	DATED_DAISY,

	NEED_OIL,
	GOT_OIL,
	DATING_BUZZ,
	DATED_BUZZ,

	NEED_GLASSES,
	GOT_GLASSES,
	DATING_DAN,
	DATED_DAN,
}
public enum soundEvents{
	BUZZ_KISS,
	DAISY_KISS,
	DAN_KISS,
	KLULU_KISS,
	BUZZ_ROOM,
	DAISY_ROOM,
	DAN_ROOM,
	KLULU_ROOM,
	HALLWAY,
}

public class GameFlags{
	public static Dictionary<StoryEvent, bool> flags;
	public static Dictionary<soundEvents, bool> soundBools;
	public static void init(){
		flags = new Dictionary<StoryEvent, bool> ();
		flags [StoryEvent.NEED_TRASH_BAGS] = false;
		flags [StoryEvent.GOT_TRASH_BAGS] = false;
		flags [StoryEvent.PICKED_UP_ALL_TRASH] = false;
		flags [StoryEvent.DATING_KLULU] = false;
		flags [StoryEvent.DATED_KLULU] = false;

		flags [StoryEvent.READ_BOOK] = false;
		flags [StoryEvent.NEED_FLOWERS] = false;
		flags [StoryEvent.GOT_FLOWER_THISTLE] = false;
		flags [StoryEvent.GOT_FLOWER_SEAFIG] = false;
		flags [StoryEvent.GOT_FLOWER_NIGHTSHADE] = false;
		flags [StoryEvent.DATING_DAISY] = false;
		flags [StoryEvent.DATED_DAISY] = false;


		flags [StoryEvent.NEED_OIL] = false;
		flags [StoryEvent.GOT_OIL] = false;
		flags [StoryEvent.DATING_BUZZ] = false;
		flags [StoryEvent.DATED_BUZZ] = false;


		flags [StoryEvent.NEED_GLASSES] = false;
		flags [StoryEvent.GOT_GLASSES] = false;
		flags [StoryEvent.DATING_DAN] = false;
		flags [StoryEvent.DATED_DAN] = false;


		soundBools = new Dictionary<soundEvents, bool> ();
		soundBools [soundEvents.BUZZ_KISS] = false;
		soundBools [soundEvents.KLULU_KISS] = false;
		soundBools [soundEvents.DAN_KISS] = false;
		soundBools [soundEvents.DAISY_KISS] = false;
		soundBools [soundEvents.BUZZ_ROOM] = false;
		soundBools [soundEvents.KLULU_ROOM] = false;
		soundBools [soundEvents.DAN_ROOM] = false;
		soundBools [soundEvents.DAISY_ROOM] = false;
		soundBools [soundEvents.HALLWAY] = false;
	}
}