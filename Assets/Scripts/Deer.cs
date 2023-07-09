using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deer : MonoBehaviour
{
    public static GameObject player;
    private AudioSource audioSource;

    // These are the sounds of the deer
    public AudioClip walkingSound;
    public AudioClip runningSound;

    // Start is called before the first frame update
    void Awake()
    {
        player = gameObject;
        audioSource = GetComponent<AudioSource>();
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

    public void Die()
    {

    }

    public void GetShoot()
    {

    }

    public void GetTrapped()
    {
    }
}
