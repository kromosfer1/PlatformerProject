using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    PlayerHealthController playerHealthController => gameObject.GetComponent<PlayerHealthController>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ICheckpoint checkpoint = collision.GetComponent<ICheckpoint>();
        if (checkpoint != null)
        {
            Debug.Log("triggered");
            playerHealthController.UpdateSpawnPoint(checkpoint.LastCheckpoint);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamager damager = collision.gameObject.GetComponent<IDamager>();
        if (damager != null)
        {
            playerHealthController.TakeDamage();
        }
    }
}
