using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] private float _fallDelay;
    [SerializeField] private float _destroyDelay;
    [SerializeField] private Rigidbody2D _rigidBody;
    private float _zeroDelay = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IPlayerController player = collision.gameObject.GetComponent<IPlayerController>();
        if (player != null)
        {
            StartCoroutine(Fall(_fallDelay,_destroyDelay));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        IPlayerController player = collision.gameObject.GetComponent<IPlayerController>();
        if (player != null)
        {
            StopAllCoroutines();
            StartCoroutine(Fall(_zeroDelay, _destroyDelay));
        }
    }

    private IEnumerator Fall(float fallDelay, float destroyDelay)
    {
        yield return new WaitForSeconds(fallDelay);
        _rigidBody.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyDelay);
    }
}
