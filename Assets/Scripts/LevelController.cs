using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    PlayerController player;
    int numberofEnemies = 0;
    bool levelTimerFinished = false;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        loseLabel.SetActive(false);
        winLabel.SetActive(false);
    }

    public void EnemySpawned()
    {
        numberofEnemies++;
    }

    public void EnemyKilled()
    {
        numberofEnemies--;

        if (numberofEnemies <= 0 && levelTimerFinished)
        {
            HandleWinCondition();
        }
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    void StopSpawners()
    {
        EnemySpawner[] spawners = FindObjectsOfType<EnemySpawner>();

        foreach (EnemySpawner spawner in spawners)
        {
            spawner.StopSpawning();
        }
    }

    public void HandleLoseCondition()
    {
        if (player != null)
        {
            player.GetComponent<Animator>().Play("Player_Death");
            player.SetCanMoveToFalse();
        }
        loseLabel.SetActive(true);
    }

    void HandleWinCondition()
    {
        if (player != null)
        {
            player.GetComponent<Animator>().Play("Player_JumpForJoy");
            player.SetCanMoveToFalse();
        }
        winLabel.SetActive(true);
    }
}
