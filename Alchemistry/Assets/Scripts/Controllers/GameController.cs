using UnityEngine;

public class GameController : MonoBehaviour
{
	ISoundManager soundManager;
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
	}
}
