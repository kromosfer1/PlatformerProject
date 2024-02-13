using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour, IDamagable
{
    [SerializeField] private int _currentHealth = 3;
    [SerializeField] private Vector2 _respawnPoint;
    [SerializeField] private float _dyingYpos;

    private CharacterEventHandler characterEventHandler;
    private CharacterEventHandler CharacterEventHandler
    {
        get
        {
            return characterEventHandler == null ? characterEventHandler
                = transform.root.GetComponent<CharacterEventHandler>()
                : characterEventHandler;
        }
    }

    private void Start()
    {
        _respawnPoint = gameObject.transform.position;
        Revive();
    }

    private void Update()
    {
        Death();
        ReviveTest();
    }

    private void OnEnable()
    {
        CharacterEventHandler.OnReviveRequested.AddListener(Revive);
        PlayerCollisionController.DamageTaken += TakeDamage;
        PlayerCollisionController.UpdateSpawnPoint += UpdateRespawnPoint;
    }

    private void OnDisable()
    {
        CharacterEventHandler.OnReviveRequested.RemoveListener(Revive);
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
            CharacterEventHandler.OnCharacterDeath?.Invoke();

            KillPlayerAction();
            return;
        }
    }

    private void KillPlayerAction()
    {
        Debug.Log($"Player Died");
    }

    private void Revive()
    {
        _currentHealth = 3;
        gameObject.transform.position = _respawnPoint;
        CharacterEventHandler.OnCharacterRevive?.Invoke();
    }

    private void ReviveTest()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Revive();
            CharacterEventHandler.OnCharacterRevive?.Invoke();
        }
    }
}
