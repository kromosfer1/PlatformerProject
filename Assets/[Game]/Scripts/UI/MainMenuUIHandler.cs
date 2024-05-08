using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIHandler : MonoBehaviour
{
    [SerializeField] private int _nextLevel;

    public void LoadLevel()
    {
        SceneManager.LoadScene(_nextLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
