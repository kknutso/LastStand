using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] Arrow projectilePrefab;
    [SerializeField] GameObject gun;

    public void Shoot()
    {
        Arrow newArrow = Instantiate
            (projectilePrefab, gun.transform.position, Quaternion.identity)
            as Arrow;
        newArrow.transform.parent = transform;
        newArrow.transform.localScale = new Vector3(1, 1, 1);
    }

    //Create functionality for shooting only if enemy is in lane
}
