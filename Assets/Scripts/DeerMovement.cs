using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerMovement : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Vector3 direction = Vector3.right;

    // These Values are used to tweek the deer Movement
    private float turningPower = 45;
    private float MovementSpeed = 20f;

    // These Values are used by the outside
    public float speed;
    public bool isInAir;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2();
        if (Input.GetKey(KeyCode.W))
        {
            input.x += 1;
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            input.x -= 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            input.y += 1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            input.y -= 1f;
        }
        if (input.magnitude > 0)
        {
            Move(input);
        }
             
    }

    private void Move(Vector2 input)
    {
        // Set Rotation
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg - turningPower * Time.deltaTime*input.y;
        Quaternion rotation = Quaternion.Euler(0, angle, 0);
        direction = rotation * Vector3.forward;

        // Add forward Movement in case of only rotation Input
        if (input.x == 0)
        {
            input.x = 0.8f;
        }

        // Set Speed
        float speed = MovementSpeed;

        // Move and rotate Deer
        Vector3 force = direction * speed * input.x * Time.deltaTime;
        rigidbody.Move(transform.position + force, rotation);
    }

}
