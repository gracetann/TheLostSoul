using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer music;
    public AudioMixer sfx;
    public GameObject master;

    //public ParticleSystem background;
    //public ParticleSystem rockThump;

    //public Toggle toggle;
    public Slider musicSlider;
    public Slider sfxSlider;
    //public bool toggleBool = true;
    //public bool tmp;

    public void SetMusicVolume(float volume)
    {
        music.SetFloat("Music", volume);
        PlayerPrefs.SetFloat("Music", volume);
    }
    public void SetSFXVolume(float volume)
    {
        sfx.SetFloat("SFX", volume);
        PlayerPrefs.SetFloat("SFX", volume);
    }

    void Update()
    {
        //toggleBool = tmp;
        //tmp = toggle.isOn;
        //if (toggleBool) PlayerPrefs.SetInt("toggleBool", 1);
        //else PlayerPrefs.SetInt("toggleBool", 0);
        musicSlider.value = PlayerPrefs.GetFloat("Music");
        sfxSlider.value = PlayerPrefs.GetFloat("SFX");
        if (Input.GetKeyDown(KeyCode.Return))
        {
            master.GetComponent<PauseActivator>().pauseUI.SetActive(true);
            this.gameObject.SetActive(false);
        }
        //Debug.Log(toggleBool + "game");
    }

    /*
    public void ToggleParticles(bool particles)
    {
        if (particles)
        {
            background.gameObject.SetActive(true);
            rockThump.gameObject.SetActive(true);
        }
        else
        {
            background.gameObject.SetActive(false);
            rockThump.gameObject.SetActive(false);
        }
        var em = background.emission;
        em.enabled = toggleBool;
        em = rockThump.emission;
        em.enabled = toggleBool;
    }
    */
    
    /*
    public void Activate()
    {
        if (PlayerPrefs.GetInt("toggleBool") == 1) toggleBool = true;
        if (PlayerPrefs.GetInt("toggleBool") == 0) toggleBool = false;
        toggle.isOn = toggleBool;
        tmp = toggle.isOn;
    }
    */
}
