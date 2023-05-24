namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Views
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Internal;

    public class HP_BossMoveEnemySpawnView : HP_BossMovesetView
    {
        #region Variables
    
        #region Protected Variables
        
        [SerializeField] protected int enemyPerSpawner;
        [SerializeField] protected float cooldownBetweenHordes;
        [SerializeField] protected GameObject enemyPrefab;
        [SerializeField] protected Transform[] spawnPositions;
        protected List<GameObject> instantiatedEnemies;
    
        #endregion
    
        #endregion
    
        #region Methods
    
        #region Protected Methods
    
        protected void OnEnable()
        {
            instantiatedEnemies = new List<GameObject>();
            instantiatedEnemies.Clear();
            
            Attack();
        }
        protected void OnDisable()
        {
            foreach (var instantiatedEnemy in instantiatedEnemies)
            {
                Destroy(instantiatedEnemy);
            }
            
            instantiatedEnemies.Clear();
            instantiatedEnemies = null;
        }
        protected virtual IEnumerator SpawnEnemies()
        {
            for (var i = 0; i < enemyPerSpawner; i++)
            {
                foreach (var spawnPosition in spawnPositions)
                {
                    instantiatedEnemies.Add(Instantiate(enemyPrefab, spawnPosition.position, Quaternion.identity));
                }
                yield return new WaitForSeconds(1f);
            }
        }
        protected override void Attack()
        {
            animator.Play(animationClip.name);
            
            LeanTween.value(0, 1, cooldownBetweenHordes).setOnComplete(() =>
            {
                StartCoroutine(SpawnEnemies());
                LeanTween.value(0, 1, enemyPerSpawner * spawnPositions.Length).setOnComplete(Attack);
            });
        }
        
        #endregion
    
        #endregion
    }
}