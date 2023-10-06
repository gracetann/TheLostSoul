using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssenceController : MonoBehaviour
{
    // settings
    public float dragRadius;

    // references
    public GameObject essenceObject;

    // state values
    public GameObject controlledBody;
    private bool isDragging;

    // sound effects
    [SerializeField]
    private AudioSource draggingSound;

    [SerializeField]
    private AudioSource possessedSound;

    void Update()
    {
        Following();
        Possessing();
    }

    private void Following() {
        this.gameObject.transform.position = controlledBody.transform.position + Vector3.forward * -1;
    }

    private void Possessing() {
        if (Input.GetMouseButtonDown(0)) {
            isDragging = true;
            essenceObject.SetActive(true);

            draggingSound.Play();
            draggingSound.volume = 1;
        }

        if (Input.GetMouseButton(0) && isDragging)
        {
            Vector2 line = Camera.main.ScreenToWorldPoint(Input.mousePosition) - controlledBody.transform.position;
            if (line.magnitude > dragRadius)
            {
                line = line.normalized * dragRadius;
            }
            this.gameObject.transform.position = controlledBody.transform.position + (Vector3)line;

        }
        else {
            isDragging = false;
            essenceObject.SetActive(false);
            draggingSound.volume = 0;
        }
    }

    public Vector3 GetMidlocation()
    {
        return (controlledBody.transform.position + this.gameObject.transform.position) / 2;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "PlayableAnimal" || collision.gameObject.tag == "PlayableObject") && collision.gameObject != controlledBody && isDragging == true)
        {
            possessedSound.Play();

            isDragging = false;
            essenceObject.SetActive(false);

            controlledBody.GetComponent<PlayableObjectController>().isEnabled = false;
            collision.gameObject.GetComponent<PlayableObjectController>().isEnabled = true;

            controlledBody = collision.gameObject;
        }
    }
}
