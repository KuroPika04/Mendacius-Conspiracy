using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAudioManager : MonoBehaviour
{
    public static MainMenuAudioManager instance;
    public Sound[] music_sound, sfx_sound;
    public AudioSource music_source, sfx_source;
    private void Awake()
    {
        if (instance == null) // to make things easier to access
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            //  Destroy(gameObject);
        }
    }
    private void Start()
    {
        PlayMusic("TitleMusic");
    }
    public void PlayMusic(string name) //Call this function from any script u want to add music
    {
        Sound sound = Array.Find(music_sound, x => x.name == name); //Search audio from array
        if (sound != null)
        {
            music_source.clip = sound.clip;
            music_source.Play();
        }
        else
        {
            Debug.Log("Music Not Found");
        }
    }
    public void PlaySFX(string name) //Call this function from any script u want to add SFX
    {
        Sound sound = Array.Find(sfx_sound, x => x.name == name); //Search audio from array
        if (sound != null)
        {
            sfx_source.PlayOneShot(sound.clip);
        }
        else
        {
            Debug.Log("SFX Not Found");
        }
    }
    public void ToggleMusic()
    {
        music_source.mute = !music_source.mute;
    }
    public void ToggleSFX()
    {
        sfx_source.mute = !sfx_source.mute;
    }
    public void MusicVolume(float volume)
    {
        music_source.volume = volume;
    }
    public void SFXVolume(float volume)
    {
        sfx_source.volume = volume;
    }
    public void ChangeMusic(string name)
    {
        Sound sound = Array.Find(music_sound, x => x.name == name);
        if (sound != null)
        {
            if (music_source.clip == null || music_source.clip == sound.clip)
            {
                Debug.Log("Same Song Played");
                return;
            }
            music_source.Stop();
            music_source.clip = sound.clip;
            music_source.clip.LoadAudioData();
            music_source.Play();
        }
        else
        {
            Debug.Log("Music Not Found");
        }
    }
}
