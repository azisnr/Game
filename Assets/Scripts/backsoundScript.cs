using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class backsoundScript : MonoBehaviour
{
    AudioSource audioSource;
    public Slider volumeSlider;

    [Header("Player Prefs")]
    string PREF_BGMVOL="bgmvol";

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        backsound();
    }

    public void backsound(){
        volumeSlider.value = audioSource.volume = PlayerPrefs.GetFloat(PREF_BGMVOL,0.5f);
    }

    public void SetVolume(){
        audioSource.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("bgmvol",audioSource.volume);
    }
}
