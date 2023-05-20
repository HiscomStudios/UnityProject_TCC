namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Views
{
    using UnityEngine;

    public class HP_BossMoveChainsView : MonoBehaviour
    {
        #region Variables

        #region Protected Variables
        
        protected GameObject chainsInstance;
    
        #endregion

        #endregion

        #region Methods

        #region Protected Methods

        private Vector3 initialScale;
        
        protected virtual void OnEnable()
        {
            Attack();
        }
        protected void OnDisable()
        {
            Destroy(chainsInstance);
        }

        protected void Attack()
        {
        }
        #endregion

        #endregion
    } 
}
