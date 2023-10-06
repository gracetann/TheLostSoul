using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseSelector : MonoBehaviour
{
    [SerializeField]
    private float buttonPadding;

    [Header("Object References")]
    public GameObject[] buttons;
    public GameObject leftSide, rightSide;
    public Animator animator;
    public GameObject master;

    //audio
    public AudioSource sfx;
    public AudioClip hover;
    public AudioClip options;

    public GameObject opMenu;

    private int currentSelection = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //Debug.Log(currentSelection);

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            ChooseScene();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //Debug.Log("down");
            sfx.clip = hover;
            sfx.Play();
            StartCoroutine(TransitionNext(1));
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //Debug.Log("up");
            sfx.clip = hover;
            sfx.Play();
            StartCoroutine(TransitionNext(-1));
        }
    }

    private IEnumerator TransitionNext(int amount)
    {
        animator.SetBool("isHidden", true);

        yield return new WaitForSecondsRealtime(animator.GetCurrentAnimatorStateInfo(0).length + .3f);

        currentSelection = (currentSelection + amount + buttons.Length) % buttons.Length;
        transform.position = buttons[currentSelection].transform.position;
        float width = buttons[currentSelection].GetComponent<RectTransform>().sizeDelta.x / 2;
        leftSide.transform.localPosition = new Vector3(-1*(width + buttonPadding), 0, 0);
        rightSide.transform.localPosition = new Vector3(width + buttonPadding, 0, 0);

        animator.SetBool("isHidden", false);
        Debug.Log("transition");
        //yield return null;
    }

    private void ChooseScene()
    {
        switch (currentSelection)
        {
            case 0:
                master.GetComponent<PauseActivator>().Resume();
                break;
            case 1:
                sfx.clip = options;
                sfx.Play();
                master.GetComponent<PauseActivator>().pauseUI.SetActive(false);
                opMenu.SetActive(true);
                //opMenu.GetComponent<OptionsMenu>().Activate();
                break;
            default:
                LevelLoader.Instance.LoadLevel("MainMenu");
                master.GetComponent<PauseActivator>().Resume();
                break;
        }
    }

    public void StartCo()
    {
        //currentSelection = 0;
        //animator.Rebind();
        transform.position = buttons[currentSelection].transform.position;
        float width = buttons[currentSelection].GetComponent<RectTransform>().sizeDelta.x / 2;
        leftSide.transform.localPosition = new Vector3(-1 * (width + buttonPadding), 0, 0);
        rightSide.transform.localPosition = new Vector3(width + buttonPadding, 0, 0);
        //StartCoroutine(TransitionNext(0));
    }
}

