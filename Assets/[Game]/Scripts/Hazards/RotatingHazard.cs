using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingHazard : RotatingObject, IDamager
{
    public int damageValue => 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();
        if (damagable != null)
        {
            DamageAction(collision.transform.position,collision.gameObject);
        }
    }

    public void DamageAction(Vector2 damagablePos, GameObject objB)
    {
        Debug.Log("Damage Given");
    }
}
