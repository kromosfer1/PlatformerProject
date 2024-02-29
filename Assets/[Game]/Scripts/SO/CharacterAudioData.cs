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

    private Dictionary<string, AudioClip> _data;
    public Dictionary<string, AudioClip> CharacterAudioCollection
    {
        get
        {
            if (_data == null)
            {
                _data = new Dictionary<string, AudioClip>();

                for (int i = 0; i < Data.Count; i++)
                {
                    _data[Data[i].ID] = Data[i].AudioClip;
                }
            }
            return _data;

        }
    }
}