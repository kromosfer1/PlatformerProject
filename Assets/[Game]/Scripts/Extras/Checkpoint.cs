using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour, ICheckpoint
{
    private Vector2 lastCheckpoint;
    public Vector2 LastCheckpoint => lastCheckpoint;

    private void Start()
    {
        lastCheckpoint = gameObject.transform.position;
    }
}
