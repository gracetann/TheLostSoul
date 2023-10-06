using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayableAnimal" || collision.gameObject.tag == "PlayableObject") {
            if (collision.gameObject.GetComponent<PlayableObjectController>().isEnabled)
            {
                collision.gameObject.GetComponent<PlayableObjectController>().Die();
                Destroy(collision.gameObject);
                LevelLoader.Instance.ReloadLevel();
            }
            else {
                if (collision.gameObject.tag == "PlayableAnimal") {
                    collision.gameObject.GetComponent<PlayableObjectController>().Die();
                    Destroy(collision.gameObject);
                }
            }
        }
    }
}
