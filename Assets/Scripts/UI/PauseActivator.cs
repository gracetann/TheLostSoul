using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseActivator : MonoBehaviour
{
    public bool isPaused;
    public GameObject pauseUI;
    public GameObject optionUI;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !optionUI.activeInHierarchy)
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        pauseUI.GetComponentInChildren<PauseSelector>().StartCo();
    }
}
