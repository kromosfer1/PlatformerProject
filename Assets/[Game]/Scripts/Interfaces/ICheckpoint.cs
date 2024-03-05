using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICheckpoint 
{
    Vector2 LastCheckpoint {  get; }
    BoxCollider2D Collider { get; }

    public void OnCollisionAction();
}
