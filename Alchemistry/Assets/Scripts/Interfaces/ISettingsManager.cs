interface ISettingsManager
{
	void SaveSettings();
	void LoadSetting();

	int GetSettingVolume(string settingName);
}