using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetDeerHealth : MonoBehaviour
{
    void Update()
    {
        if (!Deer.player)
        {
            return;
        }

        GetComponent<Slider>().SetValueWithoutNotify(Deer.player.GetComponent<Deer>().health);
    }
}
