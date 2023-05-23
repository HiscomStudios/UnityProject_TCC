namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Controllers
{
    using System.Linq;
    using System.Collections.Generic;
    using UnityEngine;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Controllers;
    
    [AddComponentMenu("Scripts/Hiscom Project/Patterns/MMVCC/Controllers/HP Stat Interface Controller")]
    public class HP_StatInterfaceController : MonoBehaviour
    {
        #region Variables
        
        #region Protected Variables
        
        [SerializeField] protected StatsController statsController;
        [SerializeField] private HP_StatInterfaceItemView lifeItemPrefab, shieldItemPrefab;
        [SerializeField] private RectTransform lifeContainer, shieldContainer;
        [SerializeField] protected int lifeStatID, shieldStatID;
        protected List<HP_StatInterfaceItemView> instantiatedLifeItems, instantiatedShieldItems;
        
        #endregion

        #endregion

        #region Methods

        #region Protected Methods

        protected virtual void Start()
        {
            SetupLife();
            SetupShield();
        }

        protected virtual void SetupLife()
        {
            instantiatedLifeItems = new List<HP_StatInterfaceItemView>();
            var lifeStat = statsController.GetStat(lifeStatID);
            if (lifeStat == null) return;
            lifeStat.OnStatAmountChanged += ShowLife;
        }
        protected virtual void SetupShield()
        {
            instantiatedShieldItems = new List<HP_StatInterfaceItemView>();
            var shieldStat = statsController.GetStat(shieldStatID);
            if (shieldStat == null) return;
            shieldStat.OnStatAmountChanged += ShowShield;
        }
        protected virtual void ShowLife(float value)
        {
            var difference = Mathf.Abs((int) value - instantiatedLifeItems.Count);

            for (int i = 0; i < difference; i++)
            {
                switch (value)
                {
                    case var _ when value > instantiatedLifeItems.Count:
                        instantiatedLifeItems.Add(Instantiate(lifeItemPrefab, lifeContainer));
                        break;
                
                    case var _ when value < instantiatedLifeItems.Count(lifeItem => lifeItem.GetItemState == HP_StatInterfaceItemView.ItemState.Full):
                        HP_StatInterfaceItemView biggestFullItem = null;
                        for (var j = 0; j < instantiatedLifeItems.Count; j++)
                        {
                            if (instantiatedLifeItems[j].GetItemState != HP_StatInterfaceItemView.ItemState.Full) continue;
                            biggestFullItem = instantiatedLifeItems[j];
                        }
                        if (biggestFullItem != null) biggestFullItem.Disable();
                        break;
                
                    case var _ when value > instantiatedLifeItems.Count(lifeItem => lifeItem.GetItemState == HP_StatInterfaceItemView.ItemState.Full):
                        HP_StatInterfaceItemView smallestEmptyItem = null;
                        for (var j = instantiatedLifeItems.Count - 1; j > 0; j--)
                        {
                            if (instantiatedLifeItems[j].GetItemState != HP_StatInterfaceItemView.ItemState.Empty) continue;
                            smallestEmptyItem = instantiatedLifeItems[j];
                        }
                        if (smallestEmptyItem != null) smallestEmptyItem.Enable();
                        break;
                }
            }
        }
        protected virtual void ShowShield(float value)
        {
            var difference = Mathf.Abs((int) value - instantiatedShieldItems.Count);

            for (int i = 0; i < difference; i++)
            {
                switch (value)
                {
                    case var _ when value > instantiatedShieldItems.Count:
                        instantiatedShieldItems.Add(Instantiate(shieldItemPrefab, shieldContainer));
                        break;
                
                    case var _ when value < instantiatedShieldItems.Count(lifeItem => lifeItem.GetItemState == HP_StatInterfaceItemView.ItemState.Full):
                        HP_StatInterfaceItemView biggestFullItem = null;
                        for (var j = 0; j < instantiatedShieldItems.Count; j++)
                        {
                            if (instantiatedShieldItems[j].GetItemState != HP_StatInterfaceItemView.ItemState.Full) continue;
                            biggestFullItem = instantiatedShieldItems[j];
                        }
                        if (biggestFullItem != null) Destroy(biggestFullItem.gameObject);
                        break;
                }
            }
        }

        #endregion

        #endregion
    }
}