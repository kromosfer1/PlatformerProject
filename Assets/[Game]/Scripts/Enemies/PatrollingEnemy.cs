using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor.Experimental.GraphView;

public class PatrollingEnemy : Patrolling, IDamager
{
    [SerializeField] private float _pushPower;
    [SerializeField] private float _duration;

    public int DamageValue => 2;

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
        Debug.Log("Damage Given");

        if (damagablePos.x > transform.position.x)
        {
            //Player.Instance.StepBack(Vector2.right * 5f);
            obj.transform.DOLocalJump(new Vector3(transform.localPosition.x + 10, transform.localPosition.y, 0), _pushPower, 1, _duration);
        }
        else if (damagablePos.x < transform.position.x)
        {
            //Player.Instance.StepBack(Vector2.left * 5f);
            obj.transform.DOLocalJump(new Vector3(transform.localPosition.x - 1, transform.localPosition.y, 0), _pushPower, 1, _duration);

        }
    }
}
