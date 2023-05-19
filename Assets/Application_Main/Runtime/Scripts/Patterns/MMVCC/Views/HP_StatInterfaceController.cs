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
            lifeStat.OnStatAmountChanged += ShowLife;
        }
        protected virtual void SetupShield()
        {
            instantiatedShieldItems = new List<HP_StatInterfaceItemView>();
            var shieldStat = statsController.GetStat(shieldStatID);
            shieldStat.OnStatAmountChanged += ShowShield;
        }
        protected virtual void ShowLife(float value)
        {
            switch ((int) value)
            {
                case var a when a < instantiatedLifeItems.Count(lifeItem => lifeItem.GetItemState == HP_StatInterfaceItemView.ItemState.Full):
                    HP_StatInterfaceItemView biggestFullItem = null;
                    for (var i = 0; i < instantiatedLifeItems.Count; i++)
                    {
                        if (instantiatedLifeItems[i].GetItemState != HP_StatInterfaceItemView.ItemState.Full) continue;
                        biggestFullItem = instantiatedLifeItems[i];
                    }
                    if (biggestFullItem != null) biggestFullItem.Disable();
                    break;
                
                case var a when a > instantiatedLifeItems.Count(lifeItem => lifeItem.GetItemState == HP_StatInterfaceItemView.ItemState.Full):
                    HP_StatInterfaceItemView smallestEmptyItem = null;
                    for (var i = instantiatedLifeItems.Count - 1; i > 0; i--)
                    {
                        if (instantiatedLifeItems[i].GetItemState != HP_StatInterfaceItemView.ItemState.Empty) continue;
                        smallestEmptyItem = instantiatedLifeItems[i];
                    }
                    if (smallestEmptyItem != null) smallestEmptyItem.Enable();
                    break;
            }

            if (value > instantiatedLifeItems.Count)
            {
                var difference = (int) value - instantiatedLifeItems.Count;
                for (var i = 0; i < difference; i++)
                {
                    instantiatedLifeItems.Add(Instantiate(lifeItemPrefab, lifeContainer));
                }
            }
        }
        protected virtual void ShowShield(float value)
        {
            switch ((int) value)
            {
                case var a when a < instantiatedShieldItems.Count(shieldItem => shieldItem.GetItemState == HP_StatInterfaceItemView.ItemState.Full):
                    HP_StatInterfaceItemView biggestFullItem = null;
                    for (var i = 0; i < instantiatedShieldItems.Count; i++)
                    {
                        if (instantiatedShieldItems[i].GetItemState != HP_StatInterfaceItemView.ItemState.Full) continue;
                        biggestFullItem = instantiatedShieldItems[i];
                    }
                    if (biggestFullItem != null) biggestFullItem.Disable();
                    break;
                
                case var a when a > instantiatedShieldItems.Count(shieldItem => shieldItem.GetItemState == HP_StatInterfaceItemView.ItemState.Full):
                    HP_StatInterfaceItemView smallestEmptyItem = null;
                    for (var i = instantiatedShieldItems.Count - 1; i > 0; i--)
                    {
                        if (instantiatedShieldItems[i].GetItemState != HP_StatInterfaceItemView.ItemState.Empty) continue;
                        smallestEmptyItem = instantiatedShieldItems[i];
                    }
                    if (smallestEmptyItem != null) smallestEmptyItem.Enable();
                    break;
            }
            
            if (value > instantiatedShieldItems.Count)
            {
                var difference = (int) value - instantiatedShieldItems.Count;
                for (var i = 0; i < difference; i++)
                {
                    instantiatedShieldItems.Add(Instantiate(shieldItemPrefab, shieldContainer));
                }
            }
        }

        #endregion

        #endregion
    }
}