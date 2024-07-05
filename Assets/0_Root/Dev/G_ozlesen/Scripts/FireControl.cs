using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControl : MonoBehaviour
{
    public Rigidbody2D Rb;
    public float Speed;
    private Vector2 targetDirection;
    private void OnEnable()
    {
        if (AttackManager.Instance.NearestEnemy == null) return;
        transform.position = GameManager.Instance.Player.position;
        Vector2 direction = (AttackManager.Instance.NearestEnemy.position - transform.position).normalized;
        Initialize(direction);
        StartCoroutine(GameobjectPassive());

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
            GameObject item = GameManager.Instance.DamageTMPPooler.GetPooledObject(0);
            item.SetActive(true);
            item.GetComponent<DamageTMPControl>().SetText(Enemy.transform.position, Random.Range(10, 20));
            int index = GameManager.Instance.Enemies.IndexOf(Enemy.transform);
            GameManager.Instance.Enemies.RemoveAt(index);
            item = GameManager.Instance.CoinPooler.GetPooledObject(0);
            item.transform.position = Enemy.transform.position;
            item.SetActive(true);
            Enemy.gameObject.SetActive(false);

        }
    }
    IEnumerator GameobjectPassive()
    {
        yield return BetterWaitForSeconds.Wait(3f);
        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
    }

}
