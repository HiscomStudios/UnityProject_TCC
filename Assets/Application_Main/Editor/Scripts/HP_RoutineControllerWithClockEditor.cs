#if UNITY_EDITOR
#if Months
#if Seasons
#if Days

namespace HiscomProject.Editor.Scripts
{
    using UnityEditor;
    using UnityEngine;
    using HiscomEngine.Addons.OpenWorld.Editor.Scripts;
    using Runtime.Scripts.Patterns.MMVCC.Controllers;

    [CustomEditor(typeof(HP_RoutineControllerWithClock)), CanEditMultipleObjects]
    public class HP_RoutineControllerWithClockEditor : RoutineControllerEditor
    {
        #region Variables

        #region Protected Variables

        protected SerializedProperty clockArrowGameObject;

        #endregion

        #endregion

        #region Methods

        #region Protected Methods

        protected override void Setup()
        {
            base.Setup();
            SetupClockArrowGameObject();
        }

        protected override void Show()
        {
            base.Show();
            EditorGUILayout.Space();
            
            EditorGUILayout.LabelField(new GUIContent("Clock Settings", "Settings related to the clock"), EditorStyles.boldLabel);
            ShowClockArrowGameObject();
        }
        
        protected virtual void SetupClockArrowGameObject()
        {
            clockArrowGameObject = serializedObject.FindProperty("clockArrowGameObject");
        }
        protected virtual void ShowClockArrowGameObject()
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(clockArrowGameObject, new GUIContent("Clock Arrow: ", "The arrow of the clock that will be rotated."), true);
            EditorGUI.indentLevel--;
        }

        #endregion
        
        #endregion
    }
}

#endif
#endif
#endif
#endif