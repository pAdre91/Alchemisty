interface ISettingsManager
{
	SettingsValue SettingsValue { get; }

	void LoadSettings();
	void ChangeSetting(string key, int value);
	void ChangeSetting(string key, string value);
}
