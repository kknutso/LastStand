using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireballCharging : MonoBehaviour
{
    PlayerController playerInput;
    Slider fireballChargeSlider;
    float fireballChargeAmount;

    void Start()
    {
        playerInput = FindObjectOfType<PlayerController>();
        fireballChargeSlider = GetComponent<Slider>();
    }

    void Update()
    {
        CheckIfSpacebarPressed();
    }

    void CheckIfSpacebarPressed()
    {
        bool playerShooting = playerInput.GetSpacebarPressed();

        if(playerShooting)
        {
            fireballChargeAmount = fireballChargeSlider.value;
            fireballChargeSlider.value = 0;
        }
        else
        {
            fireballChargeSlider.value += 1 * Time.deltaTime;
        }
    }

    float GetFireballChargeAmount()
    {
        return fireballChargeAmount;
    }
}
