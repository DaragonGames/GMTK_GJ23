using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerArea : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.SniffingAction += DestroyMe;
    }

    void OnDestroy()
    {
        EventManager.SniffingAction -= DestroyMe;
    }

    void DestroyMe()
    {
        Destroy(gameObject);
    }

}
