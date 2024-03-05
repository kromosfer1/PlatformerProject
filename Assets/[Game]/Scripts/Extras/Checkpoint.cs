using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour, ICheckpoint
{
    private Vector2 lastCheckpoint;
    public Vector2 LastCheckpoint => lastCheckpoint;

    private BoxCollider2D checkpointCollider;
    public BoxCollider2D Collider => checkpointCollider;

    private void Start()
    {
        lastCheckpoint = gameObject.transform.position;
        checkpointCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    public void OnCollisionAction()
    {
    }
}
