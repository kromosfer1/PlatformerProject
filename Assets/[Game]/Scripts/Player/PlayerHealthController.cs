using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour, IPlayerHealth, IDamagable
{
    private Vector2 spawnPoint;
    Vector2 IPlayerHealth.SpawnPoint => spawnPoint;

    private void Start()
    {
        spawnPoint = transform.position;
        Respawn();
    }
    private void Update()
    {
        CharacterDeath();
    }

    public void UpdateSpawnPoint(Vector2 newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }

    private void CharacterDeath()
    {
        if (gameObject.transform.position.y < -15)
        {
            Respawn();
        }
    }
    public void TakeDamage()
    {
        Debug.Log("Damage taken");
    }

    private void Respawn()
    {
        gameObject.transform.position = spawnPoint;
        Debug.Log("respawned");
    }
}
