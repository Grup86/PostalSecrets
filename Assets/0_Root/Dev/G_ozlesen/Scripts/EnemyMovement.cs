using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private Transform _player;
    public int AttackDamage;
    public int EnemyArmor;
    public int TotalHealt;
    public float MoveSpeed = .5f;
    [Range(.1f, 3f)] public float AttackSpeed;
    private int _tempHealt;

    private void OnEnable()
    {
        _tempHealt = TotalHealt;
    }
    private void Start()
    {
        _player = GameManager.Instance.Player;
    }
    void FixedUpdate()
    {
        Vector2 direction = (_player.position - transform.position).normalized;
        rb.velocity = direction * MoveSpeed;
        LookAtPlayer();
    }
    void LookAtPlayer()
    {
        Vector3 targetDirection = _player.position - transform.position;
        targetDirection.z = 0f;
        if (targetDirection.x >= 0)
        {
            transform.right = targetDirection.normalized;
        }
        else
        {
            transform.right = -targetDirection.normalized;
        }
    }

    bool attack;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out AttackManager Player))
        {
            if (attack) return;
            attack = true;
            Player.GetDamage(AttackDamage);
            StartCoroutine(AttackReset());
        }
    }


    IEnumerator AttackReset()
    {
        yield return BetterWaitForSeconds.Wait(AttackSpeed);
        attack = false;

    }

    public void TakeDamage(int damage)
    {
        _tempHealt = _tempHealt - damage + EnemyArmor;
        GameObject damageItem = GameManager.Instance.DamageTMPPooler.GetPooledObject(0);
        damageItem.SetActive(true);
        damageItem.GetComponent<DamageTMPControl>().SetText(transform.position, damage - EnemyArmor);

        if (_tempHealt <= 0)
        {
            GameManager.Instance.SetKilledEnemyCount();
            EnemySpawnerControl.Instance.EnemyCount--;
            int index = GameManager.Instance.Enemies.IndexOf(transform);
            GameManager.Instance.Enemies.RemoveAt(index);
            GameObject item = GameManager.Instance.CoinPooler.GetPooledObject(0);
            item.transform.position = transform.position;
            item.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
