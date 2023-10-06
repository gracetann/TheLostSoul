using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableObjectController : MonoBehaviour
{
    public bool isEnabled;

    public ParticleSystem deathEffect;
    public AudioSource deathSound;

    public void Die()
    {
        ParticleSystem particleEffect = Instantiate(deathEffect, transform.position, transform.rotation);
        particleEffect.gameObject.SetActive(true);
        particleEffect.Stop();
        particleEffect.Play();

        deathSound.Play();
    }
}
