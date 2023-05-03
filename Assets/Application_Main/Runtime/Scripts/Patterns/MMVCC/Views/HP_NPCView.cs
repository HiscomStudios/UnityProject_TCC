namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Views
{
    using UnityEngine;
    using Managers;
    
    public class HP_NPCView : MonoBehaviour
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected string id, npcName;
        [SerializeField] protected Sprite splashArtSprite;

        #endregion

        #region Public Variables
        
        public string GetID => id;
        public string GetNpcName => npcName;
        public Sprite GetSplashArtSprite => splashArtSprite;

        #endregion

        #endregion

        #region Methods

        #region Protected Methods

        protected void Awake()
        {
            HP_NPCSpawnManager.Instance.GetAvailableNpcs.Add(id);
        }

        #endregion

        #endregion
    }
}