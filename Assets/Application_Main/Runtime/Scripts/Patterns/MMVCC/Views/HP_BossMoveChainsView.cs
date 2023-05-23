namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Views
{
    using System.Collections;
    using UnityEngine;
    using Internal;

    public class HP_BossMoveChainsView : HP_BossMovesetView
    {
        #region Variables

        #region Protected Variables
        
        [SerializeField] protected HP_ChainView[] chains;
        protected GameObject chainsInstance;
    
        #endregion

        #endregion

        #region Methods

        #region Protected Methods

        protected virtual void OnEnable()
        {
            Attack();
        }
        protected virtual void OnDisable()
        {
            Destroy(chainsInstance);
        }

        protected IEnumerator SpawnChain()
        {
            foreach (var chain in chains)
            {
                chain.Spawn();
                yield return new WaitForSeconds(chain.GetCooldownToNextInstantiation + 0.01f);
            }
        }
        protected override void Attack()
        {
            StartCoroutine(SpawnChain());
        }
        
        #endregion

        #endregion
    }
}
