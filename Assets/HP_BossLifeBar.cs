using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Controllers;
using UnityEngine;
using UnityEngine.UI;

public class HP_BossLifeBar : MonoBehaviour
{
    #region Variables

    #region Protected Variables

    [SerializeField] protected StatsController bossStatsController;
    [SerializeField] protected Slider lifeSlider;
    [SerializeField] protected int lifeStatID;

    #endregion

    #endregion

    #region Methods

    #region Protected Methods

    protected virtual void OnEnable()
    {
        lifeSlider.value = lifeSlider.maxValue = bossStatsController.GetStat(lifeStatID).GetStatAmount;
        bossStatsController.GetStat(lifeStatID).OnStatAmountChanged += UpdateLifeBar;
    }
    protected virtual void UpdateLifeBar(float amount)
    {
        lifeSlider.value = amount;
    }

    #endregion

    #endregion
}
