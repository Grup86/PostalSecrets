using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AttackManager : MonoBehaviour
{
    public Transform NearestEnemy;
    public static AttackManager Instance { get; private set; }
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
        InvokeRepeating("Fire", 0, 1f);
    }
    void Update()
    {
        NearestEnemy = GetNearestEnemy();
    }

    Transform GetNearestEnemy()
    {
        Transform nearestEnemy = null;
        float minDistance = Mathf.Infinity;

        foreach (Transform enemy in GameManager.Instance.Enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }

    public void Fire()
    {
        if (NearestEnemy != null)
        {
            GameObject item = GameManager.Instance.FirePooler.GetPooledObject(0);
            item.SetActive(true);
        }
    }
}
