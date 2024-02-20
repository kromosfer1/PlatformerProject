using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerHealth 
{
    public Vector2 SpawnPoint { get; }
    public int MaxHealth {  get; }
    public int CurrentHealth { get; }
}
