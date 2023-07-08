using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            return;
        }
        Deer deer = other.gameObject.GetComponent<Deer>();
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
