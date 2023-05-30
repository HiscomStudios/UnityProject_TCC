namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Views
{
    using System.Collections;
    using UnityEngine;
    using Connectors;
    using Internal;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Models;
    using HiscomEngine.Runtime.Scripts.Structures.Enums;
    
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
            bool IsAnimatorNull()
            {
                return Identifier.IdentifyIncident(() => animator == null, IncidentType.Warning, "", gameObject);
            }
            bool IsDefaultAnimationClipNull()
            {
                return Identifier.IdentifyIncident(() => defaultAnimationClip == null, IncidentType.Warning, "", gameObject);
            }
            if (!IsAnimatorNull() && !IsDefaultAnimationClipNull())
                animator.Play(defaultAnimationClip.name);
            
            StartCoroutine(SpawnChain());
        }
        
        #endregion

        #endregion
    }
}
