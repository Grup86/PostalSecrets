using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = .5f;
    private Transform _player;

    private void Start()
    {
        _player = GameManager.Instance.Player;
    }
    void FixedUpdate()
    {
        Vector2 direction = (_player.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
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
}
