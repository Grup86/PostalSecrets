using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = .5f;
    public Animator PlayerAnimator;
    public SpriteRenderer SpriteRenderer;
    private Vector2 _movement;
    public Rigidbody2D PlayerRigidbody;


    private void Update()
    {
        if (!GameManager.Instance.StartGame) return;
        #region Move
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        _movement = new Vector2(moveX, moveY).normalized;
        PlayerAnimator.SetFloat("Speed", _movement.sqrMagnitude);

        if (moveX < 0)
        {
            SpriteRenderer.flipX = false;
        }
        else if (moveX > 0)
        {
            SpriteRenderer.flipX = true;
        }
        PlayerRigidbody.velocity = _movement * MoveSpeed;
        #endregion Move
    }
}
