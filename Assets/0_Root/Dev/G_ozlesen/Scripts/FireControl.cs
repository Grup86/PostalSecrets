using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControl : MonoBehaviour
{
    public Rigidbody2D Rb;
    public float Speed;
    private Vector2 targetDirection;
    public bool Multiple;
    private void OnEnable()
    {
        if (AttackManager.Instance.NearestEnemy == null) return;
        transform.position = GameManager.Instance.Player.position;
        if (!Multiple)
        {
            Vector2 direction = (AttackManager.Instance.NearestEnemy.position - transform.position).normalized;
            Initialize(direction);
            StartCoroutine(GameobjectPassive());
        }
        else
        {
            int randomEnemy = Random.Range(0, GameManager.Instance.Enemies.Count);
            Vector2 direction = (GameManager.Instance.Enemies[randomEnemy].transform.position - transform.position).normalized;
            Initialize(direction);
            StartCoroutine(GameobjectPassive());
        }

    }

    public void Initialize(Vector2 direction)
    {
        targetDirection = direction;
        Rb.AddForce(targetDirection * Speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyMovement Enemy))
        {
            gameObject.SetActive(false);
            Enemy.TakeDamage(AttackManager.Instance.Damage);
            Multiple = false;
        }
    }
    IEnumerator GameobjectPassive()
    {
        yield return BetterWaitForSeconds.Wait(3f);
        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
            Multiple = false;
        }
    }

}
