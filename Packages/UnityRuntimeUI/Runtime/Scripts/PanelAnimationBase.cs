using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnilHarmandali.UnityRuntimeUI
{
    public abstract class PanelAnimationBase : MonoBehaviour, IPanelAnimation
    {
        [SerializeField] private Ease showEase;
        public Ease ShowEase => showEase;

        [SerializeField] private Ease hideEase;
        public Ease HideEase => hideEase;

        [SerializeField] private float duration;
        public float Duration => duration;

        public abstract void PlayHideAnimation(Action onComplete = null);

        public virtual void PlayHideAnimation(Ease hideEase, float duration, Action onComplete = null)
        {
            throw new System.NotImplementedException();
        }

        public abstract void PlayShowAnimation(Action onComplete = null);

        public virtual void PlayShowAnimation(Ease showEase, float duration, Action onComplete = null)
        {
            throw new System.NotImplementedException();
        }
    }
}
