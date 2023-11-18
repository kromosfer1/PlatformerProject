using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float _bouncePower;
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private float _duration;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IPlayerController player = collision.gameObject.GetComponent<IPlayerController>();
        if (player != null)
        {
            ExecuteBounce(collision.gameObject);
        }
    }
    
    private void ExecuteBounce(GameObject obj)
    {
        obj.transform.DOLocalJump(_targetPosition.position, _bouncePower, 1, _duration);
    }
}
