using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampEquipment : MonoBehaviour
{
    public GameObject smokePrefab;
    public GameObject alternativeVersion;

    public int personalAnnoyanceValue = 0;
    public int globalAnnoyanceValue = 5;
    public Hunter associatedHunter;

    public void CreateDestruction()
    {
        Instantiate(smokePrefab, transform.position, Quaternion.identity);
        //Instantiate(alternativeVersion, transform.position, Quaternion.identity);
        EventManager.DestructionOfPropertyEvent(globalAnnoyanceValue);
        //associatedHunter.LosePatience(personalAnnoyanceValue);
        Destroy(gameObject);
    }
}
