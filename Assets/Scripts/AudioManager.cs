using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
                if (instance == null)
                {
                    GameObject ob = new GameObject();
                    ob.hideFlags = HideFlags.HideAndDontSave;
                    instance = ob.AddComponent<AudioManager>();
                    DontDestroyOnLoad(ob);
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public AudioSource mainMusic;
    public AudioSource playerDraggingSound;
    public AudioSource playerPossesedSound;
}
