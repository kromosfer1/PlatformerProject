using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinishPoint : MonoBehaviour,ILevelFinish
{
    private BoxCollider2D finishCollider;
    public BoxCollider2D FinishCollider => finishCollider;

    private void Start()
    {
        finishCollider = gameObject.GetComponent<BoxCollider2D>();
    }
}
