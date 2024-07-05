using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerControl : MonoBehaviour
{
    public Transform EnemySpawnPoint;

    private void Start()
    {
        InvokeRepeating("EnemySpawn", 0, .5f);
    }
    public void EnemySpawn()
    {
        if (!GameManager.Instance.StartGame) return;
        GameObject enemy = GameManager.Instance.EnemyPooler.GetPooledObject(0);
        enemy.transform.position = EnemySpawnPoint.position;
        enemy.SetActive(true);
    }
}
