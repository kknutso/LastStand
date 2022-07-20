using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFiring : MonoBehaviour
{
    [SerializeField] GameObject fireball;

    public void ShootFireball()
    {
        Instantiate(fireball, transform.position, Quaternion.identity);
    }
}
