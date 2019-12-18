using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundFxScript : MonoBehaviour
{
    // public static soundFxScript  Instance;
    AudioSource audioSource;
    public Slider audioVolume;
    // public AudioSource gameOver, jump, frezee, pusing, yeah, fast;

    [Header("Player Prefs")]
    string PREF_SFXVOL="sfxvol";
    // string PREF_SFXSTATUS="sfxstatus";

    // Start is called before the first frame update
    void Start()
    {
        // Instance = this;
        audioSource = GetComponent<AudioSource>();
        sfx();
    }

    public void sfx(){
        audioVolume.value = audioSource.volume = PlayerPrefs.GetFloat(PREF_SFXVOL,0.5f);
    }

    public void SetVolume(){
        audioSource.volume = audioVolume.value;
        PlayerPrefs.SetFloat("sfxvol",audioSource.volume);
    }
}
