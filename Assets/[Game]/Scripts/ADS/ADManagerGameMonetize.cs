using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADManagerGameMonetize : MonoBehaviour
{
    void Awake()
    {
        GameMonetize.OnResumeGame += ResumeGame;
        GameMonetize.OnPauseGame += PauseGame;
    }

    void OnDestroy()
    {
        GameMonetize.OnResumeGame -= ResumeGame;
        GameMonetize.OnPauseGame -= PauseGame;
    }

    public void ResumeGame()
    {
        // RESUME MY GAME
        AudioListener.volume = 1f;
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        // PAUSE MY GAME
        Time.timeScale = 0.01f;
        AudioListener.volume = 0f;
    }

    public void ShowAd()
    {
        GameMonetize.Instance.ShowAd();
    }
}
