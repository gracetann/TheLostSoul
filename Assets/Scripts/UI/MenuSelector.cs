using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelector : MonoBehaviour
{
    [SerializeField]
    private float buttonPadding;

    [Header("Object References")]
    public GameObject[] buttons;
    public GameObject leftSide, rightSide;
    public Animator animator;

    private int currentSelection = 0;

    public GameObject mainOpMenu;

    //audio
    public AudioSource sfx;
    public AudioClip start;
    public AudioClip hover;
    public AudioClip options;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            ChooseScene();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            sfx.clip = hover;
            sfx.Play();
            StartCoroutine(TransitionNext(1));
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            sfx.clip = hover;
            sfx.Play();
            StartCoroutine(TransitionNext(-1));
        }
    }

    private IEnumerator TransitionNext(int amount) {
        animator.SetBool("isHidden", true);

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length + 0.3f);

        currentSelection = (currentSelection + amount + buttons.Length) % buttons.Length;
        transform.position = buttons[currentSelection].transform.position;
        float width = buttons[currentSelection].GetComponent<RectTransform>().sizeDelta.x / 2;
        leftSide.transform.localPosition = new Vector3(-1 * (width + buttonPadding), 0, 0);
        rightSide.transform.localPosition = new Vector3(width + buttonPadding, 0, 0);

        animator.SetBool("isHidden", false);
    }

    private void ChooseScene()
    {
        switch (currentSelection)
        {
            case 0:
                sfx.clip = start;
                sfx.Play();
                LevelLoader.Instance.LoadLevel("LEVEL_1");
                break;
            case 1:
                sfx.clip = options;
                if (!mainOpMenu.activeInHierarchy) sfx.Play();
                mainOpMenu.SetActive(true);
                //mainOpMenu.GetComponent<MainOptionsMenu>().Activate();
                break;
            default:
                Debug.Log("Credits");
                break;
        }
    }
}

