using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayableAnimal" || collision.gameObject.tag == "PlayableObject") {
            if (collision.gameObject.GetComponent<PlayableObjectController>().enabled) {
                LevelLoader.Instance.LoadNextLevel();
            }
        }
    }
}
