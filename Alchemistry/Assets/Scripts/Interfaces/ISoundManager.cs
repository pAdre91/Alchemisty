interface ISoundManager
{
	int SoundVolume { get; set; }
	int MusicVolume { get; set; }

	void PlaySound(string soundName, bool pausable, string path);
	void PlayMusic(string musicName, bool pausable, string path);

	void Pause();
	void UnPause();
}