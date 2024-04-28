using System.Collections;
using System.Collections.Generic;
using CHARK.ScriptableEvents.Events;
using UnityEngine;

public class CharacterAudioController : CharacterAudioControllerBase
{
    [SerializeField] private StringScriptableEvent OnAudioRequested;

    #region EventHandler
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
    #endregion

    #region Audio IDs
    private string jumpID = "JumpAudio";
    private string damageID = "DamageAudio";
    private string checkpointID = "CheckpointAudio";
    private string[] footstepsIDs = { "Footstep1", "Footstep2" };

    #endregion
    private bool footstepsActive;

    private void OnEnable()
    {
        CharacterEventHandler.OnDamageTaken.AddListener(PlayDamageSound);
        CharacterEventHandler.OnCharacterJumped.AddListener(PlayJumpSound);
        CharacterEventHandler.OnCheckpointActivation.AddListener(PlayCheckpointSound);
        CharacterEventHandler.OnCharacterRunning.AddListener(PlayFootstepsSound);
    }
    private void OnDisable()
    {
        CharacterEventHandler.OnDamageTaken.RemoveListener(PlayDamageSound);
        CharacterEventHandler.OnCharacterJumped.RemoveListener(PlayJumpSound);
        CharacterEventHandler.OnCheckpointActivation.RemoveListener(PlayCheckpointSound);
        CharacterEventHandler.OnCharacterRunning.RemoveListener(PlayFootstepsSound);
    }
    public override void PlayAudioOneShot(string audioID)
    {
        //Debug.Log($"Audio Quee Played{audioID}");
        OnAudioRequested.Raise(audioID);
    }

    #region Play Sound Methods
    private void PlayJumpSound()
    {
        PlayAudioOneShot(jumpID);
    }

    private void PlayDamageSound()
    {
        PlayAudioOneShot(damageID);
    }

    private void PlayCheckpointSound()
    {
        PlayAudioOneShot(checkpointID);
    }

    private void PlayFootstepsSound()
    {
        if (footstepsActive == true)
            return;
        //StartCoroutine(Footsteps(14));
        StartCoroutine(FootstepSounds(0.3f));
    }

    #endregion

    private string GetRandomFootstepID()
    {
        return footstepsIDs[Random.Range(0, footstepsIDs.Length)];
    }

    private void Step()
    {
        string getrandomID = GetRandomFootstepID();
        PlayAudioOneShot(getrandomID);
    }

    private IEnumerator FootstepSounds(float waittime)
    {
        footstepsActive = true;
        Step();
        yield return new WaitForSeconds(waittime);
        footstepsActive = false;
    }
}
