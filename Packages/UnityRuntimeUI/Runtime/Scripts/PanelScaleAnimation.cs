using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnilHarmandali.UnityRuntimeUI
{
    public class PanelScaleAnimation : PanelAnimationBase
    {
        private Vector3 startScale;

        private void Start()
        {
            startScale = transform.localScale;
        }

        public override void PlayShowAnimation(Action onComplete = null)
        {
            transform.localScale = Vector3.zero;
            transform.DOScale(startScale, Duration).SetEase(ShowEase)
                .OnComplete(() => onComplete?.Invoke());
        }
        public override void PlayHideAnimation(Action onComplete = null)
        {            
            transform.DOScale(Vector3.zero, Duration).SetEase(HideEase)
                .OnComplete(() => onComplete?.Invoke());
        }
    }
}
