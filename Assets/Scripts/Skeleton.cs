using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObject = other.gameObject;

        if(otherObject.GetComponent<Defender>())
        {
            GetComponent<Enemy>().Attack(otherObject);
        }
    }
}
