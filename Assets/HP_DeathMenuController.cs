namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Controllers
{
    using UnityEngine;
    using Managers;
    using Views;
    
    public class HP_DeathMenuController : MonoBehaviour
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected CanvasGroup bgCanvasgroup, npcsCarouselCanvasGroup;
        [SerializeField] protected HP_NPCCarouselView hpNpcCarouselView;
        
        #endregion

        #endregion

        #region Methods

        #region Protected Methods

        protected virtual void OnEnable()
        {
            SetupInterface();
        }
        
        protected virtual void SetupInterface()
        {
            bgCanvasgroup.alpha = npcsCarouselCanvasGroup.alpha = 0;
            hpNpcCarouselView.Setup(HP_NPCSpawnManager.Instance.GetSessionNpcs);
        }

        #endregion
        
        #region Public Methods

        /// <summary>
        /// Enables the death menu.
        /// </summary>
        public void OnCharacterDeath()
        {
            LeanTween.alphaCanvas(bgCanvasgroup, 1, .25f).setEaseInExpo().setIgnoreTimeScale(true).setOnComplete(() =>
            {
                LeanTween.alphaCanvas(npcsCarouselCanvasGroup, 1, .25f).setDelay(.35f).setEaseInExpo().setIgnoreTimeScale(true);
            });
        }
        
        /// <summary>
        /// Kills the selected NPC.
        /// </summary>
        public void OnKillNpcButtonPressed()
        {
            HP_NPCSpawnManager.Instance.GetSessionNpcs.Remove(HP_NPCSpawnManager.Instance.GetSessionNpcs[hpNpcCarouselView.ActiveCellIndex]);
        }

        #endregion

        #endregion
    }
}