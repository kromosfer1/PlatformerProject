using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingHazard : RotatingObject, IDamager
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();
        if (damagable != null)
        {
            DamageAction();
        }
    }

    public void DamageAction()
    {
        Debug.Log("Damage Given");
    }
}
