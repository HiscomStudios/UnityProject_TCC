namespace HiscomProject.Scripts.Patterns.MMVCC.Views
{
    using UnityEngine;
    
    public class HP_NPCView : MonoBehaviour
    {
        #region Variables

        #region Private Variables

        [SerializeField] private string id;
        [SerializeField] private Vector3 spawnPosition, spawnRotation;

        #endregion

        #region Public Variables
        
        public string GetID => id;
        public Vector3 GetSpawnPosition => spawnPosition;
        public Vector3 GetSpawnRotation => spawnRotation;

        #endregion

        #endregion
    }
}