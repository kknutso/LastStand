using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldDisplay : MonoBehaviour
{
    [SerializeField] int gold = 100;
    Text goldText;

    
    void Start()
    {
        goldText = GetComponent<Text>();
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        goldText.text = gold.ToString();
    }

    public bool HaveEnoughGold(int amount)
    {
        return gold >= amount;
    }

    public void AddGold(int amount)
    {
        gold += amount;
        UpdateDisplay();
    }

    public void SpendGold(int amount)
    {
        if (gold >= amount)
        {
            gold -= amount;
            UpdateDisplay();
        }
    }
}
