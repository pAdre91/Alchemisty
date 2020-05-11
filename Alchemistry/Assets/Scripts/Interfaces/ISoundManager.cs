interface ISoundManager
{
	int SoundVolume { set; }
	int MusicVolume { set; }

	void PlaySound(string soundName, bool pausable, string path);
	void PlayMusic(string musicName, bool pausable, string path);

	void Pause();
	void UnPause();
}