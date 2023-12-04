using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamager
{
    int damageValue { get; }
    void DamageAction(Vector2 damagablePos, GameObject obj);
}
