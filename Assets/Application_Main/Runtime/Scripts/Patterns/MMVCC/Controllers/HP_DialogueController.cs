namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Controllers
{
    using UnityEngine;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Controllers;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Views.Internal;
    
    public class HP_DialogueController : DialogueController
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected GameObject dialogueBoxGameObject, characterIconGameObject;
        [SerializeField] protected RectTransform dialogueBoxAnimationStartPositionRT, dialogueBoxAnimationEndPositionRT, characterIconAnimationStartPositionRT, characterIconAnimationEndPositionRT;
        
        DialogueContentView previousDialogueContent;
        
        #endregion

        #endregion

        #region Methods

        #region Protected Methods

        protected void Start()
        {
            LeanTween.move(dialogueBoxGameObject, dialogueBoxAnimationStartPositionRT, 0);
            LeanTween.move(characterIconGameObject, characterIconAnimationStartPositionRT, 0);
        }

        protected override void UpdateDialogue()
        {
            var currentDialogueContent = currentDialogue.GetDialogueContent;
            
            if (currentDialogueContentId == currentDialogueContent.Length)
            {
                LeanTween.move(dialogueBoxGameObject, dialogueBoxAnimationStartPositionRT, .5f).setEaseOutBack().setOnComplete(() =>
                {
                    EndDialogue();
                });

                LeanTween.move(characterIconGameObject, characterIconAnimationStartPositionRT, .5f).setEaseOutBack();
                return;
            }

            UpdateInterface();
        }
        protected override void UpdateInterface()
        {
            var currentDialogueContent = currentDialogue.GetDialogueContent[currentDialogueContentId];
            if (previousDialogueContent == null || previousDialogueContent.GetSpeakerId != currentDialogueContent.GetSpeakerId)
            {
                LeanTween.move(dialogueBoxGameObject, dialogueBoxAnimationStartPositionRT, .5f).setEaseOutBack().setOnComplete(() =>
                {
                    LeanTween.move(dialogueBoxGameObject, dialogueBoxAnimationEndPositionRT, 1f).setEaseOutBack().setOnComplete(() =>
                    {
                        base.UpdateInterface();
                        currentDialogueContentId++;
                    });
                });
            
                LeanTween.move(characterIconGameObject, characterIconAnimationStartPositionRT, .5f).setEaseOutBack().setOnComplete(() =>
                {
                    LeanTween.move(characterIconGameObject, characterIconAnimationEndPositionRT, 1f).setEaseOutBack();
                });

                return;
            }
            
            base.UpdateInterface();
            currentDialogueContentId++;
        }

        #endregion

        #endregion
    }
}