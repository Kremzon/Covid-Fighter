using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundPanel : MonoBehaviour
{
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider soundEffectsVolumeSlider;

    private void Awake()
    {
        AudioPlayer audioPlayer = FindObjectOfType<AudioPlayer>();

        musicVolumeSlider.onValueChanged.AddListener(audioPlayer.MusicVolumeChanged);
        soundEffectsVolumeSlider.onValueChanged.AddListener(audioPlayer.SoundEffectsVolumeChanged);

        musicVolumeSlider.value = audioPlayer.GetMusicVolume();
        soundEffectsVolumeSlider.value = audioPlayer.GetSoundEffectsVolume();
    }
}
