using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterEventHandler : MonoBehaviour
{
    public UnityEvent OnDamageTaken;
    public UnityEvent OnCharacterRevive;
    public UnityEvent OnCharacterDeath;
    public UnityEvent OnReviveRequested;
    public UnityEvent OnCharacterJumped;
    public UnityEvent OnLevelFinished;
    public UnityEvent OnCharacterRunning;
}
