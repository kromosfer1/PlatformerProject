using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    [SerializeField] private CapsuleCollider2D _playerCollider;
    [SerializeField] private float _collisionIgnoreTime;
    private GameObject _currentOneWayPlatform;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            if (_currentOneWayPlatform != null)
                StartCoroutine(DisableCollision());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IPlayerController player = collision.gameObject.GetComponent<IPlayerController>();

        if (player != null)
            _currentOneWayPlatform = gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        IPlayerController player = collision.gameObject.GetComponent<IPlayerController>();

        if (player != null)
            _currentOneWayPlatform = null;
    }

    private IEnumerator DisableCollision()
    {
        BoxCollider2D platformCollider = _currentOneWayPlatform.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(_playerCollider, platformCollider);
        yield return new WaitForSeconds(_collisionIgnoreTime);
        Physics2D.IgnoreCollision(_playerCollider, platformCollider, false);
    }
}
