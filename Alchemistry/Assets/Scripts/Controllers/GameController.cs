using UnityEngine;

public class GameController : MonoBehaviour
{
	ISettingsManager settingsManager;
	ILocalizationManager localizationManager;
	IProgressManager progressManager;
	IGameData gameData;

	private void Start()
	{
		progressManager = new ProgressManager();
		gameData = new ProgressData();
		settingsManager = new SettingsManager();

		gameData.Elements = progressManager.LoadProgress();
		progressManager.SaveProgress(gameData.Elements);

		settingsManager.ChangeSetting(Auxiliary.SettingsKey.musicKey, 60);
		settingsManager.ChangeSetting(Auxiliary.SettingsKey.soundKey, 90);

		SoundManager.Instance.SoundVolume = settingsManager.SettingsValue.soundVolume;
		SoundManager.Instance.MusicVolume = settingsManager.SettingsValue.musicVolume;
		SoundManager.Instance.PlaySound("1");
		SoundManager.Instance.PlayMusic("sound");
	}
}
