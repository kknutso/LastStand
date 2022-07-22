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
            Invoke("ResetFireballChargeSlider", .25f);
        }
        else
        {
            fireballChargeSlider.value += 1 * Time.deltaTime;
        }
    }

    void ResetFireballChargeSlider()
    {
        fireballChargeSlider.value = 0;
    }

    public float GetFireballChargeAmount()
    {
        return fireballChargeAmount;
    }
}
