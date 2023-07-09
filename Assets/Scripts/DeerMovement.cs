using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerMovement : MonoBehaviour
{
    private Rigidbody rigidbody;

    private Vector3 direction = Vector3.forward;



    // These Values are used to tweek the deer Movement
    public float turningPower = 45;
    public float speed = 0f;
    public float sprintingFactor = 1.5f;
    public float maxSpeed = 20f;
    public float minSpeed = 10;
    public float acceleration = 5f;
    public float breakingSpeed = 30f;
    private float sprinting = 1f;
    private float lastDirection;
    private float trapped = 0f;

    [NonSerialized]
    public bool isInAir;

    public float relativeSpeed = 0;
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
        if (Deer.isDead)
        {
            speed = 0;
            relativeSpeed = 0;
            return;
        }
        if (trapped > 0)
        {
            trapped -= Time.deltaTime;
            return;
        }
        Vector2 input = new Vector2();
        if (Input.GetKey(KeyCode.W))
        {
            input.x += 1;

        }
        if (Input.GetKey(KeyCode.S))
        {
            input.x -= 0.3f;
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
            sprinting = sprintingFactor;
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
        relativeSpeed = speed / (sprintingFactor*maxSpeed*lastDirection);
        SetAnimationValues(input);
        if (transform.position.y <= -2)
        {
            DontDig();
        }
    }

    private void Break()
    {
        speed -= breakingSpeed * Time.deltaTime;
        if (speed < 0)
        {
            speed = 0;
        }
        Vector3 force = direction * speed * Time.deltaTime* lastDirection;
        rigidbody.MovePosition(transform.position + force);
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
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg - turningPower * Time.deltaTime * input.y;
        Quaternion rotation = Quaternion.Euler(0, angle, 0);
        direction = rotation * Vector3.forward;        

        // Add forward Movement in case of only rotation Input
        if (input.x == 0)
        {
            input.x = 0.7f;
        }

        // No sudden Change during forward/back Momentum
        if (lastDirection * input.x < 0 && speed != 0)
        {
            // Reduce Speed by x if at 0 or below continue as used
            speed -= breakingSpeed * Time.deltaTime;
            if (speed < 0)
            {
                speed = minSpeed;
                lastDirection = input.x;
            }
            else
            {
                input.x = lastDirection;
            }
        }
        else
        {
            lastDirection = input.x;

            // Define the Speed
            speed += acceleration * Time.deltaTime * sprinting;            
            if (speed > maxSpeed * sprinting)
            {
                speed -= breakingSpeed * Time.deltaTime;
                if (speed < maxSpeed * sprinting)
                {
                    speed = maxSpeed * sprinting;
                }
            }
            if (speed < minSpeed)
            {
                speed = minSpeed;
            }
        }      

        // Move and rotate Deer
        Vector3 force = direction * speed * input.x * Time.deltaTime;
        rigidbody.Move(transform.position + force, rotation);
    }

    private void SetAnimationValues(Vector2 input)
    {
        _animator.SetFloat("RelativeSpeed", relativeSpeed);
        _animator.SetFloat("AbsoluteSpeed", speed);
        _animator.SetBool("IsOnGround", !isInAir);
    }
    public Vector3 FacingDirection()
    {
        return direction;
    }

    public void Trapped()
    {
        speed = 0;
        maxSpeed *= 0.9f;
        acceleration *= 0.9f;
        trapped = UnityEngine.Random.Range(1f, 3f);
    }

    public void DontDig()
    {
        transform.position += new Vector3(0, 10, 0);
    }
}
