using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCollisionController : MonoBehaviour
{
    public static event Action<int> DamageTaken;
    public static event Action<Vector2> UpdateSpawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ICheckpoint checkpoint = collision.gameObject.GetComponent<ICheckpoint>();
        if (checkpoint != null)
        {
            UpdateSpawnPoint?.Invoke(checkpoint.LastCheckpoint);
            checkpoint.Collider.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamager damager = collision.gameObject.GetComponent<IDamager>();
        if (damager != null)
        {
            DamageTaken?.Invoke(damager.DamageValue);
            Debug.Log($"{damager.DamageValue} damage taken");
        }
    }
    
}
