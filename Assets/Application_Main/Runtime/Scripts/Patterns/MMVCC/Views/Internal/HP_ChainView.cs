namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Views
{
    using System;
    using UnityEngine;
    using Object = UnityEngine.Object;

    [Serializable]
    public class HP_ChainView
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected float cooldownToNextInstantiation;
        [SerializeField] protected float animationSpeed, appearanceDelay, disappearanceDelay, maxChainDistance;
        [SerializeField] protected GameObject chainPrefab;
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
            var chainInstance = Object.Instantiate(chainPrefab, spawnPosition.position, Quaternion.identity);
            chainInstance.transform.localScale = new Vector3(0, 1, 1);

            LeanTween.scaleX(chainInstance, maxChainDistance, animationSpeed).setDelay(appearanceDelay).setOnComplete(() =>
            {
                LeanTween.scaleX(chainInstance, 1, animationSpeed).setDelay(disappearanceDelay).setOnComplete(() =>
                {
                    Object.Destroy(chainInstance);
                });
            });
        }

        #endregion

        #endregion
    }
}