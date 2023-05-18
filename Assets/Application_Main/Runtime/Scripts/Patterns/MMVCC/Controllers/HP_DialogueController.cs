namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Controllers
{
    using UnityEngine;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Controllers;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Views.Internal;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Models;
    using HiscomEngine.Runtime.Scripts.Structures.Enums;

    public class HP_DialogueController : DialogueTypewriterController
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected GameObject dialogueBoxGameObject;
        [SerializeField] protected RectTransform dialogueBoxAnimationStartPositionRT, dialogueBoxAnimationEndPositionRT;
        
        protected int boxTween;
        protected DialogueContentView previousDialogueContent;
        
        #endregion

        #endregion

        #region Methods

        #region Protected Methods

        protected void Start()
        {
            LeanTween.move(dialogueBoxGameObject, dialogueBoxAnimationStartPositionRT, 0f);
        }

        protected override void UpdateDialogue()
        {
            bool IsCurrentDialogueNull()
            {
                return Identifier.IdentifyIncident(() => currentDialogue == null, IncidentType.Error, "", gameObject);
            }
            if (IsCurrentDialogueNull()) return;
            
            var currentDialogueContent = currentDialogue.GetDialogueContent;
            LeanTween.cancel(typewriterId);
            
            if (isTyping)
            {
                subtitleTMP.text = previousDialogueContent.GetSentence;
                isTyping = false;
            }
            else
            {
                if (currentDialogueContentId == currentDialogueContent.Length)
                {
                    LeanTween.move(dialogueBoxGameObject, dialogueBoxAnimationStartPositionRT, .5f).setEaseOutBack().setOnComplete(() =>
                    {
                        previousDialogueContent = null;
                        EndDialogue();
                    });
                    return;
                }
                
                UpdateInterface();
            }
        }
        protected override void UpdateInterface()
        {
            var currentDialogueContent = currentDialogue.GetDialogueContent[currentDialogueContentId];
            dialogueBoxGameObject.SetActive(true);
            
            switch (previousDialogueContent == null || previousDialogueContent.GetSpeakerId != currentDialogueContent.GetSpeakerId)
            {
                case true:
                    LeanTween.cancel(boxTween);
                    boxTween = LeanTween.move(dialogueBoxGameObject, dialogueBoxAnimationStartPositionRT, .5f).setEaseOutBack().setOnComplete(() =>
                    {
                        subtitleTMP.text = "";
                        UpdateIcon(currentDialogueContent);
                        
                        LeanTween.move(dialogueBoxGameObject, dialogueBoxAnimationEndPositionRT, 1f).setEaseOutBack().setOnComplete(() =>
                        {
                            UpdateSubtitle(currentDialogueContent);
                            UpdateDubbing(currentDialogueContent);
                        });
                    }).id;
                    break;
                
                case false:
                    UpdateSubtitle(currentDialogueContent);
                    UpdateDubbing(currentDialogueContent);
                    break;
            }    
                
            currentDialogueContentId++;
            previousDialogueContent = currentDialogueContent;
        }

        #endregion

        #endregion
    }
}