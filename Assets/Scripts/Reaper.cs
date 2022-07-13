using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaper : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObject = other.gameObject;

        if (otherObject.GetComponent<Defender>())
        {
            if (otherObject.GetComponent<Soldier>())
            {
                GetComponent<Enemy>().Attack(otherObject);
            }
            else
            {
                GetComponent<Animator>().SetTrigger("phaseTrigger");
            }
        }
        else { return; }
    }
}
