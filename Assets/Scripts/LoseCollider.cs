using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    { 
        FindObjectOfType<LevelController>().HandleLoseCondition();
    }



    
}
