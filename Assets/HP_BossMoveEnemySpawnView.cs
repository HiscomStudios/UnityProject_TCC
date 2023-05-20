using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_BossMoveEnemySpawnView : MonoBehaviour
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
        Attack();
    }
    protected void OnDisable()
    {
        foreach (var instantiatedEnemy in instantiatedEnemies)
        {
            Destroy(instantiatedEnemy);
        }
        instantiatedEnemies.Clear();
    }

    protected void Attack()
    {
        LeanTween.value(0, 1, cooldownBetweenHordes).setOnComplete(() =>
        {
            StartCoroutine(SpawnEnemies());
            LeanTween.value(0, 1, enemyPerSpawner * spawnPositions.Length).setOnComplete(Attack);
        });
    }

    protected IEnumerator SpawnEnemies()
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

    #endregion

    #endregion
}
