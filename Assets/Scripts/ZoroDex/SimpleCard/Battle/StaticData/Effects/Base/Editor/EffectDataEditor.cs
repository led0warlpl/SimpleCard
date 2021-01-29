using UnityEditor;
using UnityEngine;
using ZoroDex.SimpleCard.Data.Effects;

namespace ZoroDex.SimpleCard.Editor
{
    [CustomEditor(typeof(BaseEffectData), true)]
    public class EffectDataEditor : UnityEditor.Editor
    {
        private BaseEffectData MyTarget => target as BaseEffectData;

        private Vector2Int Position { get; set; }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (EditorApplication.isPlaying)
            {
                GUILayout.Space(10);
                GUILayout.Label("Playmode: Debug");
                GUILayout.BeginHorizontal();
                Position = EditorGUILayout.Vector2IntField("Position: ", Position, GUILayout.Width(100));

                if (GUILayout.Button("Resolve Targets"))
                {
                    //ResolveTargets();
                }

                GUILayout.EndHorizontal();
            }
        }
    }
}
