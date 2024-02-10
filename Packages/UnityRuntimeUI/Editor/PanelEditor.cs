using UnityEditor;
using UnityEngine;
using UnityEditor.TerrainTools;

namespace AnilHarmandali.UnityRuntimeUI.Editor
{
    [CustomEditor(typeof(PanelBase), true)]
    public class PanelEditor : UnityEditor.Editor
    {
        private PanelBase panel;

        private void OnEnable()
        {
            panel = (PanelBase)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("ShowPanel"))
            {
                panel.ShowPanel();
            }

            if (GUILayout.Button("HidePanel"))
            {
                panel.HidePanel();
            }
        }
    }
}
