using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : Singleton<MusicManager>
{
    [SerializeField] private AudioSource _musicSourceObject;

    public void PlayMusic()
    {
        _musicSourceObject.Play();
    }
}
