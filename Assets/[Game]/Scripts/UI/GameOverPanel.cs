using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnilHarmandali.UnityRuntimeUI
{
    public class GameOverPanel : PanelBase
    {
        protected override string ID => "GameOverPanel";

        private CharacterEventHandler eventHandler;
        private CharacterEventHandler EventHandler => eventHandler ?? FindAnyObjectByType<CharacterEventHandler>();

        public override void ShowPanel()
        {
            base.ShowPanel();
            
        }
        public override void HidePanel()
        {
            base.HidePanel();
            EventHandler.OnReviveRequested?.Invoke();
        }
    }
}
