namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Views.Internal
{
    using UnityEngine;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Models;
    using HiscomEngine.Runtime.Scripts.Structures.Enums;
    
    public abstract class HP_BossMovesetView : MonoBehaviour
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected Animator animator;
        [SerializeField] protected AnimationClip animationClip;

        #endregion

        #endregion
        
        #region Methods

        #region Protected Methods

        protected virtual void Attack()
        {
            bool IsAnimatorNull()
            {
                return Identifier.IdentifyIncident(() => animator == null, IncidentType.Warning, "", gameObject);
            }
            bool IsAnimationClipNull()
            {
                return Identifier.IdentifyIncident(() => animationClip == null, IncidentType.Warning, "", gameObject);
            }
            
            if (!IsAnimatorNull() && !IsAnimationClipNull())
                animator.Play(animationClip.name);
        }

        #endregion

        #endregion
    }
}