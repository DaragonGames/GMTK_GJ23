using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerSniffing : MonoBehaviour
{
    private float reach = 75;
    public GameObject dangerIndicator;
    private float coolDown = 10f;

    // Update is called once per frame
    void Update()
    {
        if (Deer.isDead)
        {
            return;
        }
        if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
            return;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            Sniff();
        }
    }

    private void Sniff()
    {
        GetComponent<AudioSource>().Play();
        EventManager.SniffingEvent();
        foreach (Hunter hunter in Hunter.hunters)
        {
            Vector3 distance = hunter.transform.position - transform.position;
            float dm =  distance.magnitude;
            if (dm <= reach)
            {
                Instantiate(dangerIndicator, hunter.transform.position-(Vector3.up*2), Quaternion.identity);
            }
        }
    }
}
