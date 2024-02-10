using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotatingObject : MonoBehaviour, IRotate
{
    private Transform _rotatingObject;
    [Range(0.1f,100)][SerializeField] private float _rotationSpeed;
    [SerializeField] private Vector3 _rotation;

    private void Start()
    {
        _rotatingObject = gameObject.GetComponent<Transform>();
    }

    private void Update()
    {
        RotateAction(_rotatingObject);
    }

    public virtual void RotateAction(Transform gameObject)
    {
        gameObject.transform.DORotate(_rotation, _rotationSpeed, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Restart)
            .SetRelative()
            .SetEase(Ease.Linear);
        
    }
}
