﻿using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundFxJump : MonoBehaviour
{
    AudioSource audioSource;
    public Slider audioVolume;

    [Header("Player Prefs")]
    string PREF_SFXVOL="sfxjump";

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        sfx();
    }

    public void sfx(){
        audioVolume.value = audioSource.volume = PlayerPrefs.GetFloat(PREF_SFXVOL,0.5f);
    }

    public void SetVolume(){
        audioSource.volume = audioVolume.value;
        PlayerPrefs.SetFloat("sfxjump",audioSource.volume);
    }
}
