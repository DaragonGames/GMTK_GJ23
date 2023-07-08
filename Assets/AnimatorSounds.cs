using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorSounds : MonoBehaviour
{

    public List<AudioClip> FootstepSounds = new List<AudioClip>();

    public void FootStepSound()
    {
        
        //SDebug.Log("Footstep sound played!");
        if (FootstepSounds.Count > 0)
        {
            GetComponent<AudioSource>().PlayOneShot(FootstepSounds[Random.Range(0, FootstepSounds.Count)]);
        }
    }
}
