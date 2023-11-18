using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamager
{
    void DamageAction(Vector2 damagablePos, GameObject obj);
}
