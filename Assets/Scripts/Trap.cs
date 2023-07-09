using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            return;
        }
        Deer deer = other.gameObject.GetComponent<Deer>();
        transform.GetChild(0).GetComponent<Animator>().SetTrigger("Close");
        if (deer != null)
        {
            deer.GetTrapped();
        }
        GetComponent<AudioSource>().Play();
        StartCoroutine(DeleaydDestruction());
    }

    IEnumerator DeleaydDestruction()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }

}
