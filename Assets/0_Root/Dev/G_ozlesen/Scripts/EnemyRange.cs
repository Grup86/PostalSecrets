using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out EnemyMovement enemy))
        {
            GameManager.Instance.Enemies.Add(enemy.transform);
        }
    }
}
