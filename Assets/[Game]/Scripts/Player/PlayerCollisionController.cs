using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCollisionController : MonoBehaviour
{
    public static event Action<int> damageTaken;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamager damager = collision.gameObject.GetComponent<IDamager>();
        if (damager != null)
        {
            damageTaken?.Invoke(damager.damageValue);
            Debug.Log($"{damager.damageValue} damage taken");
        }
    }
    
}
