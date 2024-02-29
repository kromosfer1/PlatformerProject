using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour, IDamagable, IPlayerHealth
{
    [SerializeField] private int _maxHealth = 3;
    [SerializeField] private int _currentHealth;
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

    public Vector2 SpawnPoint => _respawnPoint;

    public int MaxHealth => _maxHealth;

    public int CurrentHealth => _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }
    private void Start()
    {
        _respawnPoint = gameObject.transform.position;
        Revive();
    }

    private void Update()
    {
        OnPlayerDeath();
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
        characterEventHandler.OnDamageTaken?.Invoke();
    }

    private void UpdateRespawnPoint(Vector2 checkpoint)
    {
        _respawnPoint = checkpoint;
    }

    private void OnPlayerDeath()
    {
        if (_currentHealth <= 0 || gameObject.transform.position.y <= _dyingYpos)
        {
            _currentHealth = 0;
            CharacterEventHandler.OnCharacterDeath?.Invoke();

            KillPlayerAction();

        }
    }

    private void KillPlayerAction()
    {
        Debug.Log($"Player Died");
    }

    private void Revive()
    {
        _currentHealth = _maxHealth;
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
