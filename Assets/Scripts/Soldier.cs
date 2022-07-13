using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    float currentSpeed;
    Animator animator;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimationState();
        TravelUntilDestination();
    }

    void TravelUntilDestination()
    {
        currentSpeed = GetComponent<Defender>().GetCurrentSpeed();
        rb2d.position = Vector2.MoveTowards(rb2d.position, new Vector2(8, rb2d.position.y), currentSpeed * Time.deltaTime);

        if (rb2d.position.x == 8)
        {
            animator.SetBool("isMoving", false);
        }
    }

    void UpdateAnimationState()
    {
        GameObject currentTarget = GetComponent<Defender>().GetCurrentTarget();

        if (!currentTarget)
        {
            animator.SetBool("isAttacking", false);
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
            animator.SetBool("isAttacking", true);
        }
    }
}
