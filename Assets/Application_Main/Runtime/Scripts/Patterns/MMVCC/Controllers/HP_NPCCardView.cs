namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Views
{
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;
    using FancyCarouselView.Runtime.Scripts;
    using Internal;
    using Connectors;
    
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

        protected override void Refresh(string npcID)
        {
            foreach (var npcConnector in FindObjectsOfType<HP_NPCConnector>())
            {
                if (!npcConnector.gameObject.activeSelf || npcConnector.GetID != npcID) continue;
                npcId = npcConnector.GetID;
                npcName = npcConnector.GetNPCName;
                
                npcSplashArtIMG.sprite = npcConnector.GetSplashArtSprite;
                npcNameTMP.text = npcName;
            }
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
