using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;

    void OnMouseDown()
    {
        if (defender != null)
        {
            AttempToPlaceDefenderAt(GetSquareClicked());
        }
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    void AttempToPlaceDefenderAt(Vector2 gridPos)
    {
        var goldDisplay = FindObjectOfType<GoldDisplay>();
        int defenderCost = defender.GetGoldCost();

        if(goldDisplay.HaveEnoughGold(defenderCost))
        {
            SpawnDefender(gridPos);
            goldDisplay.SpendGold(defenderCost);
        }
    }

    Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    void SpawnDefender(Vector2 roundedPos)
    {
        Defender newDefender = Instantiate(defender, roundedPos, Quaternion.identity) as Defender;
    }
}
