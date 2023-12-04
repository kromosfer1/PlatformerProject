using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour, IDamager
{
    public int damageValue => 3;

    public void DamageAction(Vector2 damagablePos, GameObject obj)
    {
        throw new System.NotImplementedException();
    }
}
