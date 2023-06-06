namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Views.Internal
{
    using System;
    using UnityEngine;

    [Serializable]
    public class HP_NPCView
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected string id;
        #endregion

        #region Public Variables
        
        public string GetID => id;
        
        #endregion

        #endregion
    }
}
