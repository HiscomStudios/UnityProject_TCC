namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Views
{
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;
    using FancyCarouselView.Runtime.Scripts;
    using Internal;
    
    public class HP_NPCCardView : CarouselCell<HP_NPCView, HP_NPCCardView>
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected Image npcSplashArtIMG;
        [SerializeField] protected TextMeshProUGUI npcNameTMP;
        [SerializeField] protected Button cardBTN;

        protected string npcId, npcName;

        #endregion

        #region Public Variables

        public string GetNpcId => npcId;
        public string GetNpcName => npcName;
        public Button GetCardBTN => cardBTN;

        #endregion

        #endregion

        #region Methods

        #region Protected Methods

        protected override void Refresh(HP_NPCView npc)
        {
            npcId = npc.GetID;
            npcName = npc.GetNpcName;
            
            npcSplashArtIMG.sprite = npc.GetSplashArtSprite;
            npcNameTMP.text = npc.GetNpcName;
        }

        #endregion

        #region Public Methods

        public void OnCardButtonPressed()
        {
        }
        protected virtual void SelectNpc(HP_NPCCardView npcCard)
        {
            //selectedNpcCard = npcCard;
        }

        #endregion

        #endregion
    }
}