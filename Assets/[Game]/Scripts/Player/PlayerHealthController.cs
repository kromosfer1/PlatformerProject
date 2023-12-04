using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour, IDamagable
{
    private int _currentHealth = 3;

    private void OnEnable()
    {
        PlayerCollisionController.damageTaken += TakeDamage;
    }

    private void OnDisable()
    {
        PlayerCollisionController.damageTaken -= TakeDamage;
    }

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            Kill();
        }
    }

    private void Kill()
    {
        Debug.Log($"Player Died");
    }
}
