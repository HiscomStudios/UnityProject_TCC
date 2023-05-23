namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Connectors
{
    using UnityEngine;
    using Managers;
    
    public class HP_NPCConnector : MonoBehaviour
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