using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundOptions : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider masterVol;
    public Slider musicVol;
    public Slider sfxVol;

    void Start(){
        if(PlayerPrefs.GetInt("set default volume") != 1){
            PlayerPrefs.SetInt("set default volume", 1);
            masterVol.value = 0.3f;
            PlayerPrefs.SetFloat("master volume", 0.1f);
            musicVol.value = 0.3f;
            PlayerPrefs.SetFloat("music volume", 0.1f);
            sfxVol.value = 0.3f;
            PlayerPrefs.SetFloat("sfx volume", 0.1f);
        }else{
            masterVol.value = PlayerPrefs.GetFloat("master volume");
            musicVol.value = PlayerPrefs.GetFloat("music volume");
            sfxVol.value = PlayerPrefs.GetFloat("sfx volume");
        }
    }

    void SetVolume(string name, float value){
        float volume = Mathf.Log10(value) * 20;
        if(value == 0){
            volume = -80;
        }
        audioMixer.SetFloat(name, volume);
    }

    public void SetMasterVolume(float value){
        SetVolume("Master", masterVol.value);
        PlayerPrefs.SetFloat("master volume", masterVol.value);
    }

    public void SetMusicVolume(float value){
        SetVolume("Music", musicVol.value);
        PlayerPrefs.SetFloat("music volume", musicVol.value);
    }

    public void SetSFXVolume(float value){
        SetVolume("SFX", sfxVol.value);
        PlayerPrefs.SetFloat("sfx volume", sfxVol.value);
    }
}
