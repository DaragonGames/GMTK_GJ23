using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetSniffCooldown : MonoBehaviour
{
    void Update()
    {
        if (DeerSniffing.Instance)
        {
            GetComponent<Slider>().value = DeerSniffing.Instance.GetSniffCooldown();
        }
    }
}
