using System.Collections;
using System.Collections.Generic;
using CHARK.ScriptableEvents.Events;
using UnityEngine;

public class CharacterAudioController : CharacterAudioControllerBase
{
    [SerializeField]
    private StringScriptableEvent OnAudioRequested;

    private CharacterEventHandler characterEventHandler;
    private CharacterEventHandler CharacterEventHandler
    {
        get
        {
            return characterEventHandler == null ? characterEventHandler
                    = transform.root.GetComponentInChildren<CharacterEventHandler>()
                    : characterEventHandler;
        }
    }

    private string jumpID = "JumpAudio";
    private string damageID = "DamageAudio";

    private void OnEnable()
    {
        CharacterEventHandler.OnDamageTaken.AddListener(PlayDamageSound);
        CharacterEventHandler.OnCharacterJumped.AddListener(PlayJumpSound);
        
    }
    private void OnDisable()
    {
        CharacterEventHandler.OnDamageTaken.RemoveListener(PlayDamageSound);
        CharacterEventHandler.OnCharacterJumped.RemoveListener(PlayJumpSound);
    }
    public override void PlayAudioOneShot(string audioID)
    {
        Debug.Log($"Audio Quee Played{audioID}");
        OnAudioRequested.Raise(audioID);
    }

    private void PlayJumpSound()
    {
        PlayAudioOneShot(jumpID);
    }

    private void PlayDamageSound()
    {
        PlayAudioOneShot(damageID);
    }
}
