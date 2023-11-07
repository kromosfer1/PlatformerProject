using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float _bouncePower;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IPlayerController player = collision.gameObject.GetComponent<IPlayerController>();
        if (player != null)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * _bouncePower,ForceMode2D.Impulse);
        }
    }
}
