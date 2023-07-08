using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerMovement : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Vector3 direction = Vector3.right;

    // These Values are used to tweek the deer Movement
    public float turningPower = 45;
    public float speed = 0f;

    private float maxSpeed = 30f;
    private float minSpeed = 10;
    private float acceleration = 5f;
    private float breakingSpeed = 30f;
    private float sprinting = 1f;

    [NonSerialized]
    public bool isInAir;

    public float relativeSpeed = 0f;
    public Animator _animator;

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
            input.x -= 0.5f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            input.y += 1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            input.y -= 1f;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprinting = 1.5f;
        }
        else
        {
            sprinting = 1f;
        }
        if (input.magnitude > 0)
        {
            Move(ref input);
        }
        else
        {
            if (speed > 0)
            {
                Break();
            }
        }
             
        SetAnimationValues(input);
    }

    private void Break()
    {
        speed -= breakingSpeed * Time.deltaTime;
        if (speed < 0)
        {
            speed = 0;
        }
        Vector3 force = direction * speed  * Time.deltaTime;
        rigidbody.MovePosition(transform.position + force);
        relativeSpeed = 45 / speed;
    }

    private void Move(ref Vector2 input)
    {
        // Change some values when going backwards
        if (input.x < 0)
        {
            input.y *= -1;
            sprinting = 1;
        }

        // Set Rotation        
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg - turningPower * Time.deltaTime*input.y;
        Quaternion rotation = Quaternion.Euler(0, angle, 0);
        direction = rotation * Vector3.forward;

        // Add forward Movement in case of only rotation Input
        if (input.x == 0)
        {
            input.x = 0.7f;
        }

        // Define the Speed
        speed += acceleration* Time.deltaTime * sprinting;
        if (speed < minSpeed)
        {
            speed = minSpeed;
        }
        if (speed > maxSpeed* sprinting)
        {
            speed -= breakingSpeed * Time.deltaTime;
            if (speed < maxSpeed * sprinting)
            {
                speed = maxSpeed * sprinting;
            }
        }

        // Move and rotate Deer
        Vector3 force = direction * speed * input.x * Time.deltaTime;
        rigidbody.Move(transform.position + force, rotation);
        relativeSpeed = 45 / speed;
    }

    private void SetAnimationValues(Vector2 input)
    {
        _animator.SetFloat("Speed", input.x);
        _animator.SetBool("IsOnGround", !isInAir);
    }
    public Vector3 FacingDirection()
    {
        return direction;
    }
}
