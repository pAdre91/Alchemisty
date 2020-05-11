using System.Collections.Generic;

namespace Auxiliary
{
	static class Constants
	{
		public const string progressFilePath = "Assets/Resources/gameProgress.json";

		public const string defaultLocale = "En";
		public const int defaultMusicVolume = 100;
		public const int defaultSoundVolume = 100;
	}

	static class SettingsKey
	{
		public const string soundKey = "SOUND_KEY";
		public const string musicKey = "MUSIC_KEY";
		public const string localeKey = "LOCALE_KEY";
	}
}