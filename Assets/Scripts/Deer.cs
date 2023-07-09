using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deer : MonoBehaviour
{
    public static GameObject player;
    public static bool isDead = false;
    public float health = 100;
    private DeerMovement deerMovement;
    private AudioSource audioSource;

    // These are the sounds of the deer
    public AudioClip walkingSound;
    public AudioClip runningSound;

    // Start is called before the first frame update
    void Awake()
    {
        player = gameObject;
        audioSource = GetComponent<AudioSource>();
        deerMovement = GetComponent<DeerMovement>();
    }

    void Update()
    {
        ManageSound();
    }

    private void ManageSound()
    {
        /*
        if (DeerMovement.relativeSpeed == 0)
        {
            audioSource.Stop();
        }
        else
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            if (DeerMovement.relativeSpeed > 0.67f)
            {
                audioSource.clip = runningSound;
                audioSource.volume = 0.75f;
            }
            else
            {
                audioSource.clip = walkingSound;
                audioSource.volume = DeerMovement.relativeSpeed;
            }
        }
        */
    }

    public void GetShoot(bool critical)
    {
        health -= 50;
        if (critical)
        {
            health -= 40;
        }
        if (health <= 0)
        {
            isDead = true;
        }
    }

    public void GetTrapped()
    {
        health -= 25;
        deerMovement.Trapped();
        if (health <= 0)
        {
            isDead = true;
        }
    }
}
