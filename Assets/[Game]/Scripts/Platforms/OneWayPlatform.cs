using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MovementController;

public class OneWayPlatform : MonoBehaviour
{
    [SerializeField] private float _dropDelay;
    private GameObject currentOneWayPlatform;
    private FrameInput _frameInput;
    private bool _hopDownButton => _frameInput.hopDownInput;

    private void Start()
    {
        currentOneWayPlatform = gameObject;
    }

    private void Update()
    {
        if (_hopDownButton && currentOneWayPlatform != null)
            StartCoroutine(DisableCollision(gameObject.GetComponent<CapsuleCollider2D>()));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IPlayerController player = collision.gameObject.GetComponent<IPlayerController>();

        if (player != null)
            currentOneWayPlatform = collision.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        IPlayerController player = collision.gameObject.GetComponent<IPlayerController>();

        if (player != null)
            currentOneWayPlatform = null;
    }

    private IEnumerator DisableCollision(CapsuleCollider2D playerCollider)
    {
        IPlayerController player = playerCollider.gameObject.GetComponent<IPlayerController>();
        if (player != null)
            gameObject.GetComponent<CapsuleCollider2D>();

        BoxCollider2D platformCollider = currentOneWayPlatform.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        yield return new WaitForSeconds(_dropDelay);
        Physics2D.IgnoreCollision(playerCollider, platformCollider);
    }
}
