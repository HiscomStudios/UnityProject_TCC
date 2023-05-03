namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Views
{
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;
    
    public class HP_NPCCardView : MonoBehaviour
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

        #region Public Methods

        public void Setup(HP_NPCView npc)
        {
            npcId = npc.GetID;
            npcName = npc.GetNpcName;
            
            npcSplashArtIMG.sprite = npc.GetSplashArtSprite;
            npcNameTMP.text = npc.GetNpcName;
        }

        #endregion

        #endregion
    }
}