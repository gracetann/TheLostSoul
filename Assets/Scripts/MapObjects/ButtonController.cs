 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField]
    private GameObject door;

    [SerializeField]
    private AudioSource buttonSound;

    // touch checking
    private HashSet<GameObject> touchingPlayableObjects = new HashSet<GameObject>();

    private bool isBeingTouched;
    public bool IsBeingTouched {
        get => isBeingTouched;
        private set {
            if (isBeingTouched == value) {
                return;
            }

            isBeingTouched = value;
            door.GetComponent<DoorController>().IsOpen = IsBeingTouched;
            buttonSound.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("InteractableObject"))
        {
            Debug.Log(collision.gameObject.name);
            if (!touchingPlayableObjects.Contains(collision.gameObject)) {
                touchingPlayableObjects.Add(collision.gameObject);
            }

            IsBeingTouched = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("InteractableObject"))
        {
            if (touchingPlayableObjects.Contains(collision.gameObject))
            {
                touchingPlayableObjects.Remove(collision.gameObject);
            }
        }

        IsBeingTouched = touchingPlayableObjects.Count > 0;
    }
}
