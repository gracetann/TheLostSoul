using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainOptionsMenu : OptionsMenu
{
    /*
    public AudioMixer audioMixer;
    public GameObject master;

    public ParticleSystem background;
    public ParticleSystem rockThump;

    public Toggle toggle;
    bool toggleBool = true;
    bool tmp;
    */

    /*
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
    */

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
            this.gameObject.SetActive(false);
        }
        //Debug.Log(toggleBool + "main");
    }

    /*
    public void  ToggleParticles(bool particles)
    {
        
    }

    public void Activate()
    {
        if (PlayerPrefs.GetInt("toggleBool") == 1) toggleBool = true;
        if (PlayerPrefs.GetInt("toggleBool") == 0) toggleBool = false;
        toggle.isOn = toggleBool;
        tmp = toggle.isOn;
    }
    */
}