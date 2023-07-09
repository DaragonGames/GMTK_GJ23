using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerSniffing : MonoBehaviour
{
    private float reach = 75;
    public GameObject dangerIndicator;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Sniff();
        }
    }

    private void Sniff()
    {
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
