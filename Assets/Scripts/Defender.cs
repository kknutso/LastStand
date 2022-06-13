using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int goldCost = 100;
    [Range(0f, 5f)] [SerializeField] float currentSpeed = 0f;
    [SerializeField] int damage = 10;
    [SerializeField] ParticleSystem deathVFX;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.75f;
    GameObject currentTarget;
    Animator animator;
    Rigidbody2D rb2d;

    void Start()
    {
        if (GetComponent<Animator>())
        {
            animator = GetComponent<Animator>();
        }
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (this.tag == "Soldier")
        {
            UpdateAnimationState();
            TravelUntilDestination();
        }
        else
        {
            transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);
        }
    }

    void TravelUntilDestination()
    {
        rb2d.position = Vector2.MoveTowards(rb2d.position, new Vector2(8, rb2d.position.y), currentSpeed * Time.deltaTime);

        if (rb2d.position.x == 8)
        {
            animator.SetBool("isMoving", false);
        }
    }

    void UpdateAnimationState()
    {
        if(!currentTarget)
        {
            animator.SetBool("isAttacking", false);
            animator.SetBool("isMoving", true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObject = other.gameObject;

        if (otherObject.GetComponent<Enemy>())
        {
            Attack(otherObject);
        }          
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        currentTarget = target;
        if (this.tag == "Soldier")
        {
            animator.SetBool("isMoving", false);
            animator.SetBool("isAttacking", true);
        }
        StrikeCurrentTarget();
    }

    public void StrikeCurrentTarget()
    {
        if (!currentTarget) { return; }

        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }
    }

    public int GetGoldCost()
    {
        return goldCost;
    }

    public void PlayDeathVFX()
    {
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSoundVolume);
        ParticleSystem death = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(death, 1f);
    }
}
