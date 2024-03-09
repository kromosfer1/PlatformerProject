using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PatrollingEnemy : Patrolling, IDamager
{
    [SerializeField] private float _pushPower;
    [SerializeField] private float _duration;
    [SerializeField] private int _damageValue;
    [SerializeField] private SpriteRenderer _sprite;
    private float _startingX;
    private bool _isMovingRight = true;
    public int DamageValue => _damageValue;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();
        if (damagable != null)
        {
            DamageAction(collision.transform.position, collision.gameObject);
        }
    }

    private void Start()
    {
        _startingX = transform.position.x;
        SetStartingPoint();
    }

    private void Update()
    {
        StartPatrolling();
        HandleSpriteFlip();
    }
    private void HandleSpriteFlip()
    {
        float currentX = transform.position.x;
        if (currentX > _startingX) // If current position is greater than previous position, enemy is moving right
        {
            _sprite.flipX = false; // No flip
            _isMovingRight = true;
        }
        else if (currentX < _startingX) // If current position is less than previous position, enemy is moving left
        {
            _sprite.flipX = true; // Flip horizontally
            _isMovingRight = false;
        }

        _startingX = currentX;
    }

    public void DamageAction(Vector2 damagablePos, GameObject obj)
    {
        Debug.Log("Damage Given");

        if (damagablePos.x > transform.position.x)
        {
            //Player.Instance.StepBack(Vector2.right * 5f);
        }
        else if (damagablePos.x < transform.position.x)
        {
            //Player.Instance.StepBack(Vector2.left * 5f);
        }
    }
}
