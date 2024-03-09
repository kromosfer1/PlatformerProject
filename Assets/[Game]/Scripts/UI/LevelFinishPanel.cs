using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

namespace AnilHarmandali.UnityRuntimeUI
{
    public class LevelFinishPanel : PanelBase
    {
        protected override string ID => "LevelFinishPanel";
        [SerializeField] private int _nextLevelIndex;
        public override void ShowPanel()
        {
            base.ShowPanel();
            PauseControl.PauseGame();
        }

        public override void HidePanel()
        {
            base.HidePanel();

            PauseControl.ResumeGame();
            SceneManager.LoadScene(_nextLevelIndex);
        }
    }
}