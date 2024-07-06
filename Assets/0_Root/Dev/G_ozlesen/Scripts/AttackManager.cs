using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackManager : MonoBehaviour
{
    public static AttackManager Instance { get; private set; }
    [HideInInspector] public Transform NearestEnemy;
    public int TotalHealt;
    private float _diviningHealt;
    public int Damage;
    public float AttackSpeed;
    public Image HealtFilledImage;
    public int Armor;
    public int MultipleAttackCount;
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
        MultipleAttackCount = 1;
        _diviningHealt = (float)TotalHealt;
        HealtFilledImage.fillAmount = 1f;
        Invoke("Fire", 0);
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
            if (MultipleAttackCount <= 1)
            {
                GameObject item = GameManager.Instance.FirePooler.GetPooledObject(0);
                item.GetComponent<FireControl>().Multiple = false;
                item.SetActive(true);
            }
            else
            {
                for (int i = 0; i < MultipleAttackCount; i++)
                {
                    GameObject item = GameManager.Instance.FirePooler.GetPooledObject(0);
                    if (i == 0) item.GetComponent<FireControl>().Multiple = false;
                    else item.GetComponent<FireControl>().Multiple = true;
                    item.SetActive(true);
                }
            }

        }

        Invoke("Fire",AttackSpeed);
    }

    public void GetDamage(int amount)
    {
        if (!GameManager.Instance.StartGame) return;
        TotalHealt = TotalHealt - amount + Armor;
        HealtFilledImage.fillAmount = TotalHealt / _diviningHealt;
        if (TotalHealt <= 0)
        {
            Debug.Log("Fail");
            GameManager.Instance.StartGame = false;
            CanvasController.Instance.EndGamePanelSetup();
            CanvasController.Instance.TogglePanel(CanvasController.Instance.EndGamePanel);
        }
    }
    public void SetHealt()
    {
        TotalHealt = (int)_diviningHealt;
        HealtFilledImage.fillAmount = TotalHealt / _diviningHealt;
    }
}
