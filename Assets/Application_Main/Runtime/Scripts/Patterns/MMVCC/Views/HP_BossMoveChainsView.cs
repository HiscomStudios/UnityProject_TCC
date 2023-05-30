namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Views
{
    using System.Collections;
    using UnityEngine;
    using Connectors;
    using Internal;

    public class HP_BossMoveChainsView : HP_BossMovesetView
    {
        #region Variables

        #region Protected Variables
        
        [SerializeField] protected HP_ChainConnector[] chains;
        protected GameObject chainsInstance;
    
        #endregion

        #endregion

        #region Methods

        #region Protected Methods

        protected virtual void OnEnable()
        {
            Debug.Log("OnEnable");
            Attack();
        }
        protected virtual void OnDisable()
        {
            Destroy(chainsInstance);
        }

        protected IEnumerator SpawnChain()
        {
            Debug.Log("SpawnChain");
            
            foreach (var chain in chains)
            {
                chain.Spawn();
                yield return new WaitForSeconds(chain.GetCooldownToNextInstantiation + 0.01f);
            }
        }
        protected override void Attack()
        {
            StartCoroutine(SpawnChain());
            base.Attack();
        }
        
        #endregion

        #endregion
    }
}
