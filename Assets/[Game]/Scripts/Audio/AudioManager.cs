using System.Collections;
using System.Collections.Generic;
using CHARK.ScriptableEvents.Events;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private StringScriptableEvent OnAudioRequested;

    [SerializeField] private CharacterAudioData audioData;

    [SerializeField] private AudioClip audioClip;

    private void OnEnable()
    {
    }
    private void OnDisable()
    {
    }

    private void PlaySFX(string audioID)
    {

    }
}
