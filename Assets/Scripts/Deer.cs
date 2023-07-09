using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deer : MonoBehaviour
{
    public static GameObject player;
    public static bool isDead = false;
    public float health = 100;
    private DeerMovement deerMovement;

    public Animator _animator;

    void Awake()
    {
        player = gameObject;
        deerMovement = GetComponent<DeerMovement>();
        isDead = false;
    }

    public void GetShoot(bool critical)
    {
        health -= 50;
        if (critical)
        {
            health -= 40;
            if (_animator)
            {
                _animator.SetTrigger("OnHit");
            }
        }
        if (health <= 0)
        {
            Die();
        }
    }

    public void GetTrapped()
    {
        health -= 25;
        deerMovement.Trapped();
        if (health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        isDead = true;
        if (_animator)
        {
            _animator.SetTrigger("OnDeath");
            _animator.SetBool("IsDead", true);
        }
        EventManager.GameOverEvent(false);
    }
}
