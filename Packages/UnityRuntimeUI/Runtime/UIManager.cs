using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AnilHarmandali.UnityRuntimeUI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _highscoreButton;

        private void OnEnable()
        {
            _playButton.onClick.AddListener(LoadLevel);
            _exitButton.onClick.AddListener(ExitGame);
            _settingsButton.onClick.AddListener(Settings);
            _highscoreButton.onClick.AddListener(Highscore);
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(LoadLevel);
            _exitButton.onClick.RemoveListener(ExitGame);
            _settingsButton.onClick.RemoveListener(Settings);
            _highscoreButton.onClick.RemoveListener(Highscore);

        }

        private void LoadLevel()
        {            
            Debug.Log($"Play Button Clicked");
        }

        private void ExitGame()
        {
            Debug.Log($"Exit Button Clicked");
        }

        private void Settings()
        {
            Debug.Log($"Settings Button Clicked");
        }
        private void Highscore()
        {
            Debug.Log($"Highscore Button Clicked");
        }
    }
}
