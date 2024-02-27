using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterAudioControllerBase : MonoBehaviour, ICharacterAudioController
{
    [SerializeField] private CharacterAudioData audioData;
    protected CharacterAudioData AudioData => audioData;

    public abstract void PlayAudioOneShot(string audioID);
}
