namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Views.Internal
{
    using UnityEngine;

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

        protected abstract void Attack();

        #endregion

        #endregion
    }
}