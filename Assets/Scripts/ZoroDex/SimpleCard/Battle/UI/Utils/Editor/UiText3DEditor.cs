using UnityEditor;

namespace ZoroDex.SimpleCard
{
    [CustomEditor(typeof(UiText3D),true)]
    public class UiText3DEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            (target as UiText3D).ResetColor();
            
        }
        
    }
}