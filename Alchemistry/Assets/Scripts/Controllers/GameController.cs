using UnityEngine;

public class GameController : MonoBehaviour
{
	ISettingsManager settingsManager;
	ILocalizationManager localizationManager;
	IProgressManager progressManager;
	IGameData gameData;

	private void Start()
	{
		#region Examples
		progressManager = new ProgressManager();
		gameData = new ProgressData();
		settingsManager = new SettingsManager();

		gameData.Elements = progressManager.LoadProgress();
		progressManager.SaveProgress(gameData.Elements);

		settingsManager.ChangeSetting(Auxiliary.SettingsKey.musicKey, 90);
		settingsManager.ChangeSetting(Auxiliary.SettingsKey.soundKey, 90);

		SoundManager.Instance.SoundVolume = settingsManager.SettingsValue.soundVolume;
		SoundManager.Instance.MusicVolume = settingsManager.SettingsValue.musicVolume;

		SoundManager.Instance.PlaySound("1", true);
		SoundManager.Instance.PlayMusic("sound", false);

		SoundManager.Instance.SoundVolume = 5;
		SoundManager.Instance.MusicVolume = 5;
		#endregion
	}
}
