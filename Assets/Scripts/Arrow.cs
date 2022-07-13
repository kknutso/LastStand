using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] float damage = 5f;
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] ParticleSystem fireballHitVFX;
    float xSpeed;

    Rigidbody2D rb2d;
    PlayerController player;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();
        xSpeed = player.transform.localScale.x * bulletSpeed;
    }

    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(xSpeed * Time.deltaTime, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Enemy>())
        {
            var health = other.GetComponent<Health>(); 
            health.DealDamage(damage);
            if (fireballHitVFX)
            {
                ParticleSystem fireballHit = Instantiate(fireballHitVFX, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }

}
