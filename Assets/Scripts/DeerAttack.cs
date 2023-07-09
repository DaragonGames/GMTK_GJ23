using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerAttack : MonoBehaviour
{
    public Animator _animator;
    private float reach = 2.5f;

    // Update is called once per frame
    void Update()
    {
        if (Deer.isDead)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 facingDirection = gameObject.GetComponent<DeerMovement>().FacingDirection();
            Attack(facingDirection);
        }
    }

    private void Attack(Vector3 facingDirection)
    {
        _animator.SetTrigger("DoPushing");
        RaycastHit hit;
        if (Physics.Raycast(transform.position, facingDirection,  out hit, reach, LayerMask.GetMask("Destroyable")))
        {
            if (hit.collider != null)
            {
                hit.collider.GetComponent<CampEquipment>().CreateDestruction();
                
            }
            return;
        }

        if (Physics.Raycast(transform.position-new Vector3(0,0.5f,0), facingDirection, out hit, reach, LayerMask.GetMask("Destroyable")))
        {
            if (hit.collider != null)
            {
                hit.collider.GetComponent<CampEquipment>().CreateDestruction();
            }
            return;
        }

        if (Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), facingDirection, out hit, reach, LayerMask.GetMask("Destroyable")))
        {
            if (hit.collider != null)
            {
                hit.collider.GetComponent<CampEquipment>().CreateDestruction();
            }
            return;
        }
    }
}
