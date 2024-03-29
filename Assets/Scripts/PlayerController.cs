using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject arrow;
    Animator animator;
    float yAxis;
    bool canMove = true;

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        yAxis = Input.GetAxisRaw("Vertical");
        if (canMove)
        {
            PlayerMove();
        }
        Attack();      
    }

    void PlayerMove()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (transform.position.y == 1)
            {
                transform.position = transform.position;
            }
            else
            {
                transform.position += Vector3.down;
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (transform.position.y == 5)
            {
                transform.position = transform.position;
            }
            else
            {
                transform.position += Vector3.up;
            }
        }

        if (yAxis != 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    void Attack()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("isMoving", false);
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    public void ShootArrow()
    {
        Instantiate(arrow, transform.position, Quaternion.identity);
    }

    public void SetCanMoveToFalse()
    {
        canMove = false;
    }
}
