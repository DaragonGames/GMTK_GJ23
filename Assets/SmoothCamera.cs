using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    private Vector3 position_ws;
    private Quaternion rotation_ws;

    public float MaxDistance = 50.0f;
    public float CameraSpeed = 0.5f;
    
    private Vector3 velocity = Vector3.one;
    
    void LateUpdate()
    {
        if (!Deer.player)
        {
            return;
        }
        
        var DeerPosition = Deer.player.transform.position;
        float CameraDistance = (DeerPosition - transform.position).magnitude;
        Vector3 direction = (DeerPosition - transform.position).normalized;
        if (CameraDistance <= 0.01)
        {
            return;
        }
        if (CameraDistance > MaxDistance)
        {
            transform.position = DeerPosition + direction * MaxDistance;
        }
        else
        {
            transform.position =
            Vector3.SmoothDamp(transform.position, DeerPosition, ref velocity, CameraSpeed);
        }

        transform.rotation = Deer.player.transform.rotation;
    }
}
