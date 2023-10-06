using System.Collections;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private Text dialogueTextbox;

    [TextArea(3, 10)]
    [SerializeField]
    private string dialogue;

    private Animator dialogueAnimator;

    public bool dialogueActive;
    private bool dialogueFinished = false;

    private void Awake()
    {
        dialogueAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (dialogueActive) {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (dialogueFinished)
                {
                    HideDialogue();
                }
                else {
                    FinishDialogue();
                }
            }
            
        }
    }

    public void ShowDialogue()
    {
        dialogueAnimator.SetBool("isActive", true);
        StartCoroutine(DisplayDialogue());
    }

    public void HideDialogue()
    {
        dialogueAnimator.SetBool("isActive", false);
    }

    // this function is called from an animation event in MessageStone/Dialogue
    public void DeactiveDialogue() {
        dialogueActive = false;
    }

    public void FinishDialogue() {
        StopAllCoroutines();
        dialogueTextbox.text = dialogue;
        dialogueFinished = true;
    }

    public IEnumerator DisplayDialogue() {
        dialogueActive = true;

        string spaceReplaced = Regex.Replace(dialogue, @"[^\n]", " ");
        StringBuilder sb = new StringBuilder(spaceReplaced, dialogue.Length);

        for(int i = 0; i < dialogue.Length; i++)
        {
            sb[i] = dialogue[i];
            dialogueTextbox.text = sb.ToString();
            yield return new WaitForSeconds(0.01f);
        }

        dialogueFinished = true;
    }
}
