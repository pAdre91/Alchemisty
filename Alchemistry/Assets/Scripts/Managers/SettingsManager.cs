using UnityEngine;
using Auxiliary;

public class SettingsManager : ISettingsManager
{
	public SettingsValue SettingsValue { get; private set; }

	public SettingsManager()
	{
		Initialize();
		LoadSettings();
	}

	private void Initialize()
	{
		SettingsValue = new SettingsValue();
	}

	public void LoadSettings()
	{
		/* Данный метод нарушает OCP, но как сделать по другому я не придумал */
		if (PlayerPrefs.HasKey(SettingsKey.soundKey))
			SettingsValue.soundVolume = PlayerPrefs.GetInt(SettingsKey.soundKey);
		if (PlayerPrefs.HasKey(SettingsKey.musicKey))
			SettingsValue.musicVolume = PlayerPrefs.GetInt(SettingsKey.musicKey);
		if (PlayerPrefs.HasKey(SettingsKey.localeKey))
			SettingsValue.locale = PlayerPrefs.GetString(SettingsKey.localeKey);
	}

	public void ChangeSetting(string key, int value)
	{
		PlayerPrefs.SetInt(key, value);
		LoadSettings();
	}

	public void ChangeSetting(string key, string value)
	{
		PlayerPrefs.SetString(key, value);
		LoadSettings();
	}
}

public class SettingsValue
{
	public int soundVolume = Constants.defaultSoundVolume;
	public int musicVolume = Constants.defaultMusicVolume;
	public string locale = Constants.defaultLocale;
}
