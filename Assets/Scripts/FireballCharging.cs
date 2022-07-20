using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireballCharging : MonoBehaviour
{

    void Update()
    {
        GetComponent<Slider>().value = Time.timeSinceLevelLoad;


    }
}
