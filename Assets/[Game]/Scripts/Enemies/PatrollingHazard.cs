using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PatrollingHazard : Patrolling, IDamager
{
    [SerializeField] private int _damageValue;
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
        SetStartingPoint();
    }

    private void Update()
    {
        StartPatrolling();
    }

    public void DamageAction(Vector2 damagablePos, GameObject obj)
    {
        //Debug.Log("Damage Given");
    }
}
