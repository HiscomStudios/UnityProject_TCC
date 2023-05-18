namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Controllers
{
    using UnityEngine;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Controllers;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Views.Internal;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Models;
    using HiscomEngine.Runtime.Scripts.Structures.Enums;
    using HiscomEngine.Runtime.Scripts.Structures.Extensions;
    
    public class HP_DialogueController : DialogueController
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
            LeanTween.move(dialogueBoxGameObject, dialogueBoxAnimationStartPositionRT, 0);
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
                
                return;
            }

            UpdateInterface();
        }
        protected override void UpdateInterface()
        {
            bool IsCurrentDialogueNull()
            {
                return Identifier.IdentifyIncident(() => currentDialogue == null, IncidentType.Error, "", gameObject);
            }
            bool IsSubtitleTMPNull()
            {
                return Identifier.IdentifyIncident(() => subtitleTMP == null, IncidentType.Warning, "", gameObject);
            }
            bool IsIconIMGNull()
            {
                return Identifier.IdentifyIncident(() => iconIMG == null, IncidentType.Warning, "", gameObject);
            }
            bool IsDubbingAudioSourceNull()
            {
                return Identifier.IdentifyIncident(() => dubbingAudioSource == null, IncidentType.Warning, "", gameObject);
            }
            
            if (IsCurrentDialogueNull()) return;
            var currentDialogueContent = currentDialogue.GetDialogueContent[currentDialogueContentId];

            if (!IsSubtitleTMPNull())
            {
                var subtitleTmpGameObject = subtitleTMP.gameObject;
                subtitleTmpGameObject.SetActive(false);
                subtitleTMP.text = "";
            }

            if (previousDialogueContent == null || previousDialogueContent.GetSpeakerId != currentDialogueContent.GetSpeakerId)
            {
                LeanTween.cancel(boxTween);
                dialogueBoxGameObject.SetActive(true);
                previousDialogueContent = currentDialogueContent;

                boxTween = LeanTween.move(dialogueBoxGameObject, dialogueBoxAnimationStartPositionRT, .5f).setEaseOutBack().setOnComplete(() =>
                {
                    if (!IsIconIMGNull())
                    {
                        var iconImgGameObject = iconIMG.gameObject;
                        iconImgGameObject.SetActive(true);
                        iconIMG.sprite = currentDialogueContent.GetIcon;
                    }
                    
                    LeanTween.move(dialogueBoxGameObject, dialogueBoxAnimationEndPositionRT, 1f).setEaseOutBack().setOnComplete(() =>
                    {
                        if (!IsSubtitleTMPNull())
                        {
                            var subtitleTmpGameObject = subtitleTMP.gameObject;
                            subtitleTmpGameObject.SetActive(true);
                            subtitleTMP.Typewrite(currentDialogueContent.GetSentence, 1f);
                        }
                        if (!IsDubbingAudioSourceNull())
                        {
                            var dubbingAudioSourceGameObject = dubbingAudioSource.gameObject;
                            dubbingAudioSourceGameObject.SetActive(true);
                            dubbingAudioSource.clip = currentDialogueContent.GetAudio;
                        }
                        currentDialogueContentId++;
                    });
                }).id;

                return;
            }
            
            if (!IsSubtitleTMPNull())
            {
                var subtitleTmpGameObject = subtitleTMP.gameObject;
                subtitleTmpGameObject.SetActive(true);
                subtitleTMP.Typewrite(currentDialogueContent.GetSentence, 1f);
            }
            if (!IsDubbingAudioSourceNull())
            {
                var dubbingAudioSourceGameObject = dubbingAudioSource.gameObject;
                dubbingAudioSourceGameObject.SetActive(true);
                dubbingAudioSource.clip = currentDialogueContent.GetAudio;
            }
            currentDialogueContentId++;
        }

        #endregion

        #endregion
    }
}