using CHARK.ScriptableEvents.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AnilHarmandali.UnityRuntimeUI
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class PanelBase : MonoBehaviour, IPanel
    {
        protected abstract string ID { get; }

        [SerializeField]
        protected StringScriptableEvent OnPanelShowRequested;
        [SerializeField]
        protected StringScriptableEvent OnPanelHideRequested;

        [SerializeField]
        protected UnityEvent OnPanelShown;
        [SerializeField]
        protected UnityEvent OnPanelHidden;

        private CanvasGroup _canvasGroup;
        private CanvasGroup CanvasGroup { get { return _canvasGroup == null ? _canvasGroup = GetComponent<CanvasGroup>() : _canvasGroup; } }

        protected IPanelAnimation PanelAnimation;

        private void Start()
        {
            PanelAnimation = GetComponent<IPanelAnimation>();
        }

        protected virtual void OnEnable()
        {
            OnPanelShowRequested.AddListener(ShowPanel);
            OnPanelHideRequested.AddListener(HidePanel);
        }

        protected virtual void OnDisable()
        {
            OnPanelShowRequested.RemoveListener(ShowPanel);
            OnPanelHideRequested.RemoveListener(HidePanel);
        }

        public virtual void ShowPanel()
        {
            if (PanelAnimation != null)
            {
                PanelAnimation?.PlayShowAnimation(OnPanelShown.Invoke);                  
            }
            else
            {
                OnPanelShown.Invoke();
            }

            CanvasGroup.alpha = 1;
            CanvasGroup.blocksRaycasts = true;
            CanvasGroup.interactable = true;
        }

        public virtual void HidePanel()
        {
            if(PanelAnimation != null)
            {
                PanelAnimation?.PlayHideAnimation(
                    () => {
                        CanvasGroup.alpha = 0;
                        OnPanelHidden.Invoke();
                        });
            }
            else 
            { 
                CanvasGroup.alpha = 0;
                OnPanelHidden.Invoke();
            }

            CanvasGroup.blocksRaycasts = false;
            CanvasGroup.interactable = false;
        }

        public void ShowPanel(string id)
        {
            if (!string.Equals(id, ID))
                return;

            ShowPanel();
        }

        public void HidePanel(string id)
        {
            if (!string.Equals(id, ID))
                return;

            HidePanel();
        }
    }
}
