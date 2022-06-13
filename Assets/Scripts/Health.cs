using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 10f;
    [SerializeField] int goldDrop = 0;

    public void DealDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {

            if(this.tag == "Enemy")
            {
                FindObjectOfType<GoldDisplay>().AddGold(goldDrop);
                this.GetComponent<Enemy>().PlayDeathVFX();
            }
            else if(this.GetComponent<Defender>())
            {
                this.GetComponent<Defender>().PlayDeathVFX();
            }
            Destroy(gameObject);
        }
    }

    public float GetHealth()
    {
        return health;
    }
}
