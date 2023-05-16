namespace HiscomProject.Editor.Scripts
{
    using UnityEditor;
    using UnityEngine;
    using HiscomEngine.Editor.Scripts;
    using Runtime.Scripts.Patterns.MMVCC.Controllers;

    [CustomEditor(typeof(HP_DialogueController)), CanEditMultipleObjects]
    public class HP_DialogueControllerEditor : DialogueControllerEditor
    {
        #region Variables

        #region Protected Variables

        protected SerializedProperty dialogueBoxGameObject, characterIconGameObject, dialogueBoxAnimationStartPositionRT, dialogueBoxAnimationEndPositionRT, characterIconAnimationStartPositionRT, characterIconAnimationEndPositionRT;

        #endregion

        #endregion

        #region Methods

        #region Protected Methods

        protected override void Setup()
        {
            base.Setup();
            SetupDialogueBoxGameObject();
            SetupCharacterIconGameObject();
        }
        protected override void Show()
        {
            base.Show();
            
            EditorGUILayout.LabelField(new GUIContent("Animation Settings", "Settings related to animations"), EditorStyles.boldLabel);
            ShowDialogueBoxGameObject();
            ShowCharacterIconGameObject();
        }
        
        protected virtual void SetupDialogueBoxGameObject()
        {
            dialogueBoxGameObject = serializedObject.FindProperty("dialogueBoxGameObject");
            dialogueBoxAnimationStartPositionRT = serializedObject.FindProperty("dialogueBoxAnimationStartPositionRT");
            dialogueBoxAnimationEndPositionRT = serializedObject.FindProperty("dialogueBoxAnimationEndPositionRT");
        }
        protected virtual void ShowDialogueBoxGameObject()
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(dialogueBoxGameObject, new GUIContent("Dialogue Box: ", "The dialogue box that will be animated."), true);
            EditorGUILayout.PropertyField(dialogueBoxAnimationStartPositionRT, new GUIContent("Dialogue Box Animation Start Position: ", "The start position of the dialogue box animation."), true);
            EditorGUILayout.PropertyField(dialogueBoxAnimationEndPositionRT, new GUIContent("Dialogue Box Animation End Position: ", "The end position of the dialogue box animation."), true);
            EditorGUI.indentLevel--;
        }
        
        protected virtual void SetupCharacterIconGameObject()
        {
            characterIconGameObject = serializedObject.FindProperty("characterIconGameObject");
            characterIconAnimationStartPositionRT = serializedObject.FindProperty("characterIconAnimationStartPositionRT");
            characterIconAnimationEndPositionRT = serializedObject.FindProperty("characterIconAnimationEndPositionRT");
        }
        protected virtual void ShowCharacterIconGameObject()
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(characterIconGameObject, new GUIContent("Character Icon: ", "The character icon that will be animated."), true);
            EditorGUILayout.PropertyField(characterIconAnimationStartPositionRT, new GUIContent("Character Icon Animation Start Position: ", "The start position of the character icon animation."), true);
            EditorGUILayout.PropertyField(characterIconAnimationEndPositionRT, new GUIContent("Character Icon Animation End Position: ", "The end position of the character icon animation."), true);
            EditorGUI.indentLevel--;
        }

        #endregion

        #endregion
    }
}