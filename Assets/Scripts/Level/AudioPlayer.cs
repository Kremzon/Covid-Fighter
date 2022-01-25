using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour
{
    [Header("Sound Effects")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] AudioClip damageClip;

    static AudioPlayer instance;
    AudioSource musicAudioSource;
    float soundEffectsVolume = 0.5f;

    const string MUSIC_VOLUME_KEY = "musicVolume";
    const string SOUND_EFFECTS_VOLUME_KEY = "soundEffectsVolume";

    public void PlayShootingClip()
    {
        PlayClip(shootingClip, soundEffectsVolume);
    }

    public void PlayDamageClip()
    {
        PlayClip(damageClip, soundEffectsVolume);
    }

    public void MusicVolumeChanged(float volume)
    {
        musicAudioSource.volume = volume;
        SaveVolume(MUSIC_VOLUME_KEY, volume);
    }

    public void SoundEffectsVolumeChanged(float volume)
    {
        soundEffectsVolume = volume;
        SaveVolume(SOUND_EFFECTS_VOLUME_KEY, volume);
    }

    public float GetMusicVolume()
    {
        return musicAudioSource.volume;
    }

    public float GetSoundEffectsVolume()
    {
        return soundEffectsVolume;
    }

    private void Awake()
    {
        ManageSingleton();
        musicAudioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        musicAudioSource.volume = LoadVolume(MUSIC_VOLUME_KEY);
        soundEffectsVolume = LoadVolume(SOUND_EFFECTS_VOLUME_KEY);
    }

    private void SaveVolume(string key, float volume)
    {
        PlayerPrefs.SetFloat(key, volume);
    }

    private float LoadVolume(string key)
    {
        if (!PlayerPrefs.HasKey(key))
        {
            SaveVolume(key, 0.5f);
        }

        return PlayerPrefs.GetFloat(key);
    }

    private void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip,
                                        Camera.main.transform.position,
                                        volume);
        }
    }
}
