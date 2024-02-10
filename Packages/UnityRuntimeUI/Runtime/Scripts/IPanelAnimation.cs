using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnilHarmandali.UnityRuntimeUI
{
    public interface IPanelAnimation
    {  
        Ease ShowEase { get; }
        Ease HideEase { get; }
        float Duration { get; }

        void PlayShowAnimation(Action onComplete = null);
        void PlayHideAnimation(Action onComplete = null);

        void PlayShowAnimation(Ease showEase, float duration, Action onComplete = null);
        void PlayHideAnimation(Ease hideEase, float duration, Action onComplete = null);
    }
}
