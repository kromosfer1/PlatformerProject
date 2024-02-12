using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour, IDamagable
{
    [SerializeField] private int _currentHealth = 3;
    [SerializeField] private Vector2 _respawnPoint;
    [SerializeField] private float _dyingYpos;
    public static event Action PlayerDied;

    private void Start()
    {
        _respawnPoint = gameObject.transform.position;
    }

    private void Update()
    {
        Death();
        Revive();
    }

    private void OnEnable()
    {
        PlayerCollisionController.DamageTaken += TakeDamage;
        PlayerCollisionController.UpdateSpawnPoint += UpdateRespawnPoint;
    }

    private void OnDisable()
    {
        PlayerCollisionController.DamageTaken -= TakeDamage;
        PlayerCollisionController.UpdateSpawnPoint -= UpdateRespawnPoint;

    }

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;
    }

    private void UpdateRespawnPoint(Vector2 checkpoint)
    {
        _respawnPoint = checkpoint;
    }

    private void Death()
    {
        if (_currentHealth <= 0 || gameObject.transform.position.y <= _dyingYpos)
        {
            _currentHealth = 0;
            PlayerDied?.Invoke();
            KillPlayerAction();
        }
    }

    private void KillPlayerAction()
    {
        Debug.Log($"Player Died");
    }

    private void Revive()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        gameObject.transform.position = _respawnPoint;
    }
}
