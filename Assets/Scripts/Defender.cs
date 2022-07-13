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

    void Update()
    {
        transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);
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

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }

    public void Attack(GameObject target)
    {
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

    public int GetGoldCost()
    {
        return goldCost;
    }

    public GameObject GetCurrentTarget()
    {
        return currentTarget;
    }

    public void PlayDeathVFX()
    {
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSoundVolume);
        ParticleSystem death = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(death, 1f);
    }
}
