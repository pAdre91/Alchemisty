using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Auxiliary;
/*
* TODO	 Все Debug.Log заменить на запись в собственный логгер 
*/
public class SoundManager : MonoBehaviour, ISoundManager
{
	private static SoundManager instanceHolder = null;
	private List<AudioSource> playableSounds = new List<AudioSource>();
	private AudioSource currentMusic = new AudioSource();

	public int SoundVolume { get; set; } = Constants.defaultSoundVolume;
	public int MusicVolume { get; set; } = Constants.defaultMusicVolume;

	public static SoundManager Instance
	{
		get
		{
			if (instanceHolder != null)
				return instanceHolder;
			return instanceHolder = new GameObject("SoundManager(singleton)").AddComponent<SoundManager>();
		}
	}

	private void Awake()
	{
		instanceHolder = this;
		DontDestroyOnLoad(gameObject);
	}

	public void PlaySound(string soundName, string soundsPath = "Sounds/")
	{
		if (string.IsNullOrEmpty(soundName))
		{
			Debug.Log("Sound null or empty");
			return;
		}

		int equelSounds = 0;
		foreach (AudioSource audioSource in playableSounds)
		{
			if (audioSource.name == soundName)
				equelSounds++;
		}

		if (equelSounds > Constants.maxEquelSounds)
		{
			Debug.Log("Too much duplicates for sound: " + soundName);
			return;
		}

		if (playableSounds.Count > Constants.maxPlayableSounds)
		{
			Debug.Log("Too much sounds");
			return;
		}

		StartCoroutine(SoundPlayback(soundName, soundsPath));
	}

	private IEnumerator SoundPlayback(string soundName, string path)
	{
		ResourceRequest request = Resources.LoadAsync<AudioClip>(path + soundName);

		while (!request.isDone)
		{
			yield return null;
		}

		AudioClip audioClip = (AudioClip)request.asset;
		if (audioClip == null)
		{
			Debug.Log("Sound not loaded " + soundName);
		}

		GameObject soundGameObject = new GameObject("Sound: " + soundName);
		soundGameObject.transform.parent = transform;

		AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();

		audioSource.mute = false;       //TODO Добавить в настройки мьют и передавать сюда
		audioSource.volume = (float)SoundVolume/100;       //TODO ИЗменить настройку громкости на шкалу от 0 до 1
		audioSource.clip = audioClip;
		audioSource.Play();

		playableSounds.Add(audioSource);
	}

	public void PlayMusic(string musicName, string musicPath = "Music/")
	{
		if (string.IsNullOrEmpty(musicName))
		{
			Debug.Log("Music empty or null");
			return;
		}

		if (currentMusic != null && currentMusic.name == musicName)
		{
			Debug.Log("Music already playing: " + musicName);
			return;
		}

		StopMusicInternal();
		StartCoroutine(MusicPlayback(musicName, musicPath));
	}

	private IEnumerator MusicPlayback(string musicName, string path)
	{
		ResourceRequest request = Resources.LoadAsync<AudioClip>(path + musicName);

		while (!request.isDone)
		{
			yield return null;
		}

		AudioClip musicClip = (AudioClip)request.asset;
		if (musicClip == null)
		{
			Debug.Log("Music not loaded " + musicName);
		}

		GameObject soundGameObject = new GameObject("Music: " + musicName);
		soundGameObject.transform.parent = transform;

		AudioSource musicSource = soundGameObject.AddComponent<AudioSource>();

		musicSource.mute = false;       //TODO Добавить в настройки мьют и передавать сюда
		musicSource.volume = (float)MusicVolume / 100;       //TODO ИЗменить настройку громкости на шкалу от 0 до 1
		musicSource.clip = musicClip;
		musicSource.loop = true;
		musicSource.Play();

		currentMusic = musicSource;
	}

	private void StopMusicInternal()
	{
		if (currentMusic != null)
			currentMusic.Stop();
	}
}
