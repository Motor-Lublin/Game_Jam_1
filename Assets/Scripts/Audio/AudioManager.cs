using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public List<AudioClip> audioClipList;
    public List<AudioClip> musicClipList;

    [SerializeField] AudioSource SFXaudioSource;
    [SerializeField] AudioSource musicAudioSource;

    private void Start()
    {
        Instance = this;
    }

    public void PlaySFX(int id)
    {
        SFXaudioSource.clip = audioClipList[id];
        SFXaudioSource.loop = false;
        SFXaudioSource.Play();
    }

    public void PlayMusic(int id)
    {
        musicAudioSource.clip = musicClipList[id];
        musicAudioSource.Play();
        musicAudioSource.loop = true;
    }
}
