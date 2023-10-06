using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ParticleController : MonoBehaviour
{
    //bool toggleBool;
    public AudioMixer music;
    public AudioMixer sfx;
    //public ParticleSystem background;
    //public ParticleSystem rockThump;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (PlayerPrefs.GetInt("toggleBool") == 1) toggleBool = true;
        if (PlayerPrefs.GetInt("toggleBool") == 0) toggleBool = false;
        var em = background.emission;
        em.enabled = toggleBool;
        em = rockThump.emission;
        em.enabled = toggleBool;
        */

        music.SetFloat("Music", PlayerPrefs.GetFloat("Music"));
        sfx.SetFloat("SFX", PlayerPrefs.GetFloat("SFX"));
    }
}
