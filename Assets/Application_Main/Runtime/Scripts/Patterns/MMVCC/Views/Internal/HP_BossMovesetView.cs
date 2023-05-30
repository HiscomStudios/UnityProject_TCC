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
        [SerializeField] protected AnimationClip defaultAnimationClip, movementAnimationClip;

        #endregion

        #endregion
        
        #region Methods

        #region Protected Methods

        protected abstract void Attack();

        #endregion

        #endregion
    }
}