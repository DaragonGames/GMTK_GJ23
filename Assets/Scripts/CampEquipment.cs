using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampEquipment : MonoBehaviour
{
    public GameObject smokePrefab;
    public GameObject alternativeVersion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CreateDestruction()
    {
        Instantiate(smokePrefab, transform.position, Quaternion.identity);
        //Instantiate(alternativeVersion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
