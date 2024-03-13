using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine.Utility;

public class PlayerCollisionController : MonoBehaviour
{
    public static event Action<int> DamageTaken;
    public static event Action<Vector2> UpdateSpawnPoint;

    private float immunityDuration = 2;
    private bool collidable = true;

    #region EventHandler
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
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ICheckpoint checkpoint = collision.gameObject.GetComponent<ICheckpoint>();
        if (checkpoint != null)
        {
            UpdateSpawnPoint?.Invoke(checkpoint.LastCheckpoint);
            checkpoint.Collider.enabled = false;
            checkpoint.OnCollisionAction();
            CharacterEventHandler.OnCheckpointActivation?.Invoke();
        }

        ILevelFinish levelFinish = collision.gameObject.GetComponent<ILevelFinish>();
        if (levelFinish != null)
        {
            CharacterEventHandler.OnLevelFinished?.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamager damager = collision.gameObject.GetComponent<IDamager>();
        if (damager != null && collidable)
        {
            DamageTaken?.Invoke(damager.DamageValue);
            Debug.Log($"{damager.DamageValue} damage taken");
            StartCoroutine(CollisionControl());
        }
    }

    private IEnumerator CollisionControl()
    {
        collidable = false;
        yield return new WaitForSeconds(immunityDuration);
        collidable = true;
    }
    
}
