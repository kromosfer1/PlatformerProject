using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour, IDamagable
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamager damager = collision.gameObject.GetComponent<IDamager>();
        if (damager != null)
        {
            TakeDamage();
        }
    }
    public void TakeDamage()
    {
        Debug.Log("Damage taken");
    }
}
