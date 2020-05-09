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

		progressManager.LoadProgress();
	}
}
