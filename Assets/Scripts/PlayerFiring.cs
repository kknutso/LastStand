using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFiring : MonoBehaviour
{
    FireballCharging fireballCharge;
    [SerializeField] GameObject[] fireballs;

    void Start()
    {
        fireballCharge = FindObjectOfType<FireballCharging>();
    }

    public void ShootFireball()
    {
        float fireballChargeAmount = fireballCharge.GetFireballChargeAmount();

        if (fireballChargeAmount == 10)
        {
            Instantiate(fireballs[2], transform.position, Quaternion.identity);
        }
        else if(fireballChargeAmount >= 6)
        {
            Instantiate(fireballs[1], transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(fireballs[0], transform.position, Quaternion.identity);
        }
    }
}
