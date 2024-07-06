using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerControl : MonoBehaviour
{
    public static EnemySpawnerControl Instance { get; private set; }

    public Transform EnemySpawnPoint;
    public int EnemyCount;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        InvokeRepeating("EnemySpawn", 0, .5f);
    }
    public void EnemySpawn()
    {
        if (!GameManager.Instance.StartGame) return;
        int enemyLevel = CoinTrigger.Instance.Level - 1;
        if (enemyLevel > 8)
        {
            enemyLevel = 8;
        }

        if(enemyLevel < 4)
        {
            if (EnemyCount > 60) return;
        }
        else if(enemyLevel >=4 && enemyLevel < 7)
        {
            if (EnemyCount > 150) return;
        }
        else if (enemyLevel >= 7 && enemyLevel < 9)
        {
            if (EnemyCount > 200) return;
        }
        else
        {
            if (EnemyCount > 350) return;
        }


        GameObject enemy = GameManager.Instance.EnemyPooler.GetPooledObject(enemyLevel);
        enemy.transform.position = EnemySpawnPoint.position;
        enemy.SetActive(true);

        enemy = GameManager.Instance.EnemyPooler.GetPooledObject(enemyLevel + 1);
        enemy.transform.position = EnemySpawnPoint.position;
        enemy.SetActive(true);

        enemy = GameManager.Instance.EnemyPooler.GetPooledObject(enemyLevel + 2);
        enemy.transform.position = EnemySpawnPoint.position;
        enemy.SetActive(true);
        EnemyCount = EnemyCount + 3;
    }
}
