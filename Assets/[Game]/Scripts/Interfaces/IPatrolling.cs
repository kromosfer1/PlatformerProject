using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPatrolling 
{
    Vector2 targetPosition { get; }

    public void StartPatrolling();
}
