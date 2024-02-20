using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour, IDamager
{
    [SerializeField] private int _damageValue;
    public int DamageValue => _damageValue;

    public void DamageAction(Vector2 damagablePos, GameObject obj)
    {
        throw new System.NotImplementedException();
    }
}
