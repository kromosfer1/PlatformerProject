using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Patrolling : MonoBehaviour
{
    [SerializeField] private Transform[] _targetPoints;
    [SerializeField] private float _speed;
    [SerializeField] private int _startPoint;
    private int i;

    protected virtual void SetStartingPoint()
    {
        transform.position = _targetPoints[_startPoint].position;
    }
    protected virtual void StartPatrolling()
    {
        if (Vector2.Distance(transform.position, _targetPoints[i].position) < 0.02f)
        {
            i++;
            if (i == _targetPoints.Length)
            {
                i = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, _targetPoints[i].position, _speed * Time.deltaTime);
    }
}
