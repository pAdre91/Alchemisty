interface ISoundManager
{
	int Volume {get; set; }
	void PlaySound(string soundName);
}