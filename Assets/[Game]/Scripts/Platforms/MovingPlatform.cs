using UnityEngine;
using DG.Tweening;

public class MovingPlatform : Patrolling

{
    
    private void Start()
    {
        SetStartingPoint();
    }
    private void Update()
    {
        StartPatrolling();
    }    
    
}
