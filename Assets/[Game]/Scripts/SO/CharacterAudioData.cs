using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AudioData
{
    public string ID;
    public AudioClip AudioClip;
}

[CreateAssetMenu(menuName = "AnilHarmandali/2DPlatformer/CharacterAudioData")]
public class CharacterAudioData : ScriptableObject
{
    public List<AudioData> Data = new List<AudioData>();


    public Dictionary<string, AudioClip> CharacterAudioCollection = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        for (int i = 0; i < Data.Count; i++)
        {
            CharacterAudioCollection[Data[i].ID] = Data[i].AudioClip;
        }
    }
}