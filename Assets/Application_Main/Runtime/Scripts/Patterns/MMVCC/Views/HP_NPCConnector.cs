namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Connectors
{
    using UnityEngine;
    using Managers;
    
    public class HP_NPCConnector : MonoBehaviour
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected string id, npcName;
        [SerializeField] protected Sprite splashArtSprite;

        #endregion

        #region Public Variables

        public string GetID => id;
        public string GetNPCName => npcName;
        public Sprite GetSplashArtSprite => splashArtSprite;

        #endregion
        
        #endregion
    }
}
