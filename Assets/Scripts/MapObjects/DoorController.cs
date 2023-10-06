using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private bool isOpen;
    public bool IsOpen {
        get => isOpen;
        set {
            if (isOpen == value) {
                return;
            }
            isOpen = value;

            if (isOpen)
            {
                OpenDoor();
            }
            else {
                CloseDoor();
            }
        }
    }

    void OpenDoor()
    {
        animator.SetBool("isOpen", true);
    }

    void CloseDoor() {
        animator.SetBool("isOpen", false);
    }
}
