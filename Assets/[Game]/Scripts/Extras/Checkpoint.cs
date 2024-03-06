using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Checkpoint : MonoBehaviour, ICheckpoint
{
    private Vector2 lastCheckpoint;
    public Vector2 LastCheckpoint => lastCheckpoint;

    private BoxCollider2D checkpointCollider;
    public BoxCollider2D Collider => checkpointCollider;

    [SerializeField] private GameObject _checkpointText;
    [SerializeField] private Transform _textTransform;
    [SerializeField] private Vector3 _endValue;
    [SerializeField] private float _duration;

    private void Start()
    {
        lastCheckpoint = gameObject.transform.position;
        checkpointCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    public void OnCollisionAction()
    {
        _checkpointText.SetActive(true);
        _textTransform.DOScale(_endValue, _duration).SetEase(Ease.InOutBounce);
    }
}
