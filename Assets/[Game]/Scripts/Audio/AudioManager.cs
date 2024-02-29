using System.Collections;
using System.Collections.Generic;
using CHARK.ScriptableEvents.Events;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private StringScriptableEvent OnAudioRequested;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private CharacterAudioData audioData;

    private void OnEnable()
    {
        OnAudioRequested.AddListener(PlaySFX);
    }

    private void OnDisable()
    {
        OnAudioRequested.RemoveListener(PlaySFX);
    }

    public void PlaySFX(string audioID)
    {
        //AudioClip audioClip = audioData.CharacterAudioCollection[audioID];
        //audioSource.PlayOneShot(audioClip);

        if (audioData.CharacterAudioCollection.TryGetValue(audioID, out AudioClip audioClip))
        {
            audioSource.clip = audioClip;
            audioSource.PlayOneShot(audioClip);
        }
        else
        {
            Debug.LogWarning($"Audio clip with ID '{audioID}' not found.");
        }
    }
}
