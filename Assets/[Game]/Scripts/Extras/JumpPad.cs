using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float _bouncePower;
    [SerializeField] private Vector3 _endvalue;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IPlayerController player = collision.gameObject.GetComponent<IPlayerController>();
        if (player != null)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * _bouncePower,ForceMode2D.Impulse);
        }
    }
}
