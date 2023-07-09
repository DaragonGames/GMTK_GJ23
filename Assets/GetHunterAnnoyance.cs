using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetHunterAnnoyance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Hunter.hunters.Count == 0)
        {
            return;
        }
        
        float HunterAveragePatience = 0.0f;
        foreach (var hunter in Hunter.hunters)
        {
            HunterAveragePatience += (float)hunter.patience;
        }

        HunterAveragePatience /= Hunter.hunters.Count;

        GetComponent<Slider>().SetValueWithoutNotify(HunterAveragePatience);
    }
}
