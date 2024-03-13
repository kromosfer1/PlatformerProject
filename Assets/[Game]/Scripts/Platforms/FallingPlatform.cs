using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("PLATFORM STATS")]
    [Tooltip("Fall delay after character hit the platform")]
    [SerializeField] private float _fallDelay;

    [Tooltip("Destroy delay after platform fall")]
    [SerializeField] private float _moveBackDelay;
    private float _zeroDelay = 0;
    private Vector2 platformInitialPosition;

    private bool platformReturningBack;
    private bool platformFalling;

    public UnityAction FallStart;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        platformInitialPosition = transform.position;
    }

    private void Update()
    {
        if (platformReturningBack)
            transform.position = Vector2.MoveTowards(transform.position, platformInitialPosition, 20f * Time.deltaTime);

        if (transform.position.y == platformInitialPosition.y)
            platformReturningBack = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IPlayerController player = collision.gameObject.GetComponent<IPlayerController>();
        if (player != null && platformFalling == false)
        {
            StartCoroutine(PlatformAction(_fallDelay,_moveBackDelay));
            FallStart?.Invoke();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        IPlayerController player = collision.gameObject.GetComponent<IPlayerController>();
        if (player != null)
        {
            StopAllCoroutines();
            StartCoroutine(PlatformAction(_zeroDelay, _moveBackDelay));
        }
    }

    private IEnumerator PlatformAction(float fallDelay, float moveBackDelay)
    {
        platformFalling = true;
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(moveBackDelay);
        platformReturningBack = true;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        platformFalling = false;

        //Destroy(gameObject, destroyDelay);
    }

}
