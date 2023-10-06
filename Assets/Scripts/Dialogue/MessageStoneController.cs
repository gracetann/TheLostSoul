using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageStoneController : MonoBehaviour
{
    [SerializeField]
    private Animator inspectPromptAnimator;

    [SerializeField]
    private DialogueManager dialogueManager;

    private bool isActive = false;

    private void Update()
    {
        if (isActive && !dialogueManager.dialogueActive) {
            if (Input.GetKeyDown(KeyCode.Return)) {
                dialogueManager.ShowDialogue();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Soul") {
            inspectPromptAnimator.SetBool("isActive", true);
            isActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Soul")
        {
            inspectPromptAnimator.SetBool("isActive", false);
            isActive = false;
        }
    }
}
