using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] sight;
    public AudioClip melee;
    public AudioClip[] death;
    public AudioClip roaming;
    public AudioClip pain;
    private int sightSize;
    private int deathSize;

    private void Start()
    {
        sightSize = sight.Length;
        deathSize = death.Length;
    }
    public void PlaySight()
    {
        int index = Random.Range(0, sightSize);
        audioSource.clip = sight[index];
        audioSource.Play();
    }
    public void PlayPain()
    {
        audioSource.clip = pain;
        audioSource.Play();
    }
    public void PlayMelee()
    {
        audioSource.clip = melee;
        audioSource.Play();
    }
    public void PlayDeath()
    {
        int index = Random.Range(0, deathSize);
        audioSource.clip = death[index];
        audioSource.Play();
    }
    public void PlayRoaming()
    {
        audioSource.clip = roaming;
        audioSource.Play();
    }
}
