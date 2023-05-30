namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Connectors
{
    using System;
    using UnityEngine;
    using Views;
    using Object = UnityEngine.Object;

    [Serializable]
    public class HP_ChainConnector
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected float cooldownToNextInstantiation;
        [SerializeField] protected float animationSpeed, appearanceDelay, disappearanceDelay, maxChainDistance;
        [SerializeField] protected HP_ChainView chainPrefab;
        [SerializeField] protected Transform spawnPosition;

        #endregion

        #region Public Variables

        public float GetCooldownToNextInstantiation => cooldownToNextInstantiation;

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public void Spawn()
        {
            var chainInstance = Object.Instantiate(chainPrefab, spawnPosition);
            chainInstance.GetChainParent.localPosition = Vector3.zero;
            chainInstance.GetChainParent.localEulerAngles = Vector3.zero;
            
            chainInstance.GetChainParent.localScale = new Vector3(0, 1, 1);

            LeanTween.scaleX(chainInstance.GetChainParent.gameObject, maxChainDistance, animationSpeed).setDelay(appearanceDelay).setOnUpdate(value =>
            {
                chainInstance.GetChainSprite.size = new Vector2(value * maxChainDistance, chainInstance.GetChainSprite.size.y);
            }).setOnComplete(() =>
            {
                LeanTween.scaleX(chainInstance.GetChainParent.gameObject, 0, animationSpeed).setDelay(disappearanceDelay).setOnUpdate(value =>
                {
                    chainInstance.GetChainSprite.size = new Vector2(maxChainDistance - value * maxChainDistance, chainInstance.GetChainSprite.size.y);
                }).setOnComplete(() =>
                {
                    Object.Destroy(chainInstance.gameObject);
                });
            });
        }

        #endregion

        #endregion
    }
}