#if UNITY_EDITOR

namespace HiscomEngine.Editor.Scripts
{
    using UnityEditor;
    using Runtime.Scripts.Patterns.MMVCC.Views;
    using HiscomEngine.Addons.EntitiesControlling.Editor.Scripts;
    
    [CustomEditor(typeof(HP_GenericRangedAttackView)), CanEditMultipleObjects]
    public class HP_GenericRangedAttackViewEditor : GenericRangedAttackViewEditor
    {
        #region Methods

        #region Public Methods

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            serializedObject.ApplyModifiedProperties();
        }

        #endregion

        #endregion
    }
}

#endif