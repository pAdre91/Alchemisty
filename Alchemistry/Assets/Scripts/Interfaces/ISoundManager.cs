interface ISoundManager
{
	int SoundVolume { get; set; }
	int MusicVolume { get; set; }

	void PlaySound(string soundName, string path);
	void PlayMusic(string musicName, string path);
}