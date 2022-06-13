using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float damage = 10;
    [SerializeField] float currentSpeed = 1f;
    [SerializeField] ParticleSystem deathVFX;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0,1)] float deathSoundVolume = 0.75f;
    GameObject currentTarget;
    Animator animator;

    void Awake()
    {
        FindObjectOfType<LevelController>().EnemySpawned();
    }

    void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();

        if (levelController != null)
        {
            levelController.EnemyKilled();
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    void UpdateAnimationState()
    {
        if(!currentTarget)
        {
            animator.SetBool("isAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        animator.SetBool("isAttacking", true);
        currentTarget = target;
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

    public void PlayDeathVFX()
    {
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSoundVolume);
        ParticleSystem death = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(death, 1f);
    }
}
