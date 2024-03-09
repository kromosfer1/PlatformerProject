using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnilHarmandali.UnityRuntimeUI
{
    public class SettingsPanel : PanelBase
    {
        protected override string ID => "SettingsPanel";

        public override void ShowPanel()
        {
            base.ShowPanel();
            PauseControl.PauseGame();
        }
        public override void HidePanel()
        {
            base.HidePanel();
            PauseControl.ResumeGame();
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}