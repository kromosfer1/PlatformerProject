using UnityEngine;
using DG.Tweening;

public class MovingPlatform : MonoBehaviour, IPatrolling

{
    [SerializeField] private Vector2 _targetpos;

    public Vector2 targetPosition => _targetpos;

    private void Start()
    {
        StartPatrolling();
    }

    public void StartPatrolling()
    {
        transform.DOMove(_targetpos, 2f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }
    
}
