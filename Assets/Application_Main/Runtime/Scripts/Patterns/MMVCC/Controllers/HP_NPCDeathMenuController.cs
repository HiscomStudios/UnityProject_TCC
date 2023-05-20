namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Controllers
{
    using UnityEngine;
    using Views;
    
    public class HP_NPCDeathMenuController : MonoBehaviour
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected HP_NPCLifeController npcLifeController;
        [SerializeField] protected HP_NPCCardView npcCardPrefab;
        [SerializeField] protected RectTransform contentRT;
        protected HP_NPCCardView selectedNpcCard;

        #endregion

        #endregion
        
        #region Methods

        #region Protected Methods

        protected void OnEnable()
        {
            SetupInterface();
        }

        protected void SetupInterface()
        {
            foreach (var npc in npcLifeController.GetSpawnedNpcs)
            {
                var instance = Instantiate(npcCardPrefab, contentRT);
                instance.Setup(npc);
                instance.GetCardBTN.onClick.AddListener(() => SelectNpc(instance));
            }
        }
        
        protected void SelectNpc(HP_NPCCardView npcCard)
        {
            selectedNpcCard = npcCard;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Kills the selected NPC.
        /// </summary>
        public void OnKillNpcButtonPressed()
        {
            npcLifeController.KillNPC(selectedNpcCard.GetNpcId);
        }

        #endregion

        #endregion
    }
}
